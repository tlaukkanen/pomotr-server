using System.Linq;
using Pomotr.Server.Database;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace Pomotr.Server.GraphQL
{
    public class UserQuery : ObjectGraphType<object>
    {
        public UserQuery(ApplicationDbContext db)
        {
            Name = "Query";
            Field<UserType>(
                "User",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id",
                        Description = "The ID of the User."
                    }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    var user = db
                        .Users
                        .Include(a => a.CompletedTasks)
                        .FirstOrDefault(i => i.Id == id);
                    return user;
                }
            );
 
            Field<ListGraphType<UserType>>(
                "Users",
                resolve: context =>
                {
                    var users = db.Users.Include(a => a.CompletedTasks);
                    return users;
                }
            );  

            Field<ListGraphType<ErrandType>>(
                "Errands",
                resolve: context =>
                {
                    var users = db.Errands;
                    return users;
                }
            );  

        }
    }
}