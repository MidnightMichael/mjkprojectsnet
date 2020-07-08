using MJKProjectsDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MJKProjectsDAL.Models
{
    [Table("educations")]
    public class Education : DBModelBase
    {
        [Required]
        [Column("education_name")]
        public string Name { get; set; }

        [Required]
        [Column("education_complete")]
        public bool Complete { get; set; }

        [Column("education_from")]
        public DateTime From { get; set; }

        [Column("education_till")]
        public DateTime Till { get; set; }

        public string CompletedDisplay()
        {
            return Complete ? "Yes" : "No";
        }

        public static Education MakeEducation(string name, DateTime start, DateTime end, bool completed)
        {
            return new Education()
            {
                Name = name,
                From = start,
                Till = end,
                Complete = completed
            };
        }
    }
}
