using ClientInfoSystem.Core.Models.Request;
using ClientInfoSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfoSystem.Core.ServiceInterfaces
{
    public interface IEmployeesService
    {
        Task<EmployeeResponseModel> CreateEmp(EmployeeCreateRequestModel employeeCreateRequest);
        Task<EmployeeResponseModel> UpdateEmp(EmployeeCreateRequestModel employeeCreateRequest);
        Task DeleteEmp(int id);
        Task<IEnumerable<EmployeeResponseModel>> ListAllEmps();
    }
}
