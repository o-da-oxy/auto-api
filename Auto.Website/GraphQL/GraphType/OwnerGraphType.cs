using Auto.Data.Entities;
using GraphQL.Types;

namespace Auto.Website.GraphQL.GraphType;

public class OwnerGraphType : ObjectGraphType<Owner> {
    public OwnerGraphType() {
        Name = "owner";
        Field(c => c.FirstName);
        Field(c => c.LastName);
        Field(c => c.PhoneNumber);
        Field(c => c.OwnersVehicle, nullable: true, type: typeof(VehicleGraphType))
            .Description("Owner's vehicle");
    }
}