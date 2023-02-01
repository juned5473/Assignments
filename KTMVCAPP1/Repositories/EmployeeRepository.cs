using AutoMapper;
using KTMVCAPP1.Data;
using KTMVCAPP1.Models;
using Microsoft.EntityFrameworkCore;

namespace KTMVCAPP1.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /*public async Task<List<Employee>>GetEmployeesAsync()
        {
            var records = _context.Employees.Select(objEmp => new Employee()
            {
                Id = objEmp.Id,
                FirstName = objEmp.FirstName,
                LastName = objEmp.LastName,
                City = objEmp.City,
                Email = objEmp.Email,
                Password = objEmp.Password
            }).ToListAsync();

            return records;
        }*/

        public IEnumerable<Employee> GetEmployee()
        {
            /*IEnumerable<Employee> listOfEmployees = (from objEmp in _context.Employees
                                                     select new Employee()
                                                     {
                                                         Id = objEmp.Id,
                                                         FirstName = objEmp.FirstName,
                                                         LastName = objEmp.LastName,
                                                         City = objEmp.City,
                                                         Email = objEmp.Email,
                                                         Password = objEmp.Password
                                                     }).ToList();
            return listOfEmployees;*/

            var emp = _context.Employees.ToList();
            return _mapper.Map<List<Employee>>(emp);
        }

        public Employee GetEmployeeByID(int empId)
        {
            var emp = _context.Employees.Find(empId);
            return _mapper.Map<Employee>(emp);

            /*return _context.Employees.Find(empId)!;*/
        }

        public void InsertEmployee(Employee emp)
        {
            /*Employee objEmp = new Employee()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                City = emp.City,
                Email = emp.Email,
                Password = emp.Password
            };*/

            var emp1 = _context.Employees.Add(emp);
             _mapper.Map<Employee>(emp);
             _context.SaveChanges();

            /*_context.Employees.Add(objEmp);
            _context.SaveChanges();*/
        }

        public void DeleteEmployee(int empId)
        {
            var emp = _context.Employees.Find(empId);
            _mapper.Map<Employee>(emp);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            

            /*Employee emp = _context.Employees.Find(empId)!;
            _context.Employees.Remove(emp);
            _context.SaveChanges();*/
        }

        public void UpdateEmployee(Employee emp)
        {
            var emp1 = _context.Employees.Update(emp);
            _mapper.Map<Employee>(emp);
            _context.SaveChanges();

            /*_context.Employees.Update(emp);
            _context.SaveChanges();*/
        }


    }
}
