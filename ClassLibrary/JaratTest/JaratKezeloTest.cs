using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ClassLibrary.JaratTest
{
    [TestFixture]
    class JaratKezeloTest
    {
        JaratKezelo jk;

        [SetUp]
        public void Setup()
        {
            jk = new JaratKezelo();
        }

        [Test]
        public void UjJaratUticel()
        {
            jk.UjJarat("76", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            
            Assert.AreEqual("United Kingdom",jk.Uticel("76"));
        }

        [Test]
        public void UjJaratKesesNulla()
        {
            jk.UjJarat("76", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            Assert.AreEqual(0, jk.getKeses("76"));
        }

        [Test]
        public void DuplikaltJarat()
        {
            jk.UjJarat("76", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            jk.UjJarat("176", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            Assert.AreEqual(1, jk.duplikaKeres("76"));

        }

        [Test]
        public void UjJaratIndulas()
        {
            jk.UjJarat("76", "Germany", "United Kingdom", DateTime.Parse("09:18"));

            Assert.AreEqual(DateTime.Parse("09:18"), jk.getIndulas("76"));
        }

        [Test]
        public void NegativKeses()
        {

            jk.UjJarat("76", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            jk.UjJarat("176", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            jk.setKeses("176", -10);

            Assert.Throws<HibasJaratSzamException>(
                () => {
                    var jarat = jk.getKeses("76");
                }
            );
        }

        [Test]
        public void NemLetezoUticel()
        {
            jk.UjJarat("176", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            jk.UjJarat("276", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            Assert.Throws<HibasJaratSzamException>(
                () => {
                    var jarat = jk.Uticel("Germany");                 
                }
            );
        }

        [Test]
        public void NemLetezoJaratSzam()
        {
            jk.UjJarat("176", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            jk.UjJarat("276", "Germany", "United Kingdom", DateTime.Parse("09:18"));
            Assert.Throws<HibasJaratSzamException>(
                () => {
                    var jarat = jk.getJaratSzam("76");
                }
            );
        }
    }
}
