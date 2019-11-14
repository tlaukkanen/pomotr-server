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
                    data.SaveChanges();
                    return task;
                }
            );

            Field<ErrandType>(
                "createErrand",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ErrandTypeInput>> { Name = "errand" }
                ),
                resolve: context => {
                    var errand = context.GetArgument<Errand>("errand");
                    errand.Id = Guid.NewGuid().ToString();
                    data.Errands.Add(errand);
                    data.SaveChanges();
                    return errand;
                }
            );
        }
        
    }
}