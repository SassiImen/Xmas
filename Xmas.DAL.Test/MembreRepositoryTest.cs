using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmas.DAL.Models;
using Xmas.DAL.Repositories;

namespace Xmas.DAL.Test
{
    [TestClass]
    public class MembreRepositoryTest
    {
        [TestMethod]
        public void GetOneMembre()
        {
            MembreRepository Mr = new MembreRepository(@"Data Source=MIKEW10\TFTIC2014;Initial Catalog=XmasDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Membre m = Mr.GetOne(1);
            Assert.IsNotNull(m);
            Assert.AreEqual("Person", m.Nom);
          
        }

        [TestMethod]
        public void DeleteMembre()
        {
            MembreRepository Mr = new MembreRepository(@"Data Source=MIKEW10\TFTIC2014;Initial Catalog=XmasDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            bool rep= Mr.Delete(6);
            Assert.IsTrue(rep); 

        }

        public void GetAllMembre()
        {
            MembreRepository Mr = new MembreRepository(@"Data Source=MIKEW10\TFTIC2014;Initial Catalog=XmasDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            IEnumerable<Membre> m = Mr.GetAll();
            Assert.IsNotNull(m);
            Assert.IsTrue(m.ToList().Count() >= 2);
        }

        public void InsertMembre()
        {
            MembreRepository Mr = new MembreRepository(@"Data Source=MIKEW10\TFTIC2014;Initial Catalog=XmasDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Membre m = new Membre();
            m.Nom = "Gillis";
            m.Prenom = "Cédric";
            m.Surnom = "Mr Cheese";
            m.Courriel = "ced@cheese.com";
            m.MotDePasse = "Test1234=";
            m = Mr.Insert(m);
            Assert.IsTrue(m.Id != 0);
        }
    }
}
