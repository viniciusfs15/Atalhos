using Microsoft.EntityFrameworkCore;
using Atalhos.Models;
using System.IO;

namespace Atalhos.DbContext
{
  public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public DbSet<AmbienteModel> Ambientes { get; set; }
    public DbSet<AliasModel> Aliases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var dbPath = Path.Combine(GetDocumentsPath(), "AtalhosData");
        if(!Directory.Exists(dbPath))
        {
          Directory.CreateDirectory(dbPath);
        }
        dbPath = Path.Combine(dbPath, "atalhos.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
      }
    }

    //Retorna o endereço da pasta Documentos do usuario atual
    private string GetDocumentsPath() 
    { 
      return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
