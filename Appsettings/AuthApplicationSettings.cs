using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Appsettings
{
    public class AuthApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string AdminRole { get; set; }
        public string NormalUserRole { get; set; }
        public AuthApplicationSettings Value { get; internal set; }
    }
}
