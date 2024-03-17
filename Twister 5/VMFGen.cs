/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/07/2008
 * Time: 4:47 PM
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
		public string VMFTop()
		{
			return "versioninfo\r\n" +
				"{\r\n" +
				"	\"editorversion\" \"400\"\r\n" +
				"	\"editorbuild\" \"3576\"\r\n" +
				"	\"mapversion\" \"1\"\r\n" +
				"	\"formatversion\" \"100\"\r\n" +
				"	\"prefab\" \"0\"\r\n" +
				"}\r\n" +
				"visgroups\r\n" +
				"{\r\n" +
				"}\r\n" +
				"viewsettings\r\n" +
				"{\r\n" +
				"	\"bSnapToGrid\" \"1\"\r\n" +
				"	\"bShowGrid\" \"1\"\r\n" +
				"	\"bShowLogicalGrid\" \"0\"\r\n" +
				"	\"nGridSpacing\" \"64\"\r\n" +
				"	\"bShow3DGrid\" \"0\"\r\n" +
				"}\r\n" +
				"world\r\n" +
				"{\r\n" +
				"	\"id\" \"1\"\r\n" +
				"	\"mapversion\" \"1\"\r\n" +
				"	\"classname\" \"worldspawn\"\r\n" +
				"	\"skyname\" \"sky_day01_01\"\r\n" +
				"	\"maxpropscreenwidth\" \"-1\"\r\n" +
				"	\"detailvbsp\" \"detail.vbsp\"\r\n" +
				"	\"detailmaterial\" \"detail/detailsprites\"\r\n";
		}
		
		public string VMFBottom()
		{
			return "}\r\n" +
				"cameras\r\n" +
				"{\r\n" +
				"	\"activecamera\" \"-1\"\r\n" +
				"}\r\n" +
				"cordon\r\n" +
				"{\r\n" +
				"	\"mins\" \"(-1024 -1024 -1024)\"\r\n" +
				"	\"maxs\" \"(1024 1024 1024)\"\r\n" +
				"	\"active\" \"0\"\r\n" +
				"}\r\n";
		}
		
		public string contentToVMF(string s)
		{
			string str = "";
			str += VMFTop() + s + VMFBottom();
			return str;
		}
		
		public string MAPTop()
		{
			return "{\r\n" +
				"\"classname\" \"worldspawn\"\r\n" +
				"\"mapversion\" \"220\"\r\n";
		}
		
		public string MAPBottom()
		{
			return "}\r\n";
		}
		
		public string contentToMAP(string s)
		{
			string str = "";
			str += MAPTop() + s + MAPBottom();
			return str;
		}
		
		public string displacementToVMF(Displacement d)
		{
			string ts;
			if (radGoldsourceType.Checked) return contentToMAP(d.toMap());
			if (radBrushType.Checked) ts = d.toBrush();
			else ts = d.toString();
			return contentToVMF(ts);
		}
		
		public string displacementGridToVMF(DisplacementGrid dg)
		{
			string ts;
			if (radGoldsourceType.Checked) return contentToMAP(dg.toMap());
			if (radBrushType.Checked) ts = dg.toBrush();
			else ts = dg.toString();
			return contentToVMF(ts);
		}
		
		public void saveContent(string s)
		{
			if (radGoldsourceType.Checked) save.Filter = "Goldsource Hammer Files (.map)|*.map";
			if (save.ShowDialog() == DialogResult.OK) {
				string saveplace = save.FileName;
				System.IO.File.WriteAllText(saveplace, s.Replace(',','.'));
			}
			save.Filter = "Hammer Files (.vmf)|*.vmf";
		}
		
		public void saveDisplacement(Displacement d)
		{
			saveContent(displacementToVMF(d));
		}
		
		public void saveDisplacementGrid(DisplacementGrid dg)
		{
			saveContent(displacementGridToVMF(dg));
		}
	}
}
