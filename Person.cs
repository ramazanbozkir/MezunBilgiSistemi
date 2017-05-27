using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string PlaceOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string ForeignLanguage { get; set; }
        public string AreasOfInterest { get; set; }
        public string Reference { get; set; }
        public double relevanceJob { get; set; }
        public StatusEdu statusEdu { get; set; }
        public Workplace workplace { get; set; }
        
    }
}
