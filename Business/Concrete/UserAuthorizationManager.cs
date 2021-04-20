using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserAuthorizationManager : IUserAuthorizationService
    {
        IUserAuthorizationDal _userAuthorizationDal;

        public UserAuthorizationManager(IUserAuthorizationDal userAuthorizationDal)
        {
            _userAuthorizationDal = userAuthorizationDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userAuthorizationDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userAuthorizationDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userAuthorizationDal.Get(u => u.Email == email);
        }
    }
}
