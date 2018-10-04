using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Hb.HexEditor2.Properties;
using System.Collections;
using System.Reflection;

namespace Hb.HexEditor2
{
	public partial class FormOptions : Core.FormEx
	{
		byte[] testdata = {32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,
		67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100};
		int recentFilesMax;
		bool Initialised = false;
		bool viewChanged = false;
		bool ColorForDo = false;
		public int RecentFilesMax
		{
			get { return recentFilesMax; }
			set
			{
				if (recentFilesMax == value)
					return;
				if (value < 0 || value > RecentFileHandler.MaxRecentFiles)
					return;

				recentFilesMax = value;
			}
		}


		bool useSystemLanguage;

		public bool UseSystemLanguage
		{
			get { return useSystemLanguage; }
			set { useSystemLanguage = value; }
		}

		public FormOptions()
		{
			InitializeComponent();
			Windows.Forms.DynamicByteProvider dBP;
			dBP = new Windows.Forms.DynamicByteProvider(testdata);
			hexBoxSample.ByteProvider = dBP;
			
			this.recentFilesMax = Settings.Default.RecentFilesMax;
			this.recentFilesMaxTextBox.DataBindings.Add("Text", this, "RecentFilesMax");
			this.useSystemLanguage = Settings.Default.UseSystemLanguage;
			this.useSystemLanguageCheckBox.DataBindings.Add("Checked", this, "UseSystemLanguage");

			if (string.IsNullOrEmpty(Settings.Default.SelectedLanguage))
				Settings.Default.SelectedLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
			LoadCmbboxes();
			LoadSettings();
			DataTable dt = new DataTable();
			dt.Columns.Add("Name", typeof(string));
			dt.Columns.Add("Value", typeof(string));
			dt.Rows.Add(strings.English, "en");
			dt.Rows.Add(strings.German, "de");
			dt.Rows.Add(strings.Italian, "it");
			dt.Rows.Add(strings.Japanese, "ja");
			dt.Rows.Add(strings.Russian, "ru");
			dt.Rows.Add(strings.SimplifiedChinese, "zh-CN");
			dt.Rows.Add(strings.Turkish, "tr");
			dt.DefaultView.Sort = "Name";

			this.languageComboBox.DataSource = dt.DefaultView;
			this.languageComboBox.DisplayMember = "Name";
			this.languageComboBox.ValueMember = "Value";
			this.languageComboBox.SelectedValue = Settings.Default.SelectedLanguage;
			if (this.languageComboBox.SelectedIndex == -1)
				this.languageComboBox.SelectedIndex = 0;
		}
/// <summary>
/// Loads sample hexbox to show current settings and manipulates option form controls
/// </summary>
		private void LoadSettings()
		{
			hexBoxSample.Font = Settings.Default.Font;
			hexBoxSample.LineInfoVisible = LineInfoVisiblechk.Checked = Settings.Default.LineInfoVisible;
			hexBoxSample.ColumnInfoVisible = ColumnInfoVisiblechk.Checked = Settings.Default.ColumnInfoVisible;
			hexBoxSample.StringViewVisible = StringViewVisiblechk.Checked = Settings.Default.StringViewVisible;
			hexBoxSample.GroupSeparatorVisible = GroupSeparatorVisiblechk.Checked = Settings.Default.GroupSeparatorVisible;
			hexBoxSample.Enabled = Enabledchk.Checked = Settings.Default.Enabled;
			hexBoxSample.ReadOnly = ReadOnlyChk.Checked = Settings.Default.ReadOnly;
			hexBoxSample.VScrollBarVisible = vScrollBarVisiblechk.Checked = Settings.Default.vScrollBarVisible;
			hexBoxSample.ShadowSelectionVisible = ShadowSelectionVisiblechk.Checked = Settings.Default.ShadowSelectionVisible;
			BorderStyleCmb.SelectedIndex = Settings.Default.BorderStyle;
			hexBoxSample.BorderStyle = (BorderStyle)BorderStyleCmb.SelectedIndex;
			HexCasingchk.Checked = Settings.Default.HexCasing;
			hexBoxSample.HexCasing = (HexCasingchk.Checked) ? Windows.Forms.HexCasing.Upper : Windows.Forms.HexCasing.Lower;
			hexBoxSample.UseFixedBytesPerLine = UseFixedBytesPerLinechk.Checked = Settings.Default.UseFixedBytesPerLine;
			BytesPerLineUpDown.Value = hexBoxSample.BytesPerLine = Settings.Default.BytesPerLine;
			GroupSizeUpDown.Value = hexBoxSample.GroupSize = Settings.Default.GroupSize;
			LineInfoOffsetUpDown.Value = hexBoxSample.LineInfoOffset = Settings.Default.LineInfoOffset;
			hexBoxSample.ShadowSelectionColor = Settings.Default.ShadowSelectionColor;
			TransparencyUpDown.Value = hexBoxSample.ShadowSelectionColor.A;
			CmbboxBackClr.Items.Add(hexBoxSample.ShadowSelectionColor.Name);
			hexBoxSample.InfoTextColor = Settings.Default.InfoTextColor;
			hexBoxSample.InfoBackColor = Settings.Default.InfoBackColor;
			hexBoxSample.HexViewTextColor = Settings.Default.HexViewTextColor;
			hexBoxSample.HexViewBackColor = Settings.Default.HexViewBackColor;
			hexBoxSample.HexStringTextColor = Settings.Default.HexStringTextColor;
			hexBoxSample.HexStringBackColor = Settings.Default.HexStringBackColor;
			hexBoxSample.BackColorDisabled = Settings.Default.BackColorDisabled;
			hexBoxSample.SelectionTextColor = Settings.Default.SelectionTextColor;
			hexBoxSample.SelectionBackColor = Settings.Default.SelectionBackColor;
			hexBoxSample.ShadowSelectionColor = Settings.Default.ShadowSelectionColor;
			CmbboxColorFor.SelectedIndex = 0;
			Initialised = true;
		}

