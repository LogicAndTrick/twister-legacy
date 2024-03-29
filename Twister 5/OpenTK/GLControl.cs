﻿#region --- License ---
/* Licensed under the MIT/X11 license.
 * Copyright (c) 2006-2008 the OpenTK Team.
 * This notice may not be removed from any source distribution.
 * See license.txt for licensing detailed licensing details.
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using OpenTK.Platform;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;

namespace OpenTK
{
    /// <summary>
    /// Defines a UserControl with OpenGL rendering capabilities.
    /// </summary>
    public partial class GLControl : UserControl
    {
        IGraphicsContext context;
        IGLControl implementation;
        GraphicsMode format;
        IWindowInfo window_info;

        #region --- Constructor ---

        /// <summary>
        /// Constructs a new GLControl.
        /// </summary>
        public GLControl()
            : this(GraphicsMode.Default)
        { }

        /// <summary>This method is obsolete and will be removed in future versions.</summary>
        /// <param name="mode">Obsolete.</param>
        public GLControl(DisplayMode mode)
            : this(mode.ToGraphicsMode())
        { }

        /// <summary>
        /// Constructs a new GLControl with the specified GraphicsMode.
        /// </summary>
        /// <param name="mode">The OpenTK.Graphics.GraphicsMode of the control.</param>
        public GLControl(GraphicsMode mode)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = false;

            this.format = mode;

            // On Windows, you first need to create the window, then set the pixel format.
            // On X11, you first need to select the visual, then create the window.
            // On OSX, ???
            // Right now, pixel formats/visuals are selected during context creation. In the future,
            // it would be better to decouple selection from context creation, which will allow us
            // to clean up this hacky code. The best option is to do this along with multisampling
            // support.
            if (Configuration.RunningOnWindows)
                implementation = new OpenTK.Platform.Windows.WinGLControl(mode, this);
            else if (Configuration.RunningOnX11)
                implementation = new OpenTK.Platform.X11.X11GLControl(mode, this);
            else if (Configuration.RunningOnOSX)
                throw new PlatformNotSupportedException("Refer to http://www.opentk.com for more information.");

            this.CreateControl();
        }

        #endregion

        #region --- Protected Methods ---

        /// <summary>Raises the HandleCreated event.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (DesignMode)
                this.Context = new DummyGLContext(null);
            else
                this.Context = implementation.CreateContext();

            this.window_info = implementation.WindowInfo;
            this.MakeCurrent();
            ((IGraphicsContextInternal)this.Context).LoadAll();
        }

        /// <summary>Raises the HandleDestroyed event.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (this.Context != null)
            {
                this.Context.Dispose();
                this.Context = null;
            }
            this.window_info = null;
        }

        #endregion

        #region --- Public Methods ---

        #region public void SwapBuffers()

        /// <summary>
        /// Swaps the front and back buffers, presenting the rendered scene to the screen.
        /// </summary>
        public void SwapBuffers()
        {
            Context.SwapBuffers();
        }

        #endregion

        #region public void MakeCurrent()

        /// <summary>
        /// Makes the underlying this GLControl current in the calling thread.
        /// All OpenGL commands issued are hereafter interpreted by this GLControl.
        /// </summary>
        public void MakeCurrent()
        {
            this.Context.MakeCurrent(this.window_info);
        }

        #endregion

        #region public void CreateContext()
        
        /// <summary>
        /// Creates a GraphicsContext and attaches it to this GLControl.
        /// </summary>
        public void CreateContext()
        {
            if (context != null) throw new InvalidOperationException("GLControl already contains an OpenGL context.");
            if (format == null) format = GraphicsMode.Default;

            if (!this.DesignMode)
            {
                // Note: Mono's implementation of Windows.Forms on X11 does not allow the context to
                // have a different colordepth from the parent window.
                //context = new GraphicsContext(format, helper.WindowInfo);
                if (Configuration.RunningOnX11)
                {
                    //OpenTK.Platform.X11.X11WindowInfo info = 
                    //    (context as IGraphicsContextInternal).Info as OpenTK.Platform.X11.X11WindowInfo;
                    //IntPtr visual = info.VisualInfo.visual;
                    //IntPtr colormap = OpenTK.Platform.X11.API.CreateColormap(info.Display, info.RootWindow, visual, 0);
                    //IntPtr visual = ((OpenTK.Platform.X11.X11WindowInfo)helper.WindowInfo).VisualInfo.visual;
                    //IntPtr colormap = OpenTK.Platform.X11.API.CreateColormap(info.Display, info.RootWindow, visual, 0);

                    //Type xplatui = Type.GetType("System.Windows.Forms.XplatUIX11, System.Windows.Forms");
                    //if (xplatui == null)
                    //    throw new PlatformNotSupportedException(
                    //        "System.Windows.Forms.XplatUIX11 missing. Unsupported platform or Mono runtime version, aborting.");

                    //xplatui.GetField("CustomVisual",
                    //                 System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                    //    .SetValue(null, visual);
                    
                    //xplatui.GetField("CustomColormap",
                    //                 System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                    //    .SetValue(null, colormap);

                    //Debug.Print("Mono/X11 System.Windows.Forms custom visual and colormap installed succesfully.");
                }
            }
            else
                context = new DummyGLContext(format);

            this.MakeCurrent();
            (context as IGraphicsContextInternal).LoadAll();
        }

        #endregion

        #region public void DestroyContext()

        /// <summary>
        /// Destroys the GraphicsContext attached to this GLControl.
        /// </summary>
        /// <exception cref="NullReferenceException">Occurs when no GraphicsContext is attached.</exception>
        public void DestroyContext()
        {
            Context.Dispose();
            Context = null;
        }

        #endregion

        #region public bool IsIdle

        /// <summary>
        /// Gets a value indicating whether the current thread contains pending system messages.
        /// </summary>
        [Browsable(false)]
        public bool IsIdle
        {
            get { return implementation.IsIdle; }
        }

        #endregion

        #region public IGraphicsContext Context

        /// <summary>
        /// Gets an interface to the underlying GraphicsContext used by this GLControl.
        /// </summary>
        [Browsable(false)]
        public IGraphicsContext Context
        {
            get { return context; }
            private set { context = value; }
        }

        #endregion

        #region public float AspectRatio

        /// <summary>
        /// Gets the aspect ratio of this GLControl.
        /// </summary>
        [Description("The aspect ratio of the client area of this GLControl.")]
        public float AspectRatio
        {
            get
            {
                return this.ClientSize.Width / (float)this.ClientSize.Height;
            }
        }

        #endregion

        #region public bool VSync

        /// <summary>
        /// Gets or sets a value indicating whether vsync is active for this GLControl.
        /// </summary>
        [Description("Indicates whether GLControl updates are synced to the monitor's refresh.")]
        public bool VSync
        {
            get
            {
                if (Context != null)
                    return Context.VSync;
                return false;
            }
            set
            {
                if (Context != null)
                    Context.VSync = value;
            }
        }

        #endregion

        #region public GraphicsMode GraphicsMode

        /// <summary>
        /// Gets the GraphicsMode of the GraphicsContext attached to this GLControl.
        /// </summary>
        /// <remarks>
        /// To change the GraphicsMode, you must destroy and recreate the GLControl.
        /// </remarks>
        public GraphicsMode GraphicsMode
        {
            get { return (Context as IGraphicsContextInternal).GraphicsMode; }
        }

        #endregion

        #region public Bitmap GrabScreenshot()

        /// <summary>Grabs a screenshot of the frontbuffer contents.</summary>
        /// <returns>A System.Drawing.Bitmap, containing the contents of the frontbuffer.</returns>
        /// <exception cref="GraphicsContextException">
        /// Occurs when no OpenTK.Graphics.GraphicsContext is current in the calling thread.
        /// </exception>
        public Bitmap GrabScreenshot()
        {
            Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            System.Drawing.Imaging.BitmapData data = 
                bmp.LockBits(this.ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                             System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, this.ClientSize.Width, this.ClientSize.Height, PixelFormat.Bgr, PixelType.UnsignedByte,
                          data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }

        #endregion

        #endregion
    }

    #region internal interface IPlatformIdle
#if false
    internal interface IPlatformIdle
    {
        bool IsIdle { get; }
    }

    internal class X11PlatformIdle : IPlatformIdle
    {
        object get_lock = new object();
        IntPtr display;

        public X11PlatformIdle(WindowInfo info)
        {
            display = new OpenTK.Platform.X11.WindowInfo(info).Display;//((OpenTK.Platform.X11.WindowInfo)info).Display;
        }

        #region IPlatformIdle Members

        public bool IsIdle
        {
            get
            {
                lock (get_lock)
                {
                    return OpenTK.Platform.X11.Functions.XPending(display) == 0;
                }
            }
        }

        #endregion
    }
#endif

    #endregion

    #region internal interface IGLControlHelper

    internal interface IGLControlHelper
    {
        IWindowInfo WindowInfo { get; }
        bool IsIdle { get; }
    }

    #endregion
}
