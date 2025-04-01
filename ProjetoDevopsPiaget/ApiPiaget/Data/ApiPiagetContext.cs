using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPiaget.Models;

namespace ApiPiaget.Data
{
    public class ApiPiagetContext : DbContext
    {
        public ApiPiagetContext (DbContextOptions<ApiPiagetContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPiaget.Models.Aluno> Aluno { get; set; } = default!;
        public DbSet<ApiPiaget.Models.Professor> Professor { get; set; } = default!;
        public DbSet<ApiPiaget.Models.Escola> Escola { get; set; } = default!;
        public DbSet<ApiPiaget.Models.Gestao> Gestao { get; set; } = default!;
    }
}
