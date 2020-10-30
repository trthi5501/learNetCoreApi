using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1.Model
{
    public class Student
    {
        /// <summary>
        /// Student ID
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// Student SName
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// Student Phone
        /// </summary>
        public string SPhone { get; set; }
        /// <summary>
        /// Student Gender
        /// </summary>
        public string SGender { get; set; }
        /// <summary>
        /// Student Address
        /// </summary>
        public string SAddress { get; set; }
        public string Token { get; set; }

        
    }
}
