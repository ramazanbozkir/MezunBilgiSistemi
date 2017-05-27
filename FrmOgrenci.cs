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
    public partial class FrmOgrenci : Form
    {
        static Person person;
        static JobController jobc = new JobController();
        static PersonnelController personc = new PersonnelController();
        string OldUserName = "";
        static FrmGiris frmgiris;
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        public void formShow()
        {
            this.Show();
        }
        public void formHide()
        {
            this.Hide();
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            formHide();
            frmgiris.formShow();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            if (frmgiris==null)
            {
                frmgiris = new FrmGiris();    
            }
            
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
        

        private void btnVericek_Click(object sender, EventArgs e)
        {
            BinarySearchTreeNode bstn = jobc.SearchPerson(txtWhois.Text);
            if (bstn == null)
                MessageBox.Show("Aranan kişi bulunamadı...");
            else
            {
                Person person = (Person)bstn.Data;
                txtUpName.Text = person.Name;
                OldUserName = person.Name;
                txtUpAddress.Text = person.Address;
                txtUpMail.Text = person.Mail;
                txtUpPhone.Text = person.Phone;
                txtUpPlaceofBirth.Text = person.PlaceOfBirth;
                txtUpDateofBirth.Text = person.DateOfBirth;
                txtUpMaritalStatus.Text = person.MaritalStatus;
                txtUpForeignLanguage.Text = person.ForeignLanguage;
                txtUpReference.Text = person.Reference;
                txtUpAreasOfInterest.Text = person.AreasOfInterest;

                txtUpGradSchool.Text = person.statusEdu.GradSchool;

                txtUpStartYear.Text = person.statusEdu.StartYear;
                txtUpEndYear.Text = person.statusEdu.EndYear;
                txtUpAverage.Text = person.statusEdu.Average.ToString();
                txtUpDepartman.Text = person.statusEdu.Departman; ;

                txtUpOldWorkplace.Text = person.workplace.Name;
                txtUpWorkplaceAddress.Text = person.workplace.Address;
                txtUpPosition.Text = person.workplace.Position;
                txtUpMission.Text = person.workplace.Mission;
            }
        }

        private void btnKisiGuncelle_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            BinarySearchTreeNode bstn = jobc.SearchPerson(OldUserName);
            jobc.RemovePerson(bstn);
            person.Name = txtUpName.Text;
            person.Address = txtUpAddress.Text;
            person.Mail = txtUpMail.Text;
            person.Phone = txtUpPhone.Text;
            person.Nationality = txtUpNationality.Text;
            person.PlaceOfBirth = txtUpPlaceofBirth.Text;
            person.DateOfBirth = txtUpDateofBirth.Text;
            person.MaritalStatus = txtUpMaritalStatus.Text;
            person.AreasOfInterest = txtUpAreasOfInterest.Text;
            person.Reference = txtUpReference.Text;
            person.ForeignLanguage = txtUpForeignLanguage.Text;

            person.statusEdu = new StatusEdu();
            person.statusEdu.StartYear = txtUpStartYear.Text;
            person.statusEdu.EndYear= txtUpEndYear.Text;
            person.statusEdu.Departman = txtUpDepartman.Text;
            person.statusEdu.GradSchool= txtUpGradSchool.Text;
            person.statusEdu.Average = Convert.ToDouble(txtUpAverage.Text);

            person.workplace= new Workplace();
            person.workplace.Name= txtUpOldWorkplace.Text;
            person.workplace.Address = txtUpWorkplaceAddress.Text;
            person.workplace.Mission = txtUpMission.Text;
            person.workplace.Position = txtUpPosition.Text;
            jobc.LinkedListAddEdu(person.statusEdu);
            jobc.LinkedListAddWorkplace(person.workplace);
            jobc.AddPerson(person);
            textClean(this);
            listKisi.Items.Remove(OldUserName);
            listKisi.Items.Add(person.Name);
           
            MessageBox.Show("Güncelleme başarılı");
        }

        private void btnKisiSil_Click(object sender, EventArgs e)
        {
            string personName = txtKisiAdiSil.Text;
            BinarySearchTreeNode bstn = jobc.SearchPerson(personName);
            if (bstn == null)
                MessageBox.Show("Aranan kişi bulunamadı...");
            else
            {
                if (jobc.RemovePerson(bstn))
                {
                    listKisi.Items.Remove(personName);
                    for (int i = 100; i < personc.advertNo; i++)
                    {
                        personc.AddPersonnel(i, personName);
                    }

                    MessageBox.Show("Kişi siindi.");
                }
                else
                    MessageBox.Show("Kişi silinemedi...");

            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Name = txtName.Text;
            person.Address = txtAddress.Text;
            person.Mail = txtMail.Text;
            person.Phone = txtPhone.Text;
            person.Nationality = txtNationality.Text;
            person.PlaceOfBirth = txtPlaceofBirth.Text;
            person.DateOfBirth = txtDateofBirth.Text;
            person.MaritalStatus = txtMaritalStatus.Text;
            person.AreasOfInterest = txtAreasOfInterest.Text;
            person.Reference = txtReference.Text;
            person.ForeignLanguage = txtForeignLanguage.Text;

            person.statusEdu = new StatusEdu();
            person.statusEdu.StartYear = txtStartYear.Text;
            person.statusEdu.EndYear = txtEndYear.Text;
            person.statusEdu.Departman = txtDepartman.Text;
            person.statusEdu.GradSchool = txtGradSchool.Text;
            person.statusEdu.Average = Convert.ToDouble(txtAverage.Text);

            person.workplace = new Workplace();
            person.workplace.Name = txtOldWorkplace.Text;
            person.workplace.Address = txtOldAddress.Text;
            person.workplace.Mission = txtMission.Text;
            person.workplace.Position = txtPosition.Text;
            jobc.LinkedListAddEdu(person.statusEdu);
            jobc.LinkedListAddWorkplace(person.workplace);
            jobc.AddPerson(person);
            MessageBox.Show("kayıt işlemi başarılı");
            textClean(this);
            listKisi.Items.Add(person.Name);
            frmgiris.OgrEkle(person.Name);
        }
    }


}
