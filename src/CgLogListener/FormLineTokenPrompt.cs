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
    public partial class FormLineTokenPrompt : Form
    {
        FormLineTokenPrompt()
        {
            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
        }

        public static DialogResult ShowDialog(IWin32Window owner, out string value)
        {
            FormLineTokenPrompt f = new FormLineTokenPrompt();
            DialogResult result = f.ShowDialog(owner);
            value = f.txtValue.Text;

            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
