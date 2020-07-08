using MJKProjectsDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJKProjectsDAL.ViewModels
{
    class AboutPageViewModel
    {
        public List<Skill> Skills { get; set; }
        public List<WorkHistory> WorkHistory { get; set; }
        public List<Education> Educations { get; set; }
        public List<PageContentSection> ContentSections { get; set; }
    }
}
