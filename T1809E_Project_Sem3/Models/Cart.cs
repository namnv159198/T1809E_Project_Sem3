using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class Cart
    {
        public Dictionary<int, Cart> Items { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }


        public Cart(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            TotalPrice = product.Price * quantity;
        }

        private Cart()
        {
            Items = new Dictionary<int, Cart>();
        }

        public void Add(Product product, int quantity, bool isUpdate)
        {
            var cart = new Cart()
            {
                Product = product,
                Quantity = quantity,

            };
            // kiểm tra tồn tại Product có trong giỏ hàng theo id chưa
            var existKey = Items.ContainsKey(product.Id);
            if (!isUpdate && existKey)
            {
                var existingItem = Items[product.Id];
                cart.Quantity += existingItem.Quantity;
            }

            if (existKey)
            {
                Items[product.Id] = cart;
            }
            else
            {
                Items.Add(product.Id, cart);
            }
        }
        public void Add(Product product)
        {
            Add(product, 1, false);
        }

        public void Update(Product product, int quantity)
        {
            Add(product, quantity, true);
        }

        public void Remove(int productId)
        {
            if (Items.ContainsKey(productId))
            {
                Items.Remove(productId);
            }
        }

    }
}