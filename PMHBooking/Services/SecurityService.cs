using PMHBooking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PMHBooking.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IIdentity _userIdentity;

        public SecurityService(IIdentity userIdentity)
        {

            _userIdentity = userIdentity;
        }

        public string User
        {
            get
            {
                if (!_userIdentity.IsAuthenticated)
                {
                    return null;
                }

                return _userIdentity.Name;
            }
        }
    }
}