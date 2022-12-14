using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Filc.Services.Interfaces;
using Filc.Services.Interfaces.RoleBasedInterfacesForApis.FullAccess;
using Filc.ViewModel;

namespace EFDataAccessLibrary.DataAccess
{
    public class SeedUsers
    {
        public static async Task InitData(IGovernmentAdminServiceFullAccess govService, ISchoolAdminServiceFullAccess schoolAdminService, 
            IStudentServiceFullAccess studentService, ITeacherServiceFullAccess teacherService, IParentServiceFullAccess parentService, 
            IRegistration registration, ISchoolServiceFullAccess schoolService)
        {
            School school1 = new School()
            {
                Address = "Very street 1",
                Name = "Uristen Very School",
                SchoolType = "Awesome school",
                Lessons = new List<Lesson>(),
                Students = new List<Student>(),
                Teachers = new List<Teacher>(),
                SchoolAdmin = new List<SchoolAdmin>(),
                Subjects = new List<Subject>(),
                Classes = new List<SchoolClass>()
            };

            try
            {
                schoolService.AddSchool(school1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding school to db" + e);
            }

            ApplicationUser user1 = new()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };
            
            ApplicationUser user2 = new()
            {
                UserName = "schooladmin@admin.com",
                Email = "schooladmin@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };
            
            ApplicationUser user3 = new()
            {
                UserName = "teacher@admin.com",
                Email = "teacher@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };
            
            ApplicationUser user4 = new()
            {
                UserName = "student@admin.com",
                Email = "student@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };
            
            ApplicationUser user5 = new()
            {
                UserName = "parent@admin.com",
                Email = "parent@admin.com",
                Salt = "$2a$10$6V3o1DUBVVi8WXdg5sEAHO",
                PasswordHash = "$2a$10$6V3o1DUBVVi8WXdg5sEAHODPbi3PDyye58Ww932M7tFeNa9evVYSa"
            };

            GovernmentAdmin admin = new GovernmentAdmin();
            admin.user = user1;
            try
            {
                if (await registration.Register(new RegistrationModel(user1, "Government")) == true)
                {
                    govService.AddGovernmentAdmin(admin);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error registering admin" + e);
            }

            SchoolAdmin schoolAdmin = new SchoolAdmin()
            {
                Address = "Street 1",
                FirstName = "Jolan",
                LastName = "Hegyi"
            };
            
            schoolAdmin.user = user2;
            schoolAdmin.School = school1;

            try
            {
                if (await registration.Register(new RegistrationModel(user2, "SchoolAdmin")) == true)
                {
                    schoolAdminService.AddSchoolAdmin(schoolAdmin);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error registering schoolAdmin" + e);
            }

            Teacher teacher = new Teacher()
            {
                BirthDate = DateTime.Now,
                FirstName = "Teachy",
                LastName = "McTeacherson",
                Address = "Street 1"
            };
            
            teacher.user = user3;
            teacher.School = school1;

            try
            {
                if (await registration.Register(new RegistrationModel(user3, "Teacher")) == true)
                {
                    teacherService.AddTeacher(teacher);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error registering teacher" + e);
            }

            Student student = new Student()
            {
                BirthDate = DateTime.Now,
                FirstName = "Student",
                LastName = "McStudentson",
                Address = "Street 2"
            };

            student.user = user4;
            student.School = school1;

            try
            {
                if (await registration.Register(new RegistrationModel(user4, "Student")) == true)
                {
                    studentService.AddStudent(student);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error registering student" + e);
            }

            Parent parent = new Parent();
            parent.user = user5;
            parent.Children = new List<Student>()
            {
                student
            };
            
            try
            {
                if (await registration.Register(new RegistrationModel(user5, "Parent")) == true)
                {
                    parentService.AddParent(parent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error registering parent" + e);
            }
        }
    }
}
