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
    public partial class ucGameSetup : UserControl
    {
        public ucGameSetup()
        {
            InitializeComponent();
            btnStart.SetRoundedControl(82, 2);
            btnBack.SetRoundedControl(82, 2);
            gbPlayerInfo.SetRoundedControl(40, 2);
            gbRound.SetRoundedControl(40, 2);
        }

        private void ucGameSetup_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainForm main = (frmMainForm)this.ParentForm;
            if (main != null)
            {
                main.LoadControl(new ucMainPage());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if((txtPlayer1.Text.Length == 0) || (txtPlayer2.Text.Length == 0) || (txtPlayer1.Text == txtPlayer2.Text))
            {
                MessageBox.Show("Players Name Can Not Be Empty, Or The Same", "Naming Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmMainForm main = (frmMainForm)this.ParentForm;
                if (main != null)
                {
                    main.LoadControl(new ucGameRounds(txtPlayer1.Text, txtPlayer2.Text, (short)numricBox.Value));
                }
            }            
        }
    }
}
