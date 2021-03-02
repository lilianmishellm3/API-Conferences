using EmployedAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployedAPI.Context
{
    public class ConferenceDbContext: DbContext
    {
        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options):base (options)
        {

        }
       


        public DbSet<Conference> Conferences { get; set; }
       public  DbSet<SessionTalk> SessionTalks { get; set; }




    }
}
