/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/07/2008
 * Time: 10:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Twister_5
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.updatestatus = new System.Windows.Forms.Label();
            this.uptime = new System.Windows.Forms.Timer(this.components);
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.btnupdate = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.loadheightmap = new System.Windows.Forms.OpenFileDialog();
            this.grpChoose = new System.Windows.Forms.GroupBox();
            this.radSphere = new System.Windows.Forms.RadioButton();
            this.radFormula = new System.Windows.Forms.RadioButton();
            this.radConvert = new System.Windows.Forms.RadioButton();
            this.radHeightmap = new System.Windows.Forms.RadioButton();
            this.radNoise = new System.Windows.Forms.RadioButton();
            this.radDome = new System.Windows.Forms.RadioButton();
            this.radCone = new System.Windows.Forms.RadioButton();
            this.radCircle = new System.Windows.Forms.RadioButton();
            this.radCorner = new System.Windows.Forms.RadioButton();
            this.radCurve = new System.Windows.Forms.RadioButton();
            this.radTwist = new System.Windows.Forms.RadioButton();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblAngle1 = new System.Windows.Forms.Label();
            this.lblAngle2 = new System.Windows.Forms.Label();
            this.nudPower = new System.Windows.Forms.NumericUpDown();
            this.nudAngle1 = new System.Windows.Forms.NumericUpDown();
            this.nudAngle2 = new System.Windows.Forms.NumericUpDown();
            this.grpTwistmode = new System.Windows.Forms.GroupBox();
            this.radSmooth = new System.Windows.Forms.RadioButton();
            this.radHallway = new System.Windows.Forms.RadioButton();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.grpFileType = new System.Windows.Forms.GroupBox();
            this.radGoldsourceType = new System.Windows.Forms.RadioButton();
            this.radBrushType = new System.Windows.Forms.RadioButton();
            this.radDispType = new System.Windows.Forms.RadioButton();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblDistVal = new System.Windows.Forms.Label();
            this.nudDistVal = new System.Windows.Forms.NumericUpDown();
            this.lblDispRes = new System.Windows.Forms.Label();
            this.nudDispRes = new System.Windows.Forms.NumericUpDown();
            this.chkOption1 = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.picHeightmap = new System.Windows.Forms.PictureBox();
            this.btnLoadHeightmap = new System.Windows.Forms.Button();
            this.pgsHeightmap = new System.Windows.Forms.ProgressBar();
            this.lblHeightmapWait = new System.Windows.Forms.Label();
            this.btnRandom = new System.Windows.Forms.Button();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.lblStat5v = new System.Windows.Forms.Label();
            this.lblStat4v = new System.Windows.Forms.Label();
            this.lblStat3v = new System.Windows.Forms.Label();
            this.lblStat2v = new System.Windows.Forms.Label();
            this.lblStat1v = new System.Windows.Forms.Label();
            this.lblStat5k = new System.Windows.Forms.Label();
            this.lblStat4k = new System.Windows.Forms.Label();
            this.lblStat3k = new System.Windows.Forms.Label();
            this.lblStat2k = new System.Windows.Forms.Label();
            this.lblStat1k = new System.Windows.Forms.Label();
            this.grpRandom = new System.Windows.Forms.GroupBox();
            this.lblRandomDensity = new System.Windows.Forms.Label();
            this.lblRandomCover = new System.Windows.Forms.Label();
            this.lblRandomAmp = new System.Windows.Forms.Label();
            this.nudRandomDensity = new System.Windows.Forms.NumericUpDown();
            this.nudRandomCover = new System.Windows.Forms.NumericUpDown();
            this.nudRandomAmp = new System.Windows.Forms.NumericUpDown();
            this.lblRandomOct = new System.Windows.Forms.Label();
            this.nudRandomOct = new System.Windows.Forms.NumericUpDown();
            this.lblRandomPers = new System.Windows.Forms.Label();
            this.nudRandomPers = new System.Windows.Forms.NumericUpDown();
            this.lblRandomFreq = new System.Windows.Forms.Label();
            this.nudRandomFreq = new System.Windows.Forms.NumericUpDown();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFormula = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grpFormulaVars = new System.Windows.Forms.GroupBox();
            this.lblFormulaVar3 = new System.Windows.Forms.Label();
            this.lblFormulaVar1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkOption2 = new System.Windows.Forms.CheckBox();
            this.chkOption3 = new System.Windows.Forms.CheckBox();
            this.grpChoose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle2)).BeginInit();
            this.grpTwistmode.SuspendLayout();
            this.grpFileType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDispRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeightmap)).BeginInit();
            this.grpStats.SuspendLayout();
            this.grpRandom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomOct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomFreq)).BeginInit();
            this.grpFormulaVars.SuspendLayout();
            this.SuspendLayout();
            // 
            // updatestatus
            // 
            this.updatestatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updatestatus.AutoSize = true;
            this.updatestatus.Location = new System.Drawing.Point(206, 369);
            this.updatestatus.Name = "updatestatus";
            this.updatestatus.Size = new System.Drawing.Size(0, 13);
            this.updatestatus.TabIndex = 25;
            this.updatestatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uptime
            // 
            this.uptime.Tick += new System.EventHandler(this.UptimeTick);
            // 
            // save
            // 
            this.save.Filter = "Hammer Files (.vmf)|*.vmf";
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnupdate.Enabled = false;
            this.btnupdate.Location = new System.Drawing.Point(443, 364);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(111, 23);
            this.btnupdate.TabIndex = 21;
            this.btnupdate.Text = "Check for Updates";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Visible = false;
            this.btnupdate.Click += new System.EventHandler(this.BtnupdateClick);
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(15, 371);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 24;
            // 
            // BtnAbout
            // 
            this.BtnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAbout.Location = new System.Drawing.Point(560, 364);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(75, 23);
            this.BtnAbout.TabIndex = 22;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAboutClick);
            // 
            // loadheightmap
            // 
            this.loadheightmap.Filter = "Image Files (*.gif, *.bmp, *.jpg, *.jpeg, *.png)|*.gif;*.bmp;*.jpg;*.jpeg;*.png";
            // 
            // grpChoose
            // 
            this.grpChoose.Controls.Add(this.radSphere);
            this.grpChoose.Controls.Add(this.radFormula);
            this.grpChoose.Controls.Add(this.radConvert);
            this.grpChoose.Controls.Add(this.radHeightmap);
            this.grpChoose.Controls.Add(this.radNoise);
            this.grpChoose.Controls.Add(this.radDome);
            this.grpChoose.Controls.Add(this.radCone);
            this.grpChoose.Controls.Add(this.radCircle);
            this.grpChoose.Controls.Add(this.radCorner);
            this.grpChoose.Controls.Add(this.radCurve);
            this.grpChoose.Controls.Add(this.radTwist);
            this.grpChoose.Location = new System.Drawing.Point(12, 12);
            this.grpChoose.Name = "grpChoose";
            this.grpChoose.Size = new System.Drawing.Size(109, 346);
            this.grpChoose.TabIndex = 26;
            this.grpChoose.TabStop = false;
            this.grpChoose.Text = "Choose";
            // 
            // radSphere
            // 
            this.radSphere.Location = new System.Drawing.Point(6, 197);
            this.radSphere.Name = "radSphere";
            this.radSphere.Size = new System.Drawing.Size(83, 24);
            this.radSphere.TabIndex = 1;
            this.radSphere.Text = "Sphere";
            this.radSphere.UseVisualStyleBackColor = true;
            // 
            // radFormula
            // 
            this.radFormula.Location = new System.Drawing.Point(6, 317);
            this.radFormula.Name = "radFormula";
            this.radFormula.Size = new System.Drawing.Size(83, 24);
            this.radFormula.TabIndex = 0;
            this.radFormula.Text = "Formula";
            this.radFormula.UseVisualStyleBackColor = true;
            this.radFormula.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radConvert
            // 
            this.radConvert.Location = new System.Drawing.Point(6, 287);
            this.radConvert.Name = "radConvert";
            this.radConvert.Size = new System.Drawing.Size(83, 24);
            this.radConvert.TabIndex = 0;
            this.radConvert.Text = "Convert";
            this.radConvert.UseVisualStyleBackColor = true;
            this.radConvert.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radHeightmap
            // 
            this.radHeightmap.Location = new System.Drawing.Point(6, 257);
            this.radHeightmap.Name = "radHeightmap";
            this.radHeightmap.Size = new System.Drawing.Size(83, 24);
            this.radHeightmap.TabIndex = 0;
            this.radHeightmap.Text = "Heightmap";
            this.radHeightmap.UseVisualStyleBackColor = true;
            this.radHeightmap.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radNoise
            // 
            this.radNoise.Location = new System.Drawing.Point(6, 227);
            this.radNoise.Name = "radNoise";
            this.radNoise.Size = new System.Drawing.Size(83, 24);
            this.radNoise.TabIndex = 0;
            this.radNoise.Text = "Noise";
            this.radNoise.UseVisualStyleBackColor = true;
            this.radNoise.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radDome
            // 
            this.radDome.Location = new System.Drawing.Point(6, 169);
            this.radDome.Name = "radDome";
            this.radDome.Size = new System.Drawing.Size(83, 24);
            this.radDome.TabIndex = 0;
            this.radDome.Text = "Dome";
            this.radDome.UseVisualStyleBackColor = true;
            this.radDome.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radCone
            // 
            this.radCone.Location = new System.Drawing.Point(6, 139);
            this.radCone.Name = "radCone";
            this.radCone.Size = new System.Drawing.Size(83, 24);
            this.radCone.TabIndex = 0;
            this.radCone.Text = "Cone";
            this.radCone.UseVisualStyleBackColor = true;
            this.radCone.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radCircle
            // 
            this.radCircle.Location = new System.Drawing.Point(6, 109);
            this.radCircle.Name = "radCircle";
            this.radCircle.Size = new System.Drawing.Size(83, 24);
            this.radCircle.TabIndex = 0;
            this.radCircle.Text = "Circle";
            this.radCircle.UseVisualStyleBackColor = true;
            this.radCircle.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radCorner
            // 
            this.radCorner.Location = new System.Drawing.Point(6, 79);
            this.radCorner.Name = "radCorner";
            this.radCorner.Size = new System.Drawing.Size(83, 24);
            this.radCorner.TabIndex = 0;
            this.radCorner.Text = "Corner";
            this.radCorner.UseVisualStyleBackColor = true;
            this.radCorner.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radCurve
            // 
            this.radCurve.Location = new System.Drawing.Point(6, 49);
            this.radCurve.Name = "radCurve";
            this.radCurve.Size = new System.Drawing.Size(83, 24);
            this.radCurve.TabIndex = 0;
            this.radCurve.Text = "Curve";
            this.radCurve.UseVisualStyleBackColor = true;
            this.radCurve.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radTwist
            // 
            this.radTwist.Checked = true;
            this.radTwist.Location = new System.Drawing.Point(6, 19);
            this.radTwist.Name = "radTwist";
            this.radTwist.Size = new System.Drawing.Size(83, 24);
            this.radTwist.TabIndex = 0;
            this.radTwist.TabStop = true;
            this.radTwist.Text = "Twist";
            this.radTwist.UseVisualStyleBackColor = true;
            this.radTwist.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(189, 20);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 27;
            this.txtWidth.Text = "512";
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(132, 20);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(51, 20);
            this.lblWidth.TabIndex = 28;
            this.lblWidth.Text = "Width";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(189, 46);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 27;
            this.txtLength.Text = "1024";
            // 
            // lblLength
            // 
            this.lblLength.Location = new System.Drawing.Point(132, 46);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(51, 20);
            this.lblLength.TabIndex = 28;
            this.lblLength.Text = "Length";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(375, 24);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(37, 13);
            this.lblPower.TabIndex = 12;
            this.lblPower.Text = "Power";
            // 
            // lblAngle1
            // 
            this.lblAngle1.AutoSize = true;
            this.lblAngle1.Location = new System.Drawing.Point(173, 145);
            this.lblAngle1.Name = "lblAngle1";
            this.lblAngle1.Size = new System.Drawing.Size(59, 13);
            this.lblAngle1.TabIndex = 12;
            this.lblAngle1.Text = "Start Angle";
            // 
            // lblAngle2
            // 
            this.lblAngle2.AutoSize = true;
            this.lblAngle2.Location = new System.Drawing.Point(173, 167);
            this.lblAngle2.Name = "lblAngle2";
            this.lblAngle2.Size = new System.Drawing.Size(64, 13);
            this.lblAngle2.TabIndex = 12;
            this.lblAngle2.Text = "Finish Angle";
            // 
            // nudPower
            // 
            this.nudPower.Location = new System.Drawing.Point(415, 20);
            this.nudPower.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPower.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPower.Name = "nudPower";
            this.nudPower.Size = new System.Drawing.Size(55, 20);
            this.nudPower.TabIndex = 13;
            this.nudPower.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPower.ValueChanged += new System.EventHandler(this.NudPowerValueChanged);
            // 
            // nudAngle1
            // 
            this.nudAngle1.Location = new System.Drawing.Point(243, 141);
            this.nudAngle1.Name = "nudAngle1";
            this.nudAngle1.Size = new System.Drawing.Size(46, 20);
            this.nudAngle1.TabIndex = 14;
            // 
            // nudAngle2
            // 
            this.nudAngle2.Location = new System.Drawing.Point(243, 164);
            this.nudAngle2.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudAngle2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAngle2.Name = "nudAngle2";
            this.nudAngle2.Size = new System.Drawing.Size(46, 20);
            this.nudAngle2.TabIndex = 14;
            this.nudAngle2.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // grpTwistmode
            // 
            this.grpTwistmode.Controls.Add(this.radSmooth);
            this.grpTwistmode.Controls.Add(this.radHallway);
            this.grpTwistmode.Location = new System.Drawing.Point(189, 72);
            this.grpTwistmode.Name = "grpTwistmode";
            this.grpTwistmode.Size = new System.Drawing.Size(100, 63);
            this.grpTwistmode.TabIndex = 17;
            this.grpTwistmode.TabStop = false;
            this.grpTwistmode.Text = "Mode";
            // 
            // radSmooth
            // 
            this.radSmooth.AutoSize = true;
            this.radSmooth.Location = new System.Drawing.Point(6, 39);
            this.radSmooth.Name = "radSmooth";
            this.radSmooth.Size = new System.Drawing.Size(91, 17);
            this.radSmooth.TabIndex = 15;
            this.radSmooth.Text = "Smooth Mode";
            this.radSmooth.UseVisualStyleBackColor = true;
            // 
            // radHallway
            // 
            this.radHallway.AutoSize = true;
            this.radHallway.Checked = true;
            this.radHallway.Location = new System.Drawing.Point(6, 16);
            this.radHallway.Name = "radHallway";
            this.radHallway.Size = new System.Drawing.Size(92, 17);
            this.radHallway.TabIndex = 15;
            this.radHallway.TabStop = true;
            this.radHallway.Text = "Hallway Mode";
            this.radHallway.UseVisualStyleBackColor = true;
            // 
            // txtFormula
            // 
            this.txtFormula.BackColor = System.Drawing.SystemColors.Window;
            this.txtFormula.Location = new System.Drawing.Point(127, 144);
            this.txtFormula.Multiline = true;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFormula.Size = new System.Drawing.Size(242, 60);
            this.txtFormula.TabIndex = 47;
            this.txtFormula.Text = "radius*sin(yval/power)*cos(xval/power)/power";
            this.txtFormula.Visible = false;
            // 
            // grpFileType
            // 
            this.grpFileType.Controls.Add(this.radGoldsourceType);
            this.grpFileType.Controls.Add(this.radBrushType);
            this.grpFileType.Controls.Add(this.radDispType);
            this.grpFileType.Location = new System.Drawing.Point(375, 46);
            this.grpFileType.Name = "grpFileType";
            this.grpFileType.Size = new System.Drawing.Size(109, 82);
            this.grpFileType.TabIndex = 18;
            this.grpFileType.TabStop = false;
            this.grpFileType.Text = "File Type";
            // 
            // radGoldsourceType
            // 
            this.radGoldsourceType.AutoSize = true;
            this.radGoldsourceType.Location = new System.Drawing.Point(6, 59);
            this.radGoldsourceType.Name = "radGoldsourceType";
            this.radGoldsourceType.Size = new System.Drawing.Size(79, 17);
            this.radGoldsourceType.TabIndex = 1;
            this.radGoldsourceType.Text = "Goldsource";
            this.radGoldsourceType.UseVisualStyleBackColor = true;
            this.radGoldsourceType.CheckedChanged += new System.EventHandler(this.GenTypeCheckedChanged);
            // 
            // radBrushType
            // 
            this.radBrushType.AutoSize = true;
            this.radBrushType.Location = new System.Drawing.Point(6, 39);
            this.radBrushType.Name = "radBrushType";
            this.radBrushType.Size = new System.Drawing.Size(75, 17);
            this.radBrushType.TabIndex = 0;
            this.radBrushType.Text = "Brushwork";
            this.radBrushType.UseVisualStyleBackColor = true;
            this.radBrushType.CheckedChanged += new System.EventHandler(this.GenTypeCheckedChanged);
            // 
            // radDispType
            // 
            this.radDispType.AutoSize = true;
            this.radDispType.Checked = true;
            this.radDispType.Location = new System.Drawing.Point(6, 17);
            this.radDispType.Name = "radDispType";
            this.radDispType.Size = new System.Drawing.Size(89, 17);
            this.radDispType.TabIndex = 0;
            this.radDispType.TabStop = true;
            this.radDispType.Text = "Displacement";
            this.radDispType.UseVisualStyleBackColor = true;
            this.radDispType.CheckedChanged += new System.EventHandler(this.GenTypeCheckedChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(189, 72);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 27;
            this.txtHeight.Text = "256";
            this.txtHeight.Visible = false;
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(132, 72);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(51, 20);
            this.lblHeight.TabIndex = 28;
            this.lblHeight.Text = "Height";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeight.Visible = false;
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(189, 98);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(100, 20);
            this.txtRadius.TabIndex = 27;
            this.txtRadius.Text = "256";
            this.txtRadius.Visible = false;
            // 
            // lblRadius
            // 
            this.lblRadius.Location = new System.Drawing.Point(132, 98);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(51, 20);
            this.lblRadius.TabIndex = 28;
            this.lblRadius.Text = "Radius";
            this.lblRadius.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRadius.Visible = false;
            // 
            // lblDistVal
            // 
            this.lblDistVal.AutoSize = true;
            this.lblDistVal.Location = new System.Drawing.Point(154, 78);
            this.lblDistVal.Name = "lblDistVal";
            this.lblDistVal.Size = new System.Drawing.Size(79, 13);
            this.lblDistVal.TabIndex = 18;
            this.lblDistVal.Text = "Distance Value";
            this.lblDistVal.Visible = false;
            // 
            // nudDistVal
            // 
            this.nudDistVal.Location = new System.Drawing.Point(234, 75);
            this.nudDistVal.Name = "nudDistVal";
            this.nudDistVal.Size = new System.Drawing.Size(55, 20);
            this.nudDistVal.TabIndex = 19;
            this.nudDistVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDistVal.Visible = false;
            // 
            // lblDispRes
            // 
            this.lblDispRes.AutoSize = true;
            this.lblDispRes.Location = new System.Drawing.Point(144, 103);
            this.lblDispRes.Name = "lblDispRes";
            this.lblDispRes.Size = new System.Drawing.Size(84, 13);
            this.lblDispRes.TabIndex = 24;
            this.lblDispRes.Text = "Disp. Resolution";
            this.lblDispRes.Visible = false;
            // 
            // nudDispRes
            // 
            this.nudDispRes.Location = new System.Drawing.Point(234, 100);
            this.nudDispRes.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudDispRes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDispRes.Name = "nudDispRes";
            this.nudDispRes.Size = new System.Drawing.Size(55, 20);
            this.nudDispRes.TabIndex = 28;
            this.nudDispRes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDispRes.Visible = false;
            this.nudDispRes.ValueChanged += new System.EventHandler(this.NudDispResValueChanged);
            // 
            // chkOption1
            // 
            this.chkOption1.Location = new System.Drawing.Point(142, 46);
            this.chkOption1.Name = "chkOption1";
            this.chkOption1.Size = new System.Drawing.Size(147, 24);
            this.chkOption1.TabIndex = 36;
            this.chkOption1.Text = "Option 1";
            this.chkOption1.UseVisualStyleBackColor = true;
            this.chkOption1.Visible = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(375, 134);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(109, 23);
            this.btnGo.TabIndex = 38;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGoClick);
            // 
            // picHeightmap
            // 
            this.picHeightmap.Location = new System.Drawing.Point(127, 159);
            this.picHeightmap.Name = "picHeightmap";
            this.picHeightmap.Size = new System.Drawing.Size(170, 170);
            this.picHeightmap.TabIndex = 39;
            this.picHeightmap.TabStop = false;
            this.picHeightmap.Visible = false;
            // 
            // btnLoadHeightmap
            // 
            this.btnLoadHeightmap.Location = new System.Drawing.Point(180, 127);
            this.btnLoadHeightmap.Name = "btnLoadHeightmap";
            this.btnLoadHeightmap.Size = new System.Drawing.Size(109, 23);
            this.btnLoadHeightmap.TabIndex = 38;
            this.btnLoadHeightmap.Text = "Load Heightmap";
            this.btnLoadHeightmap.UseVisualStyleBackColor = true;
            this.btnLoadHeightmap.Visible = false;
            this.btnLoadHeightmap.Click += new System.EventHandler(this.BtnLoadHeightmapClick);
            // 
            // pgsHeightmap
            // 
            this.pgsHeightmap.Location = new System.Drawing.Point(127, 335);
            this.pgsHeightmap.Name = "pgsHeightmap";
            this.pgsHeightmap.Size = new System.Drawing.Size(357, 23);
            this.pgsHeightmap.TabIndex = 40;
            // 
            // lblHeightmapWait
            // 
            this.lblHeightmapWait.BackColor = System.Drawing.Color.White;
            this.lblHeightmapWait.Location = new System.Drawing.Point(254, 166);
            this.lblHeightmapWait.Name = "lblHeightmapWait";
            this.lblHeightmapWait.Size = new System.Drawing.Size(101, 17);
            this.lblHeightmapWait.TabIndex = 41;
            this.lblHeightmapWait.Text = "Please wait...";
            this.lblHeightmapWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeightmapWait.Visible = false;
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(38, 177);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(75, 23);
            this.btnRandom.TabIndex = 42;
            this.btnRandom.Text = "Generate";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.BtnRandomClick);
            // 
            // grpStats
            // 
            this.grpStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStats.Controls.Add(this.lblStat5v);
            this.grpStats.Controls.Add(this.lblStat4v);
            this.grpStats.Controls.Add(this.lblStat3v);
            this.grpStats.Controls.Add(this.lblStat2v);
            this.grpStats.Controls.Add(this.lblStat1v);
            this.grpStats.Controls.Add(this.lblStat5k);
            this.grpStats.Controls.Add(this.lblStat4k);
            this.grpStats.Controls.Add(this.lblStat3k);
            this.grpStats.Controls.Add(this.lblStat2k);
            this.grpStats.Controls.Add(this.lblStat1k);
            this.grpStats.Location = new System.Drawing.Point(490, 20);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(150, 125);
            this.grpStats.TabIndex = 43;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Stats";
            // 
            // lblStat5v
            // 
            this.lblStat5v.Location = new System.Drawing.Point(99, 96);
            this.lblStat5v.Name = "lblStat5v";
            this.lblStat5v.Size = new System.Drawing.Size(43, 20);
            this.lblStat5v.TabIndex = 44;
            this.lblStat5v.Text = "Stat 5v";
            this.lblStat5v.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat4v
            // 
            this.lblStat4v.Location = new System.Drawing.Point(99, 76);
            this.lblStat4v.Name = "lblStat4v";
            this.lblStat4v.Size = new System.Drawing.Size(43, 20);
            this.lblStat4v.TabIndex = 44;
            this.lblStat4v.Text = "Stat 4v";
            this.lblStat4v.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat3v
            // 
            this.lblStat3v.Location = new System.Drawing.Point(99, 56);
            this.lblStat3v.Name = "lblStat3v";
            this.lblStat3v.Size = new System.Drawing.Size(43, 20);
            this.lblStat3v.TabIndex = 44;
            this.lblStat3v.Text = "Stat 3v";
            this.lblStat3v.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat2v
            // 
            this.lblStat2v.Location = new System.Drawing.Point(99, 36);
            this.lblStat2v.Name = "lblStat2v";
            this.lblStat2v.Size = new System.Drawing.Size(43, 20);
            this.lblStat2v.TabIndex = 44;
            this.lblStat2v.Text = "Stat 2v";
            this.lblStat2v.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat1v
            // 
            this.lblStat1v.Location = new System.Drawing.Point(99, 16);
            this.lblStat1v.Name = "lblStat1v";
            this.lblStat1v.Size = new System.Drawing.Size(43, 20);
            this.lblStat1v.TabIndex = 44;
            this.lblStat1v.Text = "Stat 1v";
            this.lblStat1v.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat5k
            // 
            this.lblStat5k.Location = new System.Drawing.Point(6, 96);
            this.lblStat5k.Name = "lblStat5k";
            this.lblStat5k.Size = new System.Drawing.Size(87, 20);
            this.lblStat5k.TabIndex = 44;
            this.lblStat5k.Text = "Stat 5k:";
            this.lblStat5k.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat4k
            // 
            this.lblStat4k.Location = new System.Drawing.Point(6, 76);
            this.lblStat4k.Name = "lblStat4k";
            this.lblStat4k.Size = new System.Drawing.Size(87, 20);
            this.lblStat4k.TabIndex = 44;
            this.lblStat4k.Text = "Stat 4k:";
            this.lblStat4k.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat3k
            // 
            this.lblStat3k.Location = new System.Drawing.Point(6, 56);
            this.lblStat3k.Name = "lblStat3k";
            this.lblStat3k.Size = new System.Drawing.Size(87, 20);
            this.lblStat3k.TabIndex = 44;
            this.lblStat3k.Text = "Stat 3k:";
            this.lblStat3k.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat2k
            // 
            this.lblStat2k.Location = new System.Drawing.Point(6, 36);
            this.lblStat2k.Name = "lblStat2k";
            this.lblStat2k.Size = new System.Drawing.Size(87, 20);
            this.lblStat2k.TabIndex = 44;
            this.lblStat2k.Text = "Stat 2k:";
            this.lblStat2k.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat1k
            // 
            this.lblStat1k.Location = new System.Drawing.Point(6, 16);
            this.lblStat1k.Name = "lblStat1k";
            this.lblStat1k.Size = new System.Drawing.Size(87, 20);
            this.lblStat1k.TabIndex = 44;
            this.lblStat1k.Text = "Stat 1k:";
            this.lblStat1k.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpRandom
            // 
            this.grpRandom.Controls.Add(this.lblRandomDensity);
            this.grpRandom.Controls.Add(this.lblRandomCover);
            this.grpRandom.Controls.Add(this.lblRandomAmp);
            this.grpRandom.Controls.Add(this.nudRandomDensity);
            this.grpRandom.Controls.Add(this.nudRandomCover);
            this.grpRandom.Controls.Add(this.nudRandomAmp);
            this.grpRandom.Controls.Add(this.lblRandomOct);
            this.grpRandom.Controls.Add(this.nudRandomOct);
            this.grpRandom.Controls.Add(this.lblRandomPers);
            this.grpRandom.Controls.Add(this.nudRandomPers);
            this.grpRandom.Controls.Add(this.lblRandomFreq);
            this.grpRandom.Controls.Add(this.nudRandomFreq);
            this.grpRandom.Controls.Add(this.btnRandom);
            this.grpRandom.Location = new System.Drawing.Point(490, 151);
            this.grpRandom.Name = "grpRandom";
            this.grpRandom.Size = new System.Drawing.Size(150, 206);
            this.grpRandom.TabIndex = 44;
            this.grpRandom.TabStop = false;
            this.grpRandom.Text = "Random Heightmap";
            this.grpRandom.Visible = false;
            // 
            // lblRandomDensity
            // 
            this.lblRandomDensity.Location = new System.Drawing.Point(6, 149);
            this.lblRandomDensity.Name = "lblRandomDensity";
            this.lblRandomDensity.Size = new System.Drawing.Size(70, 20);
            this.lblRandomDensity.TabIndex = 44;
            this.lblRandomDensity.Text = "Density";
            this.lblRandomDensity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRandomCover
            // 
            this.lblRandomCover.Location = new System.Drawing.Point(6, 123);
            this.lblRandomCover.Name = "lblRandomCover";
            this.lblRandomCover.Size = new System.Drawing.Size(70, 20);
            this.lblRandomCover.TabIndex = 44;
            this.lblRandomCover.Text = "Coverage";
            this.lblRandomCover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRandomAmp
            // 
            this.lblRandomAmp.Location = new System.Drawing.Point(6, 97);
            this.lblRandomAmp.Name = "lblRandomAmp";
            this.lblRandomAmp.Size = new System.Drawing.Size(70, 20);
            this.lblRandomAmp.TabIndex = 44;
            this.lblRandomAmp.Text = "Amplitude";
            this.lblRandomAmp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudRandomDensity
            // 
            this.nudRandomDensity.DecimalPlaces = 2;
            this.nudRandomDensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRandomDensity.Location = new System.Drawing.Point(82, 149);
            this.nudRandomDensity.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRandomDensity.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.nudRandomDensity.Name = "nudRandomDensity";
            this.nudRandomDensity.Size = new System.Drawing.Size(56, 20);
            this.nudRandomDensity.TabIndex = 43;
            this.nudRandomDensity.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // nudRandomCover
            // 
            this.nudRandomCover.DecimalPlaces = 2;
            this.nudRandomCover.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRandomCover.Location = new System.Drawing.Point(82, 123);
            this.nudRandomCover.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRandomCover.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.nudRandomCover.Name = "nudRandomCover";
            this.nudRandomCover.Size = new System.Drawing.Size(56, 20);
            this.nudRandomCover.TabIndex = 43;
            this.nudRandomCover.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // nudRandomAmp
            // 
            this.nudRandomAmp.DecimalPlaces = 2;
            this.nudRandomAmp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRandomAmp.Location = new System.Drawing.Point(82, 97);
            this.nudRandomAmp.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRandomAmp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRandomAmp.Name = "nudRandomAmp";
            this.nudRandomAmp.Size = new System.Drawing.Size(56, 20);
            this.nudRandomAmp.TabIndex = 43;
            this.nudRandomAmp.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // lblRandomOct
            // 
            this.lblRandomOct.Location = new System.Drawing.Point(6, 71);
            this.lblRandomOct.Name = "lblRandomOct";
            this.lblRandomOct.Size = new System.Drawing.Size(70, 20);
            this.lblRandomOct.TabIndex = 44;
            this.lblRandomOct.Text = "Octaves";
            this.lblRandomOct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudRandomOct
            // 
            this.nudRandomOct.Location = new System.Drawing.Point(82, 71);
            this.nudRandomOct.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudRandomOct.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRandomOct.Name = "nudRandomOct";
            this.nudRandomOct.Size = new System.Drawing.Size(56, 20);
            this.nudRandomOct.TabIndex = 43;
            this.nudRandomOct.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblRandomPers
            // 
            this.lblRandomPers.Location = new System.Drawing.Point(6, 45);
            this.lblRandomPers.Name = "lblRandomPers";
            this.lblRandomPers.Size = new System.Drawing.Size(70, 20);
            this.lblRandomPers.TabIndex = 44;
            this.lblRandomPers.Text = "Persistance";
            this.lblRandomPers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudRandomPers
            // 
            this.nudRandomPers.DecimalPlaces = 2;
            this.nudRandomPers.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRandomPers.Location = new System.Drawing.Point(82, 45);
            this.nudRandomPers.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRandomPers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRandomPers.Name = "nudRandomPers";
            this.nudRandomPers.Size = new System.Drawing.Size(56, 20);
            this.nudRandomPers.TabIndex = 43;
            this.nudRandomPers.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // lblRandomFreq
            // 
            this.lblRandomFreq.Location = new System.Drawing.Point(6, 19);
            this.lblRandomFreq.Name = "lblRandomFreq";
            this.lblRandomFreq.Size = new System.Drawing.Size(70, 20);
            this.lblRandomFreq.TabIndex = 44;
            this.lblRandomFreq.Text = "Frequency";
            this.lblRandomFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudRandomFreq
            // 
            this.nudRandomFreq.DecimalPlaces = 3;
            this.nudRandomFreq.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudRandomFreq.Location = new System.Drawing.Point(82, 19);
            this.nudRandomFreq.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudRandomFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudRandomFreq.Name = "nudRandomFreq";
            this.nudRandomFreq.Size = new System.Drawing.Size(56, 20);
            this.nudRandomFreq.TabIndex = 43;
            this.nudRandomFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(132, 23);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(28, 20);
            this.lblFile.TabIndex = 46;
            this.lblFile.Text = "File";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFile.Visible = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(166, 23);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(237, 20);
            this.txtFile.TabIndex = 45;
            this.txtFile.Text = "Click Browse to find a file to convert...";
            this.txtFile.Visible = false;
            // 
            // lblFormula
            // 
            this.lblFormula.Location = new System.Drawing.Point(127, 121);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(51, 20);
            this.lblFormula.TabIndex = 28;
            this.lblFormula.Text = "Formula";
            this.lblFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormula.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(409, 22);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnBrowse.TabIndex = 48;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
            // 
            // grpFormulaVars
            // 
            this.grpFormulaVars.Controls.Add(this.lblFormulaVar3);
            this.grpFormulaVars.Controls.Add(this.lblFormulaVar1);
            this.grpFormulaVars.Location = new System.Drawing.Point(490, 151);
            this.grpFormulaVars.Name = "grpFormulaVars";
            this.grpFormulaVars.Size = new System.Drawing.Size(150, 206);
            this.grpFormulaVars.TabIndex = 49;
            this.grpFormulaVars.TabStop = false;
            this.grpFormulaVars.Text = "Formula Variables";
            this.grpFormulaVars.Visible = false;
            // 
            // lblFormulaVar3
            // 
            this.lblFormulaVar3.Location = new System.Drawing.Point(49, 16);
            this.lblFormulaVar3.Name = "lblFormulaVar3";
            this.lblFormulaVar3.Size = new System.Drawing.Size(95, 187);
            this.lblFormulaVar3.TabIndex = 0;
            this.lblFormulaVar3.Text = "Grid position in the said direction\r\n\r\nDistance from zero in said direction\r\n\r\nDi" +
    "stance from the center\r\n\r\nPower of disp\r\n\r\n2^power";
            // 
            // lblFormulaVar1
            // 
            this.lblFormulaVar1.Location = new System.Drawing.Point(6, 16);
            this.lblFormulaVar1.Name = "lblFormulaVar1";
            this.lblFormulaVar1.Size = new System.Drawing.Size(37, 187);
            this.lblFormulaVar1.TabIndex = 0;
            this.lblFormulaVar1.Text = "xval\r\nyval\r\n\r\nxdist\r\nydist\r\n\r\nradius\r\n\r\n\r\npower\r\n\r\nres";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(375, 306);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(109, 23);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreviewClick);
            // 
            // chkOption2
            // 
            this.chkOption2.Location = new System.Drawing.Point(142, 126);
            this.chkOption2.Name = "chkOption2";
            this.chkOption2.Size = new System.Drawing.Size(147, 24);
            this.chkOption2.TabIndex = 36;
            this.chkOption2.Text = "Option 2";
            this.chkOption2.UseVisualStyleBackColor = true;
            this.chkOption2.Visible = false;
            // 
            // chkOption3
            // 
            this.chkOption3.Location = new System.Drawing.Point(295, 44);
            this.chkOption3.Name = "chkOption3";
            this.chkOption3.Size = new System.Drawing.Size(74, 24);
            this.chkOption3.TabIndex = 36;
            this.chkOption3.Text = "Option 3";
            this.chkOption3.UseVisualStyleBackColor = true;
            this.chkOption3.Visible = false;
            this.chkOption3.CheckedChanged += new System.EventHandler(this.ChkOption3CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 394);
            this.Controls.Add(this.btnLoadHeightmap);
            this.Controls.Add(this.grpRandom);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.nudDispRes);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.grpStats);
            this.Controls.Add(this.lblHeightmapWait);
            this.Controls.Add(this.picHeightmap);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.nudDistVal);
            this.Controls.Add(this.lblDistVal);
            this.Controls.Add(this.grpFileType);
            this.Controls.Add(this.nudAngle2);
            this.Controls.Add(this.grpChoose);
            this.Controls.Add(this.nudAngle1);
            this.Controls.Add(this.updatestatus);
            this.Controls.Add(this.nudPower);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.lblAngle2);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.lblAngle1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.grpTwistmode);
            this.Controls.Add(this.pgsHeightmap);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.grpFormulaVars);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.chkOption3);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.chkOption1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblDispRes);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.chkOption2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(655, 433);
            this.MinimumSize = new System.Drawing.Size(655, 433);
            this.Name = "MainForm";
            this.Text = "Twister 5";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.grpChoose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle2)).EndInit();
            this.grpTwistmode.ResumeLayout(false);
            this.grpTwistmode.PerformLayout();
            this.grpFileType.ResumeLayout(false);
            this.grpFileType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDispRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeightmap)).EndInit();
            this.grpStats.ResumeLayout(false);
            this.grpRandom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomOct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomFreq)).EndInit();
            this.grpFormulaVars.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.CheckBox chkOption3;
		private System.Windows.Forms.CheckBox chkOption2;
		internal System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.Label lblFormulaVar1;
		private System.Windows.Forms.Label lblFormulaVar3;
		private System.Windows.Forms.GroupBox grpFormulaVars;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label lblStat1k;
		private System.Windows.Forms.Label lblStat2k;
		private System.Windows.Forms.Label lblStat3k;
		private System.Windows.Forms.Label lblStat4k;
		private System.Windows.Forms.Label lblStat5k;
		private System.Windows.Forms.Label lblStat1v;
		private System.Windows.Forms.Label lblStat2v;
		private System.Windows.Forms.Label lblStat3v;
		private System.Windows.Forms.Label lblStat4v;
		private System.Windows.Forms.Label lblStat5v;
		private System.Windows.Forms.Label lblFormula;
		private System.Windows.Forms.TextBox txtFormula;
		private System.Windows.Forms.RadioButton radFormula;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.NumericUpDown nudRandomCover;
		private System.Windows.Forms.NumericUpDown nudRandomDensity;
		private System.Windows.Forms.Label lblRandomCover;
		private System.Windows.Forms.Label lblRandomDensity;
		private System.Windows.Forms.NumericUpDown nudRandomFreq;
		private System.Windows.Forms.Label lblRandomFreq;
		private System.Windows.Forms.NumericUpDown nudRandomPers;
		private System.Windows.Forms.Label lblRandomPers;
		private System.Windows.Forms.NumericUpDown nudRandomOct;
		private System.Windows.Forms.Label lblRandomOct;
		private System.Windows.Forms.NumericUpDown nudRandomAmp;
		private System.Windows.Forms.Label lblRandomAmp;
		private System.Windows.Forms.GroupBox grpRandom;
		private System.Windows.Forms.GroupBox grpStats;
		private System.Windows.Forms.Button btnRandom;
		private System.Windows.Forms.RadioButton radConvert;
		private System.Windows.Forms.Label lblHeightmapWait;
		public System.Windows.Forms.ProgressBar pgsHeightmap;
		private System.Windows.Forms.Button btnLoadHeightmap;
		private System.Windows.Forms.PictureBox picHeightmap;
		internal System.Windows.Forms.RadioButton radGoldsourceType;
		private System.Windows.Forms.RadioButton radSphere;
		private System.Windows.Forms.Button btnGo;
		internal System.Windows.Forms.Label lblAngle1;
		internal System.Windows.Forms.Label lblAngle2;
		internal System.Windows.Forms.NumericUpDown nudAngle1;
		internal System.Windows.Forms.NumericUpDown nudAngle2;
		internal System.Windows.Forms.Label lblDistVal;
		internal System.Windows.Forms.NumericUpDown nudDistVal;
		internal System.Windows.Forms.Label lblDispRes;
		internal System.Windows.Forms.NumericUpDown nudDispRes;
		private System.Windows.Forms.GroupBox grpChoose;
		private System.Windows.Forms.CheckBox chkOption1;
		private System.Windows.Forms.Label lblRadius;
		private System.Windows.Forms.TextBox txtRadius;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.TextBox txtHeight;
		internal System.Windows.Forms.RadioButton radDispType;
		internal System.Windows.Forms.RadioButton radBrushType;
		internal System.Windows.Forms.GroupBox grpFileType;
		internal System.Windows.Forms.RadioButton radSmooth;
		internal System.Windows.Forms.RadioButton radHallway;
		internal System.Windows.Forms.GroupBox grpTwistmode;
		internal System.Windows.Forms.NumericUpDown nudPower;
		internal System.Windows.Forms.Label lblPower;
		private System.Windows.Forms.Label lblLength;
		private System.Windows.Forms.TextBox txtLength;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.RadioButton radTwist;
		private System.Windows.Forms.RadioButton radCurve;
		private System.Windows.Forms.RadioButton radCorner;
		private System.Windows.Forms.RadioButton radCircle;
		private System.Windows.Forms.RadioButton radCone;
		private System.Windows.Forms.RadioButton radDome;
		private System.Windows.Forms.RadioButton radNoise;
		private System.Windows.Forms.RadioButton radHeightmap;
		internal System.Windows.Forms.OpenFileDialog loadheightmap;
		internal System.Windows.Forms.Button BtnAbout;
		internal System.Windows.Forms.Label Status;
		internal System.Windows.Forms.Button btnupdate;
		internal System.Windows.Forms.SaveFileDialog save;
		internal System.Windows.Forms.Timer uptime;
		internal System.Windows.Forms.Label updatestatus;
	}
}
