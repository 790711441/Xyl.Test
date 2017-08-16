using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xyl.Test.Models;

namespace Xyl.Test.Code.Expand
{
    public static class Expand
    {

        public static ApplicationUser GetUser(this Controller _this) {
            string _str = "";
            if (_this.User == null) return null;
            if (_this.User.Identity == null) return null;
            try
            {
                string kName = "UserJson";
                var claims = ((System.Security.Claims.ClaimsIdentity)_this.User.Identity).Claims;
                _str = claims.Where(p => p.Type == kName).FirstOrDefault().Value;
                var user = JsonConvert.DeserializeObject<ApplicationUser>(_str);
                return user;
            }
            catch {

            }
            return null;
        }
    }
}