using Dapper;


namespace WebApiTemplate.Domain.Customers
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }

        [Column("Name")]
        public string CustomerName { get; set; }
    }
}