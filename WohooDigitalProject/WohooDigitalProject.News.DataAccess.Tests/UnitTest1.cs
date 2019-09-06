using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WohooDigitalProject.News.DataAccess.Concrete.EntityFramework;

namespace WohooDigitalProject.News.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void Get_all_returns_all_users()
        {
            EFUserDal userDal = new EFUserDal();
            var users = userDal.GetAll().ToList();
            Assert.AreEqual(0, users.Count());

        }
    }
}
