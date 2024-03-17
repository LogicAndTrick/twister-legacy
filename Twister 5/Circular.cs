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
		CylindricalCoordinate[,] circlecoords;
		
		public void doCircular()
		{
			try {
				float radius = float.Parse(txtRadius.Text);
				float width = (float)Math.Sqrt(Math.PI * radius * radius);
				float height = float.Parse(txtHeight.Text);
				int power = (int)nudPower.Value;
				if (width >= 8192 | radius >= 4098 | (!radCircle.Checked & height > 8192)) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement circular = new Displacement(width,width,-64,power,0,0,0);
				initializeCircular();
				calculateCircular(ref circular);
				//txtDisplay.Text = circular.doABarrelRoll();
				saveDisplacement(circular);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void doCircular(bool b)
		{
			try {
				float radius = float.Parse(txtRadius.Text);
				float width = (float)Math.Sqrt(Math.PI * radius * radius);
				float height = float.Parse(txtHeight.Text);
				int power = (int)nudPower.Value;
				if (width >= 8192 | radius >= 4098 | (!radCircle.Checked & height > 8192)) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				Displacement circular = new Displacement(width,width,-64,power,0,0,0);
				initializeCircular();
				calculateCircular(ref circular);
				//txtDisplay.Text = circular.doABarrelRoll();
				//saveDisplacement(circular);
				createPreview(ref circular);
			}
			catch (Exception e) {
				MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		private void initializeCircular()
		{
			int power = (int)nudPower.Value;
			int res = (int)Math.Pow(2,power);
			float rings = res / 2;
			float radius = float.Parse(txtRadius.Text);
			circlecoords = new CylindricalCoordinate[(int)res+1,(int)res+1];
			circlecoords.Initialize();
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					circlecoords[i,j] = new CylindricalCoordinate();
				}
			}
			//---
			for (int i = 0; i <= rings; i++) {
				populateCircleAngles(i,(int)res, radius);
			}
		}
		
		private float findCircluarHeight(int ring)
		{
			if (radCircle.Checked) return 0;
			int rings = (int)Math.Pow(2,(int)nudPower.Value-1);
			bool isinside = chkOption1.Checked;
			float height;
			if (radCone.Checked) {
				height = float.Parse(txtHeight.Text);
				if (isinside) return (height / (float)rings) * (float)ring;
				return height - ((height / (float)rings) * (float)ring);
			}
			float radius = float.Parse(txtRadius.Text);
			float angle;
			if (radDome.Checked) {
				angle = 90 - ((90 / (float)rings) * (float)ring);
				angle = angle * (float)Math.PI / 180;
				height = radius * (float)Math.Sin(angle);
				if (isinside) return radius - height;
				return height;
			}
			angle = 90 - ((180 / (float)rings) * (float)ring);
			angle = angle * (float)Math.PI / 180;
			height = radius * (float)Math.Sin(angle);
			if (isinside) return radius - height;
			return height + radius;
		}
		
		private float newDomeRadius(float rh)
		{
			float ringheight = rh;
			if (chkOption1.Checked) {
				float radius = float.Parse(txtRadius.Text);
				rh = radius - rh;
			}
			float rad = float.Parse(txtRadius.Text);
			return (float)Math.Sqrt(Math.Pow(rad,2) - Math.Pow(rh,2));
		}
		
		private float newSphereRadius(float rh)
		{
			float radius = float.Parse(txtRadius.Text);
			float ringheight = Math.Abs(radius - rh);
			float rad = float.Parse(txtRadius.Text);
			return (float)Math.Sqrt(Math.Pow(rad,2) - Math.Pow(ringheight,2));
		}
		
		private void setCoordinateProperties(int i, int j, float angle, float distance, float ringheight)
		{
			circlecoords[i,j].setAngle(angle);
			circlecoords[i,j].setDistance(distance);
			circlecoords[i,j].setHeight(ringheight);
			if (radDome.Checked) circlecoords[i,j].setDistance(newDomeRadius(ringheight));
			if (radSphere.Checked) circlecoords[i,j].setDistance(newSphereRadius(ringheight));
		}
		
		private void populateCircleAngles(int ring, int res, float rad)
		{
			int half = res / 2;
			float partrad = rad / (float)(res / 2);
			if (ring == 0) {
				circlecoords[half,half].setAngle(0);
				circlecoords[half,half].setDistance(0);
				circlecoords[half,half].setHeight(findCircluarHeight(0));
				return;
			}
			float angle = (45 / (float)ring);
			float ringheight = findCircluarHeight(ring);
			float d = partrad * (float)ring;
			for (int i = 0; i < ring * 2; i++) {
				setCoordinateProperties(half-ring,half-ring+i,135-(angle*i),d,ringheight);
				setCoordinateProperties(half-ring+i,half+ring,(45-(angle*i)+360)%360,d,ringheight);
				setCoordinateProperties(half+ring-i,half-ring,225-(angle*i),d,ringheight);
				setCoordinateProperties(half+ring,half+ring-i,315-(angle*i),d,ringheight);
			}
		}
		
		public void calculateCircular(ref Displacement d)
		{
			float radius = float.Parse(txtRadius.Text);
			float width = (float)Math.Sqrt(Math.PI * radius * radius);
			float halfwid = width / 2;
			int power = (int)nudPower.Value;
			float res = (float)Math.Pow(2,power);
			//---
			float xval, yval, zval;
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					xval = (float)Math.Round((halfwid + (circlecoords[((int)res-i),j].getDistance() * Math.Cos(circlecoords[((int)res-i),j].getAngle() * Math.PI / 180))),4);
					yval = (float)Math.Round((halfwid + (circlecoords[((int)res-i),j].getDistance() * Math.Sin(circlecoords[((int)res-i),j].getAngle() * Math.PI / 180))),4);
					zval = circlecoords[((int)res-i),j].getHeight();
					d.setPoint(i,j,xval,yval,zval);
				}
			}
		}
	}
}