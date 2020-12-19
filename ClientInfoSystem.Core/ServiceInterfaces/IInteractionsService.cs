using ClientInfoSystem.Core.Models.Request;
using ClientInfoSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfoSystem.Core.ServiceInterfaces
{
    public interface IInteractionsService
    {
        Task<InteractionResponseModel> CreateInteraction(InteractionCreateRequestModel interactionCreateRequest);
        Task<InteractionResponseModel> UpdateInteraction(InteractionCreateRequestModel interactionCreateRequest);
        Task DeleteInteraction(int id);
        Task<IEnumerable<InteractionResponseModel>> ListAllInteractions();
        Task<IEnumerable<InteractionResponseModel>> GetByEmpId(int id);
        Task<IEnumerable<InteractionResponseModel>> GetByCliId(int id);

    }
}
