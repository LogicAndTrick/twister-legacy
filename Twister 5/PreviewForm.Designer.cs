/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/08/2008
 * Time: 1:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Twister_5
{
	partial class PreviewForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.btnSaveDisp = new System.Windows.Forms.Button();
			this.btnSaveBrush = new System.Windows.Forms.Button();
			this.btnSaveGoldsource = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(507, 449);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(53, 25);
			this.button1.TabIndex = 0;
			this.button1.Text = "Save...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// btnSaveDisp
			// 
			this.btnSaveDisp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveDisp.Location = new System.Drawing.Point(469, 362);
			this.btnSaveDisp.Name = "btnSaveDisp";
			this.btnSaveDisp.Size = new System.Drawing.Size(91, 23);
			this.btnSaveDisp.TabIndex = 1;
			this.btnSaveDisp.Text = "Displacement";
			this.btnSaveDisp.UseVisualStyleBackColor = true;
			this.btnSaveDisp.Visible = false;
			this.btnSaveDisp.Click += new System.EventHandler(this.BtnSaveDispClick);
			// 
			// btnSaveBrush
			// 
			this.btnSaveBrush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveBrush.Location = new System.Drawing.Point(469, 391);
			this.btnSaveBrush.Name = "btnSaveBrush";
			this.btnSaveBrush.Size = new System.Drawing.Size(91, 23);
			this.btnSaveBrush.TabIndex = 1;
			this.btnSaveBrush.Text = "Brushwork";
			this.btnSaveBrush.UseVisualStyleBackColor = true;
			this.btnSaveBrush.Visible = false;
			this.btnSaveBrush.Click += new System.EventHandler(this.BtnSaveBrushClick);
			// 
			// btnSaveGoldsource
			// 
			this.btnSaveGoldsource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveGoldsource.Location = new System.Drawing.Point(469, 420);
			this.btnSaveGoldsource.Name = "btnSaveGoldsource";
			this.btnSaveGoldsource.Size = new System.Drawing.Size(91, 23);
			this.btnSaveGoldsource.TabIndex = 1;
			this.btnSaveGoldsource.Text = "Goldsource";
			this.btnSaveGoldsource.UseVisualStyleBackColor = true;
			this.btnSaveGoldsource.Visible = false;
			this.btnSaveGoldsource.Click += new System.EventHandler(this.BtnSaveGoldsourceClick);
			// 
			// PreviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(572, 486);
			this.Controls.Add(this.btnSaveGoldsource);
			this.Controls.Add(this.btnSaveBrush);
			this.Controls.Add(this.btnSaveDisp);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "PreviewForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PreviewForm";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnSaveGoldsource;
		private System.Windows.Forms.Button btnSaveBrush;
		private System.Windows.Forms.Button btnSaveDisp;
		private System.Windows.Forms.Button button1;
	}
}
