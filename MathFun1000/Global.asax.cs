/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Global.asax.cs
*
* Brief Description: Global
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using MathFun1000;

namespace MathFun1000
{
    public class Global : HttpApplication
    {
        // Code that runs on application startup
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //  Code that runs on application shutdown
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        // Code that runs when an unhandled error occurs
        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
