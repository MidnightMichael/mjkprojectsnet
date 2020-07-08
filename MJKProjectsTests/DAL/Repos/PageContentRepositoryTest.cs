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
    class PageContentRepositoryTest
    {
        private PageContentSectionRepository _projectRepository;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetupTest()
        {
            var testOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "mjkprojects_test_db");
            _context = new ApplicationDbContext(testOptionsBuilder.Options);
            _context.Database.EnsureCreated();
            _projectRepository = new PageContentSectionRepository(_context);
        }

        [TearDown]
        public void TearDownTest()
        {
            _context.Database.EnsureDeleted();
            _context = null;
            _projectRepository = null;
        }

        [Test]
        public void TestAdd()
        {
            var p = new PageContentSection()
            {

                Title = "Foo",
                Content = "sadfasdfsadfasdfsadf"
            };

            _projectRepository.Add(p);

            Assert.IsTrue(_projectRepository.List().Count == 1);
        }

        public void TestUpdate()
        {
            var p = new PageContentSection()
            {

                Title = "Foo",
                Content = "sadfasdfsadfasdfsadf"
            };

            _projectRepository.Add(p);

            p.Title = "Bar";

            _projectRepository.Update(p);

            Assert.IsTrue(_projectRepository.GetBy(p => p.Title == "Bar") != null);
        }

        public void TestDelete()
        {
            var p = new PageContentSection()
            {
                Title = "Foo",
                Content = "sadfasdfsadfasdfsadf"
            };

            _projectRepository.Add(p);
            _projectRepository.Delete(p);

            Assert.IsTrue(_projectRepository.List().Count == 0);
        }
    }
}
