using Pomotr.Server.Database;
using GraphQL.Types;

namespace Pomotr.Server.GraphQL
{
    public class TaskType : ObjectGraphType<Task>
    {
        public TaskType()
        {
            Name = "Task";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the completed task");
            //Field(x => x.User).Description("User that completed the task");
            Field(x => x.Description).Description("Description of the task");
            Field(x => x.Points).Description("Points given for the task");
            Field(x => x.DateCompleted).Description("Date when task was completed");
        }
    }
}