using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MJKProjectsDAL.Models.Base;

namespace MJKProjectsDAL.Models
{
    [Table("page_content_sections")]
    public class PageContentSection : DBModelBase
    {
        [Required]
        [Column("page_content_section_title")]
        public string Title { get; set; }

        [Required]
        [Column("page_content_section_page")]
        public string Page { get; set; }
        
        [Column("page_content_section_content")]
        public string Content { get; set; }
    }
}
