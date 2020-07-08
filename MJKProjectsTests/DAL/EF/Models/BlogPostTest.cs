using Microsoft.EntityFrameworkCore;
using MJKProjectsDAL.EF;
using MJKProjectsDAL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MJKProjectsTests.DAL.EF.Models
{
    public class BlogPostTest
    {
        private ApplicationDbContext _context;

        [SetUp]
        public void InitTest()
        {
            var testOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "mjkprojects_test_db");
            _context = new ApplicationDbContext(testOptionsBuilder.Options);
            _context.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDownTest()
        {
            _context.Database.EnsureDeleted();
            _context = null;
        }

        [Test]
        public void TestAddProject()
        {
            var BlogPost = new BlogPost()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            _context.BlogPosts.Add(BlogPost);
            _context.SaveChanges();

            Assert.IsTrue(_context.BlogPosts.ToList().Count == 1);
        }

        [Test]
        public void TestGetBlogPosts()
        {
            var BlogPosts = new List<BlogPost>()
            {
                new BlogPost()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                },
                new BlogPost()
                {
                    Title = "Dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                }
            };

            _context.BlogPosts.AddRange(BlogPosts);
            _context.SaveChanges();

            Assert.IsTrue(_context.BlogPosts.ToList().Count == 2);
        }

        [Test]
        public void TestGetSingleBlogPost()
        {
            var BlogPost = new BlogPost()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            _context.BlogPosts.Add(BlogPost);
            _context.SaveChanges();

            Assert.IsTrue(_context.BlogPosts.Where(s => s.Title == "Lorem ipsum dolor sit amet").Single().Title == "Lorem ipsum dolor sit amet");
        }

        [Test]
        public void TestUpdateBlogPost()
        {
            var BlogPost = new BlogPost()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            _context.BlogPosts.Add(BlogPost);
            _context.SaveChanges();

            BlogPost.Title = "Lorem ipsum";
            _context.BlogPosts.Update(BlogPost);
            _context.SaveChanges();

            Assert.IsTrue(_context.BlogPosts.Where(s => s.Title == "Lorem ipsum").Single() != null);
        }

        [Test]
        public void TestDelete()
        {
            var BlogPosts = new List<BlogPost>()
            {
                new BlogPost()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                },
                new BlogPost()
                {
                    Title = "Dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                }
            };

            _context.BlogPosts.AddRange(BlogPosts);
            _context.SaveChanges();

            Assert.IsTrue(_context.BlogPosts.ToList().Count == 2);

            _context.BlogPosts.Remove(BlogPosts[0]);
            _context.SaveChanges();

            Assert.IsTrue(_context.BlogPosts.ToList().Count == 1);
        }
    }
}
