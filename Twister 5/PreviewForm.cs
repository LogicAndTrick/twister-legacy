/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/08/2008
 * Time: 1:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Twister_5
{
	/// <summary>
	/// Description of PreviewForm.
	/// </summary>
	public partial class PreviewForm : Form
	{
		private OGLView oglview;
		private object renderThis;
		public PreviewForm(object d)
		{
			InitializeComponent();
			renderThis = d;
			oglview = new OGLView();
			oglview.RenderThis = d;
			oglview.Dock = DockStyle.Fill;
			Controls.Add(oglview);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			btnSaveDisp.Visible = true;
			btnSaveBrush.Visible = true;
			btnSaveGoldsource.Visible = true;
		}
		
		void BtnSaveDispClick(object sender, EventArgs e)
		{
			btnSaveDisp.Visible = false;
			btnSaveBrush.Visible = false;
			btnSaveGoldsource.Visible = false;
			//tview.saveDisplacement(1);
			Renderer.saveDisplacement(renderThis, 1);
		}
		
		void BtnSaveBrushClick(object sender, EventArgs e)
		{
			btnSaveDisp.Visible = false;
			btnSaveBrush.Visible = false;
			btnSaveGoldsource.Visible = false;
			//tview.saveDisplacement(2);
			Renderer.saveDisplacement(renderThis, 2);
		}
		
		void BtnSaveGoldsourceClick(object sender, EventArgs e)
		{
			btnSaveDisp.Visible = false;
			btnSaveBrush.Visible = false;
			btnSaveGoldsource.Visible = false;
			//tview.saveDisplacement(3);
			Renderer.saveDisplacement(renderThis, 3);
		}
	}
}
