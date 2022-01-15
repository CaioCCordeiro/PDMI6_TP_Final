using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDMI6_TP_Final.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConexao();
    }
}
