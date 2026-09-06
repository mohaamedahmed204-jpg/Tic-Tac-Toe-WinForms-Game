using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fifth_project
{
    public partial class ucGameOver : UserControl
    {
        public ucGameOver(string WinnerPlayer)
        {
            InitializeComponent();
            btnBack.SetRoundedControl(80, 2);
            lblTheWinner.Text = WinnerPlayer;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainForm main = (frmMainForm)this.ParentForm;
            if (main != null)
            {
                main.LoadControl(new ucMainPage());
            }
        }

        private void lblTheWinner_Click(object sender, EventArgs e)
        {

        }
    }
}
