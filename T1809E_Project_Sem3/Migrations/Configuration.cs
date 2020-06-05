﻿namespace T1809E_Project_Sem3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using T1809E_Project_Sem3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<T1809E_Project_Sem3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(T1809E_Project_Sem3.Models.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.
            context.Categories.AddOrUpdate(x => x.Id,
                new Category() { Id = 0, Name = "Men", Status = Category.StatusEnum.Active },
                new Category() { Id = 1, Name = "Women", Status = Category.StatusEnum.Active }
            );
            var adminId = "Admin";
            var adminRoleId = "Admin";
            if (!context.Roles.Any(r => r.Id == adminRoleId))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = new IdentityRole { Id = adminRoleId, Name = "Admin" };
                roleManager.Create(role);
            }
            var adminId2 = "Employee";
            var adminRoleId2 = "Employee";
            if (!context.Roles.Any(r => r.Id == adminRoleId2))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = new IdentityRole { Id = adminRoleId2, Name = "Employee" };
                roleManager.Create(role);
            }

            // Dong ho nam
            //product1
            var product1 = new Product()
            {
                Id = 1,
                Name = "SKY-DWELLER",
                Status = Product.ProductStatus.Active,
                Description = "Style: : fashion casual, business simple design",
                Thumbnails = "image/upload/v1591077386/clock/m126301-0009e6c4_ck1er7.png",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product1);

            //product2
            var product2 = new Product()
            {
                Id = 2,
                Name = "DATEJUST 41",
                Status = Product.ProductStatus.Active,
                Description = "This is a good gift for your love or friends women watch leather band strap bracelet womens watches clearance sale fossil bulova stuhrling michael kors kate spade clearance sale michael kors Silver Guess under 20 timex g shock eco drive invicta gold on sale rose gold luxury casio citizen digital sports waterproof Watches for Women girl Casual Design bling rhinestone dress watch girl gift 2016 Bracelet Quartz Braided Winding Wrap Wrist Watch fashion party bangle Gold-Tone Pink Bracelet Wa",
                Thumbnails = "image/upload/v1591077388/clock/m128238-0069e6c4_mr2ret.png",
                Price = 29,
                Discount = 0,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product2);
            var product3 = new Product()
            {
                Id = 3,
                Name = "OYSTER PERPETUAL 39",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077387/clock/m126719blro-0002e6c4_dqghum.png",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product3);
            var product4 = new Product()
            {
                Id = 4,
                Name = "AIR-KING",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product4);
            var product5 = new Product()
            {
                Id = 5,
                Name = "COSMOGRAPH DAYTONA",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-yacht-master_m116680_0002_1809jva_001_portrait32c7_xuztge.jpg",
                Price = 1200,
                Discount = 1,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product5);
            var product6 = new Product()
            {
                Id = 6,
                Name = "SUBMARINER DATE",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-cosmograph-daytona_m116518ln_0040_1706jva_001_r_portrait32c7_iq7run.jpg",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product6);
            var product7 = new Product()
            {
                Id = 7,
                Name = "SEA-DWELLER",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-submariner_m116613lb-0005_1807jva_001_portrait32c7_ijs2op.jpg",
                Price = 1400,
                Discount = 3,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product7);
            var product8 = new Product()
            {
                Id = 8,
                Name = "GMT-MASTER II",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-skydweller_m326934_0003_1711jva_001_r_portrait32c7_sxlvxa.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product8);
            var product9 = new Product()
            {
                Id = 9,
                Name = "YACHT-MASTER 42",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-sea-dweller_m126600-0001_1710jva_001_portrait32c7_ad3qsz.jpg",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product9);
            var product10 = new Product()
            {
                Id = 10,
                Name = "EXPLORER II",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-pearlmaster_m86285-0001_1612jva_001_r_portrait32c7_wba00x.jpg",
                Price = 1200,
                Discount = 1,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product10);
            var product11 = new Product()
            {
                Id = 11,
                Name = "MILGAUSS",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-oyster-perpetual_m114300_0004_1809jva_001_portrait32c7_jxzjsd.jpg",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product11);
            var product12 = new Product()
            {
                Id = 12,
                Name = "CELLINI MOONPHASE",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-milgauss_m116400gv-0002_1809jva_001_portrait32c7_guveo8.jpg",
                Price = 1400,
                Discount = 3,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product12);
            var product13 = new Product()
            {
                Id = 13,
                Name = "DAY-DATE 36",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-explorer-ii_m216570_0001_1809jva_002_portrait32c7_b4ctli.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product13);
            var product14 = new Product()
            {
                Id = 14,
                Name = "DAY-DATE 40",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-lady-datejust_m279381rbr-0013_1610jva_001_r_portrait32c7_l5pamr.jpg",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product14);
            var product15 = new Product()
            {
                Id = 15,
                Name = "OYSTER PERPETUAL 36",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-datejust_m126333-0010_1802jva_001_r_portrait32c7_k2zngs.jpg",
                Price = 1200,
                Discount = 1,
                CreateAt = DateTime.Now,
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product15);
            var product16 = new Product()
            {
                Id = 16,
                Name = "DATEJUST 36",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-day-date_m228238_0042_1804jva_001_2_re_portrait32c7_lstqgq.jpg",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now,
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product16);
            var product17 = new Product()
            {
                Id = 17,
                Name = "SUBMARINER",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-gmt-master-ii_m126710blro_0001_1809jva_001_portrait32c7_y2my8r.jpg",
                Price = 1400,
                Discount = 3,
                CreateAt = DateTime.Now,
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product17);
            var product18 = new Product()
            {
                Id = 18,
                Name = "ROLEX DEEPSEA",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-cellini_m50535-0002_1712jva_001_r_portrait32c7_qo5ipr.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now,
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product18);
            var product19 = new Product()
            {
                Id = 19,
                Name = "YACHT-MASTER II",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-air-king_m116900-0001_1809jva_001_portrait32c7_xkmnbg.jpg",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now,
                CategoryID = 0
            };
            context.Products.AddOrUpdate(product19);


            // dong ho nu
            var product20 = new Product()
            {
                Id = 20,
                Name = "LADY-DATEJUST",
                Status = Product.ProductStatus.Active,
                Description = "he woman watches comes with nice gift box and it can be as perfect gift for your mom, girlfriend, little girl, wife, your friend, your business partner and other women. Also you can wear it in business meeting, parties, shopping and daily life. This watch comes with 180 days warranty. Any product issues we guarantee 100% refund or replacement, providing you a wonderful shopping experience. If you have any question, please contact us without hesitation.",
                Thumbnails = "image/upload/v1591106637/Women/14_u2cous.jpg",
                Price = 47,
                Discount = 50,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product20);
            var product21 = new Product()
            {
                Id = 21,
                Name = "PEARLMASTER 39",
                Status = Product.ProductStatus.Active,
                Description = "Style: : fashion casual, business simple design",
                Thumbnails = "image/upload/v1591106637/Women/16_zqyoeq.jpg",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product21);
            var product22 = new Product()
            {
                Id = 22,
                Name = "DATEJUST 31",
                Status = Product.ProductStatus.Active,
                Description = "This is a good gift for your love or friends women watch leather band strap bracelet womens watches clearance sale fossil bulova stuhrling michael kors kate spade clearance sale michael kors Silver Guess under 20 timex g shock eco drive invicta gold on sale rose gold luxury casio citizen digital sports waterproof Watches for Women girl Casual Design bling rhinestone dress watch girl gift 2016 Bracelet Quartz Braided Winding Wrap Wrist Watch fashion party bangle Gold-Tone Pink Bracelet Wa",
                Thumbnails = "image/upload/v1591106637/Women/15_uubcvr.jpg",
                Price = 29,
                Discount = 0,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product22);
            var product23 = new Product()
            {
                Id = 23,
                Name = "DATEJUST 36",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106636/Women/13_laicnp.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product23);
            var product24 = new Product()
            {
                Id = 24,
                Name = "DAY-DATE 36",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106636/Women/11_wok9nc.jpg",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now.AddDays(-7),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product24);
            var product25 = new Product()
            {
                Id = 25,
                Name = "LADY-DATEJUST 12",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106636/Women/10_gebyse.jpg",
                Price = 1200,
                Discount = 1,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product25);
            var product26 = new Product()
            {
                Id = 26,
                Name = "DATEJUST 32",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106636/Women/12_hmud5w.jpg",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product26);
            var product27 = new Product()
            {
                Id = 27,
                Name = "DATEJUST 33",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106636/Women/3_igogb6.jpg",
                Price = 1400,
                Discount = 3,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product27);
            // product 28
            var product28 = new Product()
            {
                Id = 28,
                Name = "DATEJUST 35",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106636/Women/9_b8ro3q.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product28);
            var product29 = new Product()
            {
                Id = 29,
                Name = "LADY-DATEJUST 22",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/7_hsox7p.jpg",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now.AddDays(-30),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product29);
            var product30 = new Product()
            {
                Id = 30,
                Name = "PEARLMASTER 35",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/6_hqyuby.jpg",
                Price = 1200,
                Discount = 1,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product30);
            var product31 = new Product()
            {
                Id = 31,
                Name = "PEARLMASTER 25",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/4_n5c9mf.jpg",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product31);
            var product32 = new Product()
            {
                Id = 32,
                Name = "PEARLMASTER 30",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/2_tw3qhh.jpg",
                Price = 1400,
                Discount = 3,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product32);
            var product33 = new Product()
            {
                Id = 33,
                Name = "PEARLMASTER 33",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/5_y2l7tb.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product33);
            var product34 = new Product()
            {
                Id = 34,
                Name = "LADY-DATEJUST 35",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/1_poazj2.jpg",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now.AddDays(-1),
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product34);
            var product35 = new Product()
            {
                Id = 35,
                Name = "DAY-DATE 33",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591106635/Women/8_wwds6l.jpg",
                Price = 1200,
                Discount = 1,
                CreateAt = DateTime.Now,
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product35);
            var product36 = new Product()
            {
                Id = 36,
                Name = "DATEJUST 22",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591087804/Women/m81298-0002_bveo6f.png",
                Price = 1300,
                Discount = 2,
                CreateAt = DateTime.Now,
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product36);
            var product37 = new Product()
            {
                Id = 37,
                Name = "DAY-DATE 30",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591087464/Women/71NTfNWmWiL._AC_SL1008__v9zmhs.jpg",
                Price = 1400,
                Discount = 3,
                CreateAt = DateTime.Now,
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product37);
            var product38 = new Product()
            {
                Id = 38,
                Name = "JACQUES LEMANS",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591086417/Women/GIMTO-Brand-Rose-Gold-Quartz-Women-Watches-Luxury-Steel-Clock-Bracelet-Ladies-Calendar-Wrist-Watches-Female_nu0h7z.jpg",
                Price = 1500,
                Discount = 4,
                CreateAt = DateTime.Now,
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product38);
            var product39 = new Product()
            {
                Id = 39,
                Name = "DAY-DATE 25",
                Status = Product.ProductStatus.Active,
                Description = "Đồng hồ cơ",
                Thumbnails = "image/upload/v1591086198/Women/Women-Watches-Rose-Gold-Luxury-Ladies-Watch-Ultra-thin-Wrist-W_gksbsx.webp",
                Price = 1600,
                Discount = 5,
                CreateAt = DateTime.Now,
                CategoryID = 1
            };
            context.Products.AddOrUpdate(product39);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
