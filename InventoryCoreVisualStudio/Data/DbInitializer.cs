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
                new Caliber{ Id=1, Name = "223", DecimalSize = .224M, MetricSize = "5.56 X 45" },
                new Caliber{Id=2, Name="308", DecimalSize=.308M, MetricSize="7.62 X 51" },
                new Caliber{Id=3, Name="9mm Luger", DecimalSize=.355M, MetricSize="9 X 19" }
            };
            foreach (Caliber c in calibers) {
                context.Caliber.Add(c);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location{ Id=1, Name="Fort Knox" },
                new Location{Id=2, Name="Sportsman Steel" }
            };
            foreach(Location l in locations)
            {
                context.Location.Add(l);
            }
            context.SaveChanges();

            var manufacturers = new Manufacturer[]
            {
                new Manufacturer{ Id=1, Name="Daniel Defence", Website="https://www.danieldefense.com/" },
                new Manufacturer{ Id=2, Name="Aero Precision", Website="https://aeroprecisionusa.com/" },
                new Manufacturer{ Id=3, Name="Spikes Tactical", Website="https://www.spikestactical.com/" },
                new Manufacturer{ Id=4, Name="Self"}
            };
            foreach(Manufacturer m in manufacturers)
            {
                context.Manufacturer.Add(m);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category{ Id=1, Name="Firearm" }
            };
            foreach(Category c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var subCategories = new SubCategory[]
            {
                new SubCategory{ Id=1, Name="Rifle" , CategoryId=1 },
                new SubCategory{ Id=2, Name="Pistol", CategoryId=1 }
            };
            foreach(SubCategory sc in subCategories)
            {
                context.SubCategory.Add(sc);
            }
            context.SaveChanges();

            var actions = new FiringAction[]
            {
                new FiringAction{ Id=1, Name="Semi-Automatic" },
                new FiringAction{ Id=2, Name="Bolt" },
                new FiringAction{ Id=3, Name="Single Action" },
                new FiringAction{ Id=4, Name="Double Action" }
            };
            foreach(FiringAction f in actions)
            {
                context.FiringAction.Add(f);
            }
            context.SaveChanges();

            var platforms = new Platform[]
            {
                new Platform{ Id=1, Name="AR-10" },
                new Platform{ Id=2, Name="AR-15"}
            };
            foreach(Platform p in platforms)
            {
                context.Platform.Add(p);
            }
            context.SaveChanges();

            var retailers = new Retailer[]
            {
                new Retailer{ Id=1, Name="Merchant Firearms", Website="https://merchantfirearms.com/" },
                new Retailer{ Id=2, Name="Caswell's", Website="https://caswells.com/"}
            };
            foreach(Retailer r in retailers)
            {
                context.Retailer.Add(r);
            }
            context.SaveChanges();

            var parts = new Part[]
            {
                new Part{ Id=1, Name="Barrel", ManufacturerId=2, Cost=189.45M },
                new Part{ Id=2, Name="Lower", ManufacturerId=3, Cost=115 }
            };
            foreach(Part p in parts)
            {
                context.Parts.Add(p);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item{ Id=1, Name="Daniel Defence M4", ManufacturerId=1, Model="DDM4V11", CaliberId=1, CategoryId=1, ActionId=1, PlatformId=2, Color="Ghost Grey", LocationId=1, PurchaseDate=new DateTime(2016, 4, 13), RetailerId=1 },
                new Item{ Id=2, Name="Aero Precision Build", ManufacturerId=4, Model="Self Build", CaliberId=2, CategoryId=1, ActionId=2, Color="Black", LocationId=2, PurchaseDate=new DateTime(2015, 6,11)}
            };
            foreach(Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();

        }
    }
}
