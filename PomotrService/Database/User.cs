using System.Collections.Generic;

namespace Pomotr.Server.Database {
    public class User {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<Task> CompletedTasks { get; set; }
    }
}