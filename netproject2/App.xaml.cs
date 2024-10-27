using System.Windows;
using netproject2.Data;
using netproject2.Views;

namespace netproject2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Set the shutdown mode to OnMainWindowClose so the app doesn't exit when the first window is closed

         

            // Initialize the database on startup
            using (var context = new AppDbContext())
            {
                context.InitializeDatabase(); // This will create the database and tables if they do not exist
            }

            // Continue with application startup logic
        }
    }
}
