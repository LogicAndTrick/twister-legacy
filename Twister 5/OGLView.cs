/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/02/2009
 * Time: 12:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Input;
using OpenTK.Math;
using OpenTK.Graphics;

namespace Twister_5
{
	/// <summary>
	/// Description of OGLView.
	/// </summary>
	public class OGLView : GLControl
	{
        public bool hasfocus;
		protected float xpos,ypos,zpos,rotation,elevation;
		protected int mousex,mousey;
		protected bool rightclick;
		
		protected double clip_distance = 50000.0;
		
		protected float pyramidRotation;
		
		protected List<Keys> pressedKeys;
		
		protected KeyboardDevice keysPressed;
		
		protected Timer timer;
		
		protected object renderThis;
		
		public object RenderThis {
			get { return renderThis; }
			set { renderThis = value; }
		}
		
		public OGLView()
		{
			initGL();
			pressedKeys = new List<Keys>();
			pyramidRotation = 0;
			resetCamera();
			//---
			timer = new Timer();
			timer.Interval = 10;
			timer.Tick += new EventHandler(timer_Tick);
			timer.Start();
            //---
            this.MouseEnter += new EventHandler(OGLView_MouseEnter);
            this.MouseLeave += new EventHandler(OGLView_MouseLeave);
            this.MouseDown += new MouseEventHandler(OGLView_MouseDown);
            this.MouseUp += new MouseEventHandler(OGLView_MouseUp);
            this.MouseWheel += new MouseEventHandler(OGLView_MouseWheel);
            this.MouseMove += new MouseEventHandler(OGLView_MouseMove);
            this.KeyDown += new KeyEventHandler(OGLView_KeyDown);
            this.KeyUp += new KeyEventHandler(OGLView_KeyUp);
            this.Resize += new EventHandler(OGLView_Resize);
		}
		
