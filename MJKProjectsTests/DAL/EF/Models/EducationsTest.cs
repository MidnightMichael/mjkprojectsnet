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
    public class EducationsTest
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
        public void TestAdd()
        {
            var education = new Education()
            {
                Name = "HBO",
                Complete = true,
                From = new DateTime(2012, 1, 1),
                Till = new DateTime(2018, 1,1)                
            };

            _context.Educations.Add(education);
            _context.SaveChanges();

            Assert.IsTrue(_context.Educations.ToList().Count == 1);
        }

        [Test]
        public void TestGetOne()
        {
            var education = new Education()
            {
                Name = "HBO",
                Complete = true,
                From = new DateTime(2012, 1, 1),
                Till = new DateTime(2018, 1, 1)
            };

            _context.Educations.Add(education);
            _context.SaveChanges();

            Assert.IsTrue(_context.Educations.ToList().Count == 1);
        }

        [Test]
        public void TestGetAll()
        {
            var educations = new List<Education>()
            {
                new Education()
                {
                    Name = "HBO",
                    Complete = true,
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                },
                new Education()
                {
                    Name = "HBO",
                    Complete = true,
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                }
            };

            _context.Educations.AddRange(educations);
            _context.SaveChanges();

            Assert.IsTrue(_context.Educations.ToList().Count == 2);
        }

        [Test]
        public void TestUpdate()
        {
            var educations = new List<Education>()
            {
                new Education()
                {
                    Name = "HBO",
                    Complete = true,
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                },
                new Education()
                {
                    Name = "HBO",
                    Complete = true,
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                }
            };

            _context.Educations.AddRange(educations);
            _context.SaveChanges();

            var education = _context.Educations.First();
            education.Name = "MBO";

            _context.Educations.Update(education);
            _context.SaveChanges();

            Assert.IsTrue(_context.Educations.Where(n => n.Name == "MBO").Single() != null);
        }

        [Test]
        public void TestDelete()
        {
            var educations = new List<Education>()
            {
                new Education()
                {
                    Name = "HBO",
                    Complete = true,
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                },
                new Education()
                {
                    Name = "MBO",
                    Complete = true,
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                }
            };

            _context.Educations.AddRange(educations);
            _context.SaveChanges();

            Assert.IsTrue(_context.Educations.ToList().Count == 2);

            var education = _context.Educations.Where(n => n.Name == "MBO").First();
            _context.Educations.Remove(education);
            _context.SaveChanges();
            Assert.IsTrue(_context.Educations.ToList().Count == 1);
        }
    }
}
