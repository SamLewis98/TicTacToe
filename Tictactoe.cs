using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiGame
{
    public partial class Tictactoe : Form
    {
        bool turn = true; //true = X, false = Y
        int turn_count = 0;
        public Tictactoe()
        {
            InitializeComponent();
        }

        private void Tictactoe_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by SL on 27/05/22. Version 1.0 ", "About");
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic tac toe, also known as 'naughts and crosses' or 'Xs & Os' is a 2 player game where the aim is to create either a horizontal, vertical or diagnal line with either X's or O's", "How to play");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)               //if turn = true (X)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;           // if turn equals not turn, to flip whos turn it is
            b.Enabled = false;
            turn_count++;

            checkForWinner();
            

        }

        private void checkForWinner()
        {
            bool winner = false;

            //Check horizontal for winner
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) 
                winner = true;

            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;

            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            winner = true;

            //Check vertical for winner
           else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;

            //Check diagnal for winner
           else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;

            


            if (winner)
            {
                disableAllButtons();

                String winnerName = "";

                if (turn)
                    winnerName = "O";
                else
                    winnerName = "X";

                MessageBox.Show(winnerName + " Wins!", "3 in a row!");
            }
            else
            {
                if(turn_count == 9)
                    MessageBox.Show("Its a draw!", "No winner today!");
            }


        }

        private void disableAllButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }


        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = " ";
            }
        }
    }
          
    }
