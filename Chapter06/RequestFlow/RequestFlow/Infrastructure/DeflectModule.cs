﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestFlow.Infrastructure
{
    public class DeflectModule:IHttpModule
    {
        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="app">An <see cref="T:System.Web.HttpApplication" /> that provides
        /// access to the methods, properties, and events common to all application objects
        /// within an ASP.NET application</param>
        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) => 
            {
                if (app.Request.RawUrl.ToLower().StartsWith("/home"))
                {
                    app.Response.StatusCode = 500;
                    app.CompleteRequest();
                }
            };
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that
        /// implements <see cref="T:System.Web.IHttpModule" />.
        /// </summary>
        public void Dispose()
        {
            //do nothing
        }
    }
}