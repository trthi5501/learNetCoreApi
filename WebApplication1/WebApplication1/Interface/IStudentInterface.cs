using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Interface
{
    public interface IStudentInterface
    { 
        Student Authenticate(string username, string password);
        List<Student> GetAll();
        List<Student> GetSID(string ID);
    }
}
