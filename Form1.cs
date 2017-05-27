using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MezunBilgiSistemi
{
    public partial class FrmGiris : Form
    {
         static FrmOgrenci formOgrenci;
         static FrmSirket formSirket;
         public static Person person;
         public static JobController jobc = new JobController();
         public static PersonnelController personc = new PersonnelController();
         static List<string> OgrList = new List<string>();

         public void OgrEkle(string name)
         {
             OgrList.Add(name);
         }
         public List<string> OgrenciList()
         {
             return OgrList;
         }
        public void formShow()
        {
            this.Show();
        }
        public void formHide()
        {
            this.Hide();
        }
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            if (formOgrenci==null)
            {
                formOgrenci = new FrmOgrenci();    
            }
            if (formSirket == null)
            {
                formSirket = new FrmSirket();
            }

        }

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            formHide();
            formOgrenci.formShow();
        }

        private void btnSirket_Click(object sender, EventArgs e)
        {
            formHide();
            formSirket.formShow();
        }
    }
}
