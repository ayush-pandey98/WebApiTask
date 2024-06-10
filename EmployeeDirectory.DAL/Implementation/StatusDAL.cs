using EmployeeDirectory.DAL.Interface;
using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Implementation
{
    public class StatusDAL : IStatusDAL
    {
        private readonly EmployeeDirectoryDbContext _context;
        public StatusDAL(EmployeeDirectoryDbContext context)
        {
           _context = context;
        }
        public int GetStatusId(string statusValue)
        {
            int id = -1;
            var status  =  _context.Statuses.Where(st=>st.Value==statusValue).FirstOrDefault();
            if(status != null) {
                id = status.Id;
            }
            return id;
        }
    }
}
