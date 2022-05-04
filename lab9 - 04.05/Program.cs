using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace lab9___04._05
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            DatabaseContext context = new DatabaseContext();
           /* context.Database.EnsureCreated();
            context.Students.Add(new Student() { ETCS = 40, Name = "Mateusz" });
            context.Students.Add(new Student() { ETCS = 30, Name = "Maciek" });
            context.Students.Add(new Student() { ETCS = 20, Name = "Juri" });
            context.SaveChanges();

            context.Ocenas.Add(new Ocena() { StudentId = 1, Value = 5, Lecture="Biologia" });
            context.Ocenas.Add(new Ocena() { StudentId = 2, Value = 4, Lecture="Chemia" });
            context.Ocenas.Add(new Ocena() { StudentId = 3, Value = 3, Lecture="Matematyka" });
            context.SaveChanges();*/

            var students = from student in context.Students
                           where student.ETCS > 20
                           select new { ETCS = student.ETCS, Name = student.Name };

            foreach(var student in students)
            {
                Console.WriteLine(student);
            }

            context.Students.Where(s=>s.ETCS>20).Select(s=> new { ETCS = s.ETCS, Name = s.Name });


            //LINQ
            var ocenaStudenta = from student in context.Students
            join ocena in context.Ocenas on student.Id equals ocena.StudentId
            where ocena.Lecture.Equals("Biologia")
            select new { Imie = student.Name, Numer = student.Id, Grade = ocena.Value };
            foreach (var item in ocenaStudenta)
            {
                Console.WriteLine(item);
            }
            //FLUETN API

           ocenaStudenta =  context.Students.Join
                (
                    context.Ocenas.Where(x => x.Lecture.Equals("Biologia")),
                    student => student.Id,
                    grade => grade.StudentId,
                    (student,grade)=>new { Imie = student.Name, Numer = student.Id, Grade = grade.Value }

                );

            foreach (var item in ocenaStudenta)
            {
                Console.WriteLine(item);
            }

            //XML

            string xml = "<studenci>" +
                            
                          "<student>"+
                            "<id>1</id>"+
                            "<name>Mateusz</name>"+
                            "<ETCS>20</ETCS>"+
                          "</student>"+
                          "<student>" +
                            "<id>2</id>" +
                            "<name>Maciek</name>" +
                            "<ETCS>30</ETCS>" +
                          "</student>" +
                          "<student>" +
                            "<id>3</id>" +
                            "<name>Juri</name>" +
                            "<ETCS>40</ETCS>" +
                          "</student>" +

                        "</studenci>";

            XDocument doc = XDocument.Parse(xml);
            IEnumerable<XElement> enumerable = doc.Elements("studenci").Elements("student").Elements("name");
            foreach (XElement element in enumerable)
            {
                Console.WriteLine(element.Value);
            }
            IEnumerable<string> enumerable2 = doc.Elements("studenci").Elements("student").Elements("name").Select(x=>x.Value);


            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/xml");
            string xmlRates = client.DownloadString("http://api.nbp.pl/api/exchangerates/tables/C");
            var rates = doc
               .Elements("ArrayOfExchangeRatesTable")
               .Elements("ExchangeRatesTable")
               .Elements("Rates")
               .Elements("Rate")
               .Select(x => new { 
                   Code = x.Elements("Code").First().Value, 
                   Bid = x.Elements("Bid").First().Value, 
                   Ask = x.Elements("Ask").First().Value 
               });
            foreach (var item in rates)
            {
                Console.WriteLine(item);
            }
        }
    }

    public record Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ETCS { get; set; }
       
    }

    public record Ocena
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Value { get; set; }
        public string Lecture { get; set; }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Ocena> Ocenas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DATASOURCE=C:\\ondrive\\OneDrive - Wyższa Szkoła Ekonomii i Informatyki w Krakowie\\WSEI - obiektówka\\database\\sqlbase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("studenci");
            modelBuilder.Entity<Ocena>().ToTable("oceny");
        }
    }
}
