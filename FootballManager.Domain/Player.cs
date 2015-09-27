using System;

namespace FootballManager.Domain
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsRetired { get; set; }

        public int? TeamId { get; set; }

        public int NationId { get; set; }

        public virtual Team Team { get; set; }

        public virtual Nation Nationality { get; set; }
    }
}
