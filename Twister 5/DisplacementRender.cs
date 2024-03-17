/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/08/2008
 * Time: 2:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using CsGL.OpenGL;

namespace Twister_5
{
	/// <summary>
	/// Description of DisplacementRender.
	/// </summary>
	public class DisplacementRender
	{
		Displacement dis;
		DisplacementGrid disgrid;
		VMFGenerator vgen;
		float xpos,ypos,zpos,rotation,elevation;
		
		public DisplacementRender(Displacement d)
		{
			vgen = new VMFGenerator();
			dis = d;
			disgrid = null;
			resetCamera();
		}
		
		public DisplacementRender(DisplacementGrid d)
		{
			vgen = new VMFGenerator();
			dis = null;
			disgrid = d;
			resetCamera();
		}
		
		public void resetCamera()
		{
			xpos = -1.5f;
			ypos = -2.5f;
			zpos = 2.0f;
			rotation = 300.0f;
			elevation = 80;
		}
        
        public void doClick()
        {
        	//System.Windows.Forms.MessageBox.Show("elev: " + elevation + "rot: " + rotation);
        }
		
		public void mouseMove(int movex, int movey)
		{
			rotation += movex/2.0f;
			if (rotation < 0) rotation += 360;
			rotation = rotation % 360;
			elevation += movey/2.0f;
			if (elevation < 0.01) elevation = 0.01f;
			if (elevation > 179.9) elevation = 179.9f;
		}
		
		public void goForward(float dist)
		{
			//go forward in the direction of the lookat vector
			float xrot = (float)(Math.Cos((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float yrot = (float)(Math.Sin((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float zrot = (float)(Math.Cos((180.0f - elevation)*Math.PI/180));
			Coordinate c = new Coordinate(xrot,yrot,zrot);
			c = (c / c.vectorMagnitude()) * dist;
			xpos += c.getX();
			ypos += c.getY();
			zpos += c.getZ();
		}
		
		public void goSideways(float dist)
		{
			float trot = rotation;
			float posneg = 1.0f;
			trot += 90*posneg;
			if (trot < 0) trot += 360;
			trot = trot % 360;
			float xrot = (float)Math.Cos((360.0f - trot)*Math.PI/180);
			float yrot = (float)Math.Sin((360.0f - trot)*Math.PI/180);
			Coordinate c = new Coordinate(xrot,yrot,1);
			c = (c / c.vectorMagnitude()) * dist;
			xpos += c.getX();
			ypos += c.getY();
		}
        
		public void glDrawDisplacement()
        {
			float xrot = xpos + (float)(Math.Cos((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float yrot = ypos + (float)(Math.Sin((360.0f - rotation)*Math.PI/180)*Math.Sin((180.0f - elevation)*Math.PI/180));
			float zrot = zpos + (float)(Math.Cos((180.0f - elevation)*Math.PI/180));
			GL.gluLookAt(xpos,ypos,zpos,xrot,yrot,zrot,0.0,0.0,1.0);
			if (disgrid != null) drawAllGridTriangles();
			else drawAllTriangles();
        }
        
        public void drawTriangle(float[] vert1, float[] vert2, float[] vert3)
        {
			GL.glColor4f(0.5f,0.5f,0.5f,0.3f);
        	GL.glBegin(GL.GL_TRIANGLES);
        	GL.glVertex3f(vert1[0]/200.0f,vert1[1]/200.0f,vert1[2]/200.0f);
        	GL.glVertex3f(vert2[0]/200.0f,vert2[1]/200.0f,vert2[2]/200.0f);
        	GL.glVertex3f(vert3[0]/200.0f,vert3[1]/200.0f,vert3[2]/200.0f);
        	GL.glEnd();
        	drawLine(vert2,vert3);
        }
        
        public void drawLine(float[] vert1, float[] vert2)
        {
        	GL.glColor3f(0.4f,0.4f,0.4f);
        	GL.glBegin(GL.GL_LINES);
        	GL.glVertex3f(vert1[0]/200.0f,vert1[1]/200.0f,vert1[2]/200.0f);
        	GL.glVertex3f(vert2[0]/200.0f,vert2[1]/200.0f,vert2[2]/200.0f);
        	GL.glEnd();
        }
        
        public void drawAllTriangles()
        {
	        for (int i = 0; i < dis.getResolution(); i++) {
				for (int j = 0; j < dis.getResolution(); j++) {
        			if (i == 0) drawLine(dis.getPoint(i,j),dis.getPoint(i,j+1));
        			if (j == 0) drawLine(dis.getPoint(i,j),dis.getPoint(i+1,j));
        			drawTriangle(dis.getPoint(i,j),dis.getPoint(i+1,j),dis.getPoint(i+1,j+1));
        			drawTriangle(dis.getPoint(i,j),dis.getPoint(i+1,j+1),dis.getPoint(i,j+1));
				}
			}
        }
        
        public void drawAllGridTriangles()
        {
        	for (int i = 0; i < disgrid.getWidth(); i++) {
        		for (int j = 0; j < disgrid.getLength(); j++) {
					Displacement temp = disgrid.getDisplacement(i,j);
					for (int k = 0; k < temp.getResolution(); k++) {
						for (int l = 0; l < temp.getResolution(); l++) {
        					if (i == 0 && k == 0) drawLine(temp.getPoint(k,l),temp.getPoint(k,l+1));
        					if (j == 0 && l == 0) drawLine(temp.getPoint(k,l),temp.getPoint(k+1,l));
		        			drawTriangle(temp.getPoint(k,l),temp.getPoint(k+1,l),temp.getPoint(k+1,l+1));
		        			drawTriangle(temp.getPoint(k,l),temp.getPoint(k+1,l+1),temp.getPoint(k,l+1));
						}
					}
				}
			}
        }
		
		public void saveDisplacement(int mode)
		{
			switch (mode) {
				case 1: vgen.modeVMF();
						break;
				case 2: vgen.modeBrush();
						break;
				case 3: vgen.modeMap();
						break;
			}
			if (disgrid != null) vgen.save(disgrid);
			else vgen.save(dis);
		}
	}
}
