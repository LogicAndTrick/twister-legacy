/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/08/2008
 * Time: 1:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;

namespace Twister_5
{
	/// <summary>
	/// Description of TestView.
	/// </summary>
	public class TestView : OpenGLControl
	{
		DisplacementRender dr;
		bool rightclick;
		int mousex,mousey;
		
		public TestView(DisplacementRender d): base()
        {
			dr = d;
			rightclick = false;
			mousex = 0;
			mousey = 0;
            this.MouseDown += new MouseEventHandler(OurView_OnMouseDown);
            this.MouseMove += new MouseEventHandler(OurView_OnMouseMove);
            this.MouseUp += new MouseEventHandler(OurView_OnMouseUp);
        }
		
		public void saveDisplacement(int mode)
		{
			dr.saveDisplacement(mode);
		}
		
		public void setDisplacementRenderer(DisplacementRender d)
		{
			dr = d;
		}
		
        public override void glDraw()
        {
        	//---
        	float travelspeed = 0.05f;
        	if (CsGL.Util.Keyboard.IsKeyPressed(Keys.ShiftKey)) travelspeed = 0.15f;
        	if (CsGL.Util.Keyboard.IsKeyPressed(Keys.D)) dr.goSideways(travelspeed);
        	if (CsGL.Util.Keyboard.IsKeyPressed(Keys.A)) dr.goSideways(-travelspeed);
        	if (CsGL.Util.Keyboard.IsKeyPressed(Keys.W)) dr.goForward(travelspeed);
        	if (CsGL.Util.Keyboard.IsKeyPressed(Keys.S)) dr.goForward(-travelspeed);
        	if (CsGL.Util.Keyboard.IsKeyPressed(Keys.R)) dr.resetCamera();
            //---
            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            GL.glLoadIdentity();
			//this.SwapBuffer();
			if (dr != null) dr.glDrawDisplacement();
        }
        
        protected override void InitGLContext()
        {
            GL.glShadeModel(GL.GL_SMOOTH);
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
			GL.glHint(GL.GL_LINE_SMOOTH_HINT,GL.GL_NICEST);
			GL.glBlendFunc(GL.GL_SRC_ALPHA,GL.GL_ONE);
			GL.glLineWidth(0.1f);
			GL.glEnable (GL.GL_BLEND);
			GL.glEnable(GL.GL_LINE_SMOOTH);
			GL.glDisable(GL.GL_DEPTH_TEST);
        }
        
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
       
            Size s = Size;
            double aspect_ratio = (double)s.Width /(double) s.Height;
            GL.glMatrixMode(GL.GL_PROJECTION); // Select The Projection Matrix
            GL.glLoadIdentity(); // Reset The Projection Matrix
           
            // Calculate The Aspect Ratio Of The Window
            GL.gluPerspective(45.0f, aspect_ratio, 0.1f, 100.0f);
   
            GL.glMatrixMode(GL.GL_MODELVIEW); // Select The Modelview Matrix
            GL.glLoadIdentity();// Reset The Modelview Matrix
        }
        
        protected void OurView_OnMouseDown(object Sender, MouseEventArgs click)
        {
        	if (click.Button == MouseButtons.Right) rightclick = true;
        	if (click.Button == MouseButtons.Left) dr.doClick();
        }
        
        protected void OurView_OnMouseUp(object Sender, MouseEventArgs click)
        {
        	if (click.Button == MouseButtons.Right) rightclick = false;
        }
        
        protected void OurView_OnMouseMove(object Sender, MouseEventArgs click)
        {
        	int diffx = click.X - mousex;
        	int diffy = mousey - click.Y;
        	if (rightclick) {
        		dr.mouseMove(diffx,diffy);
        	}
        	mousex = click.X;
        	mousey = click.Y;
        }
	}
}
