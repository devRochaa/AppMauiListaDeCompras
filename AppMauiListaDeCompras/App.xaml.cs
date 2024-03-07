namespace AppMauiListaDeCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
