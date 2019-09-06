using System;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WohooDigitalProject.News.Bussiness.Abstract;
using WohooDigitalProject.News.Bussiness.Concrete.EntityFramework;
using WohooDigitalProject.News.DataAccess.Abstract;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void UserValidationCheck()
        {
            Mock<IUserDal> mock = new Mock<IUserDal>();
            Mock<IValidator<User>> mock2 = new Mock<IValidator<User>>();
            EFUserService userManager = new EFUserService(mock.Object,mock2.Object);
            userManager.Add(new User() { Id = 1, EMail = "mail@mail.com" });
        }
    }
}
