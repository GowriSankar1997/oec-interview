using MediatR;
using RL.Backend.Models;
using RL.Data;
using RL.Data.DataModels;
using Newtonsoft.Json;

namespace RL.Backend.Commands.Handlers.Plans
{
    public class AddUserToProcedureCommandHandler:IRequestHandler<AddUserToProcedureCommand, ApiResponse<PlanProcedure>>
    {

        private readonly RLContext _context;

        public AddUserToProcedureCommandHandler(RLContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<PlanProcedure>> Handle(AddUserToProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {   var userList = _context.Users.ToList();
                var Procedureuser = _context.PlanProcedures.ToList();
                PlanProcedure procedureUser1 = new PlanProcedure();
                if (userList.Any() && Procedureuser.Any() && request != null )
                {                    
                    foreach (var item in Procedureuser)
                    {
                        if (item.ProcedureId == request.ProcedureId)
                          procedureUser1 = item;                    
                    }
                    var existingProcedure = procedureUser1?.UserList != null ? JsonConvert.DeserializeObject<List<User>>(procedureUser1.UserList) : new List<User>();
                   
                    bool isUpdate = existingProcedure.Any(i => i.UserId != request.UserId);
                    if (isUpdate) 
                    {
                        List<User> userlist = userList.Where(u => u.UserId == request.UserId).ToList();
                        existingProcedure.AddRange(userlist);
                        procedureUser1.UserList = JsonConvert.SerializeObject(existingProcedure);
                        _context.Update(procedureUser1);
                        await _context.SaveChangesAsync();
                    }            
                }
                return ApiResponse<PlanProcedure>.Succeed(procedureUser1);
                
            }
            catch (Exception e)
            {
                return ApiResponse<PlanProcedure>.Fail(e);
            }
        }


    }
}
