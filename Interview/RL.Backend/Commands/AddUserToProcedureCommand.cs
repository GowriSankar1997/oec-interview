using MediatR;
using RL.Backend.Models;
using RL.Data.DataModels;

namespace RL.Backend.Commands
{
    public class AddUserToProcedureCommand : IRequest<ApiResponse<PlanProcedure>>
    {
        public int PlanId { get; set; }
        public int ProcedureId { get; set; }
        public int UserId { get; set; }
        
    }
  
}
