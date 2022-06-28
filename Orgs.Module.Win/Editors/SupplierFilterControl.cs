using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orgs.Module.Win.Editors
{
    public partial class SupplierFilterControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SupplierFilterControl()
        {
            InitializeComponent();
        }
        public event Action ApplyFilter = delegate { };
        private void buttonOK_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
