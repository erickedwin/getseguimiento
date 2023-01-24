using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apixmlwin.Models;

namespace apixmlwin.Context
{
    public class awsEquifaxContext : DbContext
    {
        public awsEquifaxContext(DbContextOptions<awsEquifaxContext> options)
            : base(options)
        {
        }

        public DbSet<equifaxAws>? t_equifax { get; set; }
        public DbSet<awsdataequi>? t_inequi { get; set; }
        public DbSet<intermediaMensaje>? t_reglas { get; set; }
    }
}