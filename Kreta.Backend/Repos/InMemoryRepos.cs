using Kreta.Backend.Context;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class StudentInMemoryRepo : StudentRepo<KretaInMemoryContext>
    {
        public StudentInMemoryRepo(IDbContextFactory<KretaInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
    public class TeacherInMemoryRepo : TeacherRepo<KretaInMemoryContext>
    {
        public TeacherInMemoryRepo(IDbContextFactory<KretaInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
