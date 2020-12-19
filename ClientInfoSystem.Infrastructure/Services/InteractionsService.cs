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
    public class InteractionsService : IInteractionsService
    {
        
        private readonly IAsyncRepository<Interactions> _interRepository;
        public InteractionsService(IAsyncRepository<Interactions> interRepository)
        {
            _interRepository = interRepository;

        }
        public async Task<InteractionResponseModel> CreateInteraction(InteractionCreateRequestModel interactionCreateRequest)
        {
            Interactions inter = InterReqModelToInter(interactionCreateRequest);
            return InterToInterRespModel(await _interRepository.AddAsync(inter));
        }

        public async Task DeleteInteraction(int id)
        {
            var ls = await _interRepository.GetByIdAsync(id);
            await _interRepository.DeleteAsync(ls);
        }

        public async Task<IEnumerable<InteractionResponseModel>> ListAllInteractions()
        {
            return InterToInterRespModelList(await _interRepository.ListAllAsync());
        }
        public async Task<IEnumerable<InteractionResponseModel>> GetByEmpId(int id)
        {
            return InterToInterRespModelList(await _interRepository.ListAsync(i => i.EmpId == id));
        }
        public async Task<IEnumerable<InteractionResponseModel>> GetByCliId(int id)
        {
            return InterToInterRespModelList(await _interRepository.ListAsync(i => i.ClientId == id));
        }
        public async Task<InteractionResponseModel> UpdateInteraction(InteractionCreateRequestModel interactionCreateRequest)
        {
            var inter = await _interRepository.GetByIdAsync(interactionCreateRequest.Id);
            inter.IntType = interactionCreateRequest.IntType;
            inter.EmpId = interactionCreateRequest.EmpId;
            inter.ClientId = interactionCreateRequest.ClientId;
            inter.IntDate = interactionCreateRequest.IntDate;
            return InterToInterRespModel(await _interRepository.UpdateAsync(inter));
        }

        // Mappers
        private Interactions InterReqModelToInter(InteractionCreateRequestModel interCreateRequestModel)
        {
            Interactions ret = new Interactions
            {
                Id = interCreateRequestModel.Id,
                ClientId = interCreateRequestModel.ClientId,
                EmpId = interCreateRequestModel.EmpId,
                Remarks = interCreateRequestModel.Remarks,
                IntDate = interCreateRequestModel.IntDate,
                IntType = interCreateRequestModel.IntType
            };
            return ret;
        }
        private InteractionResponseModel InterToInterRespModel(Interactions inter)
        {
            return new InteractionResponseModel
            {
                Id = inter.Id,
                ClientId = inter.ClientId,
                EmpId = inter.EmpId,
                IntType = inter.IntType,
                Remarks = inter.Remarks,
                IntDate = inter.IntDate
            };
        }
        private List<InteractionResponseModel> InterToInterRespModelList(IEnumerable<Interactions> ls)
        {
            var ret = new List<InteractionResponseModel>();
            foreach (var client in ls)
            {
                ret.Add(InterToInterRespModel(client));
            }
            return ret;
        }
    }
}
