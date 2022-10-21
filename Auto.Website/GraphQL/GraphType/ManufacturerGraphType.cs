using Auto.Data.Entities;
using GraphQL.Types;

namespace Auto.Website.GraphQL.GraphType;

public class ManufacturerGraphType : ObjectGraphType<Manufacturer>
{
    public ManufacturerGraphType() {
        Name = "manufacturer";
        Field(c => c.Name).Description("Manufacturer's name");
    }
}