using MJKProjectsDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJKProjectsDAL.Repos.Interfaces
{
    public interface IBlogPostRepository : IRepo<BlogPost>
    {
        BlogPost GetByFunction(Func<BlogPost, bool> func);
    }
}
