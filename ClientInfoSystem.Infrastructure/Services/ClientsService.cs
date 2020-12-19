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
    public class ClientsService : IClientsService
    {
        private readonly IAsyncRepository<Clients> _clientRepository;
        public ClientsService(IAsyncRepository<Clients> clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ClientResponseModel> CreateClient(ClientCreateRequestModel clientCreateRequest)
        {
            Clients client = ClientReqModelToClient(clientCreateRequest);
            return ClientToClientRespModel(await _clientRepository.AddAsync(client));
        }

        public async Task DeleteClient(int id)
        {
            var ls = await _clientRepository.GetByIdAsync(id);
            await _clientRepository.DeleteAsync(ls);
        }

        public async Task<IEnumerable<ClientResponseModel>> ListAllClients()
        {
            return ClientToClientRespModelList(await _clientRepository.ListAllAsync());
        }

        public async Task<ClientResponseModel> UpdateClient(ClientCreateRequestModel clientCreateRequest)
        {
            var cli = await _clientRepository.GetByIdAsync(clientCreateRequest.Id);
            cli.Name = clientCreateRequest.Name;
            cli.Phone = clientCreateRequest.Phone;
            cli.Email = clientCreateRequest.Email;
            cli.Address = clientCreateRequest.Address;
            return ClientToClientRespModel(await _clientRepository.UpdateAsync(cli));
        }
        
        // Mappers
        
        private Clients ClientReqModelToClient(ClientCreateRequestModel clientCreateRequestModel)
        {
            Clients ret = new Clients
            {
                Name = clientCreateRequestModel.Name,
                Phone = clientCreateRequestModel.Phone,
                Address = clientCreateRequestModel.Address,
                Email = clientCreateRequestModel.Email
            };
            return ret;
        }
        private ClientResponseModel ClientToClientRespModel(Clients client)
        {
            return new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            };
        }
        private List<ClientResponseModel> ClientToClientRespModelList(IEnumerable<Clients> ls)
        {
            var ret = new List<ClientResponseModel>();
            foreach (var client in ls)
            {
                ret.Add(ClientToClientRespModel(client));
            }
            return ret;
        }
    }
}
