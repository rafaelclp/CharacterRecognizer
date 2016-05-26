using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainSetBuilder
{
    public partial class charsetEditForm : Form
    {
        private static charsetEditForm openedForm;
        private EventHandler eventHandler;

        public delegate void EventHandler(bool canceled, string charset, string path);

        public charsetEditForm()
        {
            InitializeComponent();
        }

        public static void Display(EventHandler handler, string charset = "", string path = "")
        {
            if (openedForm == null)
                openedForm = new charsetEditForm();
            openedForm.init(handler, charset, path);
        }

        private void init(EventHandler handler, string charset, string path)
        {
            charsetTextBox.Text = charset;
            charsetPathTextBox.Text = path;
            eventHandler = handler;
            ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string charset = charsetTextBox.Text;
            string path = charsetPathTextBox.Text;

            openedForm = null;
            Close();

            eventHandler(false, charset, path);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void charsetEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (openedForm != null)
            {
                string charset = charsetTextBox.Text;
                string path = charsetPathTextBox.Text;

                openedForm = null;
                eventHandler(true, charset, path);
            }
        }

        private void charsetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                okButton_Click(sender, e);
        }

        private void charsetPathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                okButton_Click(sender, e);
        }

        private void charsetEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
