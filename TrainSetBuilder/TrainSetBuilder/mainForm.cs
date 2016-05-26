using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainSetBuilder
{
    public partial class mainForm : Form
    {
        private static char CHARSET_SEP = ','; // multidimensional-charset separator
        private static string DIGITS = "0123456789";
        private static string LETTERS_LC = "abcdefghijklmnopqrstuvwxyz";
        private static string LETTERS_UC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string FONT_PREVIEW = DIGITS + " " + LETTERS_LC + " " + LETTERS_UC;
        private static bool USE_TRANSPARENT_BG = false; // use transparent instead of white?
        private static bool USE_GDI_INSTEAD_OF_GDIPLUS = false;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            initFontsList();
            initCharsetList();
            mainForm_Resize();
        }

        private void initFontsList()
        {
            fontsList.Items.Clear();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            foreach (FontFamily fontFamily in installedFontCollection.Families)
            {
                ListViewItem item = new ListViewItem(new string[] { fontFamily.Name, FONT_PREVIEW });
                item.Tag = fontFamily;
                item.UseItemStyleForSubItems = false;
                item.SubItems[1].Font = new Font(fontFamily, item.Font.Size);
                fontsList.Items.Add(item);
            }
        }

        private void initCharsetList()
        {
            charsetList.Items.Clear();
            charsetList.Items.Add(new ListViewItem(new string[] { DIGITS, "digitos/$f_$c.png" }));
            charsetList.Items.Add(new ListViewItem(new string[] { LETTERS_LC, "letras/$f_$c_lc.png" }));
            charsetList.Items.Add(new ListViewItem(new string[] { LETTERS_UC, "letras/$f_$c_uc.png" }));
            for (int i = 0; i < charsetList.Items.Count; i++)
                charsetList.Items[i].Checked = true;
            charsetList.Items.Add(new ListViewItem(new string[] { DIGITS + CHARSET_SEP + LETTERS_UC, "digitos_letras/$f_$c_uc.png" }));
            charsetList.Items.Add(new ListViewItem(new string[] { DIGITS + CHARSET_SEP + LETTERS_LC, "digitos_letras/$f_$c_lc.png" }));
        }

        private void mainForm_Resize(object sender = null, EventArgs e = null)
        {
            charsetList.Width = Width - 42;
            fontsList.Width = Width - 42;
            charsetEditButton.Left = Width - 129;
            trainPathTextBox.Width = Width - trainGenerateButton.Width - clearDirectoryButton.Width - 56;
            trainGenerateButton.Left = Width - 129;
            clearDirectoryButton.Left = trainGenerateButton.Left - clearDirectoryButton.Width - 7;
            fontsList.Height = Height - 300;
        }

        private void deleteSelectedCharset(bool uiRequestConfirm = false)
        {
            if (uiRequestConfirm && charsetList.SelectedItems.Count != 0 && MessageBox.Show("Os itens selecionados serão removidos.", "Deseja remover?", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            foreach (ListViewItem item in charsetList.SelectedItems)
                charsetList.Items.Remove(item);
        }

        private void editSelectedCharsetHandler(bool canceled, string charset, string path)
        {
            if (!canceled)
            {
                charsetList.SelectedItems[0].SubItems[0].Text = charset;
                charsetList.SelectedItems[0].SubItems[1].Text = path;
            }
        }

        private void addCharsetHandler(bool canceled, string charset, string path)
        {
            if (!canceled)
            {
                ListViewItem item = new ListViewItem(new string[] { charset, path });
                item.Checked = true;
                charsetList.Items.Add(item);
            }
        }

        private void editSelectedCharset()
        {
            if (charsetList.SelectedItems.Count != 1)
                return;
            ListViewItem item = charsetList.SelectedItems[0];
            charsetEditForm.Display(editSelectedCharsetHandler, item.SubItems[0].Text, item.SubItems[1].Text);
        }

        private void charsetList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteSelectedCharset(!e.Shift);
            if (e.KeyCode == Keys.Enter && charsetList.SelectedItems.Count == 1)
                editSelectedCharset();
        }

        private void charsetEditButton_Click(object sender, EventArgs e)
        {
            editSelectedCharset();
        }

        private void charsetRemoveButton_Click(object sender, EventArgs e)
        {
            deleteSelectedCharset(true);
        }

        private void charsetList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (charsetList.SelectedItems.Count == 0)
            {
                charsetEditButton.Enabled = false;
                charsetRemoveButton.Enabled = false;
            } else if (charsetList.SelectedItems.Count == 1)
            {
                charsetRemoveButton.Enabled = true;
                charsetEditButton.Enabled = true;
            } else
            {
                charsetRemoveButton.Enabled = true;
                charsetEditButton.Enabled = false;
            }

        }

        private void charsetAddButton_Click(object sender, EventArgs e)
        {
            charsetEditForm.Display(addCharsetHandler);
        }

        private void trainPathTextBox_TextChanged(object sender, EventArgs e)
        {
            trainPathTextBox.Text = trainPathTextBox.Text.Replace("\n", "").Replace("\r", "");
        }

        private void trainPathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                trainPathTextBox_DoubleClick(sender, e);
        }

        private void trainPathTextBox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string path = trainPathTextBox.Text;

            if (Directory.Exists(path))
                fbd.SelectedPath = path;
            if (fbd.ShowDialog() == DialogResult.OK)
                trainPathTextBox.Text = fbd.SelectedPath.Replace('\\', '/');
        }

        private void fontsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                foreach (ListViewItem item in fontsList.Items)
                    item.Selected = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                {
                    foreach (ListViewItem item in fontsList.SelectedItems)
                        item.Checked = !item.Checked;
                } else
                {
                    bool allSelectedAreChecked = true;
                    foreach (ListViewItem item in fontsList.SelectedItems)
                        allSelectedAreChecked = allSelectedAreChecked && item.Checked;
                    foreach (ListViewItem item in fontsList.SelectedItems)
                        item.Checked = !allSelectedAreChecked;
                }
            }
        }

        private string getDirectory(string pathWithFilename)
        {
            pathWithFilename = pathWithFilename.Replace('\\', '/');
            for (int i = pathWithFilename.Length - 1; i >= 0; i--)
                if (pathWithFilename[i] == '/')
                    return pathWithFilename.Substring(0, i);
            return "";
        }

        private string adjustFolderPath(string path)
        {
            if (path.Length == 0 || path.Last() != '/')
                return path + '/';
            return path;
        }

        private Bitmap drawText(string text, Font font, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            RectangleF rectf = new RectangleF(0, 0, width, height);
            if (!USE_TRANSPARENT_BG)
                g.DrawRectangle(new Pen(Color.White, width), 0, 0, width, height);
            g.DrawString(text, font, Brushes.Black, rectf);
            g.Flush();
            return bmp;
        }

        private void drawText(string filePath, string text, FontFamily fontFamily)
        {
            int width = (int)imgWidthUpDown.Value;
            int height = (int)imgHeightUpDown.Value;
            Directory.CreateDirectory(getDirectory(filePath));

            float fontSize = (float)fontSizeUpDown.Value;
            if (adjustSizeCheckBox.Checked)
            {
                Bitmap bmp = new Bitmap(2*width, 2*height);
                int minSize = (int)fontSizeUpDown.Minimum, maxSize = (int)fontSizeUpDown.Maximum;
                while (minSize <= maxSize)
                {
                    int avgSize = (minSize + maxSize) / 2;

                    // Get size
                    Font myFont = new Font(fontFamily, avgSize);
                    int h, w;

                    if (USE_GDI_INSTEAD_OF_GDIPLUS)
                    {
                        Size size = TextRenderer.MeasureText(text, myFont);
                        h = size.Height;
                        w = size.Width;
                    }
                    else
                    {
                        Graphics g = Graphics.FromImage(bmp);
                        g.DrawString(text, myFont, Brushes.Black, new PointF(0, 0));
                        h = (int)myFont.GetHeight(g);
                        w = (int)g.MeasureString(text, myFont).Width;
                    }
                    
                    // Compare
                    if (h < height && w < width)
                    {
                        minSize = avgSize + 1;
                        fontSize = avgSize;
                    }
                    else
                        maxSize = avgSize - 1;
                }
            }
            drawText(text, new Font(fontFamily, fontSize), width, height).Save(filePath);
        }

        private void drawAll(ref FontFamily[] fontFamilies, ref string filePath, ref string[] charset, int charsetIdx = 0, string prefix = "")
        {
            if (charsetIdx >= charset.Length)
            {
                foreach (FontFamily fontFamily in fontFamilies)
                {
                    string path = filePath.Replace("$f", fontFamily.Name).Replace("$c", prefix);
                    drawText(path, prefix, fontFamily);
                }
                advanceProgress(fontFamilies.Length);
            } else
            {
                foreach (char c in charset[charsetIdx])
                    drawAll(ref fontFamilies, ref filePath, ref charset, charsetIdx + 1, prefix + c);
            }
        }

        private Stopwatch stopwatch = new Stopwatch();
        private void initProgress(int maximum, string text = "Gerando")
        {
            statusProgressBar.Visible = true;
            statusProgressLabel.Visible = true;
            statusLabel.Visible = true;

            statusProgressBar.Maximum = maximum;
            statusProgressBar.Value = 0;
            statusProgressLabel.Text = "0% (0 de " + maximum + ")";
            statusLabel.Text = text;

            stopwatch.Start();
        }
        
        private void advanceProgress(int amount = 1)
        {
            statusProgressBar.Value += amount;

            if (stopwatch.ElapsedMilliseconds >= 500)
            {
                stopwatch.Reset();
                stopwatch.Start();

                int value = statusProgressBar.Value;
                int maxValue = statusProgressBar.Maximum;
                int percentage = (int)(0.1 + Math.Round(100 * (double)value / maxValue));
                statusProgressLabel.Text = percentage + "% (" + value + " de " + maxValue + ")";
                Update();
            }
        }

        private void concludeProgress(string text = "Concluído")
        {
            statusProgressBar.Visible = false;
            statusProgressLabel.Visible = false;
            statusLabel.Text = text;

            stopwatch.Reset();
        }

        private FontFamily[] getCheckedFontFamilies()
        {
            int itemsChecked = 0;
            foreach (ListViewItem item in fontsList.Items)
                if (item.Checked) itemsChecked++;
            FontFamily[] fontFamilies = new FontFamily[itemsChecked];

            foreach (ListViewItem item in fontsList.Items)
                if (item.Checked)
                    fontFamilies[--itemsChecked] = (FontFamily)item.Tag;

            return fontFamilies;
        }

        private int countCheckedCharsetCombinations()
        {
            int totalCharsetCombinations = 0;
            foreach (ListViewItem item in charsetList.Items)
            {
                if (item.Checked == false) continue;
                int total = 1;
                string[] charsets = item.Text.Split(new char[] { CHARSET_SEP });
                foreach (string charset in charsets)
                    total *= charset.Length;
                totalCharsetCombinations += total;
            }

            return totalCharsetCombinations;
        }

        private void generate(FontFamily[] fontFamilies)
        {
            foreach (ListViewItem item in charsetList.Items)
            {
                if (item.Checked == false) continue;
                string[] charset = item.Text.Split(new char[] { CHARSET_SEP });
                string filePath = adjustFolderPath(trainPathTextBox.Text) + item.SubItems[1].Text;
                drawAll(ref fontFamilies, ref filePath, ref charset);
            }
        }
    
        private void trainGenerateButton_Click(object sender, EventArgs e)
        {
            FontFamily[] fontFamilies = getCheckedFontFamilies();
            int totalCharsetCombinations = countCheckedCharsetCombinations();
            int totalImages = totalCharsetCombinations * fontFamilies.Length;

            if (MessageBox.Show("Serão geradas " + totalImages + " imagens.", "Tem certeza de que deseja iniciar?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            initProgress(totalImages);

            Enabled = false;
            Update();

            generate(fontFamilies);

            concludeProgress();
            Enabled = true;
        }

        private void clearDirectoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(trainPathTextBox.Text))
                {
                    if (MessageBox.Show("Todos os arquivos e pastas do diretório serão removidos.", "Tem certeza de que deseja remover?", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return;
                
                    if (Directory.Exists(".lixeira"))
                        Directory.Delete(".lixeira", true);
                    Directory.Move(trainPathTextBox.Text, ".lixeira");
                }
                else
                {
                    if (Directory.Exists(".lixeira"))
                    {
                        if (MessageBox.Show(
                            "O diretório não existe. Deseja recuperar os últimos arquivos removidos para este diretório?",
                            "Recuperar arquivos removidos", MessageBoxButtons.OKCancel) == DialogResult.OK
                        )
                            Directory.Move(".lixeira", trainPathTextBox.Text);
                    }
                    else
                        MessageBox.Show("O diretório não existe.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Não é possível remover/recuperar.\r\n\r\n" + err);
            }
        }

        private void adjustSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fontSizeUpDown.Enabled = !adjustSizeCheckBox.Checked;
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
