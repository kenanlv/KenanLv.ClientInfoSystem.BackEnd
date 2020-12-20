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
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionsService _interService;
        public InteractionsController(IInteractionsService interService)
        {
            _interService = interService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateClient(InteractionCreateRequestModel clientCreateRequestModel)
        {
            var ret = await _interService.CreateInteraction(clientCreateRequestModel);
            if (ret == null)
            {
                return BadRequest(new { message = "Please Check Your Input" });
            }
            return Ok(ret);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateClient(InteractionCreateRequestModel clientCreateRequestModel)
        {
            var inter = await _interService.UpdateInteraction(clientCreateRequestModel);
            if (inter == null)
            {
                return NotFound(new { message = "there is no such clients in the DB" });
            }
            return Ok(inter);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _interService.DeleteInteraction(id);
            return Ok();
        }
        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var ls = await _interService.ListAllInteractions();
            if (!ls.Any())
            {
                return NotFound(new { message = "No Interactions" });
            }
            return Ok(ls);
        }
        [HttpGet]
        [Route("GetByEmpId/{id:int}")]
        public async Task<IActionResult> GetByEmpId(int id)
        {
            var ls = await _interService.GetByEmpId(id);
            return Ok(ls);
        }
        [HttpGet]
        [Route("GetByCliId/{id:int}")]
        public async Task<IActionResult> GetByCliId(int id)
        {
            var ls = await _interService.GetByCliId(id);
            return Ok(ls);
        }
    }
}
