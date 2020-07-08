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
    public class WorkHistoryTest
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
            var WorkHistory = new WorkHistory()
            {
                Employer = "HBO",                
                From = new DateTime(2012, 1, 1),
                Till = new DateTime(2018, 1, 1)
            };

            _context.WorkHistories.Add(WorkHistory);
            _context.SaveChanges();

            Assert.IsTrue(_context.WorkHistories.ToList().Count == 1);
        }

        [Test]
        public void TestGetOne()
        {
            var WorkHistory = new WorkHistory()
            {
                Employer = "HBO",                
                From = new DateTime(2012, 1, 1),
                Till = new DateTime(2018, 1, 1)
            };

            _context.WorkHistories.Add(WorkHistory);
            _context.SaveChanges();

            Assert.IsTrue(_context.WorkHistories.ToList().Count == 1);
        }

        [Test]
        public void TestGetAll()
        {
            var WorkHistorys = new List<WorkHistory>()
            {
                new WorkHistory()
                {
                    Employer = "HBO",                    
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                },
                new WorkHistory()
                {
                    Employer = "HBO",                    
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                }
            };

            _context.WorkHistories.AddRange(WorkHistorys);
            _context.SaveChanges();

            Assert.IsTrue(_context.WorkHistories.ToList().Count == 2);
        }

        [Test]
        public void TestUpdate()
        {
            var WorkHistorys = new List<WorkHistory>()
            {
                new WorkHistory()
                {
                    Employer = "HBO",                    
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                },
                new WorkHistory()
                {
                    Employer = "HBO",                    
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                }
            };

            _context.WorkHistories.AddRange(WorkHistorys);
            _context.SaveChanges();

            var WorkHistory = _context.WorkHistories.First();
            WorkHistory.Employer = "MBO";

            _context.WorkHistories.Update(WorkHistory);
            _context.SaveChanges();

            Assert.IsTrue(_context.WorkHistories.Where(n => n.Employer == "MBO").Single() != null);
        }

        [Test]
        public void TestDelete()
        {
            var WorkHistorys = new List<WorkHistory>()
            {
                new WorkHistory()
                {
                    Employer = "HBO",                    
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                },
                new WorkHistory()
                {
                    Employer = "MBO",                    
                    From = new DateTime(2012, 1, 1),
                    Till = new DateTime(2018, 1,1)
                }
            };

            _context.WorkHistories.AddRange(WorkHistorys);
            _context.SaveChanges();

            Assert.IsTrue(_context.WorkHistories.ToList().Count == 2);

            var WorkHistory = _context.WorkHistories.Where(n => n.Employer == "MBO").First();
            _context.WorkHistories.Remove(WorkHistory);
            _context.SaveChanges();
            Assert.IsTrue(_context.WorkHistories.ToList().Count == 1);
        }
    }
}
