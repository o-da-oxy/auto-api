using System.Collections.Generic;
using Auto.Data;
using Auto.Data.Entities;
using Auto.Website.GraphQL.GraphType;
using GraphQL;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Queries;

public class AutoQuery : ObjectGraphType
{
    private readonly IAutoDatabase _db;
    public AutoQuery(IAutoDatabase db)
    {
        _db = db;

        Field<ListGraphType<OwnerGraphType>>("owners", "Запрос: все владельцы", 
            resolve: GetAllOwners);

        Field<ListGraphType<VehicleGraphType>>("vehicles", "Запрос: все авто", 
            resolve: GetAllVehicles);
    }

    private IEnumerable<Vehicle> GetAllVehicles(IResolveFieldContext<object> context)
    {
        return _db.ListVehicles();
    }

    private IEnumerable<Owner> GetAllOwners(IResolveFieldContext<object> context)
    {
        return _db.ListOwners();
    }
}