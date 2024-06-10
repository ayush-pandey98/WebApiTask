using EmployeeDirectory.BLL.Interface;
using EmployeeDirectory.DAL.Interface;

namespace EmployeeDirectory.BLL.Implementation
{
    public class StatusBL : IStatusBL
    {
        private readonly IStatusDAL _statusDAL;
        public StatusBL(IStatusDAL statusDAL)
        {
          _statusDAL = statusDAL;
        }
        public int GetStatusId(string statusValue)
        {
            return _statusDAL.GetStatusId(statusValue);
        }
    }
}
