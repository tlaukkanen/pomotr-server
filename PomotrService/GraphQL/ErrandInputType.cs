using Pomotr.Server.Database;
using GraphQL.Types;

namespace Pomotr.Server.GraphQL
{
    public class ErrandTypeInput : InputObjectGraphType<Errand>
    {
        public ErrandTypeInput()
        {
            Name = "ErrandInput";
            Field(x => x.Name).Description("Name of the errand");
            Field(x => x.ValuePoints).Description("Points given for the completed errand task");
        }
    }
}