using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDMI6_TP_Final.Data;
using Xamarin.Forms;

namespace PDMI6_TP_Final.Model
{
    public class Mercadoria
    {
        public Mercadoria()
        {
            database =
            DependencyService.Get<ISQLite>().GetConexao();
            database.CreateTable<Mercadoria>();
        }
        #region Propriedades
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Peso { get; set; }
        public string NomeProdutor { get; set; }
        public string EmailProdutor { get; set; }
        public int NCM { get; set; }
        #endregion
        #region Mercadoria Local Database
        private SQLiteConnection database;
        static object locker = new object();
        public int SalvarMercadoria(Mercadoria mercadoria)
        {
            lock (locker)
            {
                if (mercadoria.Id != 0)
                {
                    database.Update(mercadoria);
                    return mercadoria.Id;
                }
                else return database.Insert(mercadoria);
            }
        }
        public IEnumerable<Mercadoria> GetMercadorias()
        {
            lock (locker)
            {
                return (from c in database.Table<Mercadoria>()
                        select c).ToList();
            }
        }
        public Mercadoria GetMercadoria(int Id)
        {
            lock (locker)
            {
                // return database.Query< Mercadoria>("SELECT * FROM [Mercadoria] WHERE[Id] = " + Id);
                return database.Table<Mercadoria>().Where(c => c.Id ==
                Id).FirstOrDefault();
            }
        }
        public int RemoverMercadoria(int Id)
        {
            lock (locker)
            {
                return database.Delete<Mercadoria>(Id);
            }
        }
        #endregion
    }
}
