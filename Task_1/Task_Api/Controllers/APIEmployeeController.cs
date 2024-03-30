using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Api.Interface;
using Task_Api.VMModel;

namespace Task_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIEmployeeController : ControllerBase
    {

        IEmployeeService _IEmployeeService;
        public APIEmployeeController(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }

        [HttpPost]
        public async Task<ActionResult> APIPostEmployee(VMEmployee vMEmployee)
        {
            try
            {
                long ret = 0;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ret = await _IEmployeeService.EmployeeSave(vMEmployee);
                return Ok(ret);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployeeList()
        {
            List<VMEmployee> vMEmployees = new List<VMEmployee>();
            try
            {
                vMEmployees = await _IEmployeeService.GetEmployeeList();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(vMEmployees);
        }


        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<ActionResult> GetEmployeeById(int empid)
        {
            VMEmployee vMEmployees = new VMEmployee();
            try
            {
                vMEmployees = await _IEmployeeService.GetEmployeeById(empid);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(vMEmployees);
        }

    }
}
