using Auto.Data;
using Grpc.Core;

namespace Auto.OwnerGrpcService.Services;

public class OwnerService : OwnerGrpcService.OwnerService.OwnerServiceBase
{
    private readonly IAutoDatabase _db;

    public OwnerService(IAutoDatabase db)
    {
        _db = db;
    }

    public override Task<OwnerReply> GetOwner(OwnerRequest request, ServerCallContext context)
    {
        return Task.FromResult(new OwnerReply
        {
            FirstName = "FirstName: " + _db.FindOwner(request.Registration).FirstName,
            LastName = "LastName: " + _db.FindOwner(request.Registration).LastName,
            PhoneNumber = "Phone number: " + _db.FindOwner(request.Registration).PhoneNumber
        });
    }
}