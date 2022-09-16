using SandyGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandyGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void DetectSelectedButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Control[] FreeButton = Controls.Find("Btn16", true);
            Button btn16 = (Button)FreeButton[0];
            TableLayoutPanelCellPosition po = tableLayoutPanel1.GetPositionFromControl(btn);
            if (po.Row > 0)
            {
                if (tableLayoutPanel1.GetControlFromPosition(po.Column, po.Row - 1) == btn16)
                {
                    tableLayoutPanel1.Controls.Remove(btn);
                    tableLayoutPanel1.Controls.Remove(btn16);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column, po.Row);
                    tableLayoutPanel1.Controls.Add(btn, po.Column, po.Row - 1);
                }
            }
            if (po.Row < tableLayoutPanel1.RowCount)
            {
                if (tableLayoutPanel1.GetControlFromPosition(po.Column, po.Row + 1) == btn16)
                {
                    tableLayoutPanel1.Controls.Remove(btn);
                    tableLayoutPanel1.Controls.Remove(btn16);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column, po.Row);
                    tableLayoutPanel1.Controls.Add(btn, po.Column, po.Row + 1);
                }
            }
            if (po.Column > 0)
            {
                if (tableLayoutPanel1.GetControlFromPosition(po.Column - 1, po.Row) == btn16)
                {
                    tableLayoutPanel1.Controls.Remove(btn);
                    tableLayoutPanel1.Controls.Remove(btn16);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column, po.Row);
                    tableLayoutPanel1.Controls.Add(btn, po.Column - 1, po.Row);
                }
            }
            if (po.Column < tableLayoutPanel1.ColumnCount)
            {
                if (tableLayoutPanel1.GetControlFromPosition(po.Column + 1, po.Row) == btn16)
                {
                    tableLayoutPanel1.Controls.Remove(btn);
                    tableLayoutPanel1.Controls.Remove(btn16);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column, po.Row);
                    tableLayoutPanel1.Controls.Add(btn, po.Column + 1, po.Row);
                }
            }
            if(CheckIfWin())
            {
                MessageBox.Show("Congratulations You Win");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }
        private bool CheckNumAvilability(int[] NumArray,int thenumber)
        {
            for (int i = 0; i < NumArray.Length; i++)
            {
                if (NumArray[i] == thenumber)
                {
                    return true;
                }
            }
            return false;
        } 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abx = new AboutBox1();
            abx.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void NewGame()
        {
            tableLayoutPanel1.Controls.Clear();
            int[] NumArray = new int[16];
            Random rnd = new Random();
            for (int i = 0; i < NumArray.Length; i++)
            {
                int thenumber = rnd.Next(0, 17);
                while (CheckNumAvilability(NumArray, thenumber))
                {
                    thenumber = rnd.Next(0, 17);
                }
                NumArray[i] = thenumber;
                Button NumBtn = new Button
                {
                    Name = "Btn" + NumArray[i].ToString(),
                    Dock = DockStyle.Fill,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    FlatStyle = FlatStyle.Flat
                };
                switch (NumArray[i])
                {
                    case 1:
                        NumBtn.BackgroundImage = Resources.icons8_1_96px;
                        break;
                    case 2:
                        NumBtn.BackgroundImage = Resources.icons8_2_96px;
                        break;
                    case 3:
                        NumBtn.BackgroundImage = Resources.icons8_3_96px;
                        break;
                    case 4:
                        NumBtn.BackgroundImage = Resources.icons8_4_96px;
                        break;
                    case 5:
                        NumBtn.BackgroundImage = Resources.icons8_5_96px;
                        break;
                    case 6:
                        NumBtn.BackgroundImage = Resources.icons8_6_96px;
                        break;
                    case 7:
                        NumBtn.BackgroundImage = Resources.icons8_7_96px;
                        break;
                    case 8:
                        NumBtn.BackgroundImage = Resources.icons8_8_96px;
                        break;
                    case 9:
                        NumBtn.BackgroundImage = Resources.icons8_9_96px;
                        break;
                    case 10:
                        NumBtn.BackgroundImage = Resources.icons8_10_96px;
                        break;
                    case 11:
                        NumBtn.BackgroundImage = Resources.icons8_11_96px;
                        break;
                    case 12:
                        NumBtn.BackgroundImage = Resources.icons8_12_96px;
                        break;
                    case 13:
                        NumBtn.BackgroundImage = Resources.icons8_13_96px;
                        break;
                    case 14:
                        NumBtn.BackgroundImage = Resources.icons8_14_96px;
                        break;
                    case 15:
                        NumBtn.BackgroundImage = Resources.icons8_15_96px;
                        break;

                }
                NumBtn.Click += new EventHandler(DetectSelectedButton);
                Controls.Add(NumBtn);
            }
            int num = 0;
            for (int LayRow = 0; LayRow < tableLayoutPanel1.RowCount; LayRow++)
            {
                for (int LayCol = 0; LayCol < tableLayoutPanel1.ColumnCount; LayCol++)
                {
                    Control[] FoundList = Controls.Find("Btn" + NumArray[num].ToString(), true);
                    tableLayoutPanel1.Controls.Add(FoundList[0], LayCol, LayRow);
                    num++;
                }
            }

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private bool CheckIfWin()
        {
            bool win = true;
            int num = 1;
            for (int row = 0;row < tableLayoutPanel1.RowCount; row++)
            {
                for(int col = 0;col < tableLayoutPanel1.ColumnCount;col++)
                {
                    Control[] SelectedButton = Controls.Find("Btn" + num.ToString(), true);
                    TableLayoutPanelCellPosition po = tableLayoutPanel1.GetPositionFromControl(SelectedButton[0]);
                    if (row != po.Row || col != po.Column)
                    {
                        return false;
                    }
                    num++;
                }
            }
            return win;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Control[] FreeButton = Controls.Find("Btn16", true);
            Button btn16 = (Button)FreeButton[0];
            TableLayoutPanelCellPosition po = tableLayoutPanel1.GetPositionFromControl(btn16);
            if(e.KeyCode == Keys.S)
            {
                if (po.Row < 3)
                {
                    tableLayoutPanel1.Controls.Remove(btn16);
                    Button replacedButton = (Button)tableLayoutPanel1.GetControlFromPosition(po.Column, po.Row + 1);
                    tableLayoutPanel1.Controls.Remove(replacedButton);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column, po.Row + 1);
                    tableLayoutPanel1.Controls.Add(replacedButton, po.Column, po.Row);

                }
            }
            if (e.KeyCode == Keys.W)
            {
                if (po.Row >0)
                {
                    tableLayoutPanel1.Controls.Remove(btn16);
                    Button replacedButton = (Button)tableLayoutPanel1.GetControlFromPosition(po.Column, po.Row - 1);
                    tableLayoutPanel1.Controls.Remove(replacedButton);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column, po.Row - 1);
                    tableLayoutPanel1.Controls.Add(replacedButton, po.Column, po.Row);

                }
            }
            if (e.KeyCode == Keys.A)
            {
                if (po.Column >0)
                {
                    tableLayoutPanel1.Controls.Remove(btn16);
                    Button replacedButton = (Button)tableLayoutPanel1.GetControlFromPosition(po.Column-1, po.Row);
                    tableLayoutPanel1.Controls.Remove(replacedButton);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column-1, po.Row );
                    tableLayoutPanel1.Controls.Add(replacedButton, po.Column, po.Row);

                }
            }
            if (e.KeyCode == Keys.D)
            {
                if (po.Column < 3)
                {
                    tableLayoutPanel1.Controls.Remove(btn16);
                    Button replacedButton = (Button)tableLayoutPanel1.GetControlFromPosition(po.Column+1, po.Row);
                    tableLayoutPanel1.Controls.Remove(replacedButton);
                    tableLayoutPanel1.Controls.Add(btn16, po.Column+1, po.Row);
                    tableLayoutPanel1.Controls.Add(replacedButton, po.Column, po.Row);

                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpform help = new Helpform();
            help.Show();
        }
    }
}

