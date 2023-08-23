using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Dao;

namespace ElgrosWeb.Server.Data.Db
{
    public static class DbInitializer
    {
        public static void Initialize(ElgrosContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.Order.Any())
            {
                return;
            }

            var subCategorys = new List<SubCategoryDao>()
            {
                new SubCategoryDao()
                {
                    Name = "Toilet",
                    Description = "Sinds",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Vandhane",
                    Description = "Sinds",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Afløbsrør",
                    Description = "Sinds",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Vaskemaskine",
                    Description = "Sinds",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Blandingsbatteri",
                    Description = "Sinds",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Eltavle",
                    Description = "Sinds",
                    Category = Category.Electrical
                },
                new SubCategoryDao()
                {
                    Name = "Stikdåse",
                    Description = "Sinds",
                    Category = Category.Electrical
                },
                new SubCategoryDao()
                {
                    Name = "Køleskab",
                    Description = "Sinds",
                    Category = Category.Electrical
                },
            };
            ctx.SubCategory.AddRange(subCategorys);
            ctx.SaveChanges();

            var orders = new List<OrderDao>()
            {
                new OrderDao()
                {
                    User = new UserDao()
                    {
                        FirstName = "Lars",
                        LastName = "Larsen",
                        Address = "Larsensvej 10",
                        City = "Slagelse",
                        PostalCode = "4200",
                        Email = "larsenlars@hotmail.com",
                        PhoneNumber = "+4525994723",
                        CreatedAt = DateTime.Now.AddDays(-2),
                        ModifiedAt = DateTime.Now,
                    },
                    HasAcceptedPolicies = false,
                    HomeDelivery = false,
                    Products = new List<ProductDao>()
                    {
                        new ProductDao()
                        {
                            Name = "Sølvgrå Vandhane",
                            Description = "Giga god til at sprøjte vand",
                            Brand = "Siemens",
                            Category = Category.VVS,
                            Price = 1234,
                            CreatedAt = DateTime.Now.AddDays(-2),
                            ModifiedAt = DateTime.Now,
                            Quantity = 4,
                            Image = "https://mediacache3.damixa.dk/v-638101502367755183/be/cf/eb83-6e6d-4173-b2af-b0320d33a141/67821.png",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Vandhane").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Sort Alluminiums Toilet",
                            Description = "Giga god til at sprøjte vand, med RGB",
                            Brand = "Razer",
                            Category = Category.VVS,
                            Price = 3245,
                            CreatedAt = DateTime.Now.AddDays(-5),
                            ModifiedAt = DateTime.Now,
                            Quantity = 7,
                            Image = "https://w7.pngwing.com/pngs/557/668/png-transparent-squat-toilet-plumbing-fixtures-flush-toilet-stainless-steel-tolet-angle-toilet-steel.png",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Toilet").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Bronze afløbsrør",
                            Description = "Mega flot, god til at dirigere vand",
                            Brand = "Asus",
                            Category = Category.VVS,
                            Price = 432,
                            CreatedAt = DateTime.Now.AddDays(-20),
                            ModifiedAt = DateTime.Now,
                            Quantity = 2,
                            Image = "https://w7.pngwing.com/pngs/251/403/png-transparent-copper-pipe-bronze-welding-others-material-metal-industry.png",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Afløbsrør").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Guld belagt Vaskemaskine",
                            Description = "Utrolig flot, understøtter WIFI",
                            Brand = "Egekilde",
                            Category = Category.VVS,
                            Price = 52000,
                            CreatedAt = DateTime.Now.AddDays(-14),
                            ModifiedAt = DateTime.Now,
                            Quantity = 14,
                            Image = "https://w7.pngwing.com/pngs/640/655/png-transparent-golden-retriever-washing-machine-tap-golden-drum-washing-machine-household-golden-frame-bathroom-thumbnail.png",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Vaskemaskine").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Sølv blandingsbatteri",
                            Description = "Den er meget god til at blande vandet godt og grundigt.",
                            Brand = "Haribo",
                            Category = Category.VVS,
                            Price = 720,
                            CreatedAt = DateTime.Now.AddDays(-23),
                            ModifiedAt = DateTime.Now,
                            Quantity = 22,
                            Image = "https://www.svedbergs.dk/globalassets/svedbergsimport/images/575/575450.png",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Blandingsbatteri").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Bidet toilet",
                            Description = "Göt skylder",
                            Brand = "Razer",
                            Category = Category.VVS,
                            Price = 9384,
                            CreatedAt = DateTime.Now.AddDays(-4),
                            ModifiedAt = DateTime.Now,
                            Quantity = 32,
                            Image = "https://thebidetshop.com.au/wp-content/uploads/2022/07/prince-king.png",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Toilet").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "ElTavle",
                            Description = "Stor eltavle",
                            Brand = "El-Manden",
                            Category = Category.Electrical,
                            Price = 21003,
                            CreatedAt = DateTime.Now.AddDays(-41),
                            ModifiedAt = DateTime.Now,
                            Quantity = 1,
                            Image = "https://www.elvandvarmer.dk/wp-content/uploads/2022/09/Eltavle-1-scaled.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Eltavle").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Stikdåse",
                            Description = "Stikdåse med 8 stik",
                            Brand = "El-Manden",
                            Category = Category.Electrical,
                            Price = 120,
                            CreatedAt = DateTime.Now.AddDays(-19),
                            ModifiedAt = DateTime.Now,
                            Quantity = 51,
                            Image = "https://medieserver.jemogfix.dk/fotoweb/dk/varer/700/7110%209000093.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Stikdåse").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Køleskab med touch display",
                            Description = "Køleskab med touch display og isterning maskine",
                            Brand = "El-Manden",
                            Category = Category.Electrical,
                            Price = 14500,
                            CreatedAt = DateTime.Now.AddDays(-14),
                            ModifiedAt = DateTime.Now,
                            Quantity = 3,
                            Image = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6196/6196192_sd.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Køleskab").ToList()
                        },
                    },
                    TotalAmount = 102638,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    PaymentDetails = new PaymentDao()
                    {
                        Provider = "Paypal",
                        Status = PaymentStatus.Success,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    }
                }
            };
            ctx.Order.AddRange(orders);
            ctx.SaveChanges();
        }
    }
}
