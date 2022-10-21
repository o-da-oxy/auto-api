using Auto.Data;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Queries;

public class AutoQuery : ObjectGraphType
{
    private readonly IAutoDatabase _db;
    public AutoQuery(IAutoDatabase db)
    {
        _db = db;
    }
}