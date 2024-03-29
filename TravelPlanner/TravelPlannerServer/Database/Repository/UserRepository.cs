﻿using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Database.Repository
{
    internal sealed class UserRepository
        : Repository<User>, IUserRepository
    {
        #region Constructors
        public UserRepository(TravelPlannerContext context)
            : base(context)
        {

        }
        #endregion
    }
}
