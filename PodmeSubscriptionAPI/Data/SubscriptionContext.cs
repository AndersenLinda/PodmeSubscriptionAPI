using Microsoft.EntityFrameworkCore;
using PodmeSubscriptionAPI.Models;

public class SubscriptionContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; }

    public SubscriptionContext(DbContextOptions<SubscriptionContext> options)
        : base(options)
    {
    }
}