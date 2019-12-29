using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Tests.BusinessTests
{
    [TestClass]
    public class UserBusinessTest : DefaultTestClass
    {
        //public UserBusinessTest() : base()
        //{

        //}
        //[TestMethod]
        //public void InsertNewUser()
        //{
        //    var userViewModel = new User()
        //    {
        //        FullName = "Marcio Cesar Gonzaga",
        //        Email = "marcio.c.gonzaga@gmail.com-teste",
        //        Password = "123456",
        //        ConfirmedEmail = true,
        //        CreateDate = DateTime.Now,
        //        Blocked = false
        //    };
        //    var userBusiness = container.Resolve<IUserBusinessClass>();
        //    var TestUser = userBusiness.Insert(userViewModel);

        //}
        //[TestMethod]
        //public void UpdateUser()
        //{

        //    try
        //    {
        //        var userBusiness = container.Resolve<IUserBusinessClass>();
        //        var TestUser = userBusiness.GetByEmail("marcio.c.gonzaga@gmail.com-teste");
        //        TestUser.Email = "marcio.c.gonzaga@gmail.com-123";
        //        TestUser.FullName = "Altered User";
        //        TestUser = userBusiness.Update(TestUser);
        //    }
        //    catch (Microsoft.EntityFrameworkCore.DbUpdateException due)
        //    {
        //        Assert.IsFalse(true, due.GetBaseException().Message);
        //    }

        //}
        //[TestMethod]
        //public void GetUserByEmail()
        //{
        //    var userBusiness = container.Resolve<IUserBusinessClass>();
        //    var TestUser = userBusiness.GetByEmail("marcio.c.gonzaga@gmail.com-123");
        //    Assert.IsTrue(!String.IsNullOrEmpty(TestUser.Email));

        //}
        //[TestMethod]
        //public void GetUserById()
        //{
        //    int id = 295113;
        //    try
        //    {

        //        var userBusiness = container.Resolve<IUserBusinessClass>();
        //        var user = userBusiness.GetByEmail("marcio.c.gonzaga@gmail.com-123");
        //        if (user == null) throw new Exception("User Not Found");
        //        User TestUser = userBusiness.GetById(user.Id);
        //        Assert.IsTrue(TestUser.Id > 0);

        //    }
        //    catch (Exception ex)
        //    {
        //        //Assert.IsFalse(true, $"User:{id} not Found on database");
        //        Assert.IsFalse(true, ex.Message);
        //    }
        //}
        //[TestMethod]
        //public void DeleteUser()
        //{
        //    var userBusiness = container.Resolve<IUserBusinessClass>();
        //    var id = userBusiness.GetByEmail("marcio.c.gonzaga@gmail.com-123").Id;
        //    userBusiness.Delete(id);

        //}
    }
}
