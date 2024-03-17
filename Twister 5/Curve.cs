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
		public void doCurve()
		{
			try {
				float radius = float.Parse(txtRadius.Text);
				float width = float.Parse(txtWidth.Text);
				float height = float.Parse(txtHeight.Text);
				float length = (float)(((double)(width * 2 * Math.PI)) / ((double)(360 / nudAngle2.Value)));
				if (chkOption3.Checked) length = float.Parse(txtLength.Text);
				if (length >= 8192 | width >= 8192 | radius >= 1024) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement curve = new Displacement(width,length,-64,(int)nudPower.Value,radius,0,0);
				calculateCurve(ref curve);
				//txtDisplay.Text = curve.toString();
				saveDisplacement(curve);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void doCurve(bool b)
		{
			try {
				float radius = float.Parse(txtRadius.Text);
				float width = float.Parse(txtWidth.Text);
				float height = float.Parse(txtHeight.Text);
				float length = (float)(((double)(width * 2 * Math.PI)) / ((double)(360 / nudAngle2.Value)));
				if (length >= 8192 | width >= 8192 | radius >= 1024) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement curve = new Displacement(width,length,-64,(int)nudPower.Value,radius,0,0);
				calculateCurve(ref curve);
				//txtDisplay.Text = curve.toString();
				//saveDisplacement(curve);
				createPreview(ref curve);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void calculateCurve(ref Displacement d)
		{
			float radius = float.Parse(txtRadius.Text);
			float width = float.Parse(txtWidth.Text);
			float height = float.Parse(txtHeight.Text);
			float totalangle = (float)nudAngle2.Value;
			float length = (float)(((double)(width * 2 * Math.PI)) / ((double)(360 / totalangle)));
			float res = (float)Math.Pow(2,(int)nudPower.Value);
			float currentradius;
			float currentangle = 0;
			float xval, yval, zval;
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					currentradius = radius + ((width / res) * j);
					currentangle = (float)((((totalangle / res) * i) * Math.PI) / 180);
					xval = (float)Math.Round((currentradius * Math.Cos(currentangle)),4);
					yval = (float)Math.Round((currentradius * Math.Sin(currentangle)),4);
					zval = (chkOption2.Checked)?(float)((height / res) * i):0;
					d.setPoint(i,j,xval,yval,zval);
				}
			}
		}
	}
}