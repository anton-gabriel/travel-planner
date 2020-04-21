using System;
using TravelPlannerServer.Model;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.TripSolverChain
{
    internal class TripSolver
    {
        #region Constructors
        public TripSolver(TripSolver parent)
        {
            ParentSolver = parent ?? throw new ArgumentNullException(nameof(parent));
        }
        #endregion

        #region Properties
        protected TripSolver ParentSolver { get; private set; }
        protected virtual double Discount => 0;
        protected virtual uint NumberOfPersons => 0;
        #endregion

        #region Public methods
        public double GetTripPrice(uint persons, Offer offer)
        {
            double unitPrice = offer.Price / offer.NumberOfPersons;
            if (ParentSolver != null)
            {
                if (NumberOfPersons < persons)
                {
                    return ParentSolver.GetTripPrice(persons, offer);
                }
            }
            return persons * (unitPrice - unitPrice * Discount);
        }
        #endregion
    }
}
