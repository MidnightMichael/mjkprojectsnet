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
    class BlogPostRepositoryTest
    {
        private BlogPostRepository _BlogPostRepository;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetupTest()
        {
            var testOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "mjkprojects_test_db");
            _context = new ApplicationDbContext(testOptionsBuilder.Options);
            _context.Database.EnsureCreated();
            _BlogPostRepository = new BlogPostRepository(_context);
        }

        [TearDown]
        public void TearDownTest()
        {
            _context.Database.EnsureDeleted();
            _context = null;
            _BlogPostRepository = null;
        }

        [Test]
        public void TestAdd()
        {
            var p = new BlogPost()
            {

                Title = "Foo",
                Content = "sadfasdfsadfasdfsadf"
            };

            _BlogPostRepository.Add(p);

            Assert.IsTrue(_BlogPostRepository.List().Count == 1);
        }

        public void TestUpdate()
        {
            var p = new BlogPost()
            {

                Title = "Foo",
                Content = "sadfasdfsadfasdfsadf"
            };

            _BlogPostRepository.Add(p);

            p.Title = "Bar";

            _BlogPostRepository.Update(p);

            Assert.IsTrue(_BlogPostRepository.GetBy(p => p.Title == "Bar") != null);
        }

        public void TestDelete()
        {
            var p = new BlogPost()
            {
                Title = "Foo",
                Content = "sadfasdfsadfasdfsadf"
            };

            _BlogPostRepository.Add(p);
            _BlogPostRepository.Delete(p);

            Assert.IsTrue(_BlogPostRepository.List().Count == 0);
        }
    }
}
