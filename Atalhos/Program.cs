using Atalhos;
using Atalhos.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Atalhos
{
  internal static class Program
  {
    private static Mutex mutex = new Mutex(true, "a24b737c-0ce2-4a71-8317-2177d503eb94");

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    /// 
    [STAThread]
    static void Main(string[] args)
    {
      if (!mutex.WaitOne(TimeSpan.Zero, true))
      {
        MessageBox.Show("O aplicativo já está em execução na bandeja de aplicativos do Windows.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();

      // Ensure database exists and apply migrations on startup
      try
      {
        using (var db = new ApplicationDbContext())
        {
          db.Database.Migrate();
        }
      }
      catch (Exception ex)
      {
        // If migration fails, you can log the exception or handle it accordingly.
        Console.WriteLine($"Database migration error: {ex.Message}");
      }

      Application.Run(new AtalhosMainForm());
    }
  }
}
