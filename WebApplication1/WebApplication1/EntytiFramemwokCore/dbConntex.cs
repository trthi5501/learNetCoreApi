using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class dbConntex
    {
        public string str { get; set; }

        public dbConntex()
        {
            str = @"Server=DESKTOP-7I2D4KB\SQLEXPRESS;Database=TEST;Trusted_Connection=True;";
        }

    }
}
