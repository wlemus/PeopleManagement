﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PeopleManagement.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PeopleManagement.WCF
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e) 		
		{
           // ServiceProvider = DependencyInjectionConfig.ConfigureServices();

        }
		
		protected void Session_Start(object sender, EventArgs e) 
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_Error(object sender, EventArgs e) 
		{

		}

		protected void Session_End(object sender, EventArgs e) 
		{

		}

		protected void Application_End(object sender, EventArgs e) 
		{

		}
      
    }
}