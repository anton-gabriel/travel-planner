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
        public TripSolver ParentSolver { get; private set; }
        public virtual double Discount { get; private set; } = 0;
        public virtual uint NumberOfPersons { get; private set; } = 0;
        #endregion

        #region Public methods
        public double GetTravelPrice(TravelRequest request, Offer offer)
        {
            double unitPrice = offer.Price / offer.NumberOfPersons;
            if (ParentSolver != null)
            {
                if (NumberOfPersons < request.NumberOfPersons)
                {
                    return ParentSolver.GetTravelPrice(request, offer);
                }
            }
            return request.NumberOfPersons * (unitPrice - unitPrice * Discount);
        }
        #endregion
    }
}
