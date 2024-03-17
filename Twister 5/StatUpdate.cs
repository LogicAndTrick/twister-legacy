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
		StatDialog statistics = new StatDialog(5);
		public void statUpdate()
		{
			if (radConvert.Checked) return;
			if (radDispType.Checked) statDisp();
			else statBrush();
			statReload();
		}
		
		public void statReset()
		{
			for (int i = 0; i < 5; i++) statistics.addStat(i,"","");
			statReload();
		}
		
		public void statDisp()
		{
			int dispcount = 1;
			if (radFormula.Checked || radHeightmap.Checked) dispcount = (int)Math.Pow((double)nudDispRes.Value,2);
			int pointcount = dispcount * (int)Math.Pow(Math.Pow(2,(double)nudPower.Value)+1,2);
			statistics.addStat(0,"Disp Count",dispcount.ToString());
			statistics.addStat(1,"Point Count",pointcount.ToString());
			statistics.addStat(2,"","");
			statistics.addStat(3,"","");
			statistics.addStat(4,"","");
		}
		
		public void statBrush()
		{
			int dispcount = 1;
			if (radFormula.Checked || radHeightmap.Checked) dispcount = (int)Math.Pow((double)nudDispRes.Value,2);
			int numtris = dispcount * (int)Math.Pow(Math.Pow(2,(double)nudPower.Value),2)*2;
			int numsides = 4 * numtris;
			int triside = dispcount * (int)Math.Pow(2,(double)nudPower.Value);
			float triwid = (float)Math.Round(float.Parse(txtWidth.Text) / triside,4);
			float trilen = (float)Math.Round(float.Parse(txtLength.Text) / triside,4);
			statistics.addStat(0,"Brush Count",numtris.ToString());
			statistics.addStat(1,"Poly Count",numsides.ToString());
			if (radNoise.Checked || radHeightmap.Checked || radFormula.Checked) {
				statistics.addStat(2,"Brush Width",triwid.ToString());
				statistics.addStat(3,"Brush Length",trilen.ToString());
			}
			else {
				statistics.addStat(2,"","");
				statistics.addStat(3,"","");
			}
			statistics.addStat(4,"","");
		}
		
		public void statReload()
		{
			string[] s;
			s = statistics.getStat(0);
			lblStat1k.Text = s[0];
			lblStat1v.Text = s[1];
			s = statistics.getStat(1);
			lblStat2k.Text = s[0];
			lblStat2v.Text = s[1];
			s = statistics.getStat(2);
			lblStat3k.Text = s[0];
			lblStat3v.Text = s[1];
			s = statistics.getStat(3);
			lblStat4k.Text = s[0];
			lblStat4v.Text = s[1];
			s = statistics.getStat(4);
			lblStat5k.Text = s[0];
			lblStat5v.Text = s[1];
		}
	}
}