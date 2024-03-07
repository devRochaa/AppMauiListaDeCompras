using AppMauiListaDeCompras.Helpers;

namespace AppMauiListaDeCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                            ), "banco_sqlite_compras.db3" 
                    );
                

                    _db = new SQLiteDatabaseHelper( path );

                } // fecha if verificando se _db é null

                return _db;
            }//feche método get
        }// fecha prodpiedade db
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