		void clearRecentFilesButton_Click(object sender, EventArgs e)
		{
			Program.ApplicationForm.RecentFileHandler.Clear();
		}

		void okButton_Click(object sender, EventArgs e)
		{
			bool changed = false;
			if (recentFilesMax != Settings.Default.RecentFilesMax)
			{
				Settings.Default.RecentFilesMax = recentFilesMax;
				changed = true;
			}

			if (Settings.Default.UseSystemLanguage != this.useSystemLanguage ||
				Settings.Default.SelectedLanguage != (string)this.languageComboBox.SelectedValue)
			{
				Settings.Default.UseSystemLanguage = this.UseSystemLanguage;
				Settings.Default.SelectedLanguage = (string)this.languageComboBox.SelectedValue;

				Program.ShowMessage(strings.ProgramRestartSettings);

				changed = true;
			}

			if (changed)
			{
				Settings.Default.Save();
			}
			if (viewChanged)
			{
				Settings.Default.Save();
				FormHexEditor._reload = true;
			}

			DialogResult = DialogResult.OK;
		}

	/// <summary>
/// Fill combobox itms with names of colors
/// </summary>
		private void LoadCmbboxes()
		{
			ArrayList ColorList = new ArrayList();
			Type colorType = typeof(System.Drawing.Color);
			PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
										  BindingFlags.DeclaredOnly | BindingFlags.Public);
			foreach (PropertyInfo c in propInfoList)
			{
				CmbboxForeClr.Items.Add(c.Name);
				CmbboxBackClr.Items.Add(c.Name);
			}
		}

		void useSystemLanguageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.languageComboBox.Enabled = this.selectLanguageLabel.Enabled = !useSystemLanguageCheckBox.Checked;

		}
