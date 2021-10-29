using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using teste.Entites;


namespace teste.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserEntity> Users {get;set;}
    }
}