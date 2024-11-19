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
    public partial class FormCustomNotifierPrompt : Form
    {
        FormCustomNotifierPrompt()
        {
            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
        }

        public static DialogResult ShowDialog(IWin32Window owner, out string value)
        {
            FormCustomNotifierPrompt f = new FormCustomNotifierPrompt();
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
