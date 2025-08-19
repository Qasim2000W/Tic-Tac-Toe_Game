using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIC_TAC_TOE_GAME.Properties;

namespace TIC_TAC_TOE_GAME
{
    public partial class Form1 : Form
    {
        STGameStatatus gameStatatus;
        enplayer player = enplayer.player1;

        public enum enplayer
        {
            player1,
            player2
        }

        public enum Enwinner
        {
            player1,
            player2,
            draw,
            gameinprogress
        }

        struct STGameStatatus
        {
           public Enwinner winner;
           public byte playcount;
           public bool gameover;
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeImage(Button button)
        {
            if (button.Tag.ToString()=="?")
            {
                switch(player)
                {
                    case enplayer.player1:
                        button.Image = Image.FromFile(@"H:\TIC-TAC-TOE GAME\x.PNG");
                        button.Tag = "x";
                        player = enplayer.player2;
                        gameStatatus.playcount++;
                        GameResult();
                        lblturn.Text = "player2";
                        break;
                    case enplayer.player2:
                        button.Image = Image.FromFile(@"H:\TIC-TAC-TOE GAME\o.PNG");
                        button.Tag = "o";
                        player = enplayer.player1;
                        gameStatatus.playcount++;
                        GameResult();
                        lblturn.Text = "player1";
                        break;
                }
            }
            else
            {
                MessageBox.Show("wrong", "wrong choicre",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if (gameStatatus.playcount==9&&!gameStatatus.gameover)
            {
                gameStatatus.gameover = true;
                gameStatatus.winner = Enwinner.draw;
                EndGame();
            }
        }

        public bool CheckValues(Button button1, Button button2, Button button3)
        {
            if (button1.Tag.ToString()!="?"&& button1.Tag.ToString()== button2.Tag.ToString()&& 
                button1.Tag.ToString()==button3.Tag.ToString())
            {
                button1.BackColor = Color.GreenYellow;
                button2.BackColor = Color.GreenYellow;
                button3.BackColor = Color.GreenYellow;

                if (button1.Tag.ToString()=="x")
                {
                    gameStatatus.gameover = true;
                    gameStatatus.winner = Enwinner.player1;
                    EndGame();
                    return true;
                }
                else
                {
                    gameStatatus.gameover = true;
                    gameStatatus.winner = Enwinner.player2;
                    EndGame();
                    return true;
                }
            }
            gameStatatus.gameover = false;
            return false;
        }

        public void GameResult()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;
        }

        public void EndGame()
        {
            lblturn.Text = "game over";

            switch (gameStatatus.winner)
            {
                case Enwinner.player1:

                    lBLRESULT.Text = "player1";

                    break;

                case Enwinner.player2:

                    lBLRESULT.Text = "player2";

                    break;

                default:

                    lBLRESULT.Text = "draw";

                    break;
            }

            MessageBox.Show("game over", "game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color white = Color.White;
            Pen pen = new Pen(white);
            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 600, 150, 600, 600);
            e.Graphics.DrawLine(pen, 850, 150, 850, 600);
            e.Graphics.DrawLine(pen, 400, 290, 1050, 290);
            e.Graphics.DrawLine(pen, 400, 450, 1050, 450);

        }
          
        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

     
        public void ResetButton(Button button)
        {
            button.Tag = "?";
            button.Image = Image.FromFile(@"H:\TIC-TAC-TOE GAME\q.PNG");
            button.BackColor = Color.Black;
        }

        private void butreset_Click(object sender, EventArgs e)
        {
            lblturn.Text = "player1";
            lBLRESULT.Text = "in prgress";

            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            gameStatatus.winner = Enwinner.gameinprogress;
            gameStatatus.playcount = 0;
            gameStatatus.gameover = false;
            player = enplayer.player1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}