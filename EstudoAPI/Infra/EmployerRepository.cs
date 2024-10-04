using EstudoAPI.Model;
using Microsoft.AspNetCore.Connections;

namespace EstudoAPI.Infra
{
    public class EmployerRepository : IEmployeeRepository
    {
        private readonly DBConnectionContext _context = new DBConnectionContext();
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _context.Employees.ToList();
        }
    }
}
