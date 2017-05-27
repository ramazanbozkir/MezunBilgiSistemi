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
    public partial class FrmSirket : Form
    {
        static Person person;
        static JobController jobc = new JobController();
        static PersonnelController personc = new PersonnelController();

        static int advertNo;
        static string OldPersonName = "";
        
        static FrmGiris formGiris;
        static FrmOgrenci formOgrenci;

        public void formShow()
        {
            this.Show();
        }
        public void formHide()
        {
            this.Hide();
        }

        public FrmSirket()
        {
            InitializeComponent();
        }
        public void textClean(Control clt)
        {
            foreach (Control item in clt.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Clear();
                if (item.Controls.Count > 0)
                    textClean(item);
            }
        }
        
       
       

        private void btnIseAl_Click(object sender, EventArgs e)
        {
            string select = ilanBasvurulariListele.GetItemText(ilanBasvurulariListele.SelectedItem);
            
            string[] Name = select.Split(' ');
            string personName = "";
            foreach (string i in Name)
            {
                personName = i;
                break;
            }
            personc.AddPersonnel(advertNo, personName);
            MessageBox.Show(select + "\nİş başvurunuz kabul edilmiştir.");

            ilanBasvurulariListele.Items.Remove(ilanBasvurulariListele.SelectedItem);
        }

        private void btnIseBasvur_Click(object sender, EventArgs e)
        {
            advertNo = IsIlaniListesi.SelectedIndex; 
            advertNo += 100;
            Company c = personc.GetJobAdvertCast(advertNo);
            if (person == null)
                MessageBox.Show("Kişi seçmediniz.");
            else
            {
                personc.JobApplication(c, person);
                ListReference();
                MessageBox.Show("başvuru yapıldı");
            }
        }

        private void btnListeleme_Click(object sender, EventArgs e)
        {
            listListeleme.Items.Clear();
            BinarySearchTreeNode BSTN= jobc.SearchPerson(txtNameInfo.Text);
            if (BSTN== null)
                MessageBox.Show("Aranan kişi bulunamadı...");
            else
            {
                Person person= BSTN.Data;
                string s = person.Name+ " " + person.Address+ " " + person.DateOfBirth + " " + person.PlaceOfBirth+ " " + person.statusEdu.Departman+ " " + person.ForeignLanguage;
                listListeleme.Items.Add(s);
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            listListeleme.Items.Clear();
            string s = jobc.postOrderList();
            string[] str = s.Split('/');
            foreach (string i in str)
            {
                listListeleme.Items.Add(i);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            listListeleme.Items.Clear();
            string s = jobc.inOrderList();
            string[] str = s.Split('/');
            foreach (string i in str)
            {
                listListeleme.Items.Add(i);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            listListeleme.Items.Clear();
            string s = jobc.preOrderList();
            string[] str = s.Split('/');
            foreach (string i in str)
            {
                listListeleme.Items.Add(i);
            }
        }

        private void btnDugumSayisi_Click(object sender, EventArgs e)
        {
            MessageBox.Show(jobc.NodeCount().ToString());
        }

        private void btnDerinlik_Click(object sender, EventArgs e)
        {
            MessageBox.Show(jobc.DeepCount().ToString());
        }

      
        public void ListReference()
        {
            ilanBasvurulariListele.Items.Clear();
            for (int i = 100; i < personc.advertNo; i++)
            {
                HeapNode[] HN= personc.JobApplicationList(i);
                for (int j = 0; j < personc.currentSize; j++)
                {
                    if (HN[j] != null)
                    {
                        ilanBasvurulariListele.Items.Add(HN[j].Value.Name+ " " + HN[j].Value.relevanceJob);
                    }

                }
            }
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            ListReference();
        }

        private void FrmSirket_Load(object sender, EventArgs e)
        {
            if (formGiris==null)
            {
                formGiris = new FrmGiris();
            }
            if (formOgrenci==null)
            {
                formOgrenci = new FrmOgrenci();
            }

            List<string> OgrList = formGiris.OgrenciList();
            foreach (var item in OgrList)
            {
                KisiListesi.Items.Add(item);
            }

        }

        private void listKisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            person = new Person();
            person.Name = KisiListesi.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            formHide();
            formGiris.formShow();
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            string Address, Phone, Fax, Mail;
            Address = txtCompanyAddress.Text;
            Phone = txtCompanyPhone.Text;
            Fax = txtCompanyFax.Text;
            Mail = txtCompanyMail.Text;
            personc.AddCompany(Address, Phone, Fax, Mail);
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            Company company = personc.getCompany();
            txtUpCompanyAddress.Text = company.Address;
            txtUpCompanyPhone.Text = company.Phone;
            txtUpCompanyFax.Text = company.Fax;
            txtUpCompanyMail.Text = company.Mail;
        }

        private void btnUpdateCompany_Click(object sender, EventArgs e)
        {
            Company company = personc.getCompany();
            company.Address = txtUpCompanyAddress.Text;
            company.Phone = txtUpCompanyPhone.Text;
            company.Fax = txtUpCompanyFax.Text;
            company.Mail = txtUpCompanyMail.Text;
            personc.CompanyUpdate(company);
        }

        private void btnAdvert_Click(object sender, EventArgs e)
        {
            string Name, Address, Mission, Mail, Position, JobDescription, SearchFeature;
            Company company = new Company();
            Name = txtJobAd.Text;
            Address = txtJobAddress.Text;
            Mission = txtJobMission.Text;
            Mail = txtCompanyMail.Text;
            Position = txtJobPosition.Text;
            company.workplace = new Workplace();
            personc.AddWorkPlace(company, Name, Address, Mission, Position);

            JobDescription = txtJobDescription.Text;
            SearchFeature = txtJobSearchFeature.Text;
            company.jobad = new JobAd();
            personc.AddAdvert(company, JobDescription, SearchFeature);
            textClean(this);
            IsIlaniListesi.Items.Add(personc.GetJobAdvert(personc.advertNo - 1));
        }
    }
}
