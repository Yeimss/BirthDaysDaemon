using Core.Entities.HBD;
using Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Implementation
{
    public class BirthdayReminder : IBirthdayReminder
    {
        public async Task BirthdayValidator()
        {
            BirthdayDto birthday = new BirthdayDto();
            List<BirthdayDto> ListBirthday = birthday.GetMaiKingsBirthdays();
            Console.WriteLine("{0,-15} | {1,-10}", "Nombre", "Cumple");

            foreach (BirthdayDto bDay in ListBirthday)
            {
                if (bDay.FifteenDaysOrLess())
                {
                    Console.WriteLine("{0,-15} | {1,-10}", bDay.Name, bDay.GetNextBD().ToString("yyyy-MM-dd"));
                }
            }
        }
    }
}
