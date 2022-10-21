using Auto.Data.Entities;
using GraphQL.Types;

namespace Auto.Website.GraphQL.GraphType;

public class ModelGraphType : ObjectGraphType<Model>
{
    public ModelGraphType() {
        Name = "model";
        Field(m => m.Name).Description("Model's name");
        Field(m => m.Manufacturer, type: typeof(ManufacturerGraphType))
            .Description("Model's manufacturer");
    }
}