/// <summary>
/// Draws list names and colors on dropdown list of comboboxes 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
		private void CmbboxForeClr_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle rect = e.Bounds;
			if (e.Index >= 0)
			{
				string n = ((ComboBox)sender).Items[e.Index].ToString();
				Font f = new Font("Arial", 9, FontStyle.Regular);
				Color c = Color.FromName(n);
				if ((e.Index == CmbboxBackClr.Items.Count - 1))
				{
					c = hexBoxSample.ShadowSelectionColor;
					n = "Shadow Color";
				}
				Brush b = new SolidBrush(c);
				g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
				g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
			}
		}

		private void LineInfoVisiblechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.LineInfoVisible = Settings.Default.LineInfoVisible = LineInfoVisiblechk.Checked;
				viewChanged = true;
			}
		}

		private void ColumnInfoVisiblechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.ColumnInfoVisible = Settings.Default.ColumnInfoVisible = ColumnInfoVisiblechk.Checked;
				viewChanged = true;
			}
		}

		private void StringViewVisiblechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.StringViewVisible = Settings.Default.StringViewVisible = StringViewVisiblechk.Checked;
				viewChanged = true;
			}
		}

		private void GroupSeparatorVisiblechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.GroupSeparatorVisible = Settings.Default.GroupSeparatorVisible = GroupSeparatorVisiblechk.Checked;
				viewChanged = true;
			}
		}


		private void Enabledchk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.Enabled = Settings.Default.Enabled = Enabledchk.Checked;
				viewChanged = true;
			}
		}
		private void ReadOnlyChk_CheckedChanged(object sender, EventArgs e)
		{
			hexBoxSample.ReadOnly = Settings.Default.ReadOnly = ReadOnlyChk.Checked;
			viewChanged = true;
		}


		private void cancelButton_Click(object sender, EventArgs e)
		{
			Settings.Default.Reload();
			LoadSettings();
		}

		private void vScrollBarVisiblechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.VScrollBarVisible = Settings.Default.vScrollBarVisible = vScrollBarVisiblechk.Checked;
				viewChanged = true;
			}
		}

		private void BorderStyleCmb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				Settings.Default.BorderStyle = BorderStyleCmb.SelectedIndex;
				hexBoxSample.BorderStyle = (BorderStyle)BorderStyleCmb.SelectedIndex;
				viewChanged = true;
				hexBoxSample.Invalidate();
			}
		}
		private void HexCasingchk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				Settings.Default.HexCasing = HexCasingchk.Checked;
				if (HexCasingchk.Checked)
					hexBoxSample.HexCasing = Windows.Forms.HexCasing.Upper;
				else
					hexBoxSample.HexCasing = Windows.Forms.HexCasing.Lower;
				viewChanged = true;
			}

		}

		private void UseFixedBytesPerLinechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.UseFixedBytesPerLine = Settings.Default.UseFixedBytesPerLine = UseFixedBytesPerLinechk.Checked;
				BytesPerLineUpDown.Enabled = hexBoxSample.UseFixedBytesPerLine;
				viewChanged = true;
			}
		}

		private void BytesPerLineUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.BytesPerLine = Settings.Default.BytesPerLine = (int)BytesPerLineUpDown.Value;
				viewChanged = true;
			}
		}

		private void GroupSizeUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.GroupSize = Settings.Default.GroupSize = (int)GroupSizeUpDown.Value;
				viewChanged = true;
			}
		}

		private void LineInfoOffsetUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.LineInfoOffset = Settings.Default.LineInfoOffset = (int)LineInfoOffsetUpDown.Value;
				viewChanged = true;
			}
		}

		private void ShadowSelectionVisiblechk_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialised)
			{
				hexBoxSample.ShadowSelectionVisible = Settings.Default.ShadowSelectionVisible = ShadowSelectionVisiblechk.Checked;
				viewChanged = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fontDialog1.ShowDialog();
			hexBoxSample.Font = Settings.Default.Font = fontDialog1.Font;
			viewChanged = true;
		}
		/// <summary>
		/// Gets selected color from combobox and applies it  to element according to CmbboxColorFor selected item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbboxForeClr_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!ColorForDo)
			{
				string s = CmbboxForeClr.SelectedItem.ToString();
				Color c = Color.FromName(s);
				switch (CmbboxColorFor.SelectedIndex)
				{
					case 0:
						hexBoxSample.InfoTextColor = Settings.Default.InfoTextColor = c;
						break;
					case 1:
						hexBoxSample.HexViewTextColor = Settings.Default.HexViewTextColor = c;
						break;
					case 2:
						hexBoxSample.HexStringTextColor = Settings.Default.HexStringTextColor = c;
						break;
					case 4:
						hexBoxSample.SelectionTextColor = Settings.Default.SelectionTextColor = c;
						break;

					default:
						break;
				}
				viewChanged = true;
			}
		}

		/// <summary>
		/// Gets selected color from combobox and applies it  to element according to CmbboxColorFor selected item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbboxBackClr_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!ColorForDo)
			{
				string s = CmbboxBackClr.SelectedItem.ToString();
				Color c = Color.FromName(s);
				switch (CmbboxColorFor.SelectedIndex)
				{
					case 0:
						hexBoxSample.InfoBackColor = Settings.Default.InfoBackColor = c;
						break;
					case 1:
						hexBoxSample.HexViewBackColor = Settings.Default.HexViewBackColor = c;
						break;
					case 2:
						hexBoxSample.HexStringBackColor = Settings.Default.HexStringBackColor = c;
						break;
					case 3:
						hexBoxSample.BackColorDisabled = Settings.Default.BackColorDisabled = c;
						break;
					case 4:
						hexBoxSample.SelectionBackColor = Settings.Default.SelectionBackColor = c;
						break;
					case 5:
						Color cc = Color.FromArgb((int)TransparencyUpDown.Value, c.R, c.G, c.B);
						CmbboxBackClr.Items.RemoveAt((CmbboxBackClr.Items.Count - 1));
						CmbboxBackClr.Items.Add(cc.Name);
						hexBoxSample.ShadowSelectionColor = Settings.Default.ShadowSelectionColor = cc;
						break;

					default:
						break;
				}
				viewChanged = true;
			}
		}

		/// <summary>
		/// Enables/disable comboboxes in accordig to  selected item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbboxColorFor_SelectedIndexChanged(object sender, EventArgs e)
		{
			int slct = CmbboxColorFor.SelectedIndex;
			if (slct != 5) TransparencyUpDown.Enabled = false;
			if (slct != 3 || slct != 5) CmbboxForeClr.Enabled = true;
			ColorForDo = true;
			switch (slct)
			{
				case 0:
					FindName(hexBoxSample.InfoTextColor.Name, hexBoxSample.InfoBackColor.Name);
					break;
				case 1:
					FindName(hexBoxSample.HexViewTextColor.Name, hexBoxSample.HexViewBackColor.Name);
					break;
				case 2:
					FindName(hexBoxSample.HexStringTextColor.Name, hexBoxSample.HexStringBackColor.Name);
					break;
				case 3:
					CmbboxForeClr.Enabled = false;
					FindName("", hexBoxSample.BackColorDisabled.Name);
					break;
				case 4:
					FindName(hexBoxSample.SelectionTextColor.Name, hexBoxSample.SelectionBackColor.Name);
					break;
				case 5:
					TransparencyUpDown.Enabled = true;
					CmbboxForeClr.Enabled = false;
					CmbboxBackClr.SelectedIndex = CmbboxBackClr.Items.Count - 1;
					break;
				default:
					break;
			}
			ColorForDo = false;
		}

		private void FindName(string s1, string s2)
		{
			if (s1 != "")
			{
				for (int i = 0; i < CmbboxForeClr.Items.Count; i++)
				{
					string value = CmbboxForeClr.GetItemText(CmbboxForeClr.Items[i]);

					if (value == s1)
					{
						CmbboxForeClr.SelectedIndex = i;
						break;
					}
				}

			}
			for (int i = 0; i < CmbboxBackClr.Items.Count; i++)
			{
				string value = CmbboxBackClr.GetItemText(CmbboxForeClr.Items[i]);

				if (value == s2)
				{
					CmbboxBackClr.SelectedIndex = i;
					break;
				}
			}

		}
	}
}

