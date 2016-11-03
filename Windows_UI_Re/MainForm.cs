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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rownumber = gv.CurrentCell.RowIndex;
            textBox7.Text =gv.Rows[rownumber].Cells[0].Value.ToString();
            textBox8.Text = gv.Rows[rownumber].Cells[1].Value.ToString();
            textBox10.Text = gv.Rows[rownumber].Cells[2].Value.ToString();
            textBox6.Text = gv.Rows[rownumber].Cells[3].Value.ToString();
            textBox5.Text = gv.Rows[rownumber].Cells[4].Value.ToString();
            textBox12.Text = gv.Rows[rownumber].Cells[5].Value.ToString();
            textBox11.Text = gv.Rows[rownumber].Cells[6].Value.ToString();
            textBox9.Text = gv.Rows[rownumber].Cells[7].Value.ToString();
            textBox16.Text = gv.Rows[rownumber].Cells[8].Value.ToString();
            textBox15.Text = gv.Rows[rownumber].Cells[9].Value.ToString();
            textBox14.Text = gv.Rows[rownumber].Cells[10].Value.ToString();
            textBox13.Text = gv.Rows[rownumber].Cells[11].Value.ToString();
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

        private void DisplayGrid()
        {
            SetGrid();
            AmountStu();
        }
        private void SetGrid()
        {
            var query = GetXMLData();

            gv.DataSource = query;

            int rownumber = 1;
            textBox7.Text = gv.Rows[rownumber].Cells[0].Value.ToString();
            textBox8.Text = gv.Rows[rownumber].Cells[1].Value.ToString();
            textBox10.Text = gv.Rows[rownumber].Cells[2].Value.ToString();
            textBox6.Text = gv.Rows[rownumber].Cells[3].Value.ToString();
            textBox5.Text = gv.Rows[rownumber].Cells[4].Value.ToString();
            textBox12.Text = gv.Rows[rownumber].Cells[5].Value.ToString();
            textBox11.Text = gv.Rows[rownumber].Cells[6].Value.ToString();
            textBox9.Text = gv.Rows[rownumber].Cells[7].Value.ToString();
            textBox16.Text = gv.Rows[rownumber].Cells[8].Value.ToString();
            textBox15.Text = gv.Rows[rownumber].Cells[9].Value.ToString();
            textBox14.Text = gv.Rows[rownumber].Cells[10].Value.ToString();
            textBox13.Text = gv.Rows[rownumber].Cells[11].Value.ToString();
        }
        private List<Student> GetXMLData()
        {
            var xDoc = XDocument.Load("./data.xml");
            var query = (from student in xDoc.Descendants("Student")
                         select new Student()
                         {
                             ID = Convert.ToInt64(student.Element("ID").Value),
                             Name = student.Element("Name").Value,
                             Gender = student.Element("Gender").Value,                     
                             StuClass = student.Element("Class").Value,                           
                             School = student.Element("School").Value,
                             Region = student.Element("Region").Value,
                             Type = student.Element("Type").Value,
                             Health = student.Element("Health").Value,
                             IDCard = Convert.ToInt64(student.Element("IDCard").Value),
                             StuDate = Convert.ToDateTime(student.Element("Date").Value),
                             PostNum = Convert.ToInt64(student.Element("PostNum").Value),
                             PhoneNum = Convert.ToInt64(student.Element("Phone").Value)
                         }).ToList();
            return query;
        }

        private void AmountStu()
        {
            int stuNum = gv.RowCount;
            int boyNum = 0;
            for (int i = 0; i < stuNum; i++)
            {
                if (Convert.ToString(gv.Rows[i].Cells[2].Value) == "Male")
                {
                    boyNum++;
                }
            }
            int girlNum = stuNum - boyNum;

            textBox17.Text = Convert.ToString(stuNum);
            textBox19.Text = Convert.ToString(boyNum);
            textBox18.Text = Convert.ToString(girlNum);
        }

        private void AddDoc()
        {

            var xDoc = XDocument.Load("./data.xml");
            XElement nodeXML = new XElement("Student");
            var root = xDoc.Element("Root");
            nodeXML.Add(new XElement("Name", textBox7.Text));
            nodeXML.Add(new XElement("ID", textBox8.Text));
            nodeXML.Add(new XElement("Gender", textBox10.Text));
            nodeXML.Add(new XElement("Class", textBox6.Text));
            nodeXML.Add(new XElement("School", textBox5.Text));
            nodeXML.Add(new XElement("Region", textBox12.Text));
            nodeXML.Add(new XElement("Type", textBox11.Text));
            nodeXML.Add(new XElement("Health", textBox9.Text));
            nodeXML.Add(new XElement("IDCard", textBox16.Text));
            nodeXML.Add(new XElement("Date", textBox15.Text));
            nodeXML.Add(new XElement("PostNum", textBox14.Text));
            nodeXML.Add(new XElement("Phone", textBox13.Text));
            root.Add(nodeXML);
            xDoc.Save("./data.xml");
            DisplayGrid();
        }

        private void DelDoc(int RowNum)
        {
            var xDoc = XDocument.Load("./data.xml");
            var stu = xDoc.Descendants("Student").ElementAt(RowNum);
            stu.Remove();
            xDoc.Save("./data.xml");
            DisplayGrid();
        }

        private void Search(string thing)
        {

            var xDoc = XDocument.Load("./data.xml");
            var query = (from student in xDoc.Descendants("Student")
                         where student.Element("Name").Value == thing
                         select new Student()
                         {
                             ID = Convert.ToInt64(student.Element("ID").Value),
                             Name = student.Element("Name").Value,
                             Gender = student.Element("Gender").Value,
                             StuClass = student.Element("Class").Value,
                             School = student.Element("School").Value,
                             Region = student.Element("Region").Value,
                             Type = student.Element("Type").Value,
                             Health = student.Element("Health").Value,
                             IDCard = Convert.ToInt64(student.Element("IDCard").Value),
                             StuDate = Convert.ToDateTime(student.Element("Date").Value),
                             PostNum = Convert.ToInt64(student.Element("PostNum").Value),
                             PhoneNum = Convert.ToInt64(student.Element("Phone").Value)
                         }).ToList();
            gv.DataSource = query;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowNum = gv.CurrentCell.RowIndex;
            DelDoc(rowNum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDoc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowNum = gv.CurrentCell.RowIndex;
            DelDoc(rowNum);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
