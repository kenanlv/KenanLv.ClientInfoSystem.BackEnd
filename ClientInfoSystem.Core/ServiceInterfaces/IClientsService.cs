using ClientInfoSystem.Core.Models.Request;
using ClientInfoSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfoSystem.Core.ServiceInterfaces
{
    public interface IClientsService
    {
        Task<ClientResponseModel> CreateClient(ClientCreateRequestModel clientCreateRequest);
        Task<ClientResponseModel> UpdateClient(ClientCreateRequestModel clientCreateRequest);
        Task DeleteClient(int id);
        Task<IEnumerable<ClientResponseModel>> ListAllClients();
    }
}
