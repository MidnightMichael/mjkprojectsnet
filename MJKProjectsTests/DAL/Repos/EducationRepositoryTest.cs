using Microsoft.EntityFrameworkCore;
using MJKProjectsDAL.EF;
using MJKProjectsDAL.Models;
using MJKProjectsDAL.Repos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJKProjectsTests.DAL.Repos
{
    class EducationRepositoryTest
    {
        private EducationRepository _EducationRepository;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetupTest()
        {
            var testOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "mjkprojects_test_db");
            _context = new ApplicationDbContext(testOptionsBuilder.Options);
            _context.Database.EnsureCreated();
            _EducationRepository = new EducationRepository(_context);
        }

        [TearDown]
        public void TearDownTest()
        {
            _context.Database.EnsureDeleted();
            _context = null;
            _EducationRepository = null;
        }

        [Test]
        public void TestAdd()
        {
            var p = new Education()
            {

                Name = "Foo",
                Complete = true
            };

            _EducationRepository.Add(p);

            Assert.IsTrue(_EducationRepository.List().Count == 1);
        }

        public void TestUpdate()
        {
            var p = new Education()
            {

                Name = "Foo",
                Complete = true
            };

            _EducationRepository.Add(p);

            p.Name = "Bar";

            _EducationRepository.Update(p);

            Assert.IsTrue(_EducationRepository.GetBy(p => p.Name == "Bar") != null);
        }

        public void TestDelete()
        {
            var p = new Education()
            {
                Name = "Foo",
                Complete = true
            };

            _EducationRepository.Add(p);
            _EducationRepository.Delete(p);

            Assert.IsTrue(_EducationRepository.List().Count == 0);
        }
    }
}
