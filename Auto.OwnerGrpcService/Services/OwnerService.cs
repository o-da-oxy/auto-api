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
        return Task.FromResult(GetOwner(request.Registration));
    }

    public OwnerReply GetOwner(string reg)
    {
        var owner = _db.FindOwner(reg);
        return new OwnerReply
        {
            FirstName = "FirstName: " + owner?.FirstName,
            LastName = "LastName: " + owner?.LastName,
            PhoneNumber = "Phone number: " + owner?.PhoneNumber
        };
    }
}