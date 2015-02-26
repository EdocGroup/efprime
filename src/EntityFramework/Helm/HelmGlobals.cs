using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity.Helm
{
    public static class HelmGlobals
    {
        public static HelmConnectionType ConnectionType { get; set; }
    }

    public enum HelmConnectionType
    {
        SQLCE,
        SQLServer
    }
}
