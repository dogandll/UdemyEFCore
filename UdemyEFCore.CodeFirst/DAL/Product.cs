using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Kdv { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        //Insert ve Update  işlemdi EF Core bu alanı göndermesin
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal PriceKdv { get; set; }
        //Insert işlemlerinde o anki saat ve tarihi atması için Identity ekledik
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; }

        //Navigation Property
        public virtual Category? Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }

    }
}
