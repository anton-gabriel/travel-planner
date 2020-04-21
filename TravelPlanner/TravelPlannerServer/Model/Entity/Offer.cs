using System.ComponentModel.DataAnnotations;
using TravelPlannerServer.Utils.Enums;

namespace TravelPlannerServer.Model.Entity
{
    internal sealed class Offer
    {
        #region Constructors
        private Offer()
        {

        }
        public Offer(TravelLocationType locationType, string location, uint days, uint price, uint numberOfPersons)
        {
            Location = location ?? throw new System.ArgumentNullException(nameof(location));
            LocationType = locationType;
            Days = days;
            Price = price;
            NumberOfPersons = numberOfPersons;
        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; private set; }
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Location { get; private set; }
        [Required]
        public uint Days { get; private set; }
        [Required]
        public double Price { get; private set; }
        [Required]
        public uint NumberOfPersons { get; private set; }
        [Required]
        public TravelLocationType LocationType { get; private set; }
        #endregion
    }
}
