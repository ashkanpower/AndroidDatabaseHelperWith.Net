using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndoirdDatabaseHelper
{
    public partial class FrmQuery : Form
    {
        public JavaClass theClass { get; set; }

        public List<string> queryOrder = new List<string>(){
            "Database class sample",
            "CREATE TABLE",
            "SELECT *",
            "INSERT",
            "UPDATE",
            "DELETE",
            "GetView",
            "Sample itemView"
        };

        int queryNum = 0;

        public FrmQuery()
        {
            InitializeComponent();
        }

        public FrmQuery(JavaClass theClass)
        {
            InitializeComponent();

            this.theClass = theClass;

            ShowQuery();
        }

        public void ShowQuery(){

            lblQueryName.Text = queryOrder[queryNum];

            switch (queryNum)
            {
                case 1:
                    txtQuery.Text = QueryHelper.GenerateCreateTable(theClass);
                    break;
                case 2:
                    txtQuery.Text = QueryHelper.GenerateSelectAll(theClass);
                    break;
                case 3:
                    txtQuery.Text = QueryHelper.GenerateInsertQuery(theClass);
                    break;
                case 4:
                    txtQuery.Text = QueryHelper.GenerateUpdateQuery(theClass);
                    break;
                case 5:
                    txtQuery.Text = QueryHelper.GenerateDeleteQuery(theClass);
                    break;
                case 6:
                    txtQuery.Text = QueryHelper.GenerateGetView(theClass) + "\n\n";
                    txtQuery.Text += QueryHelper.GenerateGetItem(theClass) + "\n\n";
                    txtQuery.Text += QueryHelper.GenerateHolderClass(theClass) + "\n\n";
                    break;
                case 7:
                    txtQuery.Text = QueryHelper.GenerateSampleView(theClass);
                    break;
                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (queryOrder.Count - 1 > queryNum)
            {
                queryNum++;
                ShowQuery();

                btnPre.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (queryNum > 0)
            {
                queryNum--;
                ShowQuery();
            }
        }
    }
}
