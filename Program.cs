using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace OperationsUsingLambda
{
    class Program
    {
        
        public static void print_array<T>(T[] result)
        {
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            
        }
        static void Main(string[] args)
        {
            List<EMP> EMP_List = new List<EMP>();
            List<EMP> EMP_Male_list = new List<EMP>();
            List<EMP> EMP_Female_list = new List<EMP>();
            List<EMP> Min_sal_list = new List<EMP>();
            List<EMP> Max_sal_list = new List<EMP>();
            List<EMP> Sorted_by_salary = new List<EMP>();

           
            List<EMP> New_EMP_List_Female = new List<EMP>();
            List<EMP> New_EMP_List_Male = new List<EMP>();

            List<string> New_EMP_List = new List<string>();


            EMP_List.Add(new EMP { id = 1, firstName = "Sam", lastName = "Vee", dept = Dept.IT, gender = Gender.Male, country = Country.USA, salary = 7000, dob = new DateTime(1998, 7, 22) });
            EMP_List.Add(new EMP { id = 2, firstName = "Ram", lastName = "Kale", dept = Dept.Sales, gender = Gender.Male, country = Country.India, salary = 1700000, dob = new DateTime(1994, 4, 11) });
            EMP_List.Add(new EMP { id = 3, firstName = "Ria", lastName = "Bosco", dept = Dept.Payroll, gender = Gender.Female, country = Country.Japan, salary = 89870000, dob = new DateTime(2002, 5, 6) });
            EMP_List.Add(new EMP { id = 4, firstName = "Sha", lastName = "VaVee", dept = Dept.Admin, gender = Gender.Male, country = Country.Russia, salary = 600, dob = new DateTime(1998, 7, 22) });


            //EMP_List.Add(new EMP(2, "Ram", "Kale", Dept.Sales, Gender.Male, Country.India, 1700000, new DateTime(1994, 4, 11)));
            //EMP_List.Add(new EMP(3, "Riy", "Bosco", Dept.Payroll, Gender.Female, Country.Japan, 89870000, new DateTime(2002, 5, 6)));
            //EMP_List.Add(new EMP(4, "Sha", "VaVee", Dept.Engineering, Gender.Male, Country.Russia, 600, new DateTime(1984, 9, 5)));



            foreach (EMP emp in EMP_List.Where(e => e.gender.ToString() == "Male"))
            {
                EMP_Male_list.Add(emp);
                //Console.WriteLine(EMP_List.Max(e => e.Salary));
            }

            int min_sal = EMP_Male_list.Min(e => e.salary);
            int max_sal = EMP_Male_list.Max(e => e.salary);
            Console.WriteLine(EMP_Male_list.Min(e => e.salary));
            Console.WriteLine(EMP_Male_list.Max(e => e.salary));

            Min_sal_list = EMP_Male_list.Where(s => s.salary == EMP_Male_list.Min(e => e.salary)).ToList();
            string min_details = "";
            string max_details = "";
            foreach (EMP min in Min_sal_list.ToList())
            {
                min_details = ("ID: " + min.id + " " + "FirstName: " + min.firstName + " " + "LastName: " + min.lastName + " " + "DOB: " + min.dob);
            }


            Max_sal_list = EMP_Male_list.Where(s => s.salary == EMP_Male_list.Max(e => e.salary)).ToList();

            var lemesee = EMP_Male_list.Where(s => s.salary == EMP_Male_list.Max(e => e.salary)).ToList().Select(e => e.firstName);

            foreach (EMP max in Max_sal_list.ToList())
            {
                max_details = "ID: " + max.id + " " + "FirstName: " + max.firstName + " " + "LastName: " + max.lastName + " " + "DOB: " + max.dob;
            }


            //New_EMP_List = EMP_List.Where(chunk => chunk.Salary == 23).ToList();

            //New Empolyee List

            // New_EMP_List = EMP_List.Select(g => new EMP { id = g.id, firstName = g.firstName, gender = g.gender }).ToList();

            //New_EMP_List=EMP_List

            foreach(EMP emp in EMP_List)
            {

                New_EMP_List.Add(EMP_List.Select(e=>e.id).ToString());
                New_EMP_List.Add(EMP_List.Select(e=>e.fullName=e.firstName+e.lastName).ToString());
                New_EMP_List.Add(EMP_List.Select(e=>e.gender).ToString());
                //New_EMP_List.Add(EMP_List.Select(e=>e.id).ToString());

               
                New_EMP_List.Add($"{emp.gender}");
            }

            //New_EMP_List.Add(new EMP { id = 1, fullName = "Nayan Kale", gender = Gender.Male });


            //New_EMP_List.Add(new EMP { id = 2, fullName = "Nora Selvia", gender = Gender.Male });
            //New_EMP_List.Add(new EMP { id = 3, fullName = "Sheetal Kale", gender = Gender.Female });
            //New_EMP_List.Add(new EMP { id = 4, fullName = "Reena Gandhi", gender = Gender.Female });


            //New_EMP_List.Add(new EMP(2, "Nora Selvia", Gender.Female));
            //        New_EMP_List.Add(new EMP(3, "Sheetal Kale", Gender.Female));
            //        New_EMP_List.Add(new EMP(4, "Nayan Kale", Gender.Male));

            //New Employee Female List
            ////foreach (EMP emp in New_EMP_List.Where(e => e.gender.ToString() == "Female"))
            ////{
            ////    New_EMP_List_Female.Add(emp);
            ////    //Console.WriteLine(EMP_List.Max(e => e.Salary));
            ////}
            //////New Employee Male List
            ////foreach (EMP emp in New_EMP_List.Where(e => e.gender.ToString() == "Male"))
            ////{
            ////    New_EMP_List_Male.Add(emp);
            ////    //Console.WriteLine(EMP_List.Max(e => e.Salary));
            ////}

            string min_salary = JsonConvert.SerializeObject(min_details);

            Console.WriteLine("All Employee Data : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Min Salary is " + min_sal + " and their details are: " + min_details);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Max Salary is " + max_sal + " and their details are: " + max_details);
            Console.WriteLine();
            Console.WriteLine();

            //sorted by salary
            Sorted_by_salary = EMP_List.OrderBy(e => e.salary).ToList();

            Console.WriteLine("Sorted List Based on salary is : ");
            Console.WriteLine();
            Console.WriteLine();
            string sorted_salary = JsonConvert.SerializeObject(Sorted_by_salary);
            string emp_male = JsonConvert.SerializeObject(EMP_Male_list);
            string new_emp_male = JsonConvert.SerializeObject(New_EMP_List_Male);
            string new_emp_female = JsonConvert.SerializeObject(New_EMP_List_Female);

            //var result = JsonConvert.DeserializeObject(new_emp_female, typeof(EMP)) as EMP;
            // result





            Console.WriteLine(sorted_salary);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of all Male Employess : ");
            Console.WriteLine(emp_male + new_emp_male);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of all Female Employess : ");
            Console.WriteLine(new_emp_female);

            Console.ReadLine();
        }

        public class EMP
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public Dept dept { get; set; }
            public Gender gender { get; set; }
            public Country country { get; set; }
            public int salary { get; set; }
            public DateTime dob { get; set; }

            public string fullName { get; set; }

            //public EMP(int ID, string FirstName, string LastName, Dept dept, Gender gender, Country country, int Salary, DateTime DOB)
            //{
            //    int iD = ID;
            //    string firstName = FirstName;
            //    string lastName = LastName;
            //    Dept Dept = dept;
            //    Gender Gender = gender;
            //    Country Country = country;
            //    int salary = Salary;
            //    DateTime dOB = DOB;
            //}



            //public EMP(int ID, string FullName, Gender gender)
            //{

            //    int iD = ID;
            //    string fullName = FullName;

            //    Gender Gender = gender;
            //    //string FullName = FirstName +" "+ LastName;
            //}


        }

        public enum Dept
        {
            Null = 0,
            IT = 1,
            HR = 2,
            Payroll = 3,
            Engineering = 4,
            Admin = 5,
            Sales = 6
        }
        public enum Gender
        {
            Null = 0,
            Male,
            Female
        }
        public enum Country
        {
            Null = 0, India, USA, China, Russia, Japan, England
        }
    }
}
