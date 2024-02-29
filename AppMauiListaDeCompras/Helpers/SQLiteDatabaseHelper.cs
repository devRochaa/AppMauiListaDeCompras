using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppMauiListaDeCompras.Models;

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

        public Task<int> Delelte(int id)
        { 
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
    }
}
