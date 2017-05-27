using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class PersonnelController
    {
        private static List<Company> companies;
         Company company;
         static HashMapChain hash;
         public int advertNo { get; set; }
        public int currentSize { get; set; }

        public PersonnelController()
        {
            companies = new List<Company>();
            hash = new HashMapChain();
            advertNo = 100;
        }

        public void AddCompany(string address, string phone, string fax , string mail)
        {
            company = new Company { Address = address, Fax=fax , Mail=mail, Phone = phone };
            companies.Add(company);
        }

        public Company getCompany()
        {
            return this.company;
        }

        public void AddWorkPlace(Company company, string name, string address, string mission, string position)
        {
            company.workplace = new Workplace { Name=name, Address=address, Mission=mission, Position = position};
        }

        public void AddAdvert(Company company, string jobDescription, string searchFeature)
        {
            company.jobad = new JobAd { JobDescription=jobDescription , SearchFeature =searchFeature};
            if(this.company !=null)
            {
                company.Address = this.company.Address;
                company.Phone = this.company.Phone;
                company.Fax = this.company.Fax;
            }
            hash.Add(advertNo, company);
            advertNo++;
        }
        public string GetJobAdvert( int advertNo)
        {
            string temp;
            Company advert = hash.GetJobAdvert(advertNo);
            if (advert != null)
                temp = advert.workplace.Name + " " + advert.jobad.SearchFeature + " " + advert.jobad.JobDescription;
            else
                temp = "Ilan bulunamadi.";
            return temp;
        }
        public Company GetJobAdvertCast(int advertNo)
        {
            Company advert = hash.GetJobAdvert(advertNo);
            return advert;
        }
        public void JobApplication(Company company, Person person)
        {
            if (company.jobad != null)
                company.jobad.AddPersonel(person);
            else
                System.Windows.Forms.MessageBox.Show("Basvurdugunuz sirketin is ilani bulunmamaktadir.");
        }
        public void CompanyUpdate(Company company)
        {
            this.company.Address = company.Address;
            this.company.Phone = company.Phone;
            this.company.Fax = company.Fax;
            this.company.Mail = company.Mail;
        }

        public HeapNode[] JobApplicationList(int advertNo)
        {
            Company advert = getCompany();
            advert = hash.GetJobAdvert(advertNo);
            HeapNode[] HN = new HeapNode[advert.jobad.heap.heapArray.Length];
            if(advert != null)
            {
                HN = advert.jobad.heap.heapArray;
                currentSize = advert.jobad.heap.currentSize;
            }

            return HN;
        }

        public void AddPersonnel(int advertNo, string Name)
        {
            Company advert = getCompany();
            advert = hash.GetJobAdvert(advertNo);

            if (advert != null)
                advert.jobad.heap.RemovePerson(Name);
        }
    }
}
