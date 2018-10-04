namespace Hb.HexEditor2
{
    partial class FormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.generalTabPage = new System.Windows.Forms.TabPage();
			this.languageSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.selectLanguageLabel = new System.Windows.Forms.Label();
			this.languageComboBox = new System.Windows.Forms.ComboBox();
			this.useSystemLanguageCheckBox = new System.Windows.Forms.CheckBox();
			this.recentFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.clearRecentFilesButton = new System.Windows.Forms.Button();
			this.recentFilesMaxlabel = new System.Windows.Forms.Label();
			this.recentFilesMaxTextBox = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ReadOnlyChk = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.BorderStylelabel = new System.Windows.Forms.Label();
			this.LineInfoOffsetlabel = new System.Windows.Forms.Label();
			this.LineInfoOffsetUpDown = new System.Windows.Forms.NumericUpDown();
			this.GroupSizelabel = new System.Windows.Forms.Label();
			this.GroupSizeUpDown = new System.Windows.Forms.NumericUpDown();
			this.BytesPerLinelabel = new System.Windows.Forms.Label();
			this.BytesPerLineUpDown = new System.Windows.Forms.NumericUpDown();
			this.UseFixedBytesPerLinechk = new System.Windows.Forms.CheckBox();
			this.HexCasingchk = new System.Windows.Forms.CheckBox();
			this.BorderStyleCmb = new System.Windows.Forms.ComboBox();
			this.Visiblegrp = new System.Windows.Forms.GroupBox();
			this.ShadowSelectionVisiblechk = new System.Windows.Forms.CheckBox();
			this.LineInfoVisiblechk = new System.Windows.Forms.CheckBox();
			this.vScrollBarVisiblechk = new System.Windows.Forms.CheckBox();
			this.ColumnInfoVisiblechk = new System.Windows.Forms.CheckBox();
			this.StringViewVisiblechk = new System.Windows.Forms.CheckBox();
			this.GroupSeparatorVisiblechk = new System.Windows.Forms.CheckBox();
			this.Enabledchk = new System.Windows.Forms.CheckBox();
			this.ColorgroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TransparencyUpDown = new System.Windows.Forms.NumericUpDown();
			this.CmbboxColorFor = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CmbboxForeClr = new System.Windows.Forms.ComboBox();
			this.CmbboxBackClr = new System.Windows.Forms.ComboBox();
			this.hexBoxSample = new Hb.Windows.Forms.HexBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.tabControl.SuspendLayout();
			this.generalTabPage.SuspendLayout();
			this.languageSettingsGroupBox.SuspendLayout();
			this.recentFilesGroupBox.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LineInfoOffsetUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupSizeUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BytesPerLineUpDown)).BeginInit();
			this.Visiblegrp.SuspendLayout();
			this.ColorgroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TransparencyUpDown)).BeginInit();
			this.flowLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			resources.ApplyResources(this.tabControl, "tabControl");
			this.tabControl.Controls.Add(this.generalTabPage);
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			// 
			// generalTabPage
			// 
			this.generalTabPage.Controls.Add(this.languageSettingsGroupBox);
			this.generalTabPage.Controls.Add(this.recentFilesGroupBox);
			resources.ApplyResources(this.generalTabPage, "generalTabPage");
			this.generalTabPage.Name = "generalTabPage";
			this.generalTabPage.UseVisualStyleBackColor = true;
			// 
			// languageSettingsGroupBox
			// 
			resources.ApplyResources(this.languageSettingsGroupBox, "languageSettingsGroupBox");
			this.languageSettingsGroupBox.Controls.Add(this.selectLanguageLabel);
			this.languageSettingsGroupBox.Controls.Add(this.languageComboBox);
			this.languageSettingsGroupBox.Controls.Add(this.useSystemLanguageCheckBox);
			this.languageSettingsGroupBox.Name = "languageSettingsGroupBox";
			this.languageSettingsGroupBox.TabStop = false;
			// 
			// selectLanguageLabel
			// 
			resources.ApplyResources(this.selectLanguageLabel, "selectLanguageLabel");
			this.selectLanguageLabel.Name = "selectLanguageLabel";
			// 
			// languageComboBox
			// 
			this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.languageComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.languageComboBox, "languageComboBox");
			this.languageComboBox.Name = "languageComboBox";
			// 
			// useSystemLanguageCheckBox
			// 
			resources.ApplyResources(this.useSystemLanguageCheckBox, "useSystemLanguageCheckBox");
			this.useSystemLanguageCheckBox.Name = "useSystemLanguageCheckBox";
			this.useSystemLanguageCheckBox.UseVisualStyleBackColor = true;
			this.useSystemLanguageCheckBox.CheckedChanged += new System.EventHandler(this.useSystemLanguageCheckBox_CheckedChanged);
			// 
			// recentFilesGroupBox
			// 
			resources.ApplyResources(this.recentFilesGroupBox, "recentFilesGroupBox");
			this.recentFilesGroupBox.Controls.Add(this.clearRecentFilesButton);
			this.recentFilesGroupBox.Controls.Add(this.recentFilesMaxlabel);
			this.recentFilesGroupBox.Controls.Add(this.recentFilesMaxTextBox);
			this.recentFilesGroupBox.Name = "recentFilesGroupBox";
			this.recentFilesGroupBox.TabStop = false;
			// 
			// clearRecentFilesButton
			// 
			resources.ApplyResources(this.clearRecentFilesButton, "clearRecentFilesButton");
			this.clearRecentFilesButton.Name = "clearRecentFilesButton";
			this.clearRecentFilesButton.UseVisualStyleBackColor = true;
			this.clearRecentFilesButton.Click += new System.EventHandler(this.clearRecentFilesButton_Click);
			// 
			// recentFilesMaxlabel
			// 
			resources.ApplyResources(this.recentFilesMaxlabel, "recentFilesMaxlabel");
			this.recentFilesMaxlabel.Name = "recentFilesMaxlabel";
			// 
			// recentFilesMaxTextBox
			// 
			resources.ApplyResources(this.recentFilesMaxTextBox, "recentFilesMaxTextBox");
			this.recentFilesMaxTextBox.Name = "recentFilesMaxTextBox";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ReadOnlyChk);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.BorderStylelabel);
			this.tabPage1.Controls.Add(this.LineInfoOffsetlabel);
			this.tabPage1.Controls.Add(this.LineInfoOffsetUpDown);
			this.tabPage1.Controls.Add(this.GroupSizelabel);
			this.tabPage1.Controls.Add(this.GroupSizeUpDown);
			this.tabPage1.Controls.Add(this.BytesPerLinelabel);
			this.tabPage1.Controls.Add(this.BytesPerLineUpDown);
			this.tabPage1.Controls.Add(this.UseFixedBytesPerLinechk);
			this.tabPage1.Controls.Add(this.HexCasingchk);
			this.tabPage1.Controls.Add(this.BorderStyleCmb);
			this.tabPage1.Controls.Add(this.Visiblegrp);
			this.tabPage1.Controls.Add(this.Enabledchk);
			this.tabPage1.Controls.Add(this.ColorgroupBox);
			this.tabPage1.Controls.Add(this.hexBoxSample);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// ReadOnlyChk
			// 
			resources.ApplyResources(this.ReadOnlyChk, "ReadOnlyChk");
			this.ReadOnlyChk.Name = "ReadOnlyChk";
			this.ReadOnlyChk.UseVisualStyleBackColor = true;
			this.ReadOnlyChk.CheckedChanged += new System.EventHandler(this.ReadOnlyChk_CheckedChanged);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// BorderStylelabel
			// 
			resources.ApplyResources(this.BorderStylelabel, "BorderStylelabel");
			this.BorderStylelabel.Name = "BorderStylelabel";
			// 
			// LineInfoOffsetlabel
			// 
			resources.ApplyResources(this.LineInfoOffsetlabel, "LineInfoOffsetlabel");
			this.LineInfoOffsetlabel.Name = "LineInfoOffsetlabel";
			// 
			// LineInfoOffsetUpDown
			// 
			resources.ApplyResources(this.LineInfoOffsetUpDown, "LineInfoOffsetUpDown");
			this.LineInfoOffsetUpDown.Maximum = new decimal(new int[] {
            16000000,
            0,
            0,
            0});
			this.LineInfoOffsetUpDown.Name = "LineInfoOffsetUpDown";
			this.LineInfoOffsetUpDown.ValueChanged += new System.EventHandler(this.LineInfoOffsetUpDown_ValueChanged);
			// 
			// GroupSizelabel
			// 
			resources.ApplyResources(this.GroupSizelabel, "GroupSizelabel");
			this.GroupSizelabel.Name = "GroupSizelabel";
			// 
			// GroupSizeUpDown
			// 
			resources.ApplyResources(this.GroupSizeUpDown, "GroupSizeUpDown");
			this.GroupSizeUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.GroupSizeUpDown.Name = "GroupSizeUpDown";
			this.GroupSizeUpDown.ValueChanged += new System.EventHandler(this.GroupSizeUpDown_ValueChanged);
			// 
			// BytesPerLinelabel
			// 
			resources.ApplyResources(this.BytesPerLinelabel, "BytesPerLinelabel");
			this.BytesPerLinelabel.Name = "BytesPerLinelabel";
			// 
			// BytesPerLineUpDown
			// 
			resources.ApplyResources(this.BytesPerLineUpDown, "BytesPerLineUpDown");
			this.BytesPerLineUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.BytesPerLineUpDown.Name = "BytesPerLineUpDown";
			this.BytesPerLineUpDown.ValueChanged += new System.EventHandler(this.BytesPerLineUpDown_ValueChanged);
			// 
			// UseFixedBytesPerLinechk
			// 
			resources.ApplyResources(this.UseFixedBytesPerLinechk, "UseFixedBytesPerLinechk");
			this.UseFixedBytesPerLinechk.Name = "UseFixedBytesPerLinechk";
			this.UseFixedBytesPerLinechk.UseVisualStyleBackColor = true;
			this.UseFixedBytesPerLinechk.CheckedChanged += new System.EventHandler(this.UseFixedBytesPerLinechk_CheckedChanged);
			// 
			// HexCasingchk
			// 
			resources.ApplyResources(this.HexCasingchk, "HexCasingchk");
			this.HexCasingchk.Name = "HexCasingchk";
			this.HexCasingchk.UseVisualStyleBackColor = true;
			this.HexCasingchk.CheckedChanged += new System.EventHandler(this.HexCasingchk_CheckedChanged);
			// 
			// BorderStyleCmb
			// 
			this.BorderStyleCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BorderStyleCmb.FormattingEnabled = true;
			this.BorderStyleCmb.Items.AddRange(new object[] {
            resources.GetString("BorderStyleCmb.Items"),
            resources.GetString("BorderStyleCmb.Items1"),
            resources.GetString("BorderStyleCmb.Items2")});
			resources.ApplyResources(this.BorderStyleCmb, "BorderStyleCmb");
			this.BorderStyleCmb.Name = "BorderStyleCmb";
			this.BorderStyleCmb.SelectedIndexChanged += new System.EventHandler(this.BorderStyleCmb_SelectedIndexChanged);
			// 
			// Visiblegrp
			// 
			this.Visiblegrp.Controls.Add(this.ShadowSelectionVisiblechk);
			this.Visiblegrp.Controls.Add(this.LineInfoVisiblechk);
			this.Visiblegrp.Controls.Add(this.vScrollBarVisiblechk);
			this.Visiblegrp.Controls.Add(this.ColumnInfoVisiblechk);
			this.Visiblegrp.Controls.Add(this.StringViewVisiblechk);
			this.Visiblegrp.Controls.Add(this.GroupSeparatorVisiblechk);
			resources.ApplyResources(this.Visiblegrp, "Visiblegrp");
			this.Visiblegrp.Name = "Visiblegrp";
			this.Visiblegrp.TabStop = false;
			// 
			// ShadowSelectionVisiblechk
			// 
			resources.ApplyResources(this.ShadowSelectionVisiblechk, "ShadowSelectionVisiblechk");
			this.ShadowSelectionVisiblechk.Name = "ShadowSelectionVisiblechk";
			this.ShadowSelectionVisiblechk.UseVisualStyleBackColor = true;
			this.ShadowSelectionVisiblechk.CheckedChanged += new System.EventHandler(this.ShadowSelectionVisiblechk_CheckedChanged);
			// 
			// LineInfoVisiblechk
			// 
			resources.ApplyResources(this.LineInfoVisiblechk, "LineInfoVisiblechk");
			this.LineInfoVisiblechk.Name = "LineInfoVisiblechk";
			this.LineInfoVisiblechk.UseVisualStyleBackColor = true;
			this.LineInfoVisiblechk.CheckedChanged += new System.EventHandler(this.LineInfoVisiblechk_CheckedChanged);
			// 
			// vScrollBarVisiblechk
			// 
			resources.ApplyResources(this.vScrollBarVisiblechk, "vScrollBarVisiblechk");
			this.vScrollBarVisiblechk.Name = "vScrollBarVisiblechk";
			this.vScrollBarVisiblechk.UseVisualStyleBackColor = true;
			this.vScrollBarVisiblechk.CheckedChanged += new System.EventHandler(this.vScrollBarVisiblechk_CheckedChanged);
			// 
			// ColumnInfoVisiblechk
			// 
			resources.ApplyResources(this.ColumnInfoVisiblechk, "ColumnInfoVisiblechk");
			this.ColumnInfoVisiblechk.Name = "ColumnInfoVisiblechk";
			this.ColumnInfoVisiblechk.UseVisualStyleBackColor = true;
			this.ColumnInfoVisiblechk.CheckedChanged += new System.EventHandler(this.ColumnInfoVisiblechk_CheckedChanged);
			// 
			// StringViewVisiblechk
			// 
			resources.ApplyResources(this.StringViewVisiblechk, "StringViewVisiblechk");
			this.StringViewVisiblechk.Name = "StringViewVisiblechk";
			this.StringViewVisiblechk.UseVisualStyleBackColor = true;
			this.StringViewVisiblechk.CheckedChanged += new System.EventHandler(this.StringViewVisiblechk_CheckedChanged);
			// 
			// GroupSeparatorVisiblechk
			// 
			resources.ApplyResources(this.GroupSeparatorVisiblechk, "GroupSeparatorVisiblechk");
			this.GroupSeparatorVisiblechk.Name = "GroupSeparatorVisiblechk";
			this.GroupSeparatorVisiblechk.UseVisualStyleBackColor = true;
			this.GroupSeparatorVisiblechk.CheckedChanged += new System.EventHandler(this.GroupSeparatorVisiblechk_CheckedChanged);
			// 
			// Enabledchk
			// 
			resources.ApplyResources(this.Enabledchk, "Enabledchk");
			this.Enabledchk.Name = "Enabledchk";
			this.Enabledchk.UseVisualStyleBackColor = true;
			this.Enabledchk.CheckedChanged += new System.EventHandler(this.Enabledchk_CheckedChanged);
			// 
			// ColorgroupBox
			// 
			this.ColorgroupBox.Controls.Add(this.label3);
			this.ColorgroupBox.Controls.Add(this.TransparencyUpDown);
			this.ColorgroupBox.Controls.Add(this.CmbboxColorFor);
			this.ColorgroupBox.Controls.Add(this.label1);
			this.ColorgroupBox.Controls.Add(this.label2);
			this.ColorgroupBox.Controls.Add(this.CmbboxForeClr);
			this.ColorgroupBox.Controls.Add(this.CmbboxBackClr);
			resources.ApplyResources(this.ColorgroupBox, "ColorgroupBox");
			this.ColorgroupBox.Name = "ColorgroupBox";
			this.ColorgroupBox.TabStop = false;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// TransparencyUpDown
			// 
			resources.ApplyResources(this.TransparencyUpDown, "TransparencyUpDown");
			this.TransparencyUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.TransparencyUpDown.Name = "TransparencyUpDown";
			this.TransparencyUpDown.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			// 
			// CmbboxColorFor
			// 
			this.CmbboxColorFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbboxColorFor.FormattingEnabled = true;
			this.CmbboxColorFor.Items.AddRange(new object[] {
            resources.GetString("CmbboxColorFor.Items"),
            resources.GetString("CmbboxColorFor.Items1"),
            resources.GetString("CmbboxColorFor.Items2"),
            resources.GetString("CmbboxColorFor.Items3"),
            resources.GetString("CmbboxColorFor.Items4"),
            resources.GetString("CmbboxColorFor.Items5")});
			resources.ApplyResources(this.CmbboxColorFor, "CmbboxColorFor");
			this.CmbboxColorFor.Name = "CmbboxColorFor";
			this.CmbboxColorFor.SelectedIndexChanged += new System.EventHandler(this.CmbboxColorFor_SelectedIndexChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// CmbboxForeClr
			// 
			this.CmbboxForeClr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.CmbboxForeClr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbboxForeClr.DropDownWidth = 216;
			this.CmbboxForeClr.FormattingEnabled = true;
			resources.ApplyResources(this.CmbboxForeClr, "CmbboxForeClr");
			this.CmbboxForeClr.Name = "CmbboxForeClr";
			this.CmbboxForeClr.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbboxForeClr_DrawItem);
			this.CmbboxForeClr.SelectedIndexChanged += new System.EventHandler(this.CmbboxForeClr_SelectedIndexChanged);
			// 
			// CmbboxBackClr
			// 
			this.CmbboxBackClr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.CmbboxBackClr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbboxBackClr.DropDownWidth = 216;
			this.CmbboxBackClr.FormattingEnabled = true;
			resources.ApplyResources(this.CmbboxBackClr, "CmbboxBackClr");
			this.CmbboxBackClr.Name = "CmbboxBackClr";
			this.CmbboxBackClr.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbboxForeClr_DrawItem);
			this.CmbboxBackClr.SelectedIndexChanged += new System.EventHandler(this.CmbboxBackClr_SelectedIndexChanged);
			// 
			// hexBoxSample
			// 
			resources.ApplyResources(this.hexBoxSample, "hexBoxSample");
			this.hexBoxSample.ForeColor = System.Drawing.SystemColors.ControlText;
			this.hexBoxSample.HexViewTextColor = System.Drawing.SystemColors.ControlText;
			this.hexBoxSample.Name = "hexBoxSample";
			this.hexBoxSample.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.hexBoxSample.VScrollBarVisible = false;
			// 
			// okButton
			// 
			resources.ApplyResources(this.okButton, "okButton");
			this.okButton.Name = "okButton";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			resources.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// flowLayoutPanel
			// 
			resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
			this.flowLayoutPanel.Controls.Add(this.cancelButton);
			this.flowLayoutPanel.Controls.Add(this.okButton);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			// 
			// FormOptions
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.cancelButton;
			this.ControlBox = false;
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.tabControl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.tabControl.ResumeLayout(false);
			this.generalTabPage.ResumeLayout(false);
			this.languageSettingsGroupBox.ResumeLayout(false);
			this.languageSettingsGroupBox.PerformLayout();
			this.recentFilesGroupBox.ResumeLayout(false);
			this.recentFilesGroupBox.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LineInfoOffsetUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupSizeUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BytesPerLineUpDown)).EndInit();
			this.Visiblegrp.ResumeLayout(false);
			this.Visiblegrp.PerformLayout();
			this.ColorgroupBox.ResumeLayout(false);
			this.ColorgroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TransparencyUpDown)).EndInit();
			this.flowLayoutPanel.ResumeLayout(false);
			this.flowLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox recentFilesGroupBox;
        private System.Windows.Forms.Button clearRecentFilesButton;
        private System.Windows.Forms.Label recentFilesMaxlabel;
        private System.Windows.Forms.TextBox recentFilesMaxTextBox;
        private System.Windows.Forms.GroupBox languageSettingsGroupBox;
        private System.Windows.Forms.Label selectLanguageLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.CheckBox useSystemLanguageCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ComboBox CmbboxForeClr;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox CmbboxBackClr;
		private Windows.Forms.HexBox hexBoxSample;
		private System.Windows.Forms.CheckBox GroupSeparatorVisiblechk;
		private System.Windows.Forms.CheckBox StringViewVisiblechk;
		private System.Windows.Forms.CheckBox ColumnInfoVisiblechk;
		private System.Windows.Forms.CheckBox LineInfoVisiblechk;
		private System.Windows.Forms.GroupBox ColorgroupBox;
		private System.Windows.Forms.CheckBox Enabledchk;
		private System.Windows.Forms.CheckBox vScrollBarVisiblechk;
		private System.Windows.Forms.GroupBox Visiblegrp;
		private System.Windows.Forms.ComboBox BorderStyleCmb;
		private System.Windows.Forms.CheckBox HexCasingchk;
		private System.Windows.Forms.CheckBox UseFixedBytesPerLinechk;
		private System.Windows.Forms.Label BytesPerLinelabel;
		private System.Windows.Forms.NumericUpDown BytesPerLineUpDown;
		private System.Windows.Forms.Label GroupSizelabel;
		private System.Windows.Forms.NumericUpDown GroupSizeUpDown;
		private System.Windows.Forms.Label LineInfoOffsetlabel;
		private System.Windows.Forms.NumericUpDown LineInfoOffsetUpDown;
		private System.Windows.Forms.CheckBox ShadowSelectionVisiblechk;
		private System.Windows.Forms.Label BorderStylelabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ComboBox CmbboxColorFor;
		private System.Windows.Forms.NumericUpDown TransparencyUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox ReadOnlyChk;
	}
}