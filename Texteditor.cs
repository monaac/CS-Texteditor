using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// added code
using System.Drawing.Text;
//added
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Texteditor
{
    public partial class Texteditor : Form
    {
        public Texteditor()
        {
            InitializeComponent();
        }

        #region Editor and General

        #region MainMenu
        void customise()
        {
            ColorDialog myDialog = new ColorDialog();
            if (myDialog.ShowDialog() == DialogResult.OK){
            mainMenu.BackColor = myDialog.Color;
            Status.BackColor = myDialog.Color;
            Tools.BackColor = myDialog.Color;
            }
        }
        #endregion

        
        #region Methods
        #region file
        void New()
        {
            Document.Clear();
        }

        void Open()
        {
            if (openWork.ShowDialog() == DialogResult.OK)
            {
                Document.LoadFile(openWork.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        void Save()
        {
            if (saveWork.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document.SaveFile(saveWork.FileName, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void Exit()
        {
            Application.Exit();
        }
        #endregion

        private void file_New_Click(object sender, EventArgs e)
        {
            New();
        }

        private void file_Open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void file_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void file_Exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        #region edit
        void Undo()
        {
            Document.Undo();
        }

        void Redo()
        {
            Document.Redo();
        }

        void Cut()
        {
            Document.Cut();
        }

        void Copy()
        {
            Document.Copy();
        }

        void Paste()
        {
            Document.Paste();
        }

        void SelectAll()
        {
            Document.SelectAll();
        }

        void ClearAll()
        {
            Document.Clear();
        }

        #endregion

        private void edit_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void edit_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void edit_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void edit_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void edit_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void edit_SelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
       
        #region Toolbar
        
        private void tb_New_Click(object sender, EventArgs e)
        {
            New();
        }
        private void tb_Open_Click(object sender, EventArgs e)
        {
            Open();
        }
        private void tb_Save_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void tb_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void tb_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void tb_Bold_Click(object sender, EventArgs e)
        {
            Font bfont = new Font(Document.Font, FontStyle.Bold);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Bold)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = bfont;
            }
        }
        private void tb_Italic_Click(object sender, EventArgs e)
        {
            Font Ifont = new Font(Document.Font, FontStyle.Italic);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Italic)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = Ifont;
            }
        }

        private void tb_UnderLine_Click(object sender, EventArgs e)
        {
            Font Ufont = new Font(Document.Font, FontStyle.Underline);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Underline)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = Ufont;
            }
        }

        private void tb_Strike_Click(object sender, EventArgs e)
        {
            Font Sfont = new Font(Document.Font, FontStyle.Strikeout);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Strikeout)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = Sfont;
            }
        }

        private void tb_AlignLeft_Click(object sender, EventArgs e)
        {
            Document.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void tb_AlignCenter_Click(object sender, EventArgs e)
        {
            Document.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void tb_AlignRight_Click(object sender, EventArgs e)
        {
            Document.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void tb_UpperCase_Click(object sender, EventArgs e)
        {
            Document.SelectedText = Document.SelectedText.ToUpper();
        }
        private void tb_LowerCase_Click(object sender, EventArgs e)
        {
            Document.SelectedText = Document.SelectedText.ToLower();
        }
        private void tb_ZoomIn_Click(object sender, EventArgs e)
        {
            if (Document.ZoomFactor == 63)
            {
                return;
            }
            else
                Document.ZoomFactor = Document.ZoomFactor + 1;
        }

        private void tb_ZoomOut_Click(object sender, EventArgs e)
        {
            if (Document.ZoomFactor == 1)
            {
                return;
            }
            else
                Document.ZoomFactor = Document.ZoomFactor - 1;
        }


        void FontSize()
        {
            for (int fntSize = 10; fntSize <= 75; fntSize++)
            {
                tb_FontSize.Items.Add(fntSize.ToString());
            }
        }
        void InstalledFonts()
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            for (int i = 0; i < fonts.Families.Length; i++)
            {
                tb_Font.Items.Add(fonts.Families[i].Name);
            }
        }



        private void tb_Font_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Drawing.Font ComboFonts = null;
            try
            {
                ComboFonts = Document.SelectionFont;
                Document.SelectionFont = new System.Drawing.Font(tb_Font.Text, Document.SelectionFont.Size, Document.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        
        #endregion
    

        #region contextmenu
        
        private void rc_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void rc_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void rc_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void rc_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void rc_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        #endregion        
        


               
        #region tools
        #endregion
        private void tools_Customisation_Click(object sender, EventArgs e)
        {
            customise();
        }
        #endregion


        private void Timer_Tick_1(object sender, EventArgs e)
        {
            charCount.Text = "Characters in the current document: " + Document.TextLength.ToString();
            status_ZoomFactor.Text = Document.ZoomFactor.ToString();
        }

        


        private void Texteditor_Load(object sender, EventArgs e)
        {
            FontSize();
            InstalledFonts();
        }

        private void tb_FontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document.SelectionFont = new Font(tb_FontSize.SelectedItem.ToString(), int.Parse(tb_FontSize.SelectedItem.ToString()), Document.SelectionFont.Style);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            charCount.Text = "Characters in the current document: " + Document.TextLength.ToString();
            status_ZoomFactor.Text = Document.ZoomFactor.ToString();
        }

        private void Document_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
       
    }
}
        #endregion