/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/07/2008
 * Time: 10:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Twister_5
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		//string checkurl;
		//string updateurl;
		//string liburl;
		string currentver;
		string codelines;
		string release;
		string releasedate;
		Form prevform;
		
		public MainForm()
		{
			InitializeComponent();
			
			//VERSION CONSTANTS
			currentver = "1.1";
			//checkurl = "../twistupdate.txt";
			//updateurl = "../TwistUpdate.exe";
			//liburl = "../csgl.native.dll";
			codelines = "6628";
			release = "Twentieth";
			releasedate = "8th November, 2009";
			//END VERSION CONSTANTS
			
			//UPDATE CHECKER VARIABLES
			//needupdate = false;
			//checkingupdate = false;
			//clickedupdate = false;
			//latestver = "";
			//END UPDATE CHECKER VARIABLES
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"/TwistUpdate.exe"))
				System.IO.File.Delete(System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"/TwistUpdate.exe");
			//---
			//string fold = System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"/";
			//if (System.IO.File.Exists(fold+"csgl.native.dll")) System.IO.File.Delete(fold+"csgl.native.dll");
			//---
			//System.Threading.Thread chk2 = null;
			//chk2 = new System.Threading.Thread(this.updatechk);
			//checkingupdate = true;
			//uptime.Enabled = true;
			//updatestatus.Text = "Checking for latest version...";
			//chk2.Start();
			statUpdate();
		}
		
		void BtnAboutClick(object sender, EventArgs e)
		{
			Status.Text = "About Twister";
			MessageBox.Show("Twister - Displacement Generator\nMade by Penguinboy in SharpDevelop (C#)\n\nVersion " + currentver + ", " + release + " Release.\n\n " + codelines + " Lines of Code\n\n(C) Penguinboy - " + releasedate,"About Twister",MessageBoxButtons.OK,MessageBoxIcon.Information);
			Status.Text = "Idle";
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			statUpdate();
			nudPower.Visible = true;
			lblPower.Visible = true;
			radDispType.Enabled = true;
			txtLength.Visible = false;
			txtLength.Enabled = true;
			lblLength.Visible = false;
			txtWidth.Visible = false;
			lblWidth.Visible = false;
			txtHeight.Visible = false;
			lblHeight.Visible = false;
			txtRadius.Visible = false;
			lblRadius.Visible = false;
			chkOption1.Visible = false;
			chkOption2.Visible = false;
			chkOption3.Visible = false;
			grpTwistmode.Visible = false;
			nudAngle1.Visible = false;
			lblAngle1.Visible = false;
			nudAngle2.Visible = false;
			lblAngle2.Visible = false;
			nudDispRes.Visible = false;
			lblDispRes.Visible = false;
			nudDistVal.Visible = false;
			lblDistVal.Visible = false;
			nudAngle2.Maximum = 180;
			picHeightmap.Visible = false;
			btnLoadHeightmap.Visible = false;
			pgsHeightmap.Visible = true;
			radBrushType.Enabled = true;
			radGoldsourceType.Enabled = true;
			grpRandom.Visible = false;
			lblFile.Visible = false;
			txtFile.Visible = false;
			lblFormula.Visible = false;
			txtFormula.Visible = false;
			nudDispRes.Maximum = 16;
			btnBrowse.Visible = false;
			grpFormulaVars.Visible = false;
			btnPreview.Enabled = true;
			if (radTwist.Checked)
			{
				txtLength.Visible = true;
				lblLength.Visible = true;
				txtWidth.Visible = true;
				lblWidth.Visible = true;
				nudAngle1.Visible = true;
				lblAngle1.Visible = true;
				lblAngle2.Text = "Finish Angle";
				nudAngle2.Visible = true;
				nudAngle2.Maximum = 180;
				lblAngle2.Visible = true;
				grpTwistmode.Visible = true;
			}
			else if (radCurve.Checked)
			{
				txtWidth.Visible = true;
				lblWidth.Visible = true;
				txtRadius.Visible = true;
				lblRadius.Visible = true;
				nudAngle2.Visible = true;
				lblAngle2.Visible = true;
				lblAngle2.Text = "Angle";
				chkOption2.Visible = true;
				chkOption2.Text = "Make Curved Ramp";
				chkOption3.Visible = true;
				chkOption3.Text = "Override";
				lblLength.Visible = true;
				txtLength.Visible = true;
				txtLength.Enabled = chkOption3.Checked;
				txtHeight.Visible = true;
				lblHeight.Visible = true;
				if (nudPower.Value == 2) nudAngle2.Maximum = 90;
				if (nudPower.Value == 3) nudAngle2.Maximum = 180;
				if (nudPower.Value == 4) nudAngle2.Maximum = 360;
				nudAngle2.Value = 90;
			}
			else if (radCorner.Checked)
			{
				txtHeight.Visible = true;
				lblHeight.Visible = true;
				txtRadius.Visible = true;
				lblRadius.Visible = true;
				nudAngle2.Visible = true;
				lblAngle2.Visible = true;
				lblAngle2.Text = "Angle";
				nudAngle2.Maximum = 360;
				chkOption2.Visible = true;
				chkOption2.Text = "Make Outer Corner";
				chkOption3.Visible = true;
				chkOption3.Text = "Override";
				lblLength.Visible = true;
				txtLength.Visible = true;
				txtLength.Enabled = chkOption3.Checked;
			}
			else if (radCircle.Checked)
			{
				txtRadius.Visible = true;
				lblRadius.Visible = true;
			}
			else if (radCone.Checked)
			{
				txtHeight.Visible = true;
				lblHeight.Visible = true;
				txtRadius.Visible = true;
				lblRadius.Visible = true;
				chkOption1.Visible = true;
				chkOption1.Text = "Make Inside Cone";
			}
			else if (radDome.Checked)
			{
				txtRadius.Visible = true;
				lblRadius.Visible = true;
				chkOption1.Visible = true;
				chkOption1.Text = "Make Inside Dome";
			}
			else if (radSphere.Checked)
			{
				txtRadius.Visible = true;
				lblRadius.Visible = true;
				chkOption1.Visible = true;
				chkOption1.Text = "Make Inside Sphere";
				radDispType.Checked = true;
				radBrushType.Enabled = false;
				radGoldsourceType.Enabled = false;
			}
			else if (radNoise.Checked)
			{
				txtLength.Visible = true;
				lblLength.Visible = true;
				txtWidth.Visible = true;
				lblWidth.Visible = true;
				nudDistVal.Visible = true;
				lblDistVal.Visible = true;
			}
			else if (radHeightmap.Checked)
			{
				txtHeight.Visible = true;
				lblHeight.Visible = true;
				txtLength.Visible = true;
				lblLength.Visible = true;
				txtWidth.Visible = true;
				lblWidth.Visible = true;
				nudDispRes.Visible = true;
				lblDispRes.Visible = true;
				picHeightmap.Visible = true;
				btnLoadHeightmap.Visible = true;
				pgsHeightmap.Value = 0;
				grpRandom.Visible = true;
			}
			else if (radConvert.Checked)
			{	
				lblFile.Visible = true;
				txtFile.Visible = true;
				btnBrowse.Visible = true;
				pgsHeightmap.Value = 0;
				nudPower.Visible = false;
				lblPower.Visible = false;
				if (radDispType.Checked) radBrushType.Checked = true;
				radDispType.Enabled = false;
				btnPreview.Enabled = false;
				statReset();
			}
			else if (radFormula.Checked)
			{
				txtLength.Visible = true;
				lblLength.Visible = true;
				txtWidth.Visible = true;
				lblWidth.Visible = true;
				nudDispRes.Visible = true;
				lblDispRes.Visible = true;
				lblFormula.Visible = true;
				txtFormula.Visible = true;
				nudDispRes.Maximum = 10;
				grpFormulaVars.Visible = true;
			}
		}
		
		void BtnGoClick(object sender, EventArgs e)
		{
			if (radTwist.Checked) doTwist();
			else if (radCurve.Checked) doCurve();
			else if (radCorner.Checked) doCorner();
			else if (radCircle.Checked) doCircular();
			else if (radCone.Checked) doCircular();
			else if (radDome.Checked) doCircular();
			else if (radSphere.Checked) doCircular();
			else if (radNoise.Checked) doNoise();
			else if (radHeightmap.Checked) doHeightmap();
			else if (radConvert.Checked) doConvert();
			else if (radFormula.Checked) doFormula();
		}
		
		void NudPowerValueChanged(object sender, EventArgs e)
		{
			statUpdate();
			if (radCurve.Checked)
			{
				nudAngle2.Minimum = 1;
				if (nudPower.Value == 2) nudAngle2.Maximum = 90;
				if (nudPower.Value == 3) nudAngle2.Maximum = 180;
				if (nudPower.Value == 4) nudAngle2.Maximum = 360;
				nudAngle2.Value = 90;
			}
		}
		
		void BtnLoadHeightmapClick(object sender, EventArgs e)
		{
			if (loadheightmap.ShowDialog() == DialogResult.OK) {
				loadedimage = System.Drawing.Image.FromFile(loadheightmap.FileName);
				resizedimage = new Bitmap(loadedimage,170,170);
				picHeightmap.Image = resizedimage;
			}
		}
		
		void BtnRandomClick(object sender, EventArgs e)
		{
			doRandomHeightmap();
		}
		
		void GenTypeCheckedChanged(object sender, EventArgs e)
		{
			statUpdate();
		}
		
		void NudDispResValueChanged(object sender, EventArgs e)
		{
			statUpdate();
		}
		
		void BtnBrowseClick(object sender, EventArgs e)
		{
			loadVMFForConvert();
		}
		
		void BtnPreviewClick(object sender, EventArgs e)
		{
			if (radTwist.Checked) doTwist(true);
			else if (radCurve.Checked) doCurve(true);
			else if (radCorner.Checked) doCorner(true);
			else if (radCircle.Checked) doCircular(true);
			else if (radCone.Checked) doCircular(true);
			else if (radDome.Checked) doCircular(true);
			else if (radSphere.Checked) doCircular(true);
			else if (radNoise.Checked) doNoise(true);
			else if (radHeightmap.Checked) doHeightmap(true);
			//else if (radConvert.Checked) doConvert(true);
			else if (radFormula.Checked) doFormula(true);
		}
		
		//void noLibMsg()
		//{
		//	DialogResult r = 
		//	MessageBox.Show("The CSGL Library could not be found.\nThe library is needed to use the 3D preview feature.\n\n" +
		//	                "Twister can automatically install CSGL for you.\n\nAn internet connection is required.\n" +
		//	                "The library is about 20kb and consists of one DLL file.\n" +
		//	                "This only needs to be done once.\n\nWould you like Twister to install CSGL?",
		//	                "Library not found!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
		//	if (r.Equals(DialogResult.Yes)) installLib();
		//}
		
		//private void installLib()
		//{
		//	try {
		//		if (IsConnectionAvailable())
		//		{
		//			btnPreview.Enabled = false;
		//			updatestatus.Text = "Installing CSGL...";
		//			updatestatus.Refresh();
		//			System.Net.WebClient downloader = new System.Net.WebClient();
		//			string fold = System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"/";
		//			downloader.DownloadFile(new Uri(liburl),fold+"csgl.native.dll");
		//			System.IO.File.Copy(fold+"csgl.native.dll",System.Environment.SystemDirectory+"/csgl.native.dll");
		//			MessageBox.Show("Installation Complete!\n\nTwister will now restart.","Finished!");
		//			Close();
		//			System.Diagnostics.Process.Start(Application.ExecutablePath);
		//		}
		//		else
		//		{
		//			MessageBox.Show("You need to be connected to the internet to install CSGL.","No Internet connection!");
		//		}
		//	}
		//	catch (Exception e) {
		//		MessageBox.Show("ERROR: "+e.Message,"OH NOES");
		//	}
		//}
		
		void createPreview(ref Displacement dis)
		{
			try {
				if (prevform != null) prevform.Dispose();
				prevform = new PreviewForm(dis);
				prevform.Show();
			}
			catch (Exception) {
				//noLibMsg();
			}
		}
		
		void createPreview(ref DisplacementGrid disg)
		{
			try {
				if (prevform != null) prevform.Dispose();
				prevform = new PreviewForm(disg);
				prevform.Show();
			}
			catch (Exception) {
				//noLibMsg();
			}
		}
		
		void ChkOption3CheckedChanged(object sender, EventArgs e)
		{
			txtLength.Enabled = chkOption3.Checked;
		}
	}
}
