using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class Connection
    {
        public string str { get; set; }

        public Connection()
        {
            str = @"Server=DESKTOP-7I2D4KB\SQLEXPRESS;Database=TEST;Trusted_Connection=True;";
        }

    }
}
