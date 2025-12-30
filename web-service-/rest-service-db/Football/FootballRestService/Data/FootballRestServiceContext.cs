using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootballRestService.Models;

namespace FootballRestService.Data
{
    public class FootballRestServiceContext : DbContext
    {
        public FootballRestServiceContext (DbContextOptions<FootballRestServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Match> Matches { get; set; } = default!;


    }
}
