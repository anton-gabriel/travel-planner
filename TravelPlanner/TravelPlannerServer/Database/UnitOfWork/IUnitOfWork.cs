using System;
using TravelPlannerServer.Database.Repository;

namespace TravelPlannerServer.Database.UnitOfWork
{
    internal interface IUnitOfWork
        : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
