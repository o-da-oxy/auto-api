using Auto.Data.Entities;
using GraphQL.Types;

namespace Auto.Website.GraphQL.GraphType;

public class VehicleGraphType : ObjectGraphType<Vehicle> {
    public VehicleGraphType() {
        Name = "vehicle";
        Field(c => c.Registration);
        Field(c => c.Color);
        Field(c => c.Year);
        Field(c => c.VehicleModel, nullable: false, type: typeof(ModelGraphType))
            .Description("Vehicle's model");
    }
}