using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using RoomM.Application.UserModule.Services;

namespace RoomM.WebApp.Security
{
    public class WebMembershipProvider : MembershipProvider
    {
        private IAuthService service;

        public WebMembershipProvider(IAuthService service)
            : base()
        {
            this.service = service;
        }

        public override MembershipUser CreateUser(string username,
            string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved,
            object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            return this.service.ValidateUser(username, password);
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }
    }
}