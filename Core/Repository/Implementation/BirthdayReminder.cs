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
        private readonly IServiceRepository _serviceRepository;
        public BirthdayReminder(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task BirthdayValidator()
        {
            BirthdayDto birthday = new BirthdayDto();
            List<BirthdayDto> ListBirthday = birthday.GetMaiKingsBirthdays();
            List<BirthdayDto> siguientesCums = ListBirthday.Where(c => (c.GetNextBD() - DateTime.Now).Days <= 20).ToList();
            _serviceRepository.EnviarInvitacion(
                string.Join(";",
                    ListBirthday.Where(r => !r.Email.Equals("")).Select(r => r.Email).ToArray()
                ),
                siguientesCums.Where(r => !r.Name.Equals("")).Select(r => r.Name).ToArray());

        }
    }
}
