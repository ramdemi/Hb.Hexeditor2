using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Hb.Windows.Forms;
using Hb.HexEditor2.Properties;
using System.Linq;

namespace Hb.HexEditor2
{
	public partial class FormHexEditor : Core.FormEx
	{
		FormFind _formFind;
		FindOptions _findOptions = new FindOptions();
		FormGoto _formGoto = new FormGoto();
		FormInsert _formInsert = new FormInsert();
		string _fileName;
		public static bool _reload = false;

		public FormHexEditor()
		{
			InitializeComponent();

			Init();
			this.toolStrip.Renderer.RenderToolStripBorder += new ToolStripRenderEventHandler(Renderer_RenderToolStripBorder);
			loadSettings();
		}

		/// <summary>
		/// Removes the border on the right of the tool strip
		/// </summary>
		/// <param name="sender">the renderer</param>
		/// <param name="e">the event args</param>
		void Renderer_RenderToolStripBorder(object sender, ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip.GetType() != typeof(ToolStrip))
				return;

			e.Graphics.DrawLine(new Pen(new SolidBrush(SystemColors.Control)), new Point(toolStrip.Width - 1, 0),
				new Point(toolStrip.Width - 1, toolStrip.Height));
		}
		int[] convarr = { };
		/// <summary>
		/// Initializes the hex editor´s main form
		/// </summary>
		void Init()
		{
			DisplayText();

			ManageAbility();

			UpdateBitControlVisibility();

			CreateConverters();

			hexBox.BuiltInContextMenu.CutMenuItemText = strings.ContextMenuCut;
			hexBox.BuiltInContextMenu.CopyMenuItemText = strings.ContextMenuCopy;
			hexBox.BuiltInContextMenu.PasteMenuItemText = strings.ContextMenuPaste;
			hexBox.BuiltInContextMenu.SelectAllMenuItemText = strings.ContextMenuSelectAll;
		}
		#region Code Page converters

		/// <summary>
		/// Gets code page display names and identifiers list, initializes converters creates dropdown menu items
		/// and events and fills code page combobox list
		/// </summary>
		private void CreateConverters()
			
		{
			var defConverter = new DefaultByteCharConverter();
			ToolStripMenuItem miDefault = new ToolStripMenuItem();
			miDefault.Text = defConverter.ToString();
			miDefault.Tag = defConverter;
			miDefault.Click += new EventHandler(encodingMenuItem_Clicked);
			//Create Code page and numbers list apply it to encodingToolStripComboBox 
			var cpn = new CodePageNames();
			cpn.displayNames.Insert(0, "ANSI (Default)");
			cpn.numbers.Insert(0, 0);
			var newList = cpn.numbers.Join(cpn.displayNames, s => cpn.numbers.IndexOf(s), i => cpn.displayNames.IndexOf(i), (s, i) => new { val = s, name = i }).ToList();

			var codePageConverter = new CodePageByteCharProvider(0);
			ToolStripMenuItem miCodePage = new ToolStripMenuItem();
			miCodePage.Text = codePageConverter.ToString(); 
			miCodePage.Tag = codePageConverter;
			miCodePage.Click += new EventHandler(cpMenuItem_Clicked);

			encodingToolStripMenuItem.DropDownItems.Add(miDefault);
			encodingToolStripMenuItem.DropDownItems.Add(miCodePage);
			//initialize combobox
			encodingToolStripComboBox.ComboBox.DisplayMember = "name";
			encodingToolStripComboBox.ComboBox.ValueMember = "val";
			encodingToolStripComboBox.ComboBox.DataSource = newList;
			encodingToolStripComboBox.SelectedIndex = 0;
		}

		private void cpMenuItem_Clicked(object sender, EventArgs e)
		{
			// Open comboboz Dropdown list so user can seleect code page from list
			encodingToolStripComboBox.DroppedDown=true;
		}

		void encodingMenuItem_Clicked(object sender, EventArgs e)
		{
			//Select ANSI (Default) in combobox it fites SelectedIndexChanged event
			encodingToolStripComboBox.SelectedIndex=0;
		}

		void toolStripEncoding_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			if (encodingToolStripComboBox.SelectedIndex > 0)
			{
				int tempn = (int)encodingToolStripComboBox.ComboBox.SelectedValue;
				var codePageConverter = new CodePageByteCharProvider(tempn);
				hexBox.ByteCharConverter = codePageConverter as IByteCharConverter;
			}
			else
			{
					var tagg = encodingToolStripMenuItem.DropDownItems[0];
					hexBox.ByteCharConverter = tagg.Tag as IByteCharConverter;
			}

