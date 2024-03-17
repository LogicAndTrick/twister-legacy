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
		public void doNoise()
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				if (length >= 8192 | width >= 8192) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement noise = new Displacement(width,length,-64,(int)nudPower.Value,0,0,0);
				noise.setStandardPoints();
				calculateNoise(ref noise);
				//txtDisplay.Text = noise.toString();
				saveDisplacement(noise);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void doNoise(bool b)
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				if (length >= 8192 | width >= 8192) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement noise = new Displacement(width,length,-64,(int)nudPower.Value,0,0,0);
				noise.setStandardPoints();
				calculateNoise(ref noise);
				//txtDisplay.Text = noise.toString();
				createPreview(ref noise);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		private void circularNoise(int ring, int res, int min, int max, ref Displacement d)
		{
			int half = res / 2;
			Random rand = new Random();
			if (ring == 0) {
				d.setHeight(half,half,rand.Next(min,max));
				return;
			}
			for (int i = 0; i < ring * 2; i++) {
				d.setHeight(half-ring,half-ring+i,rand.Next(min,max));
				d.setHeight(half-ring+i,half+ring,rand.Next(min,max));
				d.setHeight(half+ring-i,half-ring,rand.Next(min,max));
				d.setHeight(half+ring,half+ring-i,rand.Next(min,max));
			}
		}
		
		public void calculateNoise(ref Displacement d)
		{
			float res = (float)Math.Pow(2,(int)nudPower.Value);
			int dist = (int)nudDistVal.Value;
			int max = dist;
			int min = -1 * max;
			min = 0;
			Random rand = new Random();
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					d.setHeight(i,j,rand.Next(min,max));
				}
			}
			/*int rings = (int)res / 2;
			for (int i = 0; i <= rings; i++) {
				circularNoise(i,(int)res,(int)(dist*(rings-i)),(int)(dist*((rings-i)+1)),ref d);
			}*/
		}
	}
}