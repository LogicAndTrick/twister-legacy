/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/07/2008
 * Time: 4:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of DisplacementGrid.
	/// </summary>
	public class DisplacementGrid
	{
		Displacement[,] grid;
		int width, length, pow, res;
		float totalwidth, totallength, partialwidth, partiallength;
		
		public DisplacementGrid(int w, int l, float tw, float tl, int r)
		{
			width = w;
			length = l;
			totalwidth = tw;
			totallength = tl;
			pow = r;
			res = (int)Math.Pow(2,pow);
			partialwidth = totalwidth / (float)width;
			partiallength = totallength / (float)length;
			grid = new Displacement[width,length];
			grid.Initialize();
			float xs, ys;
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < length; j++) {
					ys = partiallength * i;
					xs = partialwidth * j;
					grid[i,j] = new Displacement(partialwidth,partiallength,-64,pow,xs,ys,0);
					for (int k = 0; k <= res; k++) {
						for (int m = 0; m <= res; m++) {
							grid[i,j].setPoint(k,m,xs+(partialwidth/(float)res*(float)m),ys+(partiallength/(float)res*(float)k),0);
						}
					}
				}
			}
		}
		
		public int getWidth()
		{
			return width;
		}
		
		public int getLength()
		{
			return length;
		}
		
		public int getResolution()
		{
			return res;
		}
		
		public Displacement getDisplacement(int row, int col)
		{
			return grid[row,col];
		}
		
		public void setGridPositionHeight(int xpos, int ypos, float height)
		{
			int xdiv = 0, ydiv = 0;
			int xrem = 0, yrem = 0;
			try {
				xdiv = Math.DivRem(xpos, res, out xrem);
				ydiv = Math.DivRem(ypos, res, out yrem);
				if (xdiv == width) {
					xdiv--;
					xrem = res;
				}
				if (ydiv == length) {
					ydiv--;
					yrem = res;
				}
				grid[xdiv,ydiv].setHeight(xrem,yrem,height);
				if (xdiv > 0 && xrem == 0) grid[xdiv-1,ydiv].setHeight(res,yrem,height);
				if (ydiv > 0 && yrem == 0) grid[xdiv,ydiv-1].setHeight(xrem,res,height);
				if (xdiv > 0 && xrem == 0 && ydiv > 0 && yrem == 0) grid[xdiv-1,ydiv-1].setHeight(res,res,height);
				
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show(xdiv + ";" + xrem + " " + ydiv + ";" + yrem);
			}
		}
		
		public string toMap()
		{
			string str = "";
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < length; j++) {
					str += grid[i,j].toMap();
				}
			}
			return str;
		}
		
		public string toBrush()
		{
			string str = "";
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < length; j++) {
					str += grid[i,j].toBrush();
				}
			}
			return str;
		}
		
		public string toString()
		{
			string str = "";
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < length; j++) {
					str += grid[i,j].toString();
				}
			}
			return str;
		}
	}
}
