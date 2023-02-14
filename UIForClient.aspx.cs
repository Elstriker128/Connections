using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Connections
{
    public partial class UIForClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> AllStudents = InOutUtils.ReadStudents(Server.MapPath("~/Required_Data/U31DUOM.txt"));
            List<Pairs> AllPairs = InOutUtils.ReadPairs(Server.MapPath("~/Required_Data/U32DUOM.txt"));

            FirstFileDataOutput(AllStudents);
            SecondFileDataOutput(AllPairs);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Student> AllStudents = InOutUtils.ReadStudents(Server.MapPath("~/Required_Data/U31DUOM.txt"));
            List<Pairs> AllPairs= InOutUtils.ReadPairs(Server.MapPath("~/Required_Data/U32DUOM.txt"));

            TaskUtils.FindFriendsFromBoth(AllStudents, AllPairs);

            PrintResult(AllPairs);

            InOutUtils.PrintOriginalData1ToTxt(AllStudents, Server.MapPath("~/Required_Data/U3REZ.txt"));
            InOutUtils.PrintOriginalData2ToTxt(AllPairs, Server.MapPath("~/Required_Data/U3REZ.txt"));
            InOutUtils.PrintResult(AllPairs, Server.MapPath("~/Required_Data/U3REZ.txt"));
        }
        private void FirstFileDataOutput(List<Student> AllStudents)
        {
            TableRow frow = new TableRow();

            TableCell fname = new TableCell();
            fname.Text = "Name";

            TableCell fcount = new TableCell();
            fcount.Text = "Count";

            TableCell fknownStud = new TableCell();
            fknownStud.Text = "Known students";

            frow.Cells.Add(fname);
            frow.Cells.Add(fcount);
            frow.Cells.Add(fknownStud);

            Table1.Rows.Add(frow);

            for (int i = 0; i < AllStudents.Count(); i++)
            {
                TableRow row = new TableRow();

                TableCell name = new TableCell();
                name.Text = AllStudents[i].Name;

                TableCell count = new TableCell();
                count.Text = AllStudents[i].KnownCount.ToString();


                TableCell knownStud = new TableCell();

                for (int j = 0; j < AllStudents[i].KnownCount; j++)
                {
                    knownStud.Text += AllStudents[i].KnownStudents[j] + " ";
                }

                row.Cells.Add(name);
                row.Cells.Add(count);
                row.Cells.Add(knownStud);

                Table1.Rows.Add(row);
            }
        }
        private void SecondFileDataOutput(List<Pairs> AllPairs)
        {
            TableRow frow = new TableRow();

            TableCell fname1 = new TableCell();
            fname1.Text = "Name of the first student";

            TableCell fname2 = new TableCell();
            fname2.Text = "Name of the second student";

            frow.Cells.Add(fname1);
            frow.Cells.Add(fname2);

            Table2.Rows.Add(frow);

            for (int i = 0; i < AllPairs.Count(); i++)
            {
                TableRow row = new TableRow();

                TableCell name1 = new TableCell();
                name1.Text = AllPairs[i].Name1;

                TableCell name2 = new TableCell();
                name2.Text = AllPairs[i].Name2;

                row.Cells.Add(name2); 
                row.Cells.Add(name1);

                Table2.Rows.Add(row);
            }
        }
        private void PrintResult(List<Pairs> AllPairs)
        {
            TableRow frow = new TableRow();
            
            TableCell fanswer = new TableCell();
            fanswer.Text = "Result";

            frow.Cells.Add (fanswer);

            Table3.Rows.Add(frow);

            for (int i = 0; i < AllPairs.Count(); i++)
            {
                TableRow row = new TableRow();

                TableCell answer = new TableCell();
                answer.Text = AllPairs[i].Full;

                row.Cells.Add(answer);

                Table3.Rows.Add(row);
            }
        }
    }
}