using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Windows_UI_Re
{
    public partial class MainForm : Form
    {
        private string dataPath = "./data.xml";
        private List<Student> studentArr;
        
        private void SetTextBox(int rownumber = 0)
        {
            nameBox.Text = studentArr[rownumber].Name;
            IDBox.Text = studentArr[rownumber].ID.ToString();
            genderBox.Text = studentArr[rownumber].Gender;
            classBox.Text = studentArr[rownumber].StuClass;
            schoolBox.Text = studentArr[rownumber].School;
            regionBox.Text = studentArr[rownumber].Region;
            typeBox.Text = studentArr[rownumber].Type;
            healthBox.Text = studentArr[rownumber].Health;
            IDCardBox.Text = studentArr[rownumber].IDCard.ToString();
            dateBox.Text = studentArr[rownumber].StuDate.ToString();
            postBox.Text = studentArr[rownumber].PostNum.ToString();
            phoneBox.Text = studentArr[rownumber].PhoneNum.ToString();
        }
        private void DisplayGrid()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("系部", typeof(string));
            DataColumn col2 = new DataColumn("班级", typeof(string));
            DataColumn col3 = new DataColumn("学号", typeof(string));
            DataColumn col4 = new DataColumn("姓名", typeof(string));
            DataColumn col5 = new DataColumn("性别", typeof(string));
            DataColumn col6 = new DataColumn("所在校区", typeof(string));
            DataColumn col7 = new DataColumn("学生类别", typeof(string));
            
            
            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col6);
            dt.Columns.Add(col7);
            

            gv.DataSource = dt.DefaultView;
            studentArr = GetXMLData();
            for (var i = 0; i < studentArr.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = studentArr[i].School;
                dr[1] = studentArr[i].StuClass;
                dr[2] = studentArr[i].ID.ToString();
                dr[3] = studentArr[i].Name;
                dr[4] = studentArr[i].Gender;
                dr[5] = studentArr[i].Region;
                dr[6] = studentArr[i].Type;
                dt.Rows.Add(dr);
            }
            SetTextBox();
            AmountStu();
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
        private void DelDoc(int rowNum)
        {
            var xDoc = XDocument.Load(dataPath);
            var stu = xDoc.Descendants("Student").ElementAt(rowNum);
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
                if (Convert.ToString(gv.Rows[i].Cells[4].Value) == "Male")
                {
                    boyNum++;
                }
            }
            int girlNum = stuNum - boyNum;

            studentCountBox.Text = Convert.ToString(stuNum);
            boyCountBox.Text = Convert.ToString(boyNum);
            girlCountBox.Text = Convert.ToString(girlNum);
        }
        private static void bubbleSort(List<Student> unsorted)
        {
            for (int i = 0; i < unsorted.Count; i++)
            {
                for (int j = i; j < unsorted.Count; j++)
                {
                    if (unsorted[i].ID > unsorted[j].ID)
                    {
                        Student temp = unsorted[i];
                        unsorted[i] = unsorted[j];
                        unsorted[j] = temp;
                    }
                }
            }
        }

        private void displayStu()
        {
            bubbleSort(studentArr);
            String messageDis = "";
            foreach (Student item in studentArr)
            {
                messageDis += item.ID + " " + item.Name + "\n";
            }
            MessageBox.Show(messageDis);
        }
    }
}
