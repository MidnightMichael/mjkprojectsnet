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
    class ProjectTest
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
            var project = new Project()
            {                
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            Assert.IsTrue(_context.Projects.ToList().Count == 1);
        }

        [Test]
        public void TestGetProjects()
        {
            var projects = new List<Project>()
            {
                new Project()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                },
                new Project()
                {
                    Title = "Dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                }
            };

            _context.Projects.AddRange(projects);
            _context.SaveChanges();

            Assert.IsTrue(_context.Projects.ToList().Count == 2);
        }

        [Test]
        public void TestGetSingleProject()
        {
            var project = new Project()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            Assert.IsTrue(_context.Projects.Where(s => s.Title == "Lorem ipsum dolor sit amet").Single().Title == "Lorem ipsum dolor sit amet");
        }

        [Test]
        public void TestUpdateProject()
        {
            var project = new Project()
            {
                Title = "Lorem ipsum dolor sit amet",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            project.Title = "Lorem ipsum";
            _context.Projects.Update(project);
            _context.SaveChanges();

            Assert.IsTrue(_context.Projects.Where(s => s.Title == "Lorem ipsum").Single() != null);
        }

        [Test]
        public void TestDelete()
        {
            var projects = new List<Project>()
            {
                new Project()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                },
                new Project()
                {
                    Title = "Dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                }
            };

            _context.Projects.AddRange(projects);
            _context.SaveChanges();

            Assert.IsTrue(_context.Projects.ToList().Count == 2);

            _context.Projects.Remove(projects[0]);
            _context.SaveChanges();

            Assert.IsTrue(_context.Projects.ToList().Count == 1);
        }
    }
}
