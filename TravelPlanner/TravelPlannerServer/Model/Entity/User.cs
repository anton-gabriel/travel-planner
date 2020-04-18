using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        #region Properties
        [Index(IsUnique = true)]
        [Required]
        [StringLength(200)]
        public int Id { get; private set; }
        [Index(IsUnique = true)]
        [Required]
        [StringLength(200)]
        public string Username { get; private set; }
        [Required]
        [StringLength(200)]
        public string Password { get; private set; }
        #endregion
    }
}
