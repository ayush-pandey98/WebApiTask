using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Presentation.Interface
{
    public interface IPresentation
    {
        public void Run();

        public void EmployeeManagment();

        public void RoleManagment();

        public void editEmployee();

        string IsAvailableId(string type);

        void LocationManagment();

        int GetNextsLocationId();

        void DepartmentManagment();

        int GetNextDepartmentId();

        public void DisplayAllEmployees();

        public void showAvailableId();

        public void displaySpecific(Employee emp);

        public void DisplayAllRole();

        void DisplayAllLocation();

        void DisplayAllDepartments();

        void AddEmployee();

        void editEmployeeOptions(Employee employee, string choice);

        void AddRole();

    }
}
