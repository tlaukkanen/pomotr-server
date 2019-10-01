using System;

namespace Pomotr.Server.Database
{
    public class Task
    {
        public string Id { get; set; }

        public User User { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }

        public DateTime DateCompleted { get; set; }
    }

}