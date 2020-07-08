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
    public class PageContentSectionTest
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
        public void TestAddPageContentSection()
        {
            var pageContentSection = new PageContentSection()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Page = "about"
            };

            _context.PageContentSections.Add(pageContentSection);
            _context.SaveChanges();

            Assert.IsTrue(_context.PageContentSections.ToList().Count == 1);
        }

        [Test]
        public void TestGetPageContentSections()
        {
            var PageContentSections = new List<PageContentSection>()
            {
                new PageContentSection()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Page = "about"
                },
                new PageContentSection()
                {
                    Title = "Dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Page = "about"
                }
            };

            _context.PageContentSections.AddRange(PageContentSections);
            _context.SaveChanges();

            Assert.IsTrue(_context.PageContentSections.ToList().Count == 2);
        }

        [Test]
        public void TestGetSinglePageContentSection()
        {
            var PageContentSection = new PageContentSection()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Page = "about"
            };

            _context.PageContentSections.Add(PageContentSection);
            _context.SaveChanges();

            Assert.IsTrue(_context.PageContentSections.Where(s => s.Title == "Lorem ipsum dolor sit amet").Single().Title == "Lorem ipsum dolor sit amet");
        }

        [Test]
        public void TestUpdatePageContentSection()
        {
            var PageContentSection = new PageContentSection()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Page = "about"
            };

            _context.PageContentSections.Add(PageContentSection);
            _context.SaveChanges();

            PageContentSection.Title = "Lorem ipsum";
            _context.PageContentSections.Update(PageContentSection);
            _context.SaveChanges();

            Assert.IsTrue(_context.PageContentSections.Where(s => s.Title == "Lorem ipsum").Single() != null);
        }

        [Test]
        public void TestDelete()
        {
            var PageContentSections = new List<PageContentSection>()
            {
                new PageContentSection()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Page = "about"
                },
                new PageContentSection()
                {
                    Title = "Dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Page = "about"
                }
            };

            _context.PageContentSections.AddRange(PageContentSections);
            _context.SaveChanges();

            Assert.IsTrue(_context.PageContentSections.ToList().Count == 2);

            _context.PageContentSections.Remove(PageContentSections[0]);
            _context.SaveChanges();

            Assert.IsTrue(_context.PageContentSections.ToList().Count == 1);
        }
    }
}
