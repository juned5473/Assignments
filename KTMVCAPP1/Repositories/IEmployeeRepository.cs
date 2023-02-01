using KTMVCAPP1.Models;

namespace KTMVCAPP1.Repositories
{
    public interface IEmployeeRepository
    {


        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeByID(int empId);
        void InsertEmployee(Employee emp);
        void DeleteEmployee(int empId);
        void UpdateEmployee(Employee emp);

        /*Task<List<Employee>> GetEmployeesAsync();*/




    }
}
