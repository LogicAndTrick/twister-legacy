/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/07/2008
 * Time: 4:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Twister_5
{
	public partial class MainForm : Form
	{
		Image loadedimage;
		Image resizedimage;
		
		public void doHeightmap()
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				float height = float.Parse(txtHeight.Text);
				int side = (int)nudDispRes.Value;
				int power = (int)nudPower.Value;
				if (length >= 16384 | width >= 16384 | height >= 8192) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				DisplacementGrid heightmap = new DisplacementGrid(side,side,width,length,power);
				calculateHeightmap(ref heightmap);
				//txtDisplay.Text = heightmap.toString();
				lblHeightmapWait.Visible = true;
				lblHeightmapWait.Refresh();
				saveDisplacementGrid(heightmap);
				lblHeightmapWait.Visible = false;
				pgsHeightmap.Value = 0;
				pgsHeightmap.Maximum = 100;
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void doHeightmap(bool b)
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				float height = float.Parse(txtHeight.Text);
				int side = (int)nudDispRes.Value;
				int power = (int)nudPower.Value;
				if (length >= 16384 | width >= 16384 | height >= 8192) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				DisplacementGrid heightmap = new DisplacementGrid(side,side,width,length,power);
				calculateHeightmap(ref heightmap);
				//txtDisplay.Text = heightmap.toString();
				lblHeightmapWait.Visible = true;
				lblHeightmapWait.Refresh();
				//saveDisplacementGrid(heightmap);
				createPreview(ref heightmap);
				lblHeightmapWait.Visible = false;
				pgsHeightmap.Value = 0;
				pgsHeightmap.Maximum = 100;
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void calculateHeightmap(ref DisplacementGrid dg)
		{
			float height = float.Parse(txtHeight.Text);
			int side = (int)nudDispRes.Value;
			int power = (int)nudPower.Value;
			int numpoints = (int)Math.Pow(2,power) * side;
			Bitmap heightimage = (Bitmap)loadedimage;
			float partwidth = (float)heightimage.Width / numpoints;
			float partheight = (float)heightimage.Height / numpoints;
			int xpos, ypos;
			int totalcalcs = (numpoints+1) * (numpoints+1);
			pgsHeightmap.Maximum = totalcalcs;
			for (int i = 0; i <= numpoints; i++) {
				for (int j = 0; j <= numpoints; j++) {
					//dg.setGridPositionHeight(i,j,(float)((Math.Pow((float)i/40+(float)j/20,3))+Math.Pow(4*(float)i/40*(float)j/20,2)));
					xpos = (int)Math.Round(partwidth * i);
					ypos = (int)Math.Round(partheight * j);
					if (xpos >= heightimage.Width) xpos = heightimage.Width - 1;
					if (ypos >= heightimage.Height) ypos = heightimage.Height - 1;
					dg.setGridPositionHeight(i,j,height*heightimage.GetPixel(xpos, ypos).GetBrightness());
					pgsHeightmap.Value += 1;
					pgsHeightmap.Refresh();
				}
			}
		}
		
		public void doRandomHeightmap()
		{
			double f = (double)nudRandomFreq.Value;
			double p = (double)nudRandomPers.Value;
			double o = (double)nudRandomOct.Value;
			double a = (double)nudRandomAmp.Value;
			double c = (double)nudRandomCover.Value;
			double d = (double)nudRandomDensity.Value;
			PerlinNoise pn = new PerlinNoise(f,p,o,a,c,d);
			Bitmap newimage = new Bitmap(500,500);
			pgsHeightmap.Maximum = 500 * 500;
			for (int i = 0; i < newimage.Width; i++) {
				for (int j = 0; j < newimage.Height; j++) {
					double p0 = 255 * pn.PerlinNoise2d(i,j);
					int p1 = (int)p0;
					newimage.SetPixel(i,j,System.Drawing.Color.FromArgb(255,p1,p1,p1));
					pgsHeightmap.Value++;
				}
			}
			pgsHeightmap.Value = 0;
			pgsHeightmap.Maximum = 100;
			loadedimage = (Image)newimage;
			resizedimage = new Bitmap(loadedimage,170,170);
			picHeightmap.Image = resizedimage;
		}
	}
}