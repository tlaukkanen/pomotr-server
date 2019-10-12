using Pomotr.Server.Database;
using GraphQL.Types;

namespace Pomotr.Server.GraphQL {

    public class ErrandType : ObjectGraphType<Errand>
    {
        public ErrandType() {
            Name = "Errand";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Errand");
            Field(x => x.Name).Description("Name of the Errand");
            Field(x => x.ValuePoints).Description("Value of the completed Errand");
        }
        
    }
}