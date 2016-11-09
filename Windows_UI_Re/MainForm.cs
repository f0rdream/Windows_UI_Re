using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Windows_UI_Re;

namespace Windows_UI_Re
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DisplayGrid();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            var nameText = textBox1.Text;
            Search(nameText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddDoc();

        }      
        private void button6_Click(object sender, EventArgs e)
        {
            DelDoc(gv.CurrentCell.RowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDoc();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetTextBox(gv.CurrentCell.RowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DelDoc(gv.CurrentCell.RowIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            displayStu();
        }
    }
}
