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
    class WorkHistoryRepositoryTest
    {
        private WorkHistoryRepository _WorkHistoryRepository;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetupTest()
        {
            var testOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "mjkprojects_test_db");
            _context = new ApplicationDbContext(testOptionsBuilder.Options);
            _context.Database.EnsureCreated();
            _WorkHistoryRepository = new WorkHistoryRepository(_context);
        }

        [TearDown]
        public void TearDownTest()
        {
            _context.Database.EnsureDeleted();
            _context = null;
            _WorkHistoryRepository = null;
        }

        [Test]
        public void TestAdd()
        {
            var p = new WorkHistory()
            {

                Employer = "Foo"
            };

            _WorkHistoryRepository.Add(p);

            Assert.IsTrue(_WorkHistoryRepository.List().Count == 1);
        }

        public void TestUpdate()
        {
            var p = new WorkHistory()
            {

                Employer = "Foo"
            };

            _WorkHistoryRepository.Add(p);

            p.Employer = "Bar";

            _WorkHistoryRepository.Update(p);

            Assert.IsTrue(_WorkHistoryRepository.GetBy(p => p.Employer == "Bar") != null);
        }

        public void TestDelete()
        {
            var p = new WorkHistory()
            {
                Employer = "Foo"                
            };

            _WorkHistoryRepository.Add(p);
            _WorkHistoryRepository.Delete(p);

            Assert.IsTrue(_WorkHistoryRepository.List().Count == 0);
        }
    }
}
