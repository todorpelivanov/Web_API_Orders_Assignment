using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkPlus_Orders_Assignment.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string OrderName { get; set; } = string.Empty;
        public int OrderPrice { get; set; } = 0;
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
