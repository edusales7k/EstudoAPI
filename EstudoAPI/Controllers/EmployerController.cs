using EstudoAPI.Model;
using EstudoAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPI.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployerController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeViewModel)
         {
            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, null);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.Get();

            return Ok(employess);
        }
    }
}
