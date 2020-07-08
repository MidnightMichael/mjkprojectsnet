using MJKProjectsDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MJKProjectsDAL.Models
{
    [Table("blog_posts")]
    public class BlogPost : DBModelBase
    {
        [Column("blog_post_title")]
        public string Title { get; set; }

        [Column("blog_post_content")]
        public string Content { get; set; }

        [Column("blog_post_slug")]
        public string Slug { get; set; }

        public static BlogPost MakeBlogPost(string title, string content)
        {
            return new BlogPost()
            {
                Title = title,
                Content = content
            };
        }

        public virtual string ShortContent()
        {
            return Content.Substring(0, Content.Length < 350 ? Content.Length - 1 : 350);
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
