using EFCore.Data;
using EFCore.Models;

namespace EFCore.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(EFCoreDbContext context) : base(context) { }
    }
}
