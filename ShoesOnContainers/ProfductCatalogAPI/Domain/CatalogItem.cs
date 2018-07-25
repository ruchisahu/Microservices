using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfductCatalogAPI.Domain
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DecimalPrecision]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }

        public virtual CatalogType CatalogType { get; set; }
        public virtual CatalogBrand CatalogBrand { get; set; }


    }

    internal class DecimalPrecisionAttribute : Attribute
    {
    }
}