using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Filteration_Task.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public String Name {  get; set; }
        
        [Required(ErrorMessage = "Description is required.")]
        public String Description {  get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]

        public Decimal Price {  get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]

        public int  Stock { get; set; }


        //Foreign Keys

        [ForeignKey("Order")]
        public int? OrderId {  get; set; }
        [JsonIgnore]

        public virtual Order? order { get; set; }



    }
}
