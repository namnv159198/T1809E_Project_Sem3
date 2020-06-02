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

                  new Product() { Id = 0, Name = "WATCHES ROSE GOLD", Status = Product.ProductStatus.Active, Description = "he woman watches comes with nice gift box and it can be as perfect gift for your mom, girlfriend, little girl, wife, your friend, your business partner and other women. Also you can wear it in business meeting, parties, shopping and daily life. This watch comes with 180 days warranty. Any product issues we guarantee 100% refund or replacement, providing you a wonderful shopping experience. If you have any question, please contact us without hesitation.", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591086198/Women/Women-Watches-Rose-Gold-Luxury-Ladies-Watch-Ultra-thin-Wrist-W_gksbsx.webp", Price = 47, Discount = 50, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },
                 new Product() { Id = 1, Name = "GIMTO BRAND ROSE GOLD QUARTZ WOMEN WATCHES LUXURY STEEL CLOCK", Status = Product.ProductStatus.Active, Description = "Style: : fashion casual, business simple design", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591086417/Women/GIMTO-Brand-Rose-Gold-Quartz-Women-Watches-Luxury-Steel-Clock-Bracelet-Ladies-Calendar-Wrist-Watches-Female_nu0h7z.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },
                 new Product() { Id = 2, Name = "Hunputa Women Luxury Crystal Women Gold Bracelet Quartz Wristwatch Rhinestone Clock Ladies Dress Gift Watches (White)", Status = Product.ProductStatus.Active, Description = "This is a good gift for your love or friends women watch leather band strap bracelet womens watches clearance sale fossil bulova stuhrling michael kors kate spade clearance sale michael kors Silver Guess under 20 timex g shock eco drive invicta gold on sale rose gold luxury casio citizen digital sports waterproof Watches for Women girl Casual Design bling rhinestone dress watch girl gift 2016 Bracelet Quartz Braided Winding Wrap Wrist Watch fashion party bangle Gold-Tone Pink Bracelet Wa", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591087464/Women/71NTfNWmWiL._AC_SL1008__v9zmhs.jpg", Price = 29, Discount = 0, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591087804/Women/m81298-0002_bveo6f.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 0 },

                  new Product() { Id = 0, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591077390/clock/m326934-0003e6c4_fjapuz.png", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 1, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077390/clock/m326135-0008e6c4_rlpqm2.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 2, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279381rbr-0013e6c4_qaztdh.png", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279173-0011e6c4_yqq5os.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 0 },

                 new Product() { Id = 0, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591077390/clock/m326934-0003e6c4_fjapuz.png", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 1, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077390/clock/m326135-0008e6c4_rlpqm2.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 2, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279381rbr-0013e6c4_qaztdh.png", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279173-0011e6c4_yqq5os.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 0 },

                 new Product() { Id = 0, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591077390/clock/m326934-0003e6c4_fjapuz.png", Price = 1200, Discount = 1, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 1, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077390/clock/m326135-0008e6c4_rlpqm2.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 2, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279381rbr-0013e6c4_qaztdh.png", Price = 1400, Discount = 3, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279173-0011e6c4_yqq5os.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now, CategoryID = 0 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now, CategoryID = 0 },



                 new Product() { Id = 0, Name = "WATCHES ROSE GOLD", Status = Product.ProductStatus.Active, Description = "he woman watches comes with nice gift box and it can be as perfect gift for your mom, girlfriend, little girl, wife, your friend, your business partner and other women. Also you can wear it in business meeting, parties, shopping and daily life. This watch comes with 180 days warranty. Any product issues we guarantee 100% refund or replacement, providing you a wonderful shopping experience. If you have any question, please contact us without hesitation.", Thumbnails = "https://res.cloudinary.com/drixqdvy6/image/upload/c_thumb,w_200,g_face/v1591086198/Women/Women-Watches-Rose-Gold-Luxury-Ladies-Watch-Ultra-thin-Wrist-W_gksbsx.webp", Price = 47, Discount = 50, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 1, Name = "GIMTO BRAND ROSE GOLD QUARTZ WOMEN WATCHES LUXURY STEEL CLOCK", Status = Product.ProductStatus.Active, Description = "Style: : fashion casual, business simple design", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591086417/Women/GIMTO-Brand-Rose-Gold-Quartz-Women-Watches-Luxury-Steel-Clock-Bracelet-Ladies-Calendar-Wrist-Watches-Female_nu0h7z.jpg", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 2, Name = "Hunputa Women Luxury Crystal Women Gold Bracelet Quartz Wristwatch Rhinestone Clock Ladies Dress Gift Watches (White)", Status = Product.ProductStatus.Active, Description = "This is a good gift for your love or friends women watch leather band strap bracelet womens watches clearance sale fossil bulova stuhrling michael kors kate spade clearance sale michael kors Silver Guess under 20 timex g shock eco drive invicta gold on sale rose gold luxury casio citizen digital sports waterproof Watches for Women girl Casual Design bling rhinestone dress watch girl gift 2016 Bracelet Quartz Braided Winding Wrap Wrist Watch fashion party bangle Gold-Tone Pink Bracelet Wa", Thumbnails = "https://res.cloudinary.com/drixqdvy6/image/upload/c_thumb,w_200,g_face/v1591087464/Women/71NTfNWmWiL._AC_SL1008__v9zmhs.jpg", Price = 29, Discount = 0, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591087804/Women/m81298-0002_bveo6f.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-7), CategoryID = 1 },

                  new Product() { Id = 0, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591077390/clock/m326934-0003e6c4_fjapuz.png", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 1, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "/image/upload/v1591077390/clock/m326135-0008e6c4_rlpqm2.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 2, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279381rbr-0013e6c4_qaztdh.png", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279173-0011e6c4_yqq5os.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-30), CategoryID = 1 },

                 new Product() { Id = 0, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591077390/clock/m326934-0003e6c4_fjapuz.png", Price = 1200, Discount = 1, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 1, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077390/clock/m326135-0008e6c4_rlpqm2.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 2, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279381rbr-0013e6c4_qaztdh.png", Price = 1400, Discount = 3, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279173-0011e6c4_yqq5os.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now.AddDays(-1), CategoryID = 1 },

                 new Product() { Id = 0, Name = "ĐỒNG HỒ JACQUES LEMANS JL-40-1D", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/c_thumb,w_200,g_face/v1591077390/clock/m326934-0003e6c4_fjapuz.png", Price = 1200, Discount = 1, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 1, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077390/clock/m326135-0008e6c4_rlpqm2.png", Price = 1300, Discount = 2, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 2, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZH", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279381rbr-0013e6c4_qaztdh.png", Price = 1400, Discount = 3, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 3, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654.2ZG", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m279173-0011e6c4_yqq5os.png", Price = 1500, Discount = 4, CreateAt = DateTime.Now, CategoryID = 1 },
                 new Product() { Id = 4, Name = "ĐỒNG HỒ JACQUES LEMANS JL-1-1654ZD", Status = Product.ProductStatus.Active, Description = "Đồng hồ cơ", Thumbnails = "image/upload/v1591077389/clock/m278288rbr-0004e6c4_gphf9e.png", Price = 1600, Discount = 5, CreateAt = DateTime.Now, CategoryID = 1 }


            );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
