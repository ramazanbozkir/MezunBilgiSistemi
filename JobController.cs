using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class JobController
    {
        private static BinarySearch binarySearch;
        private static LinkedList linkedlistWorkPlace;
        private static LinkedList linkedlistStatusEdu;
         Person person;

        public JobController()
        {
            binarySearch = new BinarySearch();
            linkedlistStatusEdu = new LinkedList();
            linkedlistWorkPlace = new LinkedList();
            person = new Person();
        }

        public string preOrderList()
        {
            binarySearch.PreOrder();
            return binarySearch.PrintNodes();
        }

        public string inOrderList()
        {
            binarySearch.InOrder();
            return binarySearch.PrintNodes();
        }

        public string postOrderList()
        {
            binarySearch.PostOrder();
            return binarySearch.PrintNodes();
        }
        public string KnowEnglish()
        {
            binarySearch.KnowEnglish();
            return binarySearch.PrintNodes();
        }
        public string AverageList()
        {
            binarySearch.AverageList();
            return binarySearch.PrintNodes();
        }

        public void AddPerson(Person person)
        {
            binarySearch.Add(person);
        }

        public BinarySearchTreeNode SearchPerson(string name)
        {
            BinarySearchTreeNode BSTN = binarySearch.Search(name);
            if (BSTN == null)
                return null;
            return BSTN;
        }
        public void LinkedListAddWorkplace(Workplace wp)
        {
            wp = new Workplace();
            if (linkedlistWorkPlace.Head == null)
                linkedlistWorkPlace.InsertFirst(wp);
            else
                linkedlistWorkPlace.InsertLast(wp);
        }
        public void LinkedListAddEdu(StatusEdu se)
        {
            se = new StatusEdu();
            if (linkedlistStatusEdu.Head == null)
                linkedlistStatusEdu.InsertFirst(se);
            else
                linkedlistStatusEdu.InsertLast(se);
        }
        public Person GetPerson (Person person)
        {
            return person;
        }

        public void PersonUpdate(Person person)
        {
            this.person.Name = person.Name;
            this.person.statusEdu = new StatusEdu();
            this.person.statusEdu.Average = person.statusEdu.Average;
        }

        public void PersonList()
        {
            binarySearch.PostOrder();
        }
        public bool RemovePerson(BinarySearchTreeNode person)
        {
            return binarySearch.Remove(person);
        }

        public int NodeCount()
        {
            return binarySearch.NodeCount();
        }
        public int DeepCount()
        {
            return binarySearch.Deep();
        }

    }
}
