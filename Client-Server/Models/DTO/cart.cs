using Client_Server.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client_Server.Models.DTO
{
    public class ItemCart
    {
        public product product { get; set; }
        public int soLuong { get; set; }
        public int size { get; set; }

    }
    public class cart
    {
        List<ItemCart> item = new List<ItemCart>();
        public IEnumerable<ItemCart> Item
        {
            get { return item; }
        }
        public void addProduct(product pro, int size, int soluong = 1)
        {
            var p = item.SingleOrDefault(s => s.product.idProduct == pro.idProduct && s.size == size);
            if (p == null)
            {
                item.Add(new ItemCart
                {
                    product = pro,
                    soLuong = soluong,
                    size = size
                });
            }
            else
            {
                p.soLuong += soluong;
            }
        }
        public void update(int id,int sizeold, int size, int soluong)
        {
            
            var sp = item.SingleOrDefault(s => s.product.idProduct.Equals(id) && s.size.Equals(sizeold));
            if (sp != null)
            {
                sp.soLuong = soluong;
                sp.size = size;
            }
        }
        public void remove(int id, int size)
        {
            var sp = item.SingleOrDefault(s => s.product.idProduct == id && s.size == size);
            if (sp != null)
            {
                item.Remove(sp);
            }
        }
        public void clear()
        {
            item.Clear();
        }
        public int Total_amount_inCart()
        {
            return item.Sum(s => s.soLuong);
        }
        public double tota_bill()
        {
            var total = item.Sum(s => s.product.Price * s.soLuong);
            return (double)total;
        }
    }
}