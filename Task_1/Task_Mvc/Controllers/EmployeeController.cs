using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Task_Mvc.Repository;
using Task_Mvc.Models;
using Newtonsoft.Json;

namespace Task_Mvc.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeRepository employeeRepository = new EmployeeRepository();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SaveEmployee(VMEmployee vMEmployee)
        {
            string response = string.Empty;
            try
            {
                response = await employeeRepository.SaveEmployee(vMEmployee);
            }
            catch (Exception ex)
            {
                response = "-99" + " Error :" + ex.Message;
            }
            return Json(response);
        }


        public async Task<JsonResult> GetEmployeeList(VMEmployee vmEmployee)
        {
            List<VMEmployee> list = new List<VMEmployee>();
            try
            {
                string response = await employeeRepository.GetEmployeeList(vmEmployee);
                if (response != null && response != "")
                    list = JsonConvert.DeserializeObject<List<VMEmployee>>(response);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }



        public async Task<JsonResult> GetEmployeeById(int id)
        {
            VMEmployee vmEmployee = new VMEmployee();
            try
            {
                string response = await employeeRepository.GetEmployeeById(id);
                if (response != null && response != "")
                    vmEmployee = JsonConvert.DeserializeObject<VMEmployee>(response);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return Json(vmEmployee, JsonRequestBehavior.AllowGet);
        }


    }
}