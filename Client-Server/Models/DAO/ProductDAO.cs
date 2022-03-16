using Client_Server.Models.DTO;
using Client_Server.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client_Server.Models.DAO
{
    public class ProductDAO
    {
        Shop_Model db;
        public ProductDAO()
        {
            db = new Shop_Model();
        }
        public IEnumerable<ProductDTO> list()
        {
            var lst = db.Database.SqlQuery<ProductDTO>("Select  " +
                            " idProduct," +
                            " p.NameProduct," +
                            " p.Price," +
                            " p.img," +
                            " p.descriptions," +
                            " p.idCate," +
                            " p.idBrand," +
                            " p.status," +
                            " b.NameBrand," +
                            " c.NameCate " +
                            " from product p join category c on p.idCate = c.idCategory join brand b on p.idBrand = b.id");
            return lst;
        }
        public IEnumerable<ProductDTO> searchByName(string keyword)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("Select " +
                            " idProduct," +
                            " p.NameProduct," +
                            " p.Price," +
                            " p.img," +
                            " p.descriptions," +
                            " p.idCate," +
                            " p.idBrand," +
                            " p.status," +
                            " b.NameBrand," +
                            " c.NameCate " +
                            " from product p join category c on p.idCate = c.idCategory join brand b on p.idBrand = b.id" +
                            " Where p.NameProduct LIKE'%" + keyword +"%'"
                            );
            return lst;
        }

        public ProductDTO FindMyID(int? id)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("Select " +
                            " idProduct," +
                            " p.NameProduct," +
                            " p.Price," +
                            " p.img," +
                            " p.descriptions," +
                            " p.idCate," +
                            " p.idBrand," +
                            " p.status," +
                            " b.NameBrand," +
                            " c.NameCate " +
                            " from product p join category c on p.idCate = c.idCategory join brand b on p.idBrand = b.id" +
                            " Where p.idProduct ==" +id
                            ).SingleOrDefault();
            return lst;
        }
    }
}