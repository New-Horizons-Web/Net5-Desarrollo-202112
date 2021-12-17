using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts;
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EFCore.BikeStore.Web.API.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider service)
        {
            BikestoresContext context = service.GetRequiredService<BikestoresContext>();
            EnsuredDatabase(context);
            EnsuredBrands(context);
        }

        private static void EnsuredDatabase(BikestoresContext context)
        {
            context.Database.Migrate();
        }
        private static void EnsuredBrands(BikestoresContext context)
        {
            Brand elektra = new Brand { BrandName = "Elektra" };
            Brand haro = new Brand { BrandName = "Haro" };
            Brand heller = new Brand { BrandName = "Heller" };

            if (!context.Brands.Where(b => b.BrandName == elektra.BrandName).Any()) { context.Brands.Add(elektra); }
            if (!context.Brands.Where(b => b.BrandName == haro.BrandName).Any()) { context.Brands.Add(haro); }
            if (!context.Brands.Where(b => b.BrandName == heller.BrandName).Any()) { context.Brands.Add(heller); }

            context.SaveChanges();
        }
    }
}
