using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nol_Adin_Sabirov.Misc;
using Nol_Adin_Sabirov.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol_Adin_Sabirov.Pages.Tests
{
    [TestClass()]
    public class SpravochnayaTableTests
    {
        [TestMethod()]
        public void CheckSpravochanyaTest()
        {
            Spravochnaya c = new Spravochnaya { IdReys = 6, NameReys = "Россия-Бтпит" };
            bool excepted = true;
            bool actual = SpravochnayaAdd.CheckClient(c);
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod()]
        public void CheckNullSpravochnayaTest()
        {
            Spravochnaya c = new Spravochnaya { IdReys = 6, NameReys = "" };
            bool excepted = false;
            bool actual = SpravochnayaAdd.CheckClient(c);
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod()]
        public void CheckDigitSpravochnayaTest() 
        {
            Spravochnaya c = new Spravochnaya { IdReys = 6, NameReys = "Россия-Бтпит404" };
            bool excepted = false;
            bool actual = SpravochnayaAdd.CheckClient(c);
            Assert.AreEqual(excepted, actual);
        }
    }
}