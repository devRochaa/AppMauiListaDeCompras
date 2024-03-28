using AppMauiListaDeCompras.Models;
using SQLite;

namespace AppMauiListaDeCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update (Produto p)
        {
            string sql = "Update Prudote SET Descricao=?, " +
                         "Preco=? Quantidade=? WHERE id=?";

            return _conn.QueryAsync<Produto>(sql,
                p.Descricao, p.Preco, p.Quantidade, p.Id);
        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
        public Task<int> Delete(int id)
        { 
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
            //mudar 1
        }
    }
}
