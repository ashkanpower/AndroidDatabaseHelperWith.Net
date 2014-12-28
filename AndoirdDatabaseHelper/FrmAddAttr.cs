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
    public partial class FrmAddAttr : Form
    {
        public FrmAddAttr()
        {
            InitializeComponent();
        }

        JavaClass theClass;

        public FrmAddAttr(JavaClass theClass)
        {
            this.theClass = theClass;

            InitializeComponent();
        }

        public JavaAttr SelectedAttr { private set; get; }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            SelectedAttr = new JavaAttr(theClass, txtName.Text, cbType.Text);

            this.Close();
        }
    }
}
