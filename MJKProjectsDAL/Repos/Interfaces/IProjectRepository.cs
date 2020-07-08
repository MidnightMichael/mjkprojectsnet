using MJKProjectsDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJKProjectsDAL.Repos.Interfaces
{
    public interface IProjectRepository : IRepo<Project>
    {
        Project GetByTitle(string title);

        Project GetByFunc(Func<Project, bool> func);
    }
}