		#region Rendering
		protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!this.DesignMode)
            {
            	if (!hasfocus) return;
                MakeCurrent();			//OpenTK allows for multiple OGL windows,
                						//so this is needed to make this one the "active" OGL window
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);	//clear the buffer
                GL.LoadIdentity();		//do...something
                doCameraControl();		//my custom camera stuff
				showCameraView();		//places my camera in the right place
				drawOrientationLines();	//draws hammer-like 3D orientation lines
				drawGLStuff();			//draws a pyramid-type thing
                SwapBuffers();			//brings the buffer that you were drawing on to the front,
                						//and pushes the second buffer behind.
                						//this is called "double buffering", and stops the "flicker"
                						//you have encountered before.
            }
            else {
            	e.Graphics.FillRectangle(new SolidBrush(Color.Blue),0,0,Width,Height);
            	e.Graphics.DrawString("LOL OPENGL",new Font(FontFamily.GenericSansSerif,20),new SolidBrush(Color.White),0,0);
            }
        }
		
		protected void drawGLStuff()
		{
			Renderer.render(renderThis);
		}
		
		protected void drawOrientationLines()
		{
			GL.LineWidth(1.0f);
			GL.Begin(BeginMode.Lines);		//Lines mode draws lines.
			GL.Color3(1.0,0.0,0.0);			//You don't need to use GL.End()
			GL.Vertex3(0.0,0.0,0.0);		//after every line like you have
			GL.Vertex3(20.0,0.0,0.0);		//to do with polygons, because
			GL.Color3(0.0,1.0,0.0);			//OpenGL knows that lines
			GL.Vertex3(0.0,0.0,0.0);		//only have 2 vertices each, whereas
			GL.Vertex3(0.0,20.0,0.0);		//polygons can have any number of vertices.
			GL.Color3(0.0,0.0,1.0);			//you can also use Triangles and Quads
			GL.Vertex3(0.0,0.0,0.0);		//for a similar behaviour on polygons,
			GL.Vertex3(0.0,0.0,20.0);		//but your objects are then limited to
			GL.End();						//3 or 4 vertices.
		}
		#endregion
		
		#region OGL init stuff
		protected void initGL()
		{
			GL.ShadeModel(ShadingModel.Smooth);		//turns smooth shading on
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);	//nice-looking perspective stuff
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);	//line AA
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);	//tells OGL what blending
            GL.Enable(EnableCap.Blend);				//turns on blending stuff				//method to use
            GL.ClearDepth(1.0);						//dunno lol
            GL.Enable(EnableCap.DepthTest);			//enables depth testing (which face is in front/behind)
            GL.DepthFunc(DepthFunction.Lequal);		//face is behind if it is less than or equal
            GL.CullFace(CullFaceMode.Front);		//culls the back of each face
            GL.Enable(EnableCap.CullFace);			//turns on back culling
            GL.ClearColor(Color.Black);				//makes the backgrount black
		}
		
		protected void SetupViewport()
		{
			MakeCurrent();
			int w = this.Width;
			int h = this.Height;
			GL.Viewport(0, 0, w, h);				//makes the viewport the same size as the control
            double ratio = w / (double)h;
            GL.MatrixMode(MatrixMode.Projection);	//move into the projection mode, to mess with
            GL.LoadIdentity();						//view stuff
            double far = clip_distance;
            Glu.Perspective(60.0, ratio, 0.1, far);	//create the FOV, etc.
            GL.MatrixMode(MatrixMode.Modelview);	//move back into the model view mode, which
            GL.LoadIdentity();						//is the mode with all the visible stuff
		}
		#endregion
		
		#region Events
		void timer_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}

		void OGLView_KeyUp(object sender, KeyEventArgs e)
		{
			if (pressedKeys.Contains(e.KeyCode)) pressedKeys.Remove(e.KeyCode);
		}

		void OGLView_KeyDown(object sender, KeyEventArgs e)
		{
			if (!pressedKeys.Contains(e.KeyCode)) pressedKeys.Add(e.KeyCode);
		}

		void OGLView_MouseMove(object sender, MouseEventArgs e)
		{
			int diffx = e.X - mousex;
        	int diffy = mousey - e.Y;
        	if (rightclick) {
        		this.mouseMove(diffx,diffy);
        	}
        	mousex = e.X;
        	mousey = e.Y;
		}

		void OGLView_MouseWheel(object sender, MouseEventArgs e)
		{
			goForward1((float)(e.Delta * (zpos / clip_distance) * 100));
		}

		void OGLView_MouseUp(object sender, MouseEventArgs e)
		{
			rightclick = false;
		}

		void OGLView_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right) rightclick = true;
		}

		void OGLView_Resize(object sender, EventArgs e)
		{
			SetupViewport();
		}

		void OGLView_MouseLeave(object sender, EventArgs e)
		{
			hasfocus = false;
		}

		void OGLView_MouseEnter(object sender, EventArgs e)
		{
			hasfocus = true;
		}
		#endregion
		
		#region Camera stuff
		public void resetCamera()
		{
			xpos = 0.5f;
			ypos = -1.5f;
			zpos = 0.5f;
			rotation = 270.0f;
			elevation = 80;
		}

		protected void mouseMove(int movex, int movey)
		{
			rotation += movex/2.0f;
			if (rotation < 0) rotation += 360;
			rotation = rotation % 360;
			elevation += movey/2.0f;
			if (elevation < 0.01) elevation = 0.01f;
			if (elevation > 179.9) elevation = 179.9f;
		}
		
		protected void goForward1(float dist)
		{
			//go forward in the direction of the lookat vector
			float xrot = (float)(Math.Cos((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float yrot = (float)(Math.Sin((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float zrot = (float)(Math.Cos((180.0f - elevation)*Math.PI/180));
			FloatCoordinate c = new FloatCoordinate(xrot,yrot,zrot);
			c = (c / c.vectorMagnitude()) * dist;
			xpos += c.getX();
			ypos += c.getY();
			zpos += c.getZ();
		}
		
		protected void goForward(float dist)
		{
			//go forward in the direction of the lookat vector
			float xrot = (float)(Math.Cos((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float yrot = (float)(Math.Sin((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float zrot = (float)(Math.Cos((180.0f - elevation)*Math.PI/180));
			FloatCoordinate c = new FloatCoordinate(xrot,yrot,zrot);
			c = (c / c.vectorMagnitude()) * dist;
			xpos += c.getX();
			ypos += c.getY();
			zpos += c.getZ();
		}
		
		protected void goSideways(float dist)
		{
			float trot = rotation;
			float posneg = 1.0f;
			trot += 90*posneg;
			if (trot < 0) trot += 360;
			trot = trot % 360;
			float xrot = (float)Math.Cos((360.0f - trot)*Math.PI/180);
			float yrot = (float)Math.Sin((360.0f - trot)*Math.PI/180);
			FloatCoordinate c = new FloatCoordinate(xrot,yrot,1);
			c = (c / c.vectorMagnitude()) * dist;
			xpos += c.getX();
			ypos += c.getY();
		}
		
		protected void doCameraControl()
		{
			float travelspeed = 2.0f;
			if (pressedKeys.Contains(Keys.ShiftKey)) travelspeed *= 3;
        	if (pressedKeys.Contains(Keys.D)) this.goSideways(travelspeed);
        	if (pressedKeys.Contains(Keys.A)) this.goSideways(-travelspeed);
        	if (pressedKeys.Contains(Keys.W)) this.goForward(travelspeed);
        	if (pressedKeys.Contains(Keys.S)) this.goForward(-travelspeed);
        	if (pressedKeys.Contains(Keys.R)) this.resetCamera();
		}
		
		protected void showCameraView()
		{
        	float xrot = xpos + (float)(Math.Cos((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float yrot = ypos + (float)(Math.Sin((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float zrot = zpos + (float)(Math.Cos((180.0f - elevation)*Math.PI/180));
			Glu.LookAt(xpos,ypos,zpos,xrot,yrot,zrot,0.0,0.0,1.0);
		}
		#endregion
	}
}
