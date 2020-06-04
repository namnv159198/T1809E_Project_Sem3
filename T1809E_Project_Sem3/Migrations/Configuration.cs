namespace T1809E_Project_Sem3.Migrations
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
            context.Products.AddOrUpdate(x => x.Id,

                //đồng hồ nam
                  new Product() { Id = 0, Name = "WATCHES ROSE GOLD", Status = Product.ProductStatus.Active, Description = "he woman watches comes with nice gift box and it can be as perfect gift for your mom, girlfriend, little girl, wife, your friend, your business partner and other women. Also you can wear it in business meeting, parties, shopping and daily life. This watch comes with 180 days warranty. Any product issues we guarantee 100% refund or replacement, providing you a wonderful shopping experience. If you have any question, please contact us without hesitation.", Thumbnails = "image/upload/v1591077387/clock/m126655-0002e6c4_cu3c2s.png", Price = 47, Discount = 50, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },
                 new Product() { Id = 1, Name = "GIMTO BRAND ROSE GOLD QUARTZ WOMEN WATCHES LUXURY STEEL CLOCK", Status = Product.ProductStatus.Active, Description = "Style: : fashion casual, business simple design", Thumbnails = "image/upload/v1591077386/clock/m126301-0009e6c4_ck1er7.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },
                 new Product() { Id = 2, Name = "Hunputa Women Luxury Crystal Women Gold Bracelet Quartz Wristwatch Rhinestone Clock Ladies Dress Gift Watches (White)", Status = Product.ProductStatus.Active, Description = "This is a good gift for your love or friends women watch leather band strap bracelet womens watches clearance sale fossil bulova stuhrling michael kors kate spade clearance sale michael kors Silver Guess under 20 timex g shock eco drive invicta gold on sale rose gold luxury casio citizen digital sports waterproof Watches for Women girl Casual Design bling rhinestone dress watch girl gift 2016 Bracelet Quartz Braided Winding Wrap Wrist Watch fashion party bangle Gold-Tone Pink Bracelet Wa", Thumbnails = "image/upload/v1591077388/clock/m128238-0069e6c4_mr2ret.png", Price = 29, Discount = 0, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077387/clock/m126719blro-0002e6c4_dqghum.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },

                  new Product() { Id = 5, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-yacht-master_m116680_0002_1809jva_001_portrait32c7_xuztge.jpg", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 6, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-cosmograph-daytona_m116518ln_0040_1706jva_001_r_portrait32c7_iq7run.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 7, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-submariner_m116613lb-0005_1807jva_001_portrait32c7_ijs2op.jpg", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 8, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-skydweller_m326934_0003_1711jva_001_r_portrait32c7_sxlvxa.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 9, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077196/clock/navigation-collection-watches-sea-dweller_m126600-0001_1710jva_001_portrait32c7_ad3qsz.jpg", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },

                 new Product() { Id = 10, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-pearlmaster_m86285-0001_1612jva_001_r_portrait32c7_wba00x.jpg", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 11, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-oyster-perpetual_m114300_0004_1809jva_001_portrait32c7_jxzjsd.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 12, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-milgauss_m116400gv-0002_1809jva_001_portrait32c7_guveo8.jpg", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 13, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-explorer-ii_m216570_0001_1809jva_002_portrait32c7_b4ctli.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 14, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-lady-datejust_m279381rbr-0013_1610jva_001_r_portrait32c7_l5pamr.jpg", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },

                 new Product() { Id = 15, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-datejust_m126333-0010_1802jva_001_r_portrait32c7_k2zngs.jpg", Price = 1200, Discount = 1, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 16, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-day-date_m228238_0042_1804jva_001_2_re_portrait32c7_lstqgq.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 17, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-gmt-master-ii_m126710blro_0001_1809jva_001_portrait32c7_y2my8r.jpg", Price = 1400, Discount = 3, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 18, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-cellini_m50535-0002_1712jva_001_r_portrait32c7_qo5ipr.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 19, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077195/clock/navigation-collection-watches-air-king_m116900-0001_1809jva_001_portrait32c7_xkmnbg.jpg", Price = 1600, Discount = 5, CreateAt = DateTime.Now, CategoryID = 0 },


                 //đồng hồ nữ
                 new Product() { Id = 20, Name = "WATCHES ROSE GOLD", Status = Product.ProductStatus.Active, Description = "he woman watches comes with nice gift box and it can be as perfect gift for your mom, girlfriend, little girl, wife, your friend, your business partner and other women. Also you can wear it in business meeting, parties, shopping and daily life. This watch comes with 180 days warranty. Any product issues we guarantee 100% refund or replacement, providing you a wonderful shopping experience. If you have any question, please contact us without hesitation.", Thumbnails = "image/upload/v1591106637/Women/14_u2cous.jpg", Price = 47, Discount = 50, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 21, Name = "GIMTO BRAND ROSE GOLD QUARTZ WOMEN WATCHES LUXURY STEEL CLOCK", Status = Product.ProductStatus.Active, Description = "Style: : fashion casual, business simple design", Thumbnails = "image/upload/v1591106637/Women/16_zqyoeq.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 22, Name = "Hunputa Women Luxury Crystal Women Gold Bracelet Quartz Wristwatch Rhinestone Clock Ladies Dress Gift Watches (White)", Status = Product.ProductStatus.Active, Description = "This is a good gift for your love or friends women watch leather band strap bracelet womens watches clearance sale fossil bulova stuhrling michael kors kate spade clearance sale michael kors Silver Guess under 20 timex g shock eco drive invicta gold on sale rose gold luxury casio citizen digital sports waterproof Watches for Women girl Casual Design bling rhinestone dress watch girl gift 2016 Bracelet Quartz Braided Winding Wrap Wrist Watch fashion party bangle Gold-Tone Pink Bracelet Wa", Thumbnails = "image/upload/v1591106637/Women/15_uubcvr.jpg", Price = 29, Discount = 0, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 23, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106636/Women/13_laicnp.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 24, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106636/Women/11_wok9nc.jpg", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },

                  new Product() { Id = 25, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106636/Women/10_gebyse.jpg", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 26, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106636/Women/12_hmud5w.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 27, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106636/Women/3_igogb6.jpg", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 28, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106636/Women/9_b8ro3q.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 29, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/7_hsox7p.jpg", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },

                 new Product() { Id = 30, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/6_hqyuby.jpg", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 31, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/4_n5c9mf.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id =32, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/2_tw3qhh.jpg", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 33, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/5_y2l7tb.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 34, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/1_poazj2.jpg", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },

                 new Product() { Id = 35, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591106635/Women/8_wwds6l.jpg", Price = 1200, Discount = 1, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 36, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591087804/Women/m81298-0002_bveo6f.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 37, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591087464/Women/71NTfNWmWiL._AC_SL1008__v9zmhs.jpg", Price = 1400, Discount = 3, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 38, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591086417/Women/GIMTO-Brand-Rose-Gold-Quartz-Women-Watches-Luxury-Steel-Clock-Bracelet-Ladies-Calendar-Wrist-Watches-Female_nu0h7z.jpg", Price = 1500, Discount = 4, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 39, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591086198/Women/Women-Watches-Rose-Gold-Luxury-Ladies-Watch-Ultra-thin-Wrist-W_gksbsx.webp", Price = 1600, Discount = 5, CreateAt = DateTime.Now, CategoryID = 1 }


            );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
