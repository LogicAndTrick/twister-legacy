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
		public void doCorner()
		{
			try {
				float radius = float.Parse(txtRadius.Text);
				float height = float.Parse(txtHeight.Text);
				float angle = (float)nudAngle2.Value;
				float length = (float)Math.Round(2 * Math.PI * radius * angle / 360);
				if (chkOption3.Checked) length = float.Parse(txtLength.Text);
				if (length >= 8192 | height >= 8192 | radius >= 1024) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement corner = new Displacement(-64,length,height,(int)nudPower.Value,0,0,0);
				corner.setDispSide(3);
				calculateCorner(ref corner);
				//txtDisplay.Text = corner.toString();
				saveDisplacement(corner);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void doCorner(bool b)
		{
			try {
				float radius = float.Parse(txtRadius.Text);
				float height = float.Parse(txtHeight.Text);
				float angle = (float)nudAngle2.Value;
				float length = (float)Math.Round(2 * Math.PI * radius * angle / 360);
				if (length >= 8192 | height >= 8192 | radius >= 1024) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement corner = new Displacement(-64,length,height,(int)nudPower.Value,0,0,0);
				corner.setDispSide(3);
				calculateCorner(ref corner);
				//txtDisplay.Text = corner.toString();
				//saveDisplacement(corner);
				createPreview(ref corner);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void calculateCorner(ref Displacement d)
		{
			float radius = float.Parse(txtRadius.Text);
			float height = float.Parse(txtHeight.Text);
			float totalangle = (float)nudAngle2.Value;
			float length = (float)Math.Round(2 * Math.PI * radius * totalangle / 360);
			float multi = (chkOption2.Checked)?1:-1;
			float res = (float)Math.Pow(2,(int)nudPower.Value);
			float currentangle = 0;
			float xval, yval, zval;
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					currentangle = (float)((((totalangle / res) * i) * Math.PI) / 180);
					xval = (float)Math.Round(((2 * radius) - ((radius * Math.Cos(currentangle)) + radius)) * multi,4);
					yval = (float)Math.Round((radius * Math.Sin(currentangle)),4);
					zval = height / res * j;
					d.setPoint(i,j,xval,yval,zval);
				}
			}
		}
	}
}