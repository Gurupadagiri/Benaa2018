using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;

namespace Benaa2018.Data.Repository
{
    public class ProjectColorRepoisitory : Repository<ProjectColorMaster>, IProjectColorRepoisitory
    {
        public ProjectColorRepoisitory(SBSDbContext context) : base(context) { }
    }
}
