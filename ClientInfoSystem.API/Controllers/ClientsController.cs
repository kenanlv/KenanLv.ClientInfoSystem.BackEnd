using ClientInfoSystem.Core.Models.Request;
using ClientInfoSystem.Core.ServiceInterfaces;
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
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientService;
        public ClientsController(IClientsService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateClient(ClientCreateRequestModel clientCreateRequestModel)
        {
            var ret = await _clientService.CreateClient(clientCreateRequestModel);
            if (ret == null)
            {
                return BadRequest(new { message = "Please Check Your Input" });
            }
            return Ok(ret);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateClient(ClientCreateRequestModel clientCreateRequestModel)
        {
            var client = await _clientService.UpdateClient(clientCreateRequestModel);
            return Ok(client);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClient(id);
            return Ok();
        }
        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var ls = await _clientService.ListAllClients();
            if (!ls.Any())
            {
                return NotFound(new { message = "No Clients" });
            }
            return Ok(ls);
        }
    }
}
