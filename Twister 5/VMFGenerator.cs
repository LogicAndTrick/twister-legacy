/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 31/08/2008
 * Time: 7:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of VMFGenerator.
	/// </summary>
	public class VMFGenerator
	{
		bool brush,map;
		System.Windows.Forms.SaveFileDialog savethefiles;
		public VMFGenerator()
		{
			brush = false;
			map = false;
			savethefiles = new System.Windows.Forms.SaveFileDialog();
			savethefiles.Filter = "Hammer Files (.vmf)|*.vmf";
		}
		
		public void modeMap()
		{
			brush = false;
			map = true;
		}
		
		public void modeBrush()
		{
			brush = true;
			map = false;
		}
		
		public void modeVMF()
		{
			brush = false;
			map = false;
		}
		
		private string VMFTop()
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
		
		private string VMFBottom()
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
		
		private string contentToVMF(string s)
		{
			string str = "";
			str += VMFTop() + s + VMFBottom();
			return str;
		}
		
		private string MAPTop()
		{
			return "{\r\n" +
				"\"classname\" \"worldspawn\"\r\n" +
				"\"mapversion\" \"220\"\r\n";
		}
		
		private string MAPBottom()
		{
			return "}\r\n";
		}
		
		private string contentToMAP(string s)
		{
			string str = "";
			str += MAPTop() + s + MAPBottom();
			return str;
		}
		
		private string displacementToVMF(Displacement d)
		{
			string ts;
			if (map) return contentToMAP(d.toMap());
			if (brush) ts = d.toBrush();
			else ts = d.toString();
			return contentToVMF(ts);
		}
		
		private string displacementGridToVMF(DisplacementGrid dg)
		{
			string ts;
			if (map) return contentToMAP(dg.toMap());
			if (brush) ts = dg.toBrush();
			else ts = dg.toString();
			return contentToVMF(ts);
		}
		
		public void save(Displacement d)
		{
			if (map) savethefiles.Filter = "Goldsource Hammer Files (.map)|*.map";
			if (savethefiles.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				string saveplace = savethefiles.FileName;
				string s = displacementToVMF(d);
				System.IO.File.WriteAllText(saveplace,s.Replace(',','.'));
			}
			savethefiles.Filter = "Hammer Files (.vmf)|*.vmf";
		}
		
		public void save(DisplacementGrid d)
		{
			if (map) savethefiles.Filter = "Goldsource Hammer Files (.map)|*.map";
			if (savethefiles.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				string saveplace = savethefiles.FileName;
				string s = displacementGridToVMF(d);
				System.IO.File.WriteAllText(saveplace,s.Replace(',','.'));
			}
			savethefiles.Filter = "Hammer Files (.vmf)|*.vmf";
		}
	}
}
