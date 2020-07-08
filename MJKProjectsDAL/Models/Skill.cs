using MJKProjectsDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MJKProjectsDAL.Models
{
    [Table("skills")]
    public class Skill : DBModelBase
    {
        [Required]
        [Column("skill_name")]
        public string Name { get; set; }

        [Required]
        [Column("skill_rating")]
        public int Rating { get; set; }

        public static Skill MakeSkill(string name, int rating)
        {
            return new Skill()
            {
                Name = name,
                Rating = rating
            };
        }
    }
}
