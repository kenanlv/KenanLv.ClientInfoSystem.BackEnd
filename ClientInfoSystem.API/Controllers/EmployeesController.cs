using ClientInfoSystem.Core.Models.Request;
using ClientInfoSystem.Core.ServiceInterfaces;
using ClientInfoSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _empService;
        public EmployeesController(IEmployeesService empService)
        {
            _empService = empService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateEmp(EmployeeCreateRequestModel empCreateRequestModel)
        {
            var ret = await _empService.CreateEmp(empCreateRequestModel);
            if (ret == null)
            {
                return BadRequest(new { message = "Please Check Your Input" });
            }
            return Ok(ret);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateEmp(EmployeeCreateRequestModel empCreateRequestModel)
        {
            var client = await _empService.UpdateEmp(empCreateRequestModel);
            return Ok(client);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            await _empService.DeleteEmp(id);
            return Ok();
        }
        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> GetAllEmps()
        {
            var ls = await _empService.ListAllEmps();
            if (!ls.Any())
            {
                return NotFound(new { message = "No Clients" });
            }
            return Ok(ls);
        }
    }
}
