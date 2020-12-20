using ClientInfoSystem.Core.Entities;
using ClientInfoSystem.Core.Models.Request;
using ClientInfoSystem.Core.Models.Response;
using ClientInfoSystem.Core.RepositoryInterfaces;
using ClientInfoSystem.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfoSystem.Infrastructure.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IAsyncRepository<Employees> _empRepository;
        public EmployeesService(IAsyncRepository<Employees> empRepository)
        {
            _empRepository = empRepository;
        }
        public async Task<EmployeeResponseModel> CreateEmp(EmployeeCreateRequestModel empCreateRequest)
        {
            return EmpToEmpRespModel(await _empRepository.AddAsync(EmpReqModelToEmp(empCreateRequest)));
        }

        public async Task DeleteEmp(int id)
        {
            var ls = await _empRepository.GetByIdAsync(id);
            await _empRepository.DeleteAsync(ls);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> ListAllEmps()
        {
            return EmpToEmpRespModelList(await _empRepository.ListAllAsync());
        }

        public async Task<EmployeeResponseModel> UpdateEmp(EmployeeCreateRequestModel empCreateRequest)
        {
            var emp = await _empRepository.GetByIdAsync(empCreateRequest.Id);
            emp.Name = empCreateRequest.Name;
            emp.Password = empCreateRequest.Password;
            emp.Designation = empCreateRequest.Designation;
            return EmpToEmpRespModel(await _empRepository.UpdateAsync(emp));
        }

        // Mappers
        private Employees EmpReqModelToEmp(EmployeeCreateRequestModel empCreateRequestModel)
        {
            Employees ret = new Employees
            {
                Name = empCreateRequestModel.Name,
                Password = empCreateRequestModel.Password,
                Designation = empCreateRequestModel.Designation
            };
            return ret;
        }
        private EmployeeResponseModel EmpToEmpRespModel(Employees emp)
        {
            return new EmployeeResponseModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Designation = emp.Designation
            };
        }
        private List<EmployeeResponseModel> EmpToEmpRespModelList(IEnumerable<Employees> ls)
        {
            var ret = new List<EmployeeResponseModel>();
            foreach (var emp in ls)
            {
                ret.Add(EmpToEmpRespModel(emp));
            }
            return ret;
        }
    }
}
