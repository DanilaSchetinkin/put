using Microsoft.EntityFrameworkCore;
using Demo.Data.RemoteData.RemoteDataBase.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase;

public class RemoteDatabaseContext : DbContext


    public DbSet<GroupDao> Groups {  get; set; }
    public DbSet<UserDao> Users {  get; set; }

    public DbSet<PresenceDao> PresenceDaos {  get; set; }


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql();
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<GroupDao>().HasKey(group => group.Id);
    modelBuilder.Entity<GroupDao>().Property(group => group.Id).ValueGeneratedOnAdd();
    modelBuilder.Entity<UserDao>().HasKey(user => user.Guid);
    modelBuilder.Entity<UserDao>().Property(user => user.Guid).ValueGeneratedOnAdd();
    modelBuilder.Entity<PresenceDao>().HasKey(presence => new
    {
        presence.UserGuid,
        presence.Date,
        presence.IsAttedance,
        presence.LessonNumber
    });
}