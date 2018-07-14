using Common.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{

    public class CurrentUser
    {

        private string _token;

        public void Init(string token, Dictionary<string, object> claims)
        {
            this._token = token;
            this._claims = claims;
        }

        private Dictionary<string, object> _claims;

        public string GetToken()
        {
            return this._token;
        }

        public Dictionary<string, object> GetClaims()
        {
            return this._claims;
        }

        public bool IsTenant()
        {
            return this._claims
                .Where(_ => _.Key.ToLower() == "tenant")
                .IsAny();
        }

        public TS GetTenantId<TS>()
        {
            if (this.IsTenant())
            {
                var subjectId = this._claims
                    .Where(_ => _.Key.ToLower() == "tenant")
                    .SingleOrDefault()
                    .Value;

                return (TS)Convert.ChangeType(subjectId, typeof(TS));
            }

            return default(TS);
        }

        public TS GetUserId<TS>()
        {
            var subjectId = this._claims
                .Where(_ => _.Key.ToLower() == "sub")
                .SingleOrDefault()
                .Value;

            return (TS)Convert.ChangeType(subjectId, typeof(TS));
        }

        public int GetUserId()
        {
            return this.GetUserId<int>();
        }

        public int GetTenantId()
        {
            return this.GetTenantId<int>();
        }


    }
}
