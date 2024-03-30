using Task_Api.VMModel;

namespace Task_Api.Interface
{
    public interface IEmployeeService
    {
        Task<long> EmployeeSave(VMEmployee vMEmployee);
        Task<List<VMEmployee>> GetEmployeeList();
        Task<VMEmployee> GetEmployeeById(int empid);
    }
}
