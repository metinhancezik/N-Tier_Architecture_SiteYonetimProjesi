using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace BusinessLayer.Container
{
    public static class Extensions
    {


        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISiteService,SiteManager>();
            services.AddScoped<ISite, EfSite>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUser, EfUser>();

            services.AddScoped<ISiteYoneticisiService, SiteYoneticisiManager>();
            services.AddScoped<ISiteYoneticisi, EfSiteYoneticisi>();

            services.AddScoped<IGiderService, GiderManager>();
            services.AddScoped<IGider, EfGider>();

            services.AddScoped<IEvSahibiKiraciService, EvSahibiKiraciManager>();
            services.AddScoped<IEvSahibiKiraci, EfEvSahibiKiraci>();

            services.AddScoped<IDaireService, DaireManager>();
            services.AddScoped<IDaire, EfDaire>();

            services.AddScoped<IBlokService, BlokManager>();
            services.AddScoped<IBlok, EfBlok>();

            services.AddScoped<IAidatService, AidatManager>();
            services.AddScoped<IAidat, EfAidat>();


        }


    }
}
