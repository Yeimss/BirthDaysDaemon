﻿using Core.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
namespace Core.Repository.Implementation
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IConfiguration _configuration;
        public ServiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool EnviarInvitacion(string correos, string[] cumpleaneros, DateTime siguienteCum)
        {
            try
            {
                string correo = _configuration["EmailSettings:Email"]!;
                string psw = _configuration["EmailSettings:Password"]!;
                GmailService gmailService = new GmailService();
                gmailService.EnviarInvitacion(correo, correos.Split(";"), $"Cumpleaños de {string.Join(", ", cumpleaneros)}" ,psw, siguienteCum);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
