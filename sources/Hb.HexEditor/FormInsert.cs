using System;
using System.Windows.Forms;

namespace Hb.HexEditor2
{
	/// <summary>
	/// Summary description for FormInsert.
	/// </summary>
	public class FormInsert : Core.FormEx
	{
		private Label byteCountLbl;
		private Button btnCancel;
		private Button btnOK;
		private Label fillPatternLbl;
		private Panel line;
		private FlowLayoutPanel flowLayoutPanel1;
		private RadioButton OctalRadio;
		private RadioButton decimalRadio;
		private RadioButton hexRadio;
		private TextBox fillPatternTxt;
		private TextBox numericTxt;
		private Panel panel1;
		private RadioButton fillTextRadio;
		private RadioButton fillHexRadio;
		private Label fillText;
		private Label insertText;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormInsert()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsert));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.line = new System.Windows.Forms.Panel();
			this.OctalRadio = new System.Windows.Forms.RadioButton();
			this.decimalRadio = new System.Windows.Forms.RadioButton();
			this.hexRadio = new System.Windows.Forms.RadioButton();
			this.fillPatternLbl = new System.Windows.Forms.Label();
			this.byteCountLbl = new System.Windows.Forms.Label();
			this.fillPatternTxt = new System.Windows.Forms.TextBox();
			this.numericTxt = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.fillTextRadio = new System.Windows.Forms.RadioButton();
			this.fillHexRadio = new System.Windows.Forms.RadioButton();
			this.fillText = new System.Windows.Forms.Label();
			this.insertText = new System.Windows.Forms.Label();
			this.flowLayoutPanel1.SuspendLayout();
			this.line.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Controls.Add(this.btnOK);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Name = "btnOK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// line
			// 
			resources.ApplyResources(this.line, "line");
			this.line.BackColor = System.Drawing.Color.LightGray;
			this.line.Controls.Add(this.OctalRadio);
			this.line.Controls.Add(this.decimalRadio);
			this.line.Controls.Add(this.hexRadio);
			this.line.Name = "line";
			// 
			// OctalRadio
			// 
			resources.ApplyResources(this.OctalRadio, "OctalRadio");
			this.OctalRadio.Name = "OctalRadio";
			this.OctalRadio.UseVisualStyleBackColor = true;
			// 
			// decimalRadio
			// 
			resources.ApplyResources(this.decimalRadio, "decimalRadio");
			this.decimalRadio.Name = "decimalRadio";
			this.decimalRadio.UseVisualStyleBackColor = true;
			// 
			// hexRadio
			// 
			resources.ApplyResources(this.hexRadio, "hexRadio");
			this.hexRadio.Checked = true;
			this.hexRadio.Name = "hexRadio";
			this.hexRadio.TabStop = true;
			this.hexRadio.UseVisualStyleBackColor = true;
			// 
			// fillPatternLbl
			// 
			resources.ApplyResources(this.fillPatternLbl, "fillPatternLbl");
			this.fillPatternLbl.Name = "fillPatternLbl";
			// 
			// byteCountLbl
			// 
			resources.ApplyResources(this.byteCountLbl, "byteCountLbl");
			this.byteCountLbl.Name = "byteCountLbl";
			// 
			// fillPatternTxt
			// 
			resources.ApplyResources(this.fillPatternTxt, "fillPatternTxt");
			this.fillPatternTxt.Name = "fillPatternTxt";
			// 
			// numericTxt
			// 
			resources.ApplyResources(this.numericTxt, "numericTxt");
			this.numericTxt.Name = "numericTxt";
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.Color.LightGray;
			this.panel1.Controls.Add(this.fillTextRadio);
			this.panel1.Controls.Add(this.fillHexRadio);
			this.panel1.Name = "panel1";
			// 
			// fillTextRadio
			// 
			resources.ApplyResources(this.fillTextRadio, "fillTextRadio");
			this.fillTextRadio.Name = "fillTextRadio";
			this.fillTextRadio.UseVisualStyleBackColor = true;
			// 
			// fillHexRadio
			// 
			resources.ApplyResources(this.fillHexRadio, "fillHexRadio");
			this.fillHexRadio.Checked = true;
			this.fillHexRadio.Name = "fillHexRadio";
			this.fillHexRadio.TabStop = true;
			this.fillHexRadio.UseVisualStyleBackColor = true;
			// 
			// fillText
			// 
			resources.ApplyResources(this.fillText, "fillText");
			this.fillText.Name = "fillText";
			// 
			// insertText
			// 
			resources.ApplyResources(this.insertText, "insertText");
			this.insertText.Name = "insertText";
			// 
			// FormInsert
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.insertText);
			this.Controls.Add(this.fillText);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.numericTxt);
			this.Controls.Add(this.fillPatternTxt);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.line);
			this.Controls.Add(this.fillPatternLbl);
			this.Controls.Add(this.byteCountLbl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormInsert";
			this.ShowInTaskbar = false;
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.line.ResumeLayout(false);
			this.line.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public long GetByteCount()
		{
			string tx = numericTxt.Text;
			long myLong=1;
			bool isNumerical = long.TryParse(tx, out myLong);
			if (OctalRadio.Checked&&isNumerical)
				{
					try { myLong = Convert.ToInt64(tx, 8); }
					catch (Exception) { myLong = 1; }
				}
			if (hexRadio.Checked)
			{
				try { myLong = Convert.ToInt64(tx, 16); }
				catch (Exception) { myLong = 1; }
			}
				return myLong;
		}

		public string GetFillPattern()
		{
			return fillPatternTxt.Text;
		}

		public int GetFillRadio()
		{
			int cc=0;
			if (fillTextRadio.Checked) cc = 1;
			return cc;
		}

		public void SetWhoCalled(int ide)
		{
			if (ide == 0)
				Text = insertText.Text;
			if (ide == 1)
				Text = fillText.Text;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
