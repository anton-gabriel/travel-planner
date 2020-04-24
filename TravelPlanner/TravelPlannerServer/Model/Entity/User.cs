using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelPlannerServer.Model.Entity
{
    internal class User
    {
        #region Constructors
        public User(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
        #endregion

        #region Private fields
        private ICollection<Trip> trips;
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; private set; }
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Username { get; private set; }
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Password { get; private set; }
        public ICollection<Trip> Trips
        {
            get 
            {
                if(this.trips == null)
                {
                    this.trips = new HashSet<Trip>();
                }
                return this.trips;
            }
            private set => trips = value;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{Username}";
        }
        #endregion
    }
}
