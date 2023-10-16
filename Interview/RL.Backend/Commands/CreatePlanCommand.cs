using MediatR;
using RL.Backend.Models;
using RL.Data.DataModels;

namespace RL.Backend.Commands;

public class CreatePlanCommand : IRequest<ApiResponse<Plan>>
{
    //public int planId { get; set; }
    //public DateTime CreatedDate { get; set; }
    //public DateTime updatedate { get; set; }
}