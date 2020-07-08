using MJKProjectsDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MJKProjectsDAL.Models
{
    [Table("work_histories")]
    public class WorkHistory : DBModelBase
    {
        [Required]
        [Column("work_history_employer")]
        public string Employer { get; set; }

        [Column("work_history_from")]
        public DateTime From { get; set; }

        [Column("work_history_till")]
        public DateTime Till { get; set; }

        public static WorkHistory MakeWorkHistory(string name, DateTime start, DateTime end)
        {
            return new WorkHistory()
            {
                Employer = name,
                From = start,
                Till = end
            };
        }
    }
}
