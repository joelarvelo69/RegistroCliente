using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ApplyGeek.Models;
using System.Threading.Tasks;

namespace ApplyGeek.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Registro>().Wait();
        }

        /// <summary>
        /// Guardar Registro
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Task<int> SaveRegistroAsync(Registro reg)
        {
            if (reg.IdCliente != 0)
            {
                return db.UpdateAsync(reg);
            }
            else
            {
                return db.InsertAsync(reg);
            }
        }


        /// <summary>
        /// Para Eliminar datos
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public Task<int> DeleteRegistroAsync(Registro registro)
        {
            return db.DeleteAsync(registro);
        }


        /// <summary>
        /// Recuperar todos los clientes
        /// </summary>
        /// <returns></returns>
        public Task<List<Registro>> GetRegistroAsync()
        {
            return db.Table<Registro>().ToListAsync();
        }


        /// <summary>
        /// Recupera cliente por ID
        /// </summary>
        /// <param name="IdCliente">Id del cliente que se requiere</param>
        /// <returns></returns>

        public Task<Registro> GetRegistroByIdAsync(int IdCliente)
        {
            return db.Table<Registro>().Where(a => a.IdCliente == IdCliente).FirstOrDefaultAsync();
        }


        /// <summary>
        /// Guardar Direcciones
        /// </summary>
        public Task<int> SaveDireccionesAsync(Registro reg)
        {
            if (reg.Direccion != null)
            {
                return db.UpdateAsync(reg);
            }
            else
            {
                return db.InsertAsync(reg);
            }
        }
    }   
}
