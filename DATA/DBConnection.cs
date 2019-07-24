using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DATA
{
    public class DBConnection
    {
        //todo : call db and get details
        
        public DataSet GetTransactionData()
        {
            DataSet ds = new DataSet();
            DataTable itemTable = new DataTable();
            DataTable transacntaionTable = new DataTable();

            PrepareMockData(ref itemTable, ref transacntaionTable);

            ds.Tables.Add(itemTable);
            ds.Tables.Add(transacntaionTable);

            return ds;
        }

        private void PrepareMockData(ref DataTable itemTable, ref DataTable transacntaionTable)
        {
            itemTable.Columns.Add("items", typeof(string));
            transacntaionTable.Columns.Add("transactions", typeof(string));

            itemTable.Rows.Add("A");
            itemTable.Rows.Add("B");
            itemTable.Rows.Add("C");
            itemTable.Rows.Add("D");
            itemTable.Rows.Add("E");

            transacntaionTable.Rows.Add("ACD");
            transacntaionTable.Rows.Add("BCE");
            transacntaionTable.Rows.Add("ABCE");
            transacntaionTable.Rows.Add("BE");
        }
    }
}
