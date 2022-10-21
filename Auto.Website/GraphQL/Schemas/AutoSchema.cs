using Auto.Data;
using Auto.Website.GraphQL.Mutations;
using Auto.Website.GraphQL.Queries;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Schemas;

//взаимосвязь между типами и запросами GraphQL, а также моделью внутреннего домена и хранилищем данных
public class AutoSchema : Schema {
    public AutoSchema(IAutoDatabase db)
    {
        Query = new AutoQuery(db);
        Mutation = new AutoMutation(db);
    }
}