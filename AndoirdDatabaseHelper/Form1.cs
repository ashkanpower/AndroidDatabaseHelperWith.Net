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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        JavaClass theClass;

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            if (txtClass.Text.Length > 0)
            {
                try
                {
                    theClass = new JavaClass(txtClass.Text);
                    gbClass.Enabled = true;

                    txtClassName.Text = theClass.TableName;

                    clAttributes.Items.Clear();
                    cbPK.Items.Clear();

                    foreach (JavaAttr attr in theClass.Attributes)
                    {

                        clAttributes.Items.Add(attr, true);

                        if (attr.SqlType == SqliteType.INTEGER)
                        {
                            cbPK.Items.Add(attr);
                        }
                    }

                    cbPK.SelectedIndex = 0;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("the class is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



        private void btnCreateQuery_Click(object sender, EventArgs e)
        {

            JavaAttr pk = cbPK.SelectedItem as JavaAttr;
            pk.IsPrimaryKey = true;

            foreach (var item in clAttributes.CheckedItems)
            {
                JavaAttr attr = item as JavaAttr;
                attr.IsEffective = true;

            }

            FrmQuery frm = new FrmQuery(theClass);
            frm.ShowDialog(this);
        }

        private void btnAddAttr_Click(object sender, EventArgs e)
        {
            FrmAddAttr frm = new FrmAddAttr(theClass);

            frm.ShowDialog();

            if (frm.SelectedAttr != null)
            {
                theClass.Attributes.Add(frm.SelectedAttr);

                clAttributes.Items.Add(frm.SelectedAttr, true);

                if (frm.SelectedAttr.Type == "int")
                    cbPK.Items.Add(frm.SelectedAttr);

            }

        }

        private void clAttributes_SelectedValueChanged(object sender, EventArgs e)
        {
            JavaAttr attr = clAttributes.SelectedItem as JavaAttr;
            attr.IsEffective = true;
        }
    }
}
