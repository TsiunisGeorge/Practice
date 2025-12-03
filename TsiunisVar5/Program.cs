using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Data;
using TsiunisVar5.Models;

string connectionString = "User ID=postgress;Password=root;Host=localhost;Port=5432;Database=TsiunisVar5";
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseNpgsql(connectionString)
    .Options;
var context = new AppDbContext(options);
    
context.Database.Migrate();
// var app = builder.Build();