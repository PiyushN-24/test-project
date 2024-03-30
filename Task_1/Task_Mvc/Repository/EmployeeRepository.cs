using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Task_Mvc.Interface;
using Task_Mvc.Services;
using Task_Mvc.Models;

namespace Task_Mvc.Repository
{
    public class EmployeeRepository
    {
        IApiClient apiClient;
        string relativePath = "";
        public EmployeeRepository()
        {
            apiClient = new WebApiClient();
        }
        public async Task<string> SaveEmployee(VMEmployee vMEmployee)
        {
            relativePath = $"api/APIEmployee";
            string flag = string.Empty;
            var responseApi = await apiClient.PostAsync(relativePath, vMEmployee);
            flag = responseApi.Data;
            return flag;
        }

        public async Task<string> GetEmployeeList(VMEmployee vMEmployee)
        {
            relativePath = $"api/APIEmployee";
            string flag = string.Empty;
            var responseApi = await apiClient.GetAsync(relativePath);
            flag = responseApi.Data;
            return flag;
        }

        public async Task<string> GetEmployeeById(int id)
        {
            relativePath = $"api/APIEmployee/GetEmployeeById?empid={id}";
            string flag = string.Empty;
            var responseApi = await apiClient.GetAsync(relativePath);
            flag = responseApi.Data;
            return flag;
        }
    }
}