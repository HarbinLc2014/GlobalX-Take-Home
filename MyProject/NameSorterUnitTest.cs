using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    [TestFixture]
    class NameSorterUnitTest
    {
        [TestCase]
        public void LastNameMoveToHeadForArray()
        {
            //  string[] sample = {"Janet Parsons", "Vaughn Lewis" ,"Adonis Julius Archer" ,"Shelby Nathan Yoder" ,"Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter"};
            string[] sample = {"Janet Parsons", "Vaughn Lewis" ,"Adonis Julius Archer" ,"Shelby Nathan Yoder" ,"Marin Alvarez"};
            string[] result = Namesorter.GetLastFirstArray(sample);
            string[] expected = { "Parsons Janet", "Lewis Vaughn", "Archer Adonis Julius", "Yoder Shelby Nathan", "Alvarez Marin" };
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase]
        public void FirstNameMoveToHeadForArray()
        {
            string[] sample = { "Parsons Janet", "Lewis Vaughn", "Archer Adonis Julius", "Yoder Shelby Nathan", "Alvarez Marin" };
            string[] expected = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez" };
            string[] result = Namesorter.GetFirstLastArray(sample);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase]
        public void CopyWholeArray()
        {
            string[] sample = {"Archer", "Adonis", "Julius" };
            string[] expected = { "Archer", "Adonis", "Julius" };
            string[] result = Namesorter.Slice(sample, 0, sample.Length);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase]
        public void CopyPartArray()
        {
            string[] sample = { "Archer", "Adonis", "Julius" };
            string[] expected = { "Adonis", "Julius" };
            string[] result = Namesorter.Slice(sample, 1, 3);
            Assert.That(result, Is.EqualTo(expected));
        }


        [TestCase]
        public void CopyNoElementsFromArray()
        {
            string[] sample = { "Archer", "Adonis", "Julius", "Jane", "Michael" };
            string[] expected = { };
            string[] result = Namesorter.Slice(sample, 0, 0);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase]
        public void CopyNegativeIndexFromArray()
        {
            string[] sample = { "Archer", "Adonis", "Julius", "Jane", "Michael" };
            string[] expected = { "Julius", "Jane" };
            string[] result = Namesorter.Slice(sample, 2, -1);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase]
        public void FirstNameMoveToHeadForString()
        {
            string sample = "Archer Adonis Julius";
            string expected = "Adonis Julius Archer";
            string result = Namesorter.GetFirstLastName(sample);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase]
        public void LastNameMoveToHeadForString()
        {
            string sample = "Adonis Julius Archer";
            string expected = "Archer Adonis Julius";
            string result = Namesorter.GetLastFirstName(sample);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
