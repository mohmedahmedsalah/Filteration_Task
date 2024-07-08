using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Filteration_Task.Models
{
    public class Order
    {
       public int OrderId {  get; set; }
       //public int  CustomerId {  get; set; }
        public DateTime OrderDate {  get; set; }
        public Decimal TotalAmount { get; set; }

        //Foreign Keys


        public virtual List<Product>? products { get; set; }= new List<Product>();



        [ForeignKey("Customer")]

        public  int? CustomerId { get; set; }
        [JsonIgnore]

        public virtual Customer? Customer { get; set; }

    }
}
