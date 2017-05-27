using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class JobAd
    {
        public string JobDescription { get; set; }
        public string SearchFeature { get; set; }
        public Heap heap { get; set; }
        public JobAd()
        {
            heap = new Heap(15);
        }

        public void AddPersonel(Person person)
        {
            if(!heap.ControlApplication(person))
            {
                double relevance = GetRandomNumber(0.0, 10.0);
                person.relevanceJob = relevance;
                heap.Insert(person);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Onceden basvurdugunuz ise tekrar basvuramazsiniz.");
            }
        }
        public double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
