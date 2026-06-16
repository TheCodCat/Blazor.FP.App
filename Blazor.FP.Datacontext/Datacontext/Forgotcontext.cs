using Microsoft.EntityFrameworkCore;
using Blazor.FP.Datamodels;
using Blazor.FP.Datamodels.models.Models;

namespace Blazor.FP.Datacontext.Datacontext;

public class Forgotcontext : DbContext
{
    public DbSet<Blazor.FP.Datamodels.models.Models.ForgotPasswordRequest> ForgotPasswordRequests { get; set; }
    public DbSet<Blazor.FP.Datamodels.models.Models.ForgotPasswordResponce> ForgotPasswordResponces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FogrotPassword.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ForgotPasswordRequest>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ForgotPasswordResponce>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ForgotPasswordResponce>()
            .HasOne(x => x.Request)
            .WithOne(x => x.Responce)
            .HasForeignKey<ForgotPasswordResponce>(x => x.RequestId);
    }
}