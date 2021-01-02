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
            if (client == null)
            {
                return NotFound(new { message="there is no such clients in the DB"});
            }
            return Ok(client);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await _clientService.DeleteClient(id);
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
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
