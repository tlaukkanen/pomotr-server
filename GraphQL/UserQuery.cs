using System.Linq;
using Pomotr.Server.Database;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace Pomotr.Server.GraphQL
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(ApplicationDbContext db)
        {
            Field<UserType>(
                "User",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>
                    {
                        Name = "username",
                        Description = "The username"
                    }
                ),
                resolve: context =>
                {
                    var username = context.GetArgument<string>("username");
                    var user = db
                        .Users
                        .Include(a => a.CompletedTasks)
                        .FirstOrDefault(i => i.Username == username);
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
        }
    }
}