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
    public class SkillTest
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
            var Skill = new Skill()
            {
                Name = "HBO",
                Rating=5
            };

            _context.Skills.Add(Skill);
            _context.SaveChanges();

            Assert.IsTrue(_context.Skills.ToList().Count == 1);
        }

        [Test]
        public void TestGetOne()
        {
            var Skill = new Skill()
            {
                Name = "HBO",
                Rating = 5
            };

            _context.Skills.Add(Skill);
            _context.SaveChanges();

            Assert.IsTrue(_context.Skills.ToList().Count == 1);
        }

        [Test]
        public void TestGetAll()
        {
            var Skills = new List<Skill>()
            {
                new Skill()
                {
                    Name = "HBO",
                    Rating=5
                },
                new Skill()
                {
                    Name = "HBO",
                    Rating=5
                }
            };

            _context.Skills.AddRange(Skills);
            _context.SaveChanges();

            Assert.IsTrue(_context.Skills.ToList().Count == 2);
        }

        [Test]
        public void TestUpdate()
        {
            var Skills = new List<Skill>()
            {
                new Skill()
                {
                    Name = "HBO",
                    Rating=5
                },
                new Skill()
                {
                    Name = "HBO",
                    Rating=5
                }
            };

            _context.Skills.AddRange(Skills);
            _context.SaveChanges();

            var Skill = _context.Skills.First();
            Skill.Name = "MBO";

            _context.Skills.Update(Skill);
            _context.SaveChanges();

            Assert.IsTrue(_context.Skills.Where(n => n.Name == "MBO").Single() != null);
        }

        [Test]
        public void TestDelete()
        {
            var Skills = new List<Skill>()
            {
                new Skill()
                {
                    Name = "HBO",
                    Rating=5
                },
                new Skill()
                {
                    Name = "MBO",
                    Rating=5
                }
            };

            _context.Skills.AddRange(Skills);
            _context.SaveChanges();

            Assert.IsTrue(_context.Skills.ToList().Count == 2);

            var Skill = _context.Skills.Where(n => n.Name == "MBO").First();
            _context.Skills.Remove(Skill);
            _context.SaveChanges();
            Assert.IsTrue(_context.Skills.ToList().Count == 1);
        }
    }
}
