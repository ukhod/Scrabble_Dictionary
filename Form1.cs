using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Scrabble_Disctionary
{
    public partial class frmScrabble_dictionary : Form
    {
        
        public frmScrabble_dictionary()
        {
            InitializeComponent();
          
        }
        private void label1_Click(object sender, EventArgs e)
        { }
        private void btn_search_Click(object sender, EventArgs e)
        {

            txt_word.Text = txt_word.Text.ToUpper();
            if (string.Compare(txt_word.Text, string.Empty) != 0)
            {
                errorProvider1.SetError(txt_word,"");
                try
                {
                    string line;
                    bool valid = false;
                    using (StreamReader sr = new StreamReader("dictionary.txt"))
                    {
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (string.Compare(txt_word.Text, line) == 0)
                            {
                                MessageBox.Show("Word " + line + " is Found.","Scrabble Dictionary.");
                                line = null;
                                valid = true;
                            }
                        }
                        if (valid == false) MessageBox.Show("Word not found.", "Scrabble Dictionary.");
                        txt_word.Clear();
                        txt_word.Focus();

                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                errorProvider1.SetError(txt_word,"Please enter word.");
                MessageBox.Show("Please enter word.", "Error");
                txt_word.Focus();
            }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Do you want to close the application","Scrabble Dictionary",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
                this.Close();
            else
            {
                txt_word.Clear();
                txt_word.Focus();
            }
                
        }
        private void frmScrabble_dictionary_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void frmScrabble_dictionary_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true && e.KeyCode == Keys.Enter)
            {
                btn_search.PerformClick();
            }

        }
    }
}
