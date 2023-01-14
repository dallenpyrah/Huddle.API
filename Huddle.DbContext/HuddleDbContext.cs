using Huddle.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Huddle.DbContext;

public class HuddleDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Issue> Issues { get; set; }

    public HuddleDbContext(DbContextOptions<HuddleDbContext> options) : base(options)
    {
    }
}