using PengaduanKeamananCLI.Database;
using PengaduanKeamananCLI.Services;

namespace PengaduanKeamananCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.InitDatabase();
            MenuService.ShowLoginMenu();
        }
    }
}
