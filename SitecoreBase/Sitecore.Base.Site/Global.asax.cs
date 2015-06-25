using Sitecore.Diagnostics;
using Sitecore.Pipelines.EndSession;
using Sitecore.Pipelines.SessionEnd;
using Sitecore.Web;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
namespace Sitecore.Base.Site
{
    /// <summary>The application.</summary>
    /// <remarks>
    /// Note to inheritors: 
    ///   Implementing Session_End or FormsAuthentication_OnAuthenticate directly in global.asax will override the methods in the base (even without the "override" keyword)
    ///   Using an intermediate subclass instead (like inside a global.asax.cs file), requires to explicitely add the "override" keyword.
    ///   Also note that alternate signatures of the event methods, will cause both methods to be called, see http://aspnetresources.com/articles/event_handlers_in_global_asax for more information.
    /// </remarks>
    public class Global : HttpApplication
    {
        /// <summary>
        /// The raise session end event.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void RaiseSessionEndEvent(HttpApplication context)
        {
            Assert.ArgumentNotNull(context, "context");
            object hostContext = System.Runtime.Remoting.Messaging.CallContext.HostContext;
            try
            {
                System.Runtime.Remoting.Messaging.CallContext.HostContext = new HttpContext(new SessionEndWorkerRequest("SESSION END", string.Empty, new System.IO.StringWriter()));
                HttpContext.Current.ApplicationInstance = context;
                HttpSessionState arg_44_0 = HttpContext.Current.Session;
                HttpContext.Current.Items["AspSession"] = context.Session;
                SessionEndPipeline.Run(new SessionEndArgs(HttpContext.Current));
            }
            finally
            {
                System.Runtime.Remoting.Messaging.CallContext.HostContext = hostContext;
            }
        }
        /// <summary>The session_ end.</summary>
        public virtual void Session_End()
        {
            Sitecore.Web.Application.RaiseSessionEndEvent(this);
        }
        /// <summary>Global event: called during authentication, see the remarks in <see cref="T:System.Web.Security.FormsAuthenticationEventHandler" /></summary>
        /// <remarks>
        /// Fixes .net 4.5 authentication issue when the mode is set to "Forms" instead of Sitecore's default of None, by assigning Sitecore's context user to args.User</remarks>
        public virtual void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
        {
            string frameworkVersion = this.GetFrameworkVersion();
            if (!string.IsNullOrEmpty(frameworkVersion) && frameworkVersion.StartsWith("v4.", System.StringComparison.InvariantCultureIgnoreCase))
            {
                args.User = Sitecore.Context.User;
            }
        }
        /// <summary>
        /// Gets the CLR version of the runtime environment
        /// </summary>
        /// <returns>the version, or empty if it failed to retrieve it</returns>
        private string GetFrameworkVersion()
        {
            string result;
            try
            {
                result = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
            }
            catch (System.Exception exception)
            {
                Log.Error("Cannot get framework version", exception, this);
                result = string.Empty;
            }
            return result;
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Default",
               "searchAPI/{action}/{id}",
               new { controller = "searchAPI", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
