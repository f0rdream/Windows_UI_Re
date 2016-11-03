using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Windows_UI_Re
{
    public partial class MainForm : Form
    {
        private string dataPath = "./data.xml";
        private void SetGrid()
        {
            var query = GetXMLData();

            gv.DataSource = query;

            int rownumber = 1;
            nameBox.Text = gv.Rows[rownumber].Cells[0].Value.ToString();
            IDBox.Text = gv.Rows[rownumber].Cells[1].Value.ToString();
            genderBox.Text = gv.Rows[rownumber].Cells[2].Value.ToString();
            classBox.Text = gv.Rows[rownumber].Cells[3].Value.ToString();
            schoolBox.Text = gv.Rows[rownumber].Cells[4].Value.ToString();
            regionBox.Text = gv.Rows[rownumber].Cells[5].Value.ToString();
            typeBox.Text = gv.Rows[rownumber].Cells[6].Value.ToString();
            healthBox.Text = gv.Rows[rownumber].Cells[7].Value.ToString();
            IDCardBox.Text = gv.Rows[rownumber].Cells[8].Value.ToString();
            dateBox.Text = gv.Rows[rownumber].Cells[9].Value.ToString();
            postBox.Text = gv.Rows[rownumber].Cells[10].Value.ToString();
            phoneBox.Text = gv.Rows[rownumber].Cells[11].Value.ToString();
        }
        private void DisplayGrid()
        {
            SetGrid();
            AmountStu();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rownumber = gv.CurrentCell.RowIndex;
            nameBox.Text = gv.Rows[rownumber].Cells[0].Value.ToString();
            IDBox.Text = gv.Rows[rownumber].Cells[1].Value.ToString();
            genderBox.Text = gv.Rows[rownumber].Cells[2].Value.ToString();
            classBox.Text = gv.Rows[rownumber].Cells[3].Value.ToString();
            schoolBox.Text = gv.Rows[rownumber].Cells[4].Value.ToString();
            regionBox.Text = gv.Rows[rownumber].Cells[5].Value.ToString();
            typeBox.Text = gv.Rows[rownumber].Cells[6].Value.ToString();
            healthBox.Text = gv.Rows[rownumber].Cells[7].Value.ToString();
            IDCardBox.Text = gv.Rows[rownumber].Cells[8].Value.ToString();
            dateBox.Text = gv.Rows[rownumber].Cells[9].Value.ToString();
            postBox.Text = gv.Rows[rownumber].Cells[10].Value.ToString();
            phoneBox.Text = gv.Rows[rownumber].Cells[11].Value.ToString();
        }
        private List<Student> GetXMLData()
        {
            var xDoc = XDocument.Load(dataPath);
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
        private void AddDoc()
        {

            var xDoc = XDocument.Load(dataPath);
            XElement nodeXML = new XElement("Student");
            var root = xDoc.Element("Root");
            nodeXML.Add(new XElement("Name", nameBox.Text));
            nodeXML.Add(new XElement("ID", IDBox.Text));
            nodeXML.Add(new XElement("Gender", genderBox.Text));
            nodeXML.Add(new XElement("Class", classBox.Text));
            nodeXML.Add(new XElement("School", schoolBox.Text));
            nodeXML.Add(new XElement("Region", regionBox.Text));
            nodeXML.Add(new XElement("Type", typeBox.Text));
            nodeXML.Add(new XElement("Health", healthBox.Text));
            nodeXML.Add(new XElement("IDCard", IDCardBox.Text));
            nodeXML.Add(new XElement("Date", dateBox.Text));
            nodeXML.Add(new XElement("PostNum", postBox.Text));
            nodeXML.Add(new XElement("Phone", phoneBox.Text));
            root.Add(nodeXML);
            xDoc.Save(dataPath);
            DisplayGrid();
        }
        private void DelDoc(int RowNum)
        {
            var xDoc = XDocument.Load(dataPath);
            var stu = xDoc.Descendants("Student").ElementAt(RowNum);
            stu.Remove();
            xDoc.Save(dataPath);
            DisplayGrid();
        }
        private void Search(string thing)
        {

            var xDoc = XDocument.Load(dataPath);
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
    }
}