			foreach (ToolStripMenuItem encodingMenuItem in encodingToolStripMenuItem.DropDownItems)
				encodingMenuItem.Checked = (encodingMenuItem.Text == hexBox.ByteCharConverter.ToString());
		}
		#endregion

		/// <summary>
		/// Updates the File size status label
		/// </summary>
		void UpdateFileSizeStatus()
		{
			if (this.hexBox.ByteProvider == null)
				this.fileSizeToolStripStatusLabel.Text = string.Empty;
			else
				this.fileSizeToolStripStatusLabel.Text = Util.GetDisplayBytes(this.hexBox.ByteProvider.Length);
		}

		/// <summary>
		/// Displays the file name in the Form´s text property
		/// </summary>
		/// <param name="fileName">the file name to display</param>
		void DisplayText()
		{
			if (_fileName != null && _fileName.Length > 0)
			{
				string textFormat = "{0}{1} - {2}";
				string readOnly = ((DynamicFileByteProvider)hexBox.ByteProvider).ReadOnly
					? strings.Readonly : "";
				string text = Path.GetFileName(_fileName);
				this.Text = string.Format(textFormat, text, readOnly, Program.SoftwareName);
			}
			else
			{
				Text = Program.SoftwareName;
			}
		}

		/// <summary>
		/// Manages enabling or disabling of menu items and toolstrip buttons.
		/// </summary>
		void ManageAbility()
		{
			if (hexBox.ByteProvider == null)
			{
				saveToolStripMenuItem.Enabled = saveToolStripButton.Enabled = false;
				saveAsToolStripMenuItem.Enabled = false;
				findToolStripMenuItem.Enabled = false;
				findNextToolStripMenuItem.Enabled = false;
				goToToolStripMenuItem.Enabled = false;
				nsertToolStripMenuItem.Enabled = false;
				fillToolStripMenuItem.Enabled = false;
				selectAllToolStripMenuItem.Enabled = false;
			}
			else
			{
				saveToolStripMenuItem.Enabled = saveToolStripButton.Enabled = hexBox.ByteProvider.HasChanges();
				saveAsToolStripMenuItem.Enabled = true;
				findToolStripMenuItem.Enabled = true;
				findNextToolStripMenuItem.Enabled = true;
				goToToolStripMenuItem.Enabled = true;
				nsertToolStripMenuItem.Enabled = true;
				fillToolStripMenuItem.Enabled = true;
				selectAllToolStripMenuItem.Enabled = true;
			}

			ManageAbilityForCopyAndPaste();
		}

		/// <summary>
		/// Manages enabling or disabling of menustrip items and toolstrip buttons for copy and paste
		/// </summary>
		void ManageAbilityForCopyAndPaste()
		{
			copyHexStringToolStripMenuItem.Enabled =
				copyToolStripSplitButton.Enabled = copyToolStripMenuItem.Enabled = hexBox.CanCopy();

			cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled = hexBox.CanCut();
			pasteToolStripSplitButton.Enabled = pasteToolStripMenuItem.Enabled = hexBox.CanPaste();
			pasteHexToolStripMenuItem.Enabled = pasteHexToolStripMenuItem1.Enabled = hexBox.CanPasteHex();
		}

		/// <summary>
		/// Shows the open file dialog.
		/// </summary>
		void OpenFile()
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				OpenFile(openFileDialog.FileName);
			}
		}

		/// <summary>
		/// Opens a file.
		/// </summary>
		/// <param name="fileName">the file name of the file to open</param>
		public void OpenFile(string fileName)
		{
			if (!File.Exists(fileName))
			{
				Program.ShowMessage(strings.FileDoesNotExist);
				return;
			}

			if (CloseFile() == DialogResult.Cancel)
				return;

			try
			{
				DynamicFileByteProvider dynamicFileByteProvider;
				try
				{
					// try to open in write mode
					dynamicFileByteProvider = new DynamicFileByteProvider(fileName);
					dynamicFileByteProvider.Changed += new EventHandler(byteProvider_Changed);
					dynamicFileByteProvider.LengthChanged += new EventHandler(byteProvider_LengthChanged);
				}
				catch (IOException) // write mode failed
				{
					try
					{
						// try to open in read-only mode
						dynamicFileByteProvider = new DynamicFileByteProvider(fileName, true);
						if (Program.ShowQuestion(strings.OpenReadonly) == DialogResult.No)
						{
							dynamicFileByteProvider.Dispose();
							return;
						}
					}
					catch (IOException) // read-only also failed
					{
						// file cannot be opened
						Program.ShowError(strings.OpenFailed);
						return;
					}
				}

				hexBox.ByteProvider = dynamicFileByteProvider;
				_fileName = fileName;

				DisplayText();

				UpdateFileSizeStatus();

				RecentFileHandler.AddFile(fileName);
			}
			catch (Exception ex1)
			{
				Program.ShowError(ex1);
				return;
			}
			finally
			{

				ManageAbility();
			}
		}

		/// <summary>
		/// Saves the current file.
		/// </summary>
		void SaveFile()
		{
			if (hexBox.ByteProvider == null)
				return;

			try
			{
				DynamicFileByteProvider dynamicFileByteProvider = hexBox.ByteProvider as DynamicFileByteProvider;
				dynamicFileByteProvider.ApplyChanges();
			}
			catch (Exception ex1)
			{
				Program.ShowError(ex1);
			}
			finally
			{
				ManageAbility();
			}
		}

		/// <summary>
		/// Saves the current file as another file.
		/// </summary>
		void SaveAsFile(string fname)
		{
			if (hexBox.ByteProvider == null)
				return;

			try
			{
				DynamicFileByteProvider dynamicFileByteProvider = hexBox.ByteProvider as DynamicFileByteProvider;
				dynamicFileByteProvider.SaveAsChanges(fname);
			}
			catch (Exception ex1)
			{
				Program.ShowError(ex1);
			}
			finally
			{
				_fileName = fname;
				DisplayText();
				ManageAbility();
			}
		}
		/// <summary>
		/// Closes the current file
		/// </summary>
		/// <returns>OK, if the current file was closed.</returns>
		DialogResult CloseFile()
		{
			if (hexBox.ByteProvider == null)
				return DialogResult.OK;

			try

			{
				if (hexBox.ByteProvider != null && hexBox.ByteProvider.HasChanges())
				{
					DialogResult res = MessageBox.Show(strings.SaveChangesQuestion,
						Program.SoftwareName,
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Warning);

					if (res == DialogResult.Yes)
					{
						SaveFile();
						CleanUp();
					}
					else if (res == DialogResult.No)
					{
						CleanUp();
					}
					else if (res == DialogResult.Cancel)
					{
						return res;
					}

					return res;
				}
				else
				{
					CleanUp();
					return DialogResult.OK;
				}
			}
			finally
			{
				ManageAbility();
			}
		}

		void CleanUp()
		{
			if (hexBox.ByteProvider != null)
			{
				IDisposable byteProvider = hexBox.ByteProvider as IDisposable;
				if (byteProvider != null)
					byteProvider.Dispose();
				hexBox.ByteProvider = null;
			}
			_fileName = null;
			DisplayText();
		}

		/// <summary>
		/// Opens the Find dialog
		/// </summary>
		void Find()
		{
			ShowFind();
		}

		/// <summary>
		/// Creates a new FormFind dialog
		/// </summary>
		/// <returns>the form find dialog</returns>
		FormFind ShowFind()
		{
			if (_formFind == null || _formFind.IsDisposed)
			{
				_formFind = new FormFind();
				_formFind.HexBox = this.hexBox;
				_formFind.FindOptions = _findOptions;
				_formFind.Show(this);
			}
			else
			{
				_formFind.Focus();
			}
			return _formFind;
		}

		/// <summary>
		/// Find next match
		/// </summary>
		void FindNext()
		{
			ShowFind().FindNext();
		}

		/// <summary>
		/// Aborts the current find process
		/// </summary>
		void FormFindCancel_Closed(object sender, EventArgs e)
		{
			hexBox.AbortFind();
		}

		/// <summary>
		/// Displays the goto byte dialog.
		/// </summary>
		void Goto()
		{
			_formGoto.SetMaxByteIndex(hexBox.ByteProvider.Length);
			_formGoto.SetDefaultValue(hexBox.SelectionStart);
			if (_formGoto.ShowDialog() == DialogResult.OK)
			{
				hexBox.SelectionStart = _formGoto.GetByteIndex();
				hexBox.SelectionLength = 1;
				hexBox.Focus();
			}
		}

		/// <summary>
		/// Enables drag&drop
		/// </summary>
		void hexBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		/// <summary>
		/// Processes a file drop
		/// </summary>
		void hexBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			object oFileNames = e.Data.GetData(DataFormats.FileDrop);
			string[] fileNames = (string[])oFileNames;
			if (fileNames.Length == 1)
			{
				OpenFile(fileNames[0]);
			}
		}

		void hexBox_Copied(object sender, EventArgs e)
		{
			ManageAbilityForCopyAndPaste();
		}

		void hexBox_CopiedHex(object sender, EventArgs e)
		{
			ManageAbilityForCopyAndPaste();
		}

		void hexBox_SelectionLengthChanged(object sender, System.EventArgs e)
		{
			ManageAbilityForCopyAndPaste();
		}

		void hexBox_SelectionStartChanged(object sender, System.EventArgs e)
		{
			ManageAbilityForCopyAndPaste();
		}

		void Position_Changed(object sender, EventArgs e)
		{
			this.toolStripStatusLabel.Text = string.Format("Ln {0}    Col {1}",
				hexBox.CurrentLine, hexBox.CurrentPositionInLine);

			string bitPresentation = string.Empty;

			byte? currentByte = hexBox.ByteProvider != null && hexBox.ByteProvider.Length > hexBox.SelectionStart
				? hexBox.ByteProvider.ReadByte(hexBox.SelectionStart)
				: (byte?)null;

			BitInfo bitInfo = currentByte != null ? new BitInfo((byte)currentByte, hexBox.SelectionStart) : null;

			if (bitInfo != null)
			{
				byte currentByteNotNull = (byte)currentByte;
				bitPresentation = string.Format("Bits of Byte {0}: {1}"
					, hexBox.SelectionStart
					, bitInfo.ToString()
					);
			}

			this.bitToolStripStatusLabel.Text = bitPresentation;

			this.bitControl1.BitInfo = bitInfo;
		}

		void byteProvider_Changed(object sender, EventArgs e)
		{
			ManageAbility();
		}

		void byteProvider_LengthChanged(object sender, EventArgs e)
		{
			UpdateFileSizeStatus();
		}

		void open_Click(object sender, EventArgs e)
		{
			OpenFile();
		}

		void save_Click(object sender, EventArgs e)
		{
			SaveFile();
		}

		void cut_Click(object sender, EventArgs e)
		{
			this.hexBox.Cut();
		}

		private void copy_Click(object sender, EventArgs e)
		{
			this.hexBox.Copy();
		}

		void paste_Click(object sender, EventArgs e)
		{
			this.hexBox.Paste();
		}

		private void copyHex_Click(object sender, EventArgs e)
		{
			this.hexBox.CopyHex();
		}

		private void pasteHex_Click(object sender, EventArgs e)
		{
			this.hexBox.PasteHex();
		}

		void find_Click(object sender, EventArgs e)
		{
			this.Find();
		}

		void findNext_Click(object sender, EventArgs e)
		{
			this.FindNext();
		}

		void goTo_Click(object sender, EventArgs e)
		{
			this.Goto();
		}

		void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.hexBox.SelectAll();
		}

		void exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void about_Click(object sender, EventArgs e)
		{
			new FormAbout().ShowDialog();
		}

		void recentFiles_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			RecentFileHandler.FileMenuItem fmi = (RecentFileHandler.FileMenuItem)e.ClickedItem;
			this.OpenFile(fmi.FileName);
		}

		void options_Click(object sender, EventArgs e)
		{
			new FormOptions().ShowDialog();
			if (_reload) loadSettings();
		}

		private void loadSettings()
		{
			hexBox.Font = Settings.Default.Font;
			hexBox.LineInfoVisible = Settings.Default.LineInfoVisible;
			hexBox.ColumnInfoVisible = Settings.Default.ColumnInfoVisible;
			hexBox.StringViewVisible = Settings.Default.StringViewVisible;
			hexBox.GroupSeparatorVisible = Settings.Default.GroupSeparatorVisible;
			hexBox.Enabled = Settings.Default.Enabled;
			hexBox.ReadOnly = Settings.Default.ReadOnly;
			hexBox.VScrollBarVisible = Settings.Default.vScrollBarVisible;
			hexBox.ShadowSelectionVisible = Settings.Default.ShadowSelectionVisible;
			hexBox.BorderStyle = (BorderStyle)Settings.Default.BorderStyle;
			hexBox.HexCasing = (Settings.Default.HexCasing) ? Windows.Forms.HexCasing.Upper : Windows.Forms.HexCasing.Lower;
			hexBox.UseFixedBytesPerLine = Settings.Default.UseFixedBytesPerLine;
			hexBox.BytesPerLine = Settings.Default.BytesPerLine;
			hexBox.GroupSize = Settings.Default.GroupSize;
			hexBox.LineInfoOffset = Settings.Default.LineInfoOffset;
			hexBox.InfoTextColor = Settings.Default.InfoTextColor;
			hexBox.InfoBackColor = Settings.Default.InfoBackColor;
			hexBox.HexViewTextColor = Settings.Default.HexViewTextColor;
			hexBox.HexViewBackColor = Settings.Default.HexViewBackColor;
			hexBox.HexStringTextColor = Settings.Default.HexStringTextColor;
			hexBox.HexStringBackColor = Settings.Default.HexStringBackColor;
			hexBox.BackColorDisabled = Settings.Default.BackColorDisabled;
			hexBox.SelectionTextColor = Settings.Default.SelectionTextColor;
			hexBox.SelectionBackColor = Settings.Default.SelectionBackColor;
			hexBox.ShadowSelectionColor = Settings.Default.ShadowSelectionColor;
			UpdateFormWidth();
			_reload = false;
		}

		void FormHexEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			var result = CloseFile();
			if (result == DialogResult.Cancel)
				e.Cancel = true;
		}

		void bitsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			UpdateBitControlVisibility();
		}

		void UpdateBitControlVisibility()
		{
			if (Util.DesignMode)
				return;
			//if (this.bitControl1.Visible == bitsToolStripMenuItem.Checked)
			//{
			//    return;
			//}
			if (bitsToolStripMenuItem.Checked)
			{
				hexBox.Height -= bitControl1.Height;
				bitControl1.Visible = true;
			}
			else
			{
				hexBox.Height += bitControl1.Height;
				bitControl1.Visible = false;
			}
		}

		void bitControl1_BitChanged(object sender, EventArgs e)
		{
			hexBox.ByteProvider.WriteByte(bitControl1.BitInfo.Position, bitControl1.BitInfo.Value);
			hexBox.Invalidate();
		}

		void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		void hexBox_RequiredWidthChanged(object sender, EventArgs e)
		{
			UpdateFormWidth();
		}

		void UpdateFormWidth()
		{
			int nn = Width - hexBox.Width;
			Width = hexBox.RequiredWidth + nn; /*+ 70;*/
		}

		private void hexaDecimalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeLineInfoFormat(0, sender.ToString());
		}

		private void decimalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeLineInfoFormat(1 , sender.ToString());
		}

		private void octalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeLineInfoFormat(2, sender.ToString());
		}

		private void ChangeLineInfoFormat(int v, string s)
		{
			string tt;
			//check and uncheck dropdown menu items colletion relative to sender menu text
			for (int ii=0;ii < editorOffsetFormatToolStripMenuItem.DropDownItems.Count; ii++)
			{
				tt= ((ToolStripMenuItem)editorOffsetFormatToolStripMenuItem.DropDownItems[ii]).ToString();
				((ToolStripMenuItem)editorOffsetFormatToolStripMenuItem.DropDownItems[ii]).Checked = tt == s;
			}

			hexBox.LineInfoFormat=v;
		}
		// If comboBox has focus after dropdown closed mouse whell changes combobox index.
		//  Then redirect to toolstrip.
		private void encodingToolStripComboBox_DropDownClosed(object sender, EventArgs e)

		{
			toolStrip.Focus();
		}

		private void nsertToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_formInsert.SetWhoCalled(0);
			if (_formInsert.ShowDialog() == DialogResult.OK)
			{
				string b1 = _formInsert.GetFillPattern();
				hexBox.InsertBytes(b1, _formInsert.GetByteCount(),_formInsert.GetFillRadio());
			}
			
		}

		private void fillToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_formInsert.SetWhoCalled(1);
			if (_formInsert.ShowDialog() == DialogResult.OK)
			{
				string b1 = _formInsert.GetFillPattern();
				hexBox.FillBytes(b1, _formInsert.GetByteCount(), _formInsert.GetFillRadio());
			}

		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.OverwritePrompt = true;
			saveFileDialog1.CreatePrompt = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				SaveAsFile(saveFileDialog1.FileName);
			}
		}
	}
}