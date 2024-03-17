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
		public void doTwist()
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				if (length >= 8192 | width >= 8192) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement twist = new Displacement(width,length,-64,(int)nudPower.Value,0,0,0);
				calculateTwist(ref twist);
				//txtDisplay.Text = twist.doABarrelRoll();
				saveDisplacement(twist);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void doTwist(bool b)
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				if (length >= 8192 | width >= 8192) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement twist = new Displacement(width,length,-64,(int)nudPower.Value,0,0,0);
				calculateTwist(ref twist);
				//txtDisplay.Text = twist.doABarrelRoll();
				//saveDisplacement(twist);
				createPreview(ref twist);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void calculateTwist(ref Displacement d)
		{
			float width = float.Parse(txtWidth.Text);
			float length = float.Parse(txtLength.Text);
			float res = (float)Math.Pow(2,(int)nudPower.Value);
			float xval, yval, zval;
			float startangle = (float)nudAngle1.Value;
			float endangle = (float)nudAngle2.Value;
			float totalangle = endangle - startangle;
			float currentangle = 0;
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					if (radHallway.Checked) {
						xval = ((res - i) * j * width) / (res * res);
						yval = length / res * i;
						zval = (width * i / res) - ((width * i * j) / (res * res));
					}
					else {
						currentangle = (float)((startangle + (totalangle / res * i)) * Math.PI / 180);
						xval = (float)((width / 2) + (((width / res * j) - (width / 2)) * Math.Cos(currentangle)));
						yval = length / res * i;
						zval = (float)(((width / res * j) - (width / 2)) * Math.Sin(currentangle));
					}
					d.setPoint(i,j,xval,yval,zval);
				}
			}
		}
	}
}
