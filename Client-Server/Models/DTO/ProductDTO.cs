using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client_Server.Models.DTO
{
    public class ProductDTO
    {
        public int idProduct { get; set; }
        public string NameProduct { get; set; }
        public int? Price { get; set; }
        public string img { get; set; }
        public string descriptions { get; set; }
        public int? idCate { get; set; }
        public int? idBrand { get; set; }
        public bool? status { get; set; }
        public string NameBrand { get; set; }
        public string NameCate { get; set; }

    }
}