using MJKProjectsDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MJKProjectsDAL.Models
{
    [Table("projects")]
    public class Project : DBModelBase
    {
        [Required]
        [Column("project_title")]
        public string Title { get; set; }

        [Required]
        [Column("project_content")]
        public string Content { get; set; }

        [Column("project_post_slug")]
        public string Slug { get; set; }

        public string ShortContent()
        {
            return Content.Substring(0, Content.Length < 200 ? Content.Length - 1 : 200);
        }

        public static Project MakeProject(string title, string content)
        {
            return new Project()
            {
                Title = title,
                Content = content,                
            };
        }

        public virtual string AllCapsTitle()
        {
            return Title.ToUpper();
        }

        public virtual string TitleToURL()
        {
            return Title.ToLower().Replace(' ', '-');
        }
    }
}
