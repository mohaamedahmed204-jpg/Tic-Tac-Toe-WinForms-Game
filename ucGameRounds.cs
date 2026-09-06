using Fifth_project.Properties;
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
    public partial class ucGameRounds : UserControl
    {
        private string Player1, Player2, Icon;
        private char[,] a;
        private const short Rows = 3, Cols = 3;
        private short Rounds, Draw = 9;

        public ucGameRounds(string Player1Name, string Player2Name, short NumOfRounds)
        {
            InitializeComponent();

            Player1 = Player1Name;
            Player2 = Player2Name;

            lblPlayerNameTurn.Text = Player1;
            Rounds = NumOfRounds;

            gbPlayerTurn.SetRoundedControl(40, 2);
            FillArray();
        }

        private void FillArray()
        {
            a = new char[Rows, Cols];
            for(short i = 0; i < Rows; i++)
            {
                for (short j = 0; j < Cols; j++)
                {
                    a[i, j] = '.';
                }
            }
        }        

        private void ResetImages()
        {
            foreach(Control c in this.Controls)
            {
                if(c is PictureBox pbx)
                {
                    pbx.Image = Resources.question_mark_96;
                    pbx.Tag = pbx.Tag.ToString().Substring(0, 2) + "E";
                }
            }
        }

        private void ResetBoard()
        {
            Draw = 9;
            ResetImages();
            FillArray();
            lblRoundNumber.Text = Convert.ToString(Convert.ToInt32(lblRoundNumber.Text) + 1);
        }

        private bool IsPlayerWon(short row, short col)
        {
            a[row, col] = Icon[0];

            // Rows
            for (short i = 0; i < Rows; ++i)
            {
                if (a[row, col] == a[i, 0] && a[row, col] == a[i, 1] && a[row, col] == a[i, 2])
                    return true;
            }

            // Cols
            for (short i = 0; i < Cols; ++i)
            {
                if (a[row, col] == a[0, i] && a[row, col] == a[1, i] && a[row, col] == a[2, i])
                    return true;
            }

            // Digo
            if (a[row, col] == a[0, 0] && a[row, col] == a[1, 1] && a[row, col] == a[2, 2])
                return true;
            if (a[row, col] == a[0, 2] && a[row, col] == a[1, 1] && a[row, col] == a[2, 0])
                return true;

            // else
            return false;
        }

        private void ChangeIcon(PictureBox pbx)
        {
            Icon = (lblPlayerNameTurn.Text == Player1) ? ("X") : ("O");
            pbx.Tag = pbx.Tag.ToString().Substring(0, 2) + Icon;
            pbx.Image = (Image)Resources.ResourceManager.GetObject(Icon);
        }

        private void ChangePlayerPoints()
        {
            if (lblPlayerNameTurn.Text == Player1)
            {
                lblPlayer1WinsTime.Text = Convert.ToString((Convert.ToInt16(lblPlayer1WinsTime.Text)) + 1);
            }
            else
            {
                lblPlayer2WinsTime.Text = Convert.ToString((Convert.ToInt16(lblPlayer2WinsTime.Text)) + 1);
            }
        }

        private bool IsEndOfTheRounds()
        {
            if (Convert.ToInt16(lblRoundNumber.Text) == Rounds)
            {
                return true;
            }
            return false;
        }

        private void ShowGameOverScreen()
        {
            MessageBox.Show("All rounds are finshed !!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmMainForm main = (frmMainForm)this.ParentForm;
            if (main != null)
            {
                string WhoWon = (lblPlayer1WinsTime.Text == lblPlayer2WinsTime.Text) ? ("Draw") :
                                ((Convert.ToInt16(lblPlayer1WinsTime.Text) > Convert.ToInt16(lblPlayer2WinsTime.Text))  ? (Player1) : (Player2));
                main.LoadControl(new ucGameOver(WhoWon));
            }
        }

        private void CurrRound(object sender, EventArgs e)
        {
            PictureBox pbx = (PictureBox)sender;
            
            // check if valid place then check if won

            if( pbx.Tag.ToString().Substring(2, 1) != "E" )
            {
                MessageBox.Show("Invild Place", "This place is taken"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ChangeIcon(pbx);

                short i = Convert.ToInt16(pbx.Tag.ToString().Substring(0, 1));
                short j = Convert.ToInt16(pbx.Tag.ToString().Substring(1, 1));

                if(IsPlayerWon(i, j))
                {
                    ChangePlayerPoints();

                    if ( MessageBox.Show($"{lblPlayerNameTurn.Text} Won The Round !!"
                    , "End of round", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (IsEndOfTheRounds())
                        {
                            ShowGameOverScreen();
                        }
                        else
                        {
                            ResetBoard();
                            return;
                        } 
                            
                    }
                }
                else if(--Draw == 0)
                {
                    if (MessageBox.Show("This Round is Draw!!"
                    , "End of round", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (IsEndOfTheRounds())
                        {
                            ShowGameOverScreen();
                        }
                        else
                            ResetBoard();
                    }
                }
                
                lblPlayerNameTurn.Text = (lblPlayerNameTurn.Text == Player1) ? (Player2) : (Player1);                
            }
        }
    }
}
