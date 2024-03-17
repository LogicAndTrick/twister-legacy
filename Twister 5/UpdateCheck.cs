/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 12/07/2008
 * Time: 4:39 PM
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
		//bool needupdate;
		//bool checkingupdate;
		//bool clickedupdate;
		//string latestver;

		//private bool IsConnectionAvailable()
		//{
		//	try
		//	{
		//		System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com",80);
		//		clnt.Close();
		//		return true;
		//	}
		//	catch(System.Exception) 
		//	{
		//		return false;
		//	}
		//}

		//private void updatechk()
		//{
		//	try {
		//		if (IsConnectionAvailable())
		//		{
		//			System.Net.WebClient downloader = new System.Net.WebClient();
		//			System.IO.Stream strm = downloader.OpenRead(checkurl);
		//			System.IO.StreamReader sr = new System.IO.StreamReader(strm);
		//			latestver = sr.ReadLine();
		//		    strm.Close();
		//		    if (latestver != currentver) needupdate = true;
		//		    else needupdate = false;
		//		}
		//		else needupdate = false;
		//	}
		//	catch (Exception e) {
		//		MessageBox.Show("ERROR: "+e.Message,"OH NOES");
		//	}
		//	checkingupdate = false;
		//}

		void BtnupdateClick(object sender, EventArgs e)
		{
			//System.Threading.Thread chk = null;
			//chk = new System.Threading.Thread(this.updatechk);
			//clickedupdate = true;
			//btnupdate.Enabled = false;
			//uptime.Enabled = true;
			//updatestatus.Text = "Checking for latest version...";
			//chk.Start();
		}

		void UptimeTick(object sender, EventArgs e)
		{
			//if (!checkingupdate)
			//{
			//	uptime.Enabled = false;
			//	afterupdate();
			//}
		}

		//private void afterupdate()
		//{
		//	updatestatus.Text = "Check complete.";

		//	if (needupdate)
		//	{
		//		DialogResult resp = MessageBox.Show("There is a new update available!\n\nUpdate now?","Update Available!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
		//		if (resp.Equals(DialogResult.Yes))
		//		{
		//			//download update
		//			System.Net.WebClient downloader = new System.Net.WebClient();
		//			string fold = System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"/TwistUpdate.exe";
		//			try {
		//				downloader.DownloadFile(updateurl,fold);
		//			Close();
		//			System.Diagnostics.Process.Start(fold);
		//			}
		//			catch (Exception) {
		//				MessageBox.Show("Unable to find updater.");
		//			}
		//		}	
		//		else
		//		{
		//			//don't download update
		//			MessageBox.Show("You will be reminded on startup until you update.\n\nYou really should do it.\n\nNow.\n\nIt takes like ten seconds. Do it. Click the 'Check for Updates' button.\n\nYou know you want to.");
		//		}
		//	}
		//	else if (clickedupdate)
		//	{
		//		MessageBox.Show("no new updates available");
		//	}

		//	needupdate = false;
		//	checkingupdate = false;
		//	clickedupdate = false;

		//	Status.Text = "Idle";
		//	btnupdate.Enabled = true;
		//}
	}
}
