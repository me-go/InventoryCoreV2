using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryCoreVisualStudio.Models;

namespace InventoryCoreVisualStudio.Data
{
    public class DbInitializer
    {
        public static void Initialize(InventoryContext context)
        {
            context.Database.EnsureCreated();
            //Look for existance of any items in DB.
            if (context.Items.Any())
            {
                return; //Db has been seeded.
            }

            var calibers = new Caliber[]
            {
                new Caliber{ Name = "223", DecimalSize = .224M, MetricSize = "5.56 X 45" },
                new Caliber{ Name="308", DecimalSize=.308M, MetricSize="7.62 X 51" },
                new Caliber{ Name="9mm Luger", DecimalSize=.355M, MetricSize="9 X 19" }
            };
            foreach (Caliber c in calibers) {
                context.Caliber.Add(c);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location{ Name="Fort Knox" },
                new Location{ Name="Sportsman Steel" }
            };
            foreach(Location l in locations)
            {
                context.Location.Add(l);
            }
            context.SaveChanges();

            var manufacturers = new Manufacturer[]
            {
                new Manufacturer{ Name="Daniel Defence", Website="https://www.danieldefense.com/" },
                new Manufacturer{ Name="Aero Precision", Website="https://aeroprecisionusa.com/" },
                new Manufacturer{ Name="Spikes Tactical", Website="https://www.spikestactical.com/" },
                new Manufacturer{ Name="Self"}
            };
            foreach(Manufacturer m in manufacturers)
            {
                context.Manufacturer.Add(m);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category{ Name="Firearm" }
            };
            foreach(Category c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var subCategories = new SubCategory[]
            {
                new SubCategory{ Name="Rifle" , CategoryId=1 },
                new SubCategory{ Name="Pistol", CategoryId=1 }
            };
            foreach(SubCategory sc in subCategories)
            {
                context.SubCategory.Add(sc);
            }
            context.SaveChanges();

            var actions = new FiringAction[]
            {
                new FiringAction{ Name="Semi-Automatic" },
                new FiringAction{ Name="Bolt" },
                new FiringAction{ Name="Single Action" },
                new FiringAction{ Name="Double Action" }
            };
            foreach(FiringAction f in actions)
            {
                context.FiringAction.Add(f);
            }
            context.SaveChanges();

            var platforms = new Platform[]
            {
                new Platform{ Name="AR-10" },
                new Platform{ Name="AR-15"}
            };
            foreach(Platform p in platforms)
            {
                context.Platform.Add(p);
            }
            context.SaveChanges();

            var retailers = new Retailer[]
            {
                new Retailer{ Name="Merchant Firearms", Website="https://merchantfirearms.com/" },
                new Retailer{ Name="Caswell's", Website="https://caswells.com/"}
            };
            foreach(Retailer r in retailers)
            {
                context.Retailer.Add(r);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item{ Name="Daniel Defence M4", ManufacturerId=1, Model="DDM4V11", CaliberId=1, CategoryId=1, ActionId=1, PlatformId=2, Color="Ghost Grey", LocationId=1, PurchaseDate=new DateTime(2016, 4, 13), RetailerId=1 },
                new Item{ Name="Aero Precision Build", ManufacturerId=4, Model="Self Build", CaliberId=2, CategoryId=1, ActionId=2, PlatformId=2, Color="Black", LocationId=2, PurchaseDate=new DateTime(2015, 6,11)}
            };
            foreach(Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();

	        var parts = new Part[]
	        {
		        new Part{ Name="Barrel", ManufacturerId=2, Cost=189.45M, ItemId = 2 },
		        new Part{ Name="Lower", ManufacturerId=3, Cost=115, ItemId = 2}
	        };
	        foreach (Part p in parts)
	        {
		        context.Parts.Add(p);
	        }
	        context.SaveChanges();

		}
    }
}
