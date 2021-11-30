using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Models;

namespace TCC.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Plantacao> Plantacoes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cultura> Culturas { get; set; }
        public DbSet<Semente> Sementes { get; set; }

    }
}
