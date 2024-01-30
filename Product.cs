using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository_Generic_Repository_Project;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace IRepository_Generic_Repository_Project
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; } 
    }

}
