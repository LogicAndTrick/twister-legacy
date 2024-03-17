/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/08/2008
 * Time: 2:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using CsGL.OpenGL;

namespace Twister_5
{
	/// <summary>
	/// Description of TestCube.
	/// </summary>
	public class TestCube
	{
		protected float[] fColor = new float[3];
		
        public float CubeColorRed
        {
            get { return fColor[0]; }
            set { fColor[0] = value ; }
        }
        
        public float CubeColorGreen
        {
            get { return fColor[1]; }
            set { fColor[1] = value ; }
        }
        
        public float CubeColorBlue
        {
            get { return fColor[2]; }
            set { fColor[2] = value ; }
        }
        
        protected float fPlusPosition;
        protected float fMinusPosition;
        
        public float Scale
        {
            set
            {
                fPlusPosition = value;
                fMinusPosition = (0 - value);
            }
        }
        public float fRotate;
        protected bool bRotateCheck;
        
        public bool Rotate
        {
            get { return bRotateCheck; }
            set { bRotateCheck = value; }
        }
        
        protected float fViewPort;
        
        public float ViewPort
        {
            get { return fViewPort; }
            set { fViewPort = (-6 + value); }
        }
        
        public TestCube()
        {
            for (int i = 0; i < 3; i++)
            {
                fColor[i] = 1.0f;
            }
            bRotateCheck = true;
            this.ViewPort = 0;
            this.fMinusPosition = -1f;
            this.fPlusPosition = 1f;
        }
        
        public void glDrawCube()// To be in OpenGL style it I gave it a gl prefix
        {
            GL.glTranslatef(0.0f,0.0f, fViewPort);     // viewport = 0 0 0 and this is 6 deep
            if (bRotateCheck == true)
            {
                GL.glRotatef(fRotate, 1.0f, 1.0f, 1.0f);
            }
            /*GL.glBegin(GL.GL_QUADS);// start drawin the cube
                    GL.glColor3fv(fColor); // Color with an array of floats
                // Draw Top of the Cube
                GL.glVertex3f( fPlusPosition, fPlusPosition, fMinusPosition);                    
                GL.glVertex3f(fMinusPosition, fPlusPosition, fPlusPosition);                
                GL.glVertex3f(fMinusPosition, fPlusPosition, fPlusPosition);                
                GL.glVertex3f( fPlusPosition, fPlusPosition, fPlusPosition);                    
                // Draw Bottom of the Cube
                GL.glVertex3f( fPlusPosition, fMinusPosition, fPlusPosition);                    
                GL.glVertex3f(fMinusPosition,fMinusPosition, fPlusPosition);                    
                GL.glVertex3f(fMinusPosition,fMinusPosition, fMinusPosition);                    
                GL.glVertex3f( fPlusPosition,fMinusPosition, fMinusPosition);                
                // Draw Front of the Cube
                GL.glVertex3f( fPlusPosition, fPlusPosition, fPlusPosition);                
                GL.glVertex3f(fMinusPosition, fPlusPosition, fPlusPosition);                
                GL.glVertex3f(fMinusPosition,fMinusPosition, fPlusPosition);                
                GL.glVertex3f( fPlusPosition,fMinusPosition, fPlusPosition);        
                // Draw Back of the Cube
                GL.glVertex3f( fPlusPosition,fMinusPosition, fMinusPosition);    
                GL.glVertex3f(fMinusPosition,fMinusPosition, fMinusPosition);                
                GL.glVertex3f(fMinusPosition, fPlusPosition, fMinusPosition);                    
                GL.glVertex3f( fPlusPosition, fPlusPosition, fMinusPosition);                    
                // Draw Left of the Cube
                GL.glVertex3f(fMinusPosition, fPlusPosition, fPlusPosition);                
                GL.glVertex3f(fMinusPosition, fPlusPosition, fMinusPosition);                    
                GL.glVertex3f(fMinusPosition,fMinusPosition, fMinusPosition);            
                GL.glVertex3f(fMinusPosition,fMinusPosition, fPlusPosition);            
                // Draw Right of the Cube
                GL.glVertex3f( fPlusPosition, fPlusPosition, fMinusPosition);            
                GL.glVertex3f( fPlusPosition, fPlusPosition, fPlusPosition);                    
                GL.glVertex3f( fPlusPosition,fMinusPosition, fPlusPosition);                
                GL.glVertex3f( fPlusPosition,fMinusPosition, fMinusPosition);    
            GL.glEnd();// end drawing the cube   */
            GL.glBegin(GL.GL_TRIANGLES);			// start drawing a triangle, always counterclockside (top-left-right)
			GL.glColor3f(1.0f,0.0f,0.0f);			// red
			GL.glVertex3f(0.0f,1.0f,0.0f);			// Top of Triangle (Front)
			GL.glVertex3f(-1.0f,-1.0f,1.0f);		// left of Triangle (front)
			GL.glVertex3f(1.0f,-1.0f,1.0f);			// right of triangle (front)
			
			GL.glColor3f(0.0f,1.0f,0.0f);			// green
			GL.glVertex3f(0.0f,1.0f,0.0f);			// top of triangle (right)
			GL.glVertex3f(1.0f,-1.0f,1.0f);			// left of triangle (right)
			GL.glVertex3f(0.0f,-1.0f,-1.0f);		// right of triangel (right)
			
            GL.glColor3fv(fColor);					// custom
			GL.glVertex3f(0.0f,1.0f,0.0f);			// top of triangle (left)
			GL.glVertex3f(0.0f,-1.0f,-1.0f);		// left of triangle (left)
			GL.glVertex3f(-1.0f,-1.0f,1.0f);		// right of triangle (left)
			
			GL.glColor3f(0.0f,0.0f,1.0f);			// blue
			GL.glVertex3f(-1.0f,-1.0f,1.0f);		// top of triangle (bottom)
			GL.glVertex3f(1.0f,-1.0f,1.0f);			// left of triangle (bottom)
			GL.glVertex3f(0.0f,-1.0f,-1.0f);		// right of triangle (bottom)
			GL.glEnd();
           
            if (bRotateCheck == true)
            {
                fRotate += 2.5f;
            }
        }
	}
}
