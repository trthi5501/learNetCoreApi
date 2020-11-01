using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Interface
{
    public interface IStudentInterface
    {
        string Authenticate(string sid);
        List<Student> GetAll();
        List<Student> GetSID(string ID);
    }
}
