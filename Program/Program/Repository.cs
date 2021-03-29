using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Program
{
    public class Repository : IRepository
    {
        private Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public Application GetApplicationById(int appId)
        {
            return _context.Applications.Include(x => x.Configuration.Algorithm).SingleOrDefault(x => x.ApplicationId == appId);
        }
    }
}
