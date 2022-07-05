using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CgLogListener
{
    public partial class FormPrompt : Form
    {
        FormPrompt()
        {
            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
        }

        public static DialogResult ShowDialog(IWin32Window owner, out string value)
        {
            FormPrompt f = new FormPrompt();
            DialogResult result = f.ShowDialog(owner);
            value = f.txtValue.Text;
            if (!string.IsNullOrWhiteSpace(f.txtExp.Text))
            {
                value += $"|{f.txtExp.Text}";
            }

            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
