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
		MathParser.Parser mathparse = new MathParser.Parser(MathParser.Mode.RAD);
		
		public void doFormula()
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				int side = (int)nudDispRes.Value;
				int power = (int)nudPower.Value;
				if (length >= 16384 | width >= 16384) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				DisplacementGrid formula = new DisplacementGrid(side,side,width,length,power);
				calculateFormula(ref formula);
				lblHeightmapWait.Visible = true;
				lblHeightmapWait.Refresh();
				saveDisplacementGrid(formula);
				lblHeightmapWait.Visible = false;
				pgsHeightmap.Value = 0;
				pgsHeightmap.Maximum = 100;
				//p.Evaluate(formula);
				//MessageBox.Show(p.Result.ToString());
				//Displacement formula = new Displacement(512,512,-64,(int)nudPower.Value,0,0,0);
				//formula.setStandardPoints();
				//txtDisplay.Text = noise.toString();
				//saveDisplacement(formula);
			}
			catch (Exception e) {
				MessageBox.Show("Your math expression is invalid.\n"+e.Message,"OH NOES");
				lblHeightmapWait.Visible = false;
				pgsHeightmap.Value = 0;
				pgsHeightmap.Maximum = 100;
			}
		}
		
		public void doFormula(bool b)
		{
			try {
				float width = float.Parse(txtWidth.Text);
				float length = float.Parse(txtLength.Text);
				int side = (int)nudDispRes.Value;
				int power = (int)nudPower.Value;
				if (length >= 16384 | width >= 16384) {
					MessageBox.Show("Too large.","ERROR");
					return;
				}
				DisplacementGrid formula = new DisplacementGrid(side,side,width,length,power);
				calculateFormula(ref formula);
				lblHeightmapWait.Visible = true;
				lblHeightmapWait.Refresh();
				//saveDisplacementGrid(formula);
				createPreview(ref formula);
				lblHeightmapWait.Visible = false;
				pgsHeightmap.Value = 0;
				pgsHeightmap.Maximum = 100;
				//p.Evaluate(formula);
				//MessageBox.Show(p.Result.ToString());
				//Displacement formula = new Displacement(512,512,-64,(int)nudPower.Value,0,0,0);
				//formula.setStandardPoints();
				//txtDisplay.Text = noise.toString();
				//saveDisplacement(formula);
			}
			catch (Exception e) {
				MessageBox.Show("Your math expression is invalid.\n"+e.Message,"OH NOES");
				lblHeightmapWait.Visible = false;
				pgsHeightmap.Value = 0;
				pgsHeightmap.Maximum = 100;
			}
		}
		
		public void calculateFormula(ref DisplacementGrid dg)
		{
			int power = (int)nudPower.Value;
			float res = (float)Math.Pow(2,power);
			string formula = txtFormula.Text;
			string tf;
			bool e = true;
			float radius,nozeroradius;//,ring;
			int side = (int)nudDispRes.Value;
			int numpoints = (int)Math.Pow(2,power) * side;
			float width = float.Parse(txtWidth.Text);
			float length = float.Parse(txtLength.Text);
			float halfwidth = width / 2;
			float halflength = length / 2;
			float widthsection = width / numpoints;
			float lengthsection = length / numpoints;
			int totalcalcs = (numpoints+1) * (numpoints+1);
			pgsHeightmap.Maximum = totalcalcs;
			formula = formula.Replace("res",numpoints.ToString());
			formula = formula.Replace("power",power.ToString());
			for (int i = 0; i <= numpoints; i++) {
				for (int j = 0; j <= numpoints; j++) {
					radius = (float)Math.Sqrt(Math.Pow((i*widthsection)-halfwidth,2)+Math.Pow((j*lengthsection)-halflength,2));
					nozeroradius = radius;
					if (radius == 0) nozeroradius = 1;
					//ring = Math.Max(Math.Abs(numpoints/2-i),Math.Abs(numpoints/2-j));
					tf = formula;
					tf = tf.Replace("xval",i.ToString());
					tf = tf.Replace("yval",j.ToString());
					tf = tf.Replace("xdist",(i*widthsection).ToString());
					tf = tf.Replace("ydist",(j*lengthsection).ToString());
					tf = tf.Replace("nzradius",nozeroradius.ToString());
					tf = tf.Replace("radius",radius.ToString());
					//tf = tf.Replace("ring",ring.ToString());
					//txtDisplay.Text += tf + ";\r\n";
					e = mathparse.Evaluate(tf);
					//d.setHeight(i,j,(float)mathparse.Result);
					dg.setGridPositionHeight(i,j,(float)mathparse.Result);
					pgsHeightmap.Value += 1;
					pgsHeightmap.Refresh();
					if (!e) throw new Exception();
				}
			}
		}
	}
}
