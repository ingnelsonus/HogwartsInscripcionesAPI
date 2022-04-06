using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

//Referenciar
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace DataAccess
{
    public class HowartsSchoolRequestDBContext : DbContext,IHowartsSchoolRequestDBContext
    {
        public HowartsSchoolRequestDBContext(DbContextOptions<HowartsSchoolRequestDBContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal.SqlServerOptionsExtension CnxOptios = (Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal.SqlServerOptionsExtension)optionsBuilder.Options.Extensions.OfType<Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal.SqlServerOptionsExtension>().First();
                string cnx = CnxOptios.ConnectionString;

                if (cnx != string.Empty)
                    optionsBuilder.UseSqlServer(cnx).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        public virtual DbSet<SolicitudIngresoEntitycs> SolicitudIngreso { get; set; }       

       
    }
}
