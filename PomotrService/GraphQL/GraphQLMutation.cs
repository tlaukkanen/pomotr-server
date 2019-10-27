using System;
using GraphQL.Types;
using Pomotr.Server.Database;

namespace Pomotr.Server.GraphQL {
    public class GraphQLMutation : ObjectGraphType<object>
    {
        public GraphQLMutation(ApplicationDbContext data) {
            Name = "Mutation";
            Field<TaskType>(
                "createTask",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TaskInputType>> { Name = "task" }
                ),
                resolve: context => {
                    var task = context.GetArgument<Task>("task");
                    task.Id = Guid.NewGuid().ToString();
                    data.Tasks.Add(task);
                    return task;
                }
            );
        }
        
    }
}