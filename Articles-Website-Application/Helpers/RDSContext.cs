using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Articles_Website_Application.Class;

namespace Articles_Website_Application.Helpers
{
    //This class is used to communicate with the database
    public class RDSContext : DbContext
    {
        public DbSet<News> news { get; set; }

        public DbSet<AWSCredentials> awsCredentials {get;set;}

        public RDSContext() : base(Properties.Settings.Default.RDSConnectionString)
        {
        }

        public static RDSContext Create()
        {
            return new RDSContext();
        }
    }
}