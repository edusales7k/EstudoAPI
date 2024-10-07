using EstudoAPI.Model;
using EstudoAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeViewModel)
         {

            var filePath = Path.Combine("Storage", employeeViewModel.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeViewModel.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.Get();

            return Ok(employess);
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/GetImageById")]
        public IActionResult GetImageById(int id)
        {
            var employeee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employeee.photo);

            return File(dataBytes, "image/png");
        }
    }
}
