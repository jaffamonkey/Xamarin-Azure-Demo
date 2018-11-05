﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using EShope.API.DataObjects;
using EShope.API.Models;
using Owin;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables.Config;
using System.Data.Entity.Migrations;

namespace EShope.API
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                //.AddMobileAppHomeController()             // from the Home package
                //.MapApiControllers()
                //.AddTables(                               // from the Tables package
                //    new MobileAppTableConfiguration()
                //        .MapTableControllers()
                //        .AddEntityFramework()             // from the Entity package
                //    )
                ////.AddPushNotifications()                   // from the Notifications package
                //.MapLegacyCrossDomainController()         // from the CrossDomain package

                //.AddTablesWithEntityFramework()

                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            //Database.SetInitializer(new MobileServiceInitializer());

            var migrator = new DbMigrator(new Migrations.Configuration());
            migrator.Update();

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<EShopeMobileServiceContext>
    {
        protected override void Seed(EShopeMobileServiceContext context)
        {
            
        }
    }
}
