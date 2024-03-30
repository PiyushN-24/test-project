using AutoMapper;
using Task_Api.Entity;
using Task_Api.Interface;
using Task_Api.ServiceInterface;
using Task_Api.VMModel;

namespace Task_Api.Service
{
    public class EmployeeService : IEmployeeService
    {

        IEmployee _IEmployee;
        public EmployeeService(IEmployee iEmployee)
        {
            _IEmployee = iEmployee;
        }

        public async Task<long> EmployeeSave(VMEmployee vMEmployee)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();

            var config = new MapperConfiguration(con =>
            {
                con.CreateMap<VMEmployee, EmployeeEntity>();
            });
            IMapper map = config.CreateMapper();

            employeeEntity = map.Map<VMEmployee, EmployeeEntity>(vMEmployee);

            long rowdata = await _IEmployee.EmployeeSave(employeeEntity);
            return rowdata;
        }

        public async Task<List<VMEmployee>> GetEmployeeList()
        {
            List<EmployeeEntity> EmployeeEntity = await _IEmployee.GetEmployeeList();
            List<VMEmployee> vMEmployee = new List<VMEmployee>();
            var config14 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeEntity, VMEmployee>();
            });
            IMapper mapper14 = config14.CreateMapper();
            vMEmployee = mapper14.Map<List<EmployeeEntity>, List<VMEmployee>>(EmployeeEntity);
            return vMEmployee;
        }

        public async Task<VMEmployee> GetEmployeeById(int empid)
        {
            EmployeeEntity EmployeeEntity = await _IEmployee.GetEmployeeById(empid);
            VMEmployee vMEmployee = new VMEmployee();
            var config14 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeEntity, VMEmployee>();
            });
            IMapper mapper14 = config14.CreateMapper();
            vMEmployee = mapper14.Map<EmployeeEntity, VMEmployee>(EmployeeEntity);
            return vMEmployee;
        }

    }
}
