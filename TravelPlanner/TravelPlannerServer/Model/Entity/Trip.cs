﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlannerServer.Model.Entity
{
    internal sealed class Trip
    {
        #region Constructors
        private Trip()
        {

        }
        public Trip(Offer offer, DateTime startDate)
        {
            Offer = offer;
            StartDate = startDate;
            EndDate = StartDate.AddDays(offer.Days);
            NumberOfPersons = 1;
        }
        #endregion

        #region Private fields
        private DateTime endDate;
        private uint numberOfPersons;
        private double price;
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; private set; }
        [Required]
        public Offer Offer { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (value < StartDate)
                {
                    throw new ArgumentException(nameof(EndDate));
                }
                this.endDate = value;
            }
        }
        public uint NumberOfPersons
        {
            get => numberOfPersons;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(nameof(NumberOfPersons));
                }
                this.numberOfPersons = value;
            }
        }
        [Required]
        public double Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(Price));
                }
                price = value;
            }
        }
        public User User { get; set; }
        #endregion

        public override string ToString()
        {
            return $"[{Offer}, {StartDate}, {EndDate}, {NumberOfPersons}, {Price}, {User.Username}]";
        }
    }
}
