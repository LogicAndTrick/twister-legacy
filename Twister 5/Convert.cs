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
		public void loadVMFForConvert()
		{
			loadheightmap.Filter = "Hammer Files (.vmf)|*.vmf";
			if (loadheightmap.ShowDialog() == DialogResult.OK) {
				txtFile.Text = loadheightmap.FileName;
				string s = System.IO.File.ReadAllText(loadheightmap.FileName);
				VMFParser v = new VMFParser(s);
				Map m = v.toMap();
				statistics.addStat(0,"Disps Converted",m.numDisp().ToString());
				statistics.addStat(1,"Brush Count",m.ToArray().Length.ToString());
				statistics.addStat(2,"","");
				statistics.addStat(3,"","");
				statistics.addStat(4,"","");
				statReload();
			}
			loadheightmap.Filter = "Image Files (*.gif, *.bmp, *.jpg, *.jpeg, *.png)|*.gif;*.bmp;*.jpg;*.jpeg;*.png";
		}
		
		public void doConvert()
		{
			string s = System.IO.File.ReadAllText(txtFile.Text);
			VMFParser v = new VMFParser(s);
			Map m = v.toMap();
			//-----------------------------------------
			Brush[] brushes = m.ToArray();
			pgsHeightmap.Value = 0;
			pgsHeightmap.Maximum = brushes.Length;
			if (radGoldsourceType.Checked) save.Filter = "Goldsource Hammer Files (.map)|*.map";
			if (save.ShowDialog() == DialogResult.OK) {
				string saveplace = save.FileName;
				if (radBrushType.Checked) System.IO.File.WriteAllText(saveplace, VMFTop());
				else if (radGoldsourceType.Checked) System.IO.File.WriteAllText(saveplace, MAPTop());
				save.Filter = "Hammer Files (.vmf)|*.vmf";
				foreach (Brush b in brushes) {
					//str += b.ToString();
					if (radBrushType.Checked) System.IO.File.AppendAllText(saveplace,b.ToString());
					else if (radGoldsourceType.Checked) System.IO.File.AppendAllText(saveplace,b.toMap());
					pgsHeightmap.Value++;
				}
				if (radBrushType.Checked) System.IO.File.AppendAllText(saveplace, VMFBottom());
				else if (radGoldsourceType.Checked) System.IO.File.AppendAllText(saveplace, MAPBottom());
				pgsHeightmap.Value = 0;
			}
		}
	}
}
