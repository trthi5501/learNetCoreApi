using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Helpers;
using WebApplication1.Model;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;
using WebApplication1.Interface;

namespace WebApplication1.Services
{
    public class StudentService: IStudentInterface
    {
        private List<Student> students = new List<Student>();
        private StudentModel model = new StudentModel();
        
        private readonly AppSettings _appSettings;

        public StudentService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Student Authenticate(string sid, string password)
        {
            students = model.GetStudent();

            var student = students.FirstOrDefault(x => x.SID == sid);

            // return null if user not found
            if (student == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, student.SID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            student.Token = tokenHandler.WriteToken(token);

           

            return student;
        }

        public List<Student> GetAll()
        {
            students = model.GetStudent();
            return students;
        }
        public List<Student> GetSID(string sid)
        {
            students = model.GetIdStudent(sid);
            return students;
        }
    }
}

