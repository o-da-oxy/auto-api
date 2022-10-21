using Auto.Data;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Mutations;

public class AutoMutation : ObjectGraphType
{
    private readonly IAutoDatabase _db;
    public AutoMutation(IAutoDatabase db)
    {
        _db = db;
    }
}