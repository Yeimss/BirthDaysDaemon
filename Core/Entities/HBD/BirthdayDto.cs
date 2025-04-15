using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.HBD
{
    public class BirthdayDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BornDate { get; set; }
        public BirthdayDto() { }
        public BirthdayDto(string name, DateTime date, string email = "")
        {
            this.Name = name;
            this.BornDate = date;
            this.Email = email;
        }
        public List<BirthdayDto> GetMaiKingsBirthdays()
        {
            return new List<BirthdayDto>{
                new BirthdayDto("Kevon", new DateTime(2000, 5, 2)),
                new BirthdayDto("Maiqui", new DateTime(1999, 7, 11)),
                new BirthdayDto("El Mecias", new DateTime(1999, 5, 2)),
                new BirthdayDto("Busta", new DateTime(2000, 8, 6)),
                new BirthdayDto("Mora", new DateTime(1999, 9, 1)),
                new BirthdayDto("Harold", new DateTime(1998, 12, 11)),
                new BirthdayDto("El Brayan", new DateTime(2000, 6, 19)),
                new BirthdayDto("Ieremaia", new DateTime(2002, 1, 18)),
                new BirthdayDto("El Yeyei", new DateTime(2001, 1, 17), "JamesHerrera364@gmail.com"),
            };
        }
        public List<BirthdayDto> GetMaiQueensBirthdays()
        {
            return new List<BirthdayDto>
            {
                new BirthdayDto("Marce", new DateTime()),
                new BirthdayDto("Mariana", new DateTime()),
                new BirthdayDto("La gorda", new DateTime()),
                new BirthdayDto("Malon", new DateTime()),
                new BirthdayDto("El niño", new DateTime(2001, 1, 17)),

            };
        }
        public DateTime GetNextBD()
        {
            DateTime hoy = DateTime.Now;
            int dateDif = hoy.Year - this.BornDate.Year;
            DateTime hbdThisYear = this.BornDate.AddYears(dateDif);
            if(hbdThisYear <= hoy)
            {
                return hbdThisYear.AddYears(1);
            }
            return hbdThisYear;
        }
        public bool FifteenDaysOrLess()
        {
            DateTime today = DateTime.Now;
            TimeSpan diferencia = (this.GetNextBD() - today);
            return diferencia.Days <= 20 ? true : false;
        }

    }
}
