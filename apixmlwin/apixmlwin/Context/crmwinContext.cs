using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apixmlwin.Models;

namespace apixmlwin.Context
{
    public class crmwinContext : DbContext
    {
        public crmwinContext(DbContextOptions<crmwinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<replicaPedidos>? CRM_PEDIDO { get; set; }
        public virtual DbSet<replicaOrdenes>? CRM_PROGRAMACION { get; set; }
        //public DbSet<queryMensaje>? qery_mensaje { get; set; }
    }
}