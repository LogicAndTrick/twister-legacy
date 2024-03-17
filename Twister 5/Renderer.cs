/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 6/07/2009
 * Time: 11:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using OpenTK.Graphics;

namespace Twister_5
{
	/// <summary>
	/// Description of Renderer.
	/// </summary>
	public static class Renderer
	{
		public static void render(object o)
		{
			if (o == null) {
				return;
			} else if (o is Displacement) {
				drawAllTriangles((Displacement)o);
			} else if (o is DisplacementGrid) {
				drawAllGridTriangles((DisplacementGrid)o);
			}
		}
        
        private static void drawTriangle(float[] vert1, float[] vert2, float[] vert3)
        {
			GL.Color4(0.5f,0.5f,0.5f,0.3f);
        	GL.Begin(BeginMode.Triangles);
        	GL.Vertex3(vert1[0],vert1[1],vert1[2]);
        	GL.Vertex3(vert2[0],vert2[1],vert2[2]);
        	GL.Vertex3(vert3[0],vert3[1],vert3[2]);
        	GL.End();
        	drawLine(vert2,vert3);
        }
        
        private static void drawLine(float[] vert1, float[] vert2)
        {
        	GL.Color3(0.4f,0.4f,0.4f);
        	GL.Begin(BeginMode.Lines);
        	GL.Vertex3(vert1[0],vert1[1],vert1[2]);
        	GL.Vertex3(vert2[0],vert2[1],vert2[2]);
        	GL.End();
        }
		
		private static void drawAllTriangles(Displacement dis)
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
        
        private static void drawAllGridTriangles(DisplacementGrid disgrid)
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
		
		public static void saveDisplacement(object d, int mode)
		{
			VMFGenerator vgen = new VMFGenerator();
			switch (mode) {
				case 1: vgen.modeVMF();
						break;
				case 2: vgen.modeBrush();
						break;
				case 3: vgen.modeMap();
						break;
			}
			if (d is DisplacementGrid) vgen.save((DisplacementGrid)d);
			else vgen.save((Displacement)d);
		}
	}
}
