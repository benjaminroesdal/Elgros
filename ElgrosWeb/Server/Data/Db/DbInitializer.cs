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
                    Description = "Toiletter",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Vandhane",
                    Description = "Vandhaner",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Afløbsrør",
                    Description = "Afløbsrør",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Vaskemaskine",
                    Description = "Vaskemaskiner",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Blandingsbatteri",
                    Description = "Blandingsbatterier",
                    Category = Category.VVS
                },
                new SubCategoryDao()
                {
                    Name = "Eltavle",
                    Description = "Eltavler",
                    Category = Category.Electrical
                },
                new SubCategoryDao()
                {
                    Name = "Stikdåse",
                    Description = "Stikdåser",
                    Category = Category.Electrical
                },
                new SubCategoryDao()
                {
                    Name = "Køleskab",
                    Description = "Køleskabe",
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
                            Name = "Hansgrohe Logis 100 vandhane, krom",
                            Description = "armaturet er forsynet med EcoSmart bruseteknologi, der gør armaturet vandbesparende, så det forbruger op til 60% mindre vand end traditionelle armaturer. Det ergonomiske greb er lækkert at betjene og ComfortZonen på 100 mm åbner op for langt mere bevægelsesfrihed mellem tud og vask. Armaturets normalstråle er med AirPower, der tilsætter luft til vandet, så vandstrålen bliver fyldigere, blødere og lettere at vaske hænder i.",
                            Brand = "Hansgrohe Logis",
                            Category = Category.VVS,
                            Price = 849,
                            CreatedAt = DateTime.Now.AddDays(-2),
                            ModifiedAt = DateTime.Now,
                            Quantity = 4,
                            Image = "https://res.cloudinary.com/evoleska/images/e_trim:0:white/q_auto,c_lpad,ar_1,f_auto,b_white/w_600/v1496499697/product/1065118/hansgrohe-logis-100-vandhane.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Vandhane").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Duravit Me",
                            Description = "Toilettets design er rimless, hvilket betyder, at der ikke er en indvendig skyllekant, hvor bakterier og smuds kan samle sig. Du får derfor et langt mere hygiejnisk og rengøringsvenligt toilet.\r\n\r\nDet væghængte toilet er belagt med en stærk og antibakteriel glasering, WonderGliss, på alle de flader, som er i berøring med vand. Glaseringen giver nemmere rengøring, da den hårde og jævne overflade på porcelænet, gør det sværere for snavs og kalk at sætte sig fast. ",
                            Brand = "Starck ",
                            Category = Category.VVS,
                            Price = 2199,
                            CreatedAt = DateTime.Now.AddDays(-5),
                            ModifiedAt = DateTime.Now,
                            Quantity = 7,
                            Image = "https://res.cloudinary.com/evoleska/images/e_trim:0:white/q_auto,c_lpad,ar_1,f_auto,b_white/w_600/v1524372861/product/1595098/duravit-me-by-starck-vghngt.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Toilet").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Wafix 50 mm grå afløbsrør",
                            Description = "Wavin Wafix afløbsrør anvendes til sikker bortledelse af spildevand fra afløbsinstallationer i bygninger over jord. Wafix-systemet er fremstillet af genanvendeligt PP-plast. Afløbsrørene er med Fix-lock tætningsringe, der tætner på tre punkter og garanterer 100% tætte samlinger. ",
                            Brand = "Wafix",
                            Category = Category.VVS,
                            Price = 119,
                            CreatedAt = DateTime.Now.AddDays(-20),
                            ModifiedAt = DateTime.Now,
                            Quantity = 2,
                            Image = "https://res.cloudinary.com/evoleska/images/e_trim:0:white/q_auto,c_lpad,ar_1,f_auto,b_white/w_600/v1524325633/product/1571748/wafix-50-mm-gra-aflbsrr-20.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Afløbsrør").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Samsung vaskemaskine WW11BGA047AEEE",
                            Description = "Udnyt muligheden for hurtig og grundig tøjvask med Samsung WW5000T vaskemaskinen WW85TA047AE, der tilbyder 8 kg kapacitet, 1.400 omdrejninger/minut, EcoBubble teknologi og adskillige praktiske programmer.",
                            Brand = "Samsung ",
                            Category = Category.VVS,
                            Price = 2499,
                            CreatedAt = DateTime.Now.AddDays(-14),
                            ModifiedAt = DateTime.Now,
                            Quantity = 14,
                            Image = "https://www.elgiganten.dk/image/dv_web_D180001002510772/185552/samsung-ww5000t-vaskemaskine-ww85ta047ae--pdp_zoom-3000--pdp_main-960.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Vaskemaskine").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Grohe Grohtherm brusearmatur",
                            Description = "Grohtherm termostat batteriet er elegant, stilfuldt og fuldstændig strømlinet. Brusebatteriets design gør det muligt for dig at justere vandmængden i den ene side, og temperatur i den anden med Safestop ved 38 grader, som sikrer dig mod skoldning. Armaturet har også Grohes Ecostop, som hjælper med at reducere dit vandforbrug.",
                            Brand = "Grohe",
                            Category = Category.VVS,
                            Price = 849,
                            CreatedAt = DateTime.Now.AddDays(-23),
                            ModifiedAt = DateTime.Now,
                            Quantity = 22,
                            Image = "https://res.cloudinary.com/evoleska/images/e_trim:0:white/q_auto,c_lpad,ar_1,f_auto,b_white/w_600/v1524393694/product/1608253/grohe-grohtherm-brusearmatur.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Blandingsbatteri").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Gustavsberg Nautic 1500 toilet",
                            Description = "Toilettet, der skal gulvmonteres med skruer, er fremstillet i hygiejnisk, holdbart og tætsintret sanitetsporcelæn med rengøringsvenlig overfladebehandling, så skidt og snavs ikke sætter sig fast. Skylleranden er fjernet og vandet skylles derfor helt op til kanten og rengør hele skålen. Det gør din rengøring af skålen lettere.",
                            Brand = "Gustavsberg ",
                            Category = Category.VVS,
                            Price = 2504,
                            CreatedAt = DateTime.Now.AddDays(-4),
                            ModifiedAt = DateTime.Now,
                            Quantity = 32,
                            Image = "https://res.cloudinary.com/evoleska/images/e_trim:0:white/q_auto,c_lpad,ar_1,f_auto,b_white/w_600/v1524328032/product/1573140/gustavsberg-nautic-1500-toilet.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Toilet").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Boligtavle ABB",
                            Description = "2 x RCD 2 x kraft 1 x kombi 8 x lys + transient",
                            Brand = "ABB",
                            Category = Category.Electrical,
                            Price = 4101,
                            CreatedAt = DateTime.Now.AddDays(-41),
                            ModifiedAt = DateTime.Now,
                            Quantity = 1,
                            Image = "https://www.wattoo.dk/media/processed/app_shop_product_primary/58/97/1813c502795c736c02afbda106e0.avif",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Eltavle").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Brennenstuhl 6-vejs stikdåse 1,4 m",
                            Description = "Brennenstuhl 6-vejs stikdåsen 1,4 m kan forbinde 6 elektriske enheder og har en praktisk tænd/sluk-kontakt og børnesikring. Kontakterne er vinklet 45 grader.",
                            Brand = "Brennenstuhl",
                            Category = Category.Electrical,
                            Price = 199,
                            CreatedAt = DateTime.Now.AddDays(-19),
                            ModifiedAt = DateTime.Now,
                            Quantity = 51,
                            Image = "https://www.elgiganten.dk/image/dv_web_D180001002679921/178654/brennenstuhl-6-vejs-stikdase-14-m--pdp_zoom-3000--pdp_main-960.jpg",
                            SubCategoryList = ctx.SubCategory.Where(e => e.Name == "Stikdåse").ToList()
                        },
                        new ProductDao()
                        {
                            Name = "Smeg 50 s style køleskab med fryser",
                            Description = "Få et kølefryseskab af høj kvalitet i den farve, dit hjerte ønsker. Hold din mad og dine drikke friske takket være Smeg køleskabet med fryser FAB28RPB5 i flot 50 s stil. Det er desuden udstyret med en speciel Life Plus-zone, isboks og LED-lys.",
                            Brand = "Smeg ",
                            Category = Category.Electrical,
                            Price = 8445,
                            CreatedAt = DateTime.Now.AddDays(-14),
                            ModifiedAt = DateTime.Now,
                            Quantity = 3,
                            Image = "https://www.elgiganten.dk/image/dv_web_D180001002610977/254321/smeg-50-s-style-koleskab-med-fryser-fab28rpb5--pdp_zoom-3000--pdp_main-960.jpg",
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
