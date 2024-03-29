﻿using TravelPlannerServer.Database;
using TravelPlannerServer.Database.UnitOfWork;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Model.DataAccess
{
    internal static class UserDataAccessLayer
    {
        #region Public methods
        public static User GetUser(string name)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            return unitOfWork.Users.SingleOrDefault(user => user.Username.Equals(name));
        }

        public static bool Login(User user)
        {
            if (user is null)
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            return unitOfWork
                .Users
                .SingleOrDefault(dbUser => dbUser.Username.Equals(user.Username) && dbUser.Password.Equals(user.Password)) != null;
        }
        public static bool Register(User user)
        {
            if (user is null)
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            bool registered = unitOfWork
                .Users
                .SingleOrDefault(dbUser => dbUser.Username.Equals(user.Username)) != null;
            if (!registered)
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Complete();
                return true;
            }
            return false;
        }
        public static void AddTrip(int userId, Trip trip)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            var result = unitOfWork.Users.Get(userId);
            result.Trips.Add(trip);
            unitOfWork.Complete();
        }
        public static void RemoveTrip(int userId, Trip trip)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            var result = unitOfWork.Users.Get(userId);
            result.Trips.Remove(trip);
            unitOfWork.Complete();
        }
        #endregion
    }
}