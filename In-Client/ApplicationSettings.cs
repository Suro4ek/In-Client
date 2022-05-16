using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Drawing;

namespace In_Client
{
    public class ApplicationSettings : ApplicationSettingsBase
    {

        [UserScopedSetting()]
        [DefaultSettingValue("http://localhost:8080")]
        public String ServerURL
        {
            get
            {
                string url = (String)this["ServerURL"];
                if (url.EndsWith("/"))
                {
                    return url;
                }
                else
                {
                    return url + "/";
                }
            }
            set
            {
                this["ServerURL"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public String JwtToken
        {
            get
            {
                string token = (String)this["JwtToken"];
                return token;
            }
            set
            {
                this["JwtToken"] = value;
            }
        }
    }
}
