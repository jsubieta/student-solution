using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repositories;
using Domain.Entities;

namespace Tests.Repositories
{
    [TestClass]
    public class StudentRepositoryTests
    {
        IStudentRepository repo;
        
        [TestInitialize]
        public void Setup()
        { 
            repo = new StudentRepository();
        }

        [TestCleanup]
        public void Clean()
        {
            repo.ClearStorage();
        }
        
        [TestMethod]
        public void Should_Save_And_Get_Students()
        {
            repo.Add(new Student { Gender = Domain.Entities.Gender.M, Name = "testdude", Type = Domain.Entities.StudentType.High, LastModified = DateTime.Now });
            repo.Add(new Student { Gender = Domain.Entities.Gender.F, Name = "testdude1", Type = Domain.Entities.StudentType.Kinder, LastModified = DateTime.Now });
            Assert.AreEqual(2, repo.GetAll().Count);
        }

        [TestMethod]
        public void Should_Delete_Students()
        {
            var studentToDelete = new Student { Gender = Domain.Entities.Gender.F, Name = "testdude1", Type = Domain.Entities.StudentType.Kinder, LastModified = DateTime.Now };
            repo.Add(new Student { Gender = Domain.Entities.Gender.M, Name = "testdude", Type = Domain.Entities.StudentType.High, LastModified = DateTime.Now });
            repo.Add(studentToDelete);

            repo.Delete(studentToDelete);
            Assert.AreEqual(1, repo.GetAll().Count);
        }

        [TestMethod]
        public void Should_Get_List_Filtered()
        {
            repo.Add(new Student { Gender = Domain.Entities.Gender.M, Name = "testdude", Type = Domain.Entities.StudentType.High, LastModified = DateTime.Now });
            repo.Add(new Student { Gender = Domain.Entities.Gender.F, Name = "testdude1", Type = Domain.Entities.StudentType.Kinder, LastModified = DateTime.Now });
            var result = repo.GetList(x => x.Name == "testdude");                
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Should_Get_One_Filtered()
        {
            repo.Add(new Student { Gender = Domain.Entities.Gender.M, Name = "testdude", Type = Domain.Entities.StudentType.High, LastModified = DateTime.Now });
            repo.Add(new Student { Gender = Domain.Entities.Gender.F, Name = "testdude1", Type = Domain.Entities.StudentType.Kinder, LastModified = DateTime.Now });
            var result = repo.GetSingle(x => x.Name == "testdude");
            Assert.IsNotNull(result);
            Assert.AreEqual("testdude", result.Name);
        }
    }
}
