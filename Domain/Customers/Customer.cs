using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTemplate.Domain.Customers
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string CustomerName { get; set; }
    }
}