using Auto.Data;
using Auto.Data.Entities;
using Auto.Website.GraphQL.GraphType;
using GraphQL;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Mutations;

public class AutoMutation : ObjectGraphType
{
    private readonly IAutoDatabase _db;
    public AutoMutation(IAutoDatabase db)
    {
        _db = db;

        Field<OwnerGraphType>(
            "createOwner",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "firstName"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "lastName"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "phoneNumber"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownersVehicle"}
            ),
            resolve: context =>
            {
                var firstName = context.GetArgument<string>("firstName");
                var lastName = context.GetArgument<string>("lastName");
                var phoneNumber = context.GetArgument<string>("phoneNumber");
                var ownersVehicle = context.GetArgument<string>("ownersVehicle");

                var vehicle = db.FindVehicle(ownersVehicle);

                var owner = new Owner
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    OwnersVehicle = vehicle
                };
                _db.CreateOwner(owner);
                return owner;
            }
        );
        
        Field<VehicleGraphType>(
            "createVehicle",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "registration"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "color"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "year"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "vehicleModel"}
            ),
            resolve: context =>
            {
                var registration = context.GetArgument<string>("registration");
                var color = context.GetArgument<string>("color");
                var year = context.GetArgument<int>("year");
                var vehicleModel = context.GetArgument<string>("vehicleModel");

                var model = db.FindModel(vehicleModel);
                var modelCode = model.Code;
                var owner = db.FindOwner(registration);

                var vehicle = new Vehicle
                {
                    Color = color,
                    ModelCode = modelCode,
                    Owner = owner,
                    Registration = registration,
                    VehicleModel = model,
                    Year = year
                };
                _db.CreateVehicle(vehicle);
                return vehicle;
            }
        );
    }
}