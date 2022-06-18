using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E112.Models;
using System.Threading.Tasks;


namespace PM2E112.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            /*Se crean las tablas*/
            dbase.CreateTableAsync<Models.Sitios>();

        }

        public Task<int> SitioSave(Sitios sitio)
        {
            if (sitio.id != 0)//update del registro
            {
                return dbase.UpdateAsync(sitio);
            }
            else
            {
                return dbase.InsertAsync(sitio);//inserter nuevo registro
            }

        }

        public Task<List<Sitios>> getListSitio()
        {
            return dbase.Table<Sitios>().ToListAsync();//se convierte el resultado a una lista.
        }
    }
}
