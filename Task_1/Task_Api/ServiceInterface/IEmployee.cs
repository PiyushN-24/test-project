using Task_Api.Entity;

namespace Task_Api.ServiceInterface
{
    public interface IEmployee
    {
        Task<long> EmployeeSave(EmployeeEntity employeeEntity);
        Task<List<EmployeeEntity>> GetEmployeeList();
        Task<EmployeeEntity> GetEmployeeById(int empid);

    }
}
