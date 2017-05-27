using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class BinarySearch
    {
        private BinarySearchTreeNode root;
        private string nodes;
        public BinarySearch()
        {
        }
        public BinarySearch(BinarySearchTreeNode root)
        {
            this.root = root;
        }
        public int NodeCount()
        {
            return NodeCount(root);
        }
        private int NodeCount(BinarySearchTreeNode node)
        {
            int count = 0;
            if (node != null)
            {
                count = 1;
                count += NodeCount(node.Left) + NodeCount(node.Right);
            }
            return count;
        }
        public int LeafCount()
        {
            return LeafCount(root);
        }
        private int LeafCount(BinarySearchTreeNode dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                if ((dugum.Left == null) && (dugum.Right == null))
                    count = 1;
                else
                    count = count + LeafCount(dugum.Left) + LeafCount(dugum.Right);
            }
            return count;
        }
        public int Deep()
        {
            return Deep(root);
        }
        private int Deep(BinarySearchTreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int LeftDeep= Deep(root.Left);
                int RightDeep= Deep(root.Right);
                if (LeftDeep> RightDeep)
                    return (LeftDeep + 1);
                else
                    return (RightDeep + 1);
            }
        }

        public string PrintNodes()
        {
            return nodes;
        }
        public void KnowEnglish()
        {
            nodes = "";
            KnowEnglish(root);
        }
        private void KnowEnglish(BinarySearchTreeNode node)
        {
            if (node == null)
                return;
            VisitEnglish(node);
            KnowEnglish(node.Left);
            KnowEnglish(node.Right);
        }
        public void AverageList()
        {
            nodes = "";
            AverageList(root);
        }
        private void AverageList(BinarySearchTreeNode node)
        {
            if (node == null)
                return;
            VisitAverage(node);
            AverageList(node.Left);
            AverageList(node.Right);
        }
        public void PreOrder()
        {
            nodes = "";
            PreOrder(root);
        }
        private void PreOrder(BinarySearchTreeNode node)
        {
            if (node == null)
                return;
            Visit(node);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
        public void InOrder()
        {
            nodes = "";
            InOrder(root);
        }
        private void InOrder(BinarySearchTreeNode node)
        {
            if (node == null)
                return;
            InOrder(node.Left);
            Visit(node);
            InOrder(node.Right);
        }
        private void Visit(BinarySearchTreeNode node)
        {
            nodes += node.Data.Name + " " + node.Data.Address + " " + node.Data.DateOfBirth+ " " + node.Data.PlaceOfBirth+ " " + node.Data.statusEdu.GradSchool+ " " + node.Data.statusEdu.Average.ToString() + " " + node.Data.workplace.Name + " " + node.Data.workplace.Mission+ "/";
        }
        private void VisitEnglish(BinarySearchTreeNode node)
        {
            if (node.Data.ForeignLanguage == "ingilizce")
                nodes += node.Data.Name + " " + node.Data.Address + " " + node.Data.DateOfBirth+ " " + node.Data.PlaceOfBirth+ " " + node.Data.statusEdu.GradSchool+ " " + node.Data.statusEdu.Average.ToString() + " " + node.Data.workplace.Name + " " + node.Data.workplace.Mission + "/";
        }
        private void VisitAverage(BinarySearchTreeNode node)
        {
            if (node.Data.statusEdu.Average > 89)
                nodes += node.Data.Name + " " + node.Data.Address + " " + node.Data.DateOfBirth+ " " + node.Data.PlaceOfBirth+ " " + node.Data.statusEdu.GradSchool+ " " + node.Data.statusEdu.Average.ToString() + " " + node.Data.workplace.Name + " " + node.Data.workplace.Mission+ "/";
        }
        public void PostOrder()
        {
            nodes = "";
            PostOrderInt(root);
        }
        private void PostOrderInt(BinarySearchTreeNode node)
        {
            if (node == null)
                return;
            PostOrderInt(node.Left);
            PostOrderInt(node.Right);
            Visit(node);
        }
        public void Add(Person value)
        {
            BinarySearchTreeNode tempParent = new BinarySearchTreeNode();
            BinarySearchTreeNode tempSearch = root;
            while (tempSearch != null)
            {
                tempParent = tempSearch;
                if (string.Compare(value.Name, tempSearch.Data.Name) == 0)
                    return;
                else if (string.Compare(value.Name, tempSearch.Data.Name) < 0)
                    tempSearch = tempSearch.Left;

                else
                    tempSearch = tempSearch.Right;
            }
            BinarySearchTreeNode Adding = new BinarySearchTreeNode(value);
            if (root == null)
                root = Adding;
            else if (value.Name.CompareTo(tempParent.Data.Name) < 0)
                tempParent.Left = Adding;
            else
                tempParent.Right = Adding;
        }
        public BinarySearchTreeNode Search(string keyName)
        {
            return SearchInt(root, keyName);
        }
        private BinarySearchTreeNode SearchInt(BinarySearchTreeNode node, string keyName)
        {
            if (node == null)
            {
                return null;
            }
            else
            {
                Person k = (Person)node.Data;
                if (string.Compare(k.Name, keyName) == 0)
                    return node;
                else if (string.Compare(k.Name, keyName) > 0)
                    return (SearchInt(node.Left, keyName));
                else
                    return (SearchInt(node.Right, keyName));
            }
        }
        private BinarySearchTreeNode Successor(BinarySearchTreeNode removeNode)
        {
            BinarySearchTreeNode successorParent = removeNode;
            BinarySearchTreeNode successor = removeNode;
            BinarySearchTreeNode current = removeNode.Right;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }
            if (successor != removeNode.Right)
            {
                successorParent.Left = successor.Right;
                successor.Right = removeNode.Right;
            }
            return successor;
        }
        public bool Remove(BinarySearchTreeNode value)
        {
            BinarySearchTreeNode current = root;
            BinarySearchTreeNode parent = root;
            bool isLeft = true;

            while ((current.Data.Name.CompareTo(value.Data.Name) != 0))
            {
                parent = current;
                if (value.Data.Name.CompareTo(current.Data.Name) < 0)
                {
                    isLeft = true;
                    current = current.Left;
                }
                else
                {
                    isLeft = false;
                    current = current.Right;
                }
                if (current == null)
                    return false;
            }
            
            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                    root = null;
                else if (isLeft)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
           
            else if (current.Right == null)
            {
                if (current == root)
                    root = current.Left;
                else if (isLeft)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Left;
            }
            else if (current.Left == null)
            {
                if (current == root)
                    root = current.Right;
                else if (isLeft)
                    parent.Left = current.Right;
                else
                    parent.Right = current.Right;
            }
            
            else
            {
                BinarySearchTreeNode successor = Successor(current);
                if (current == root)
                    root = successor;
                else if (isLeft)
                    parent.Left = successor;
                else
                    parent.Right = successor;
                successor.Left = current.Left;
            }
            return true;
        }
    }
}
