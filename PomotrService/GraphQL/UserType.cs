using Pomotr.Server.Database;
using GraphQL.Types;

namespace Pomotr.Server.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the user");
            Field(x => x.Username).Description("The username for the user");
            Field(x => x.Email).Description("The email address of the user");
            Field(x => x.CompletedTasks, type: typeof(ListGraphType<TaskType>)).Description("User's tasks");
        }
    }
}