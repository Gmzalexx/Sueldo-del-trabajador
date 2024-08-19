using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sueldo_del_trabajador
{
    public class LocalDbService
    {
        private const string DB_NAME = "sueldo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            // Crear la tabla Sueldos en la base de datos
            _connection.CreateTableAsync<Sueldo>().Wait();
        }

        // Método para obtener todos los sueldos
        public async Task<List<Sueldo>> GetSueldos()
        {
            return await _connection.Table<Sueldo>().ToListAsync();
        } 

        public async Task Create(Sueldo sueldo)
        {
            await _connection.InsertAsync(sueldo);
        }

        public async Task Update(Sueldo sueldo)
        {
            await _connection.UpdateAsync(sueldo);
        }

        // Método para eliminar un sueldo
        public async Task Delete(Sueldo sueldo)
        {
            await _connection.DeleteAsync(sueldo);
        }
    }
}
