using System;
using Microsoft.EntityFrameworkCore;
using KmedAPI.Poco;
namespace KmedAPI.Contexto
{
    public class APIContexto : DbContext
    {
        public APIContexto(DbContextOptions<APIContexto> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}
