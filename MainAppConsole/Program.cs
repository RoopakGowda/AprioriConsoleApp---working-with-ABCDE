using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DATA;
using AprioriAlgorithm;

namespace MainAppConsole
{
    class Program
    {
        static List<string> ItemSets;
        static List<string> TransactionSets;
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, Thank you for choosing AgentNet. \n\n\nGetting latest transaction data from DB...");
            InititalizeData();
            Console.WriteLine("Following items found :");
            Console.WriteLine(string.Join(",", ItemSets));
            Console.WriteLine("Number of transactions found : " + TransactionSets.Count);
            //Console.WriteLine(string.Join(",", TransactionSets));
            Console.Write("Please enter a minimum support (%) :");
            string minSupportStr = Console.ReadLine();//"50";//Console.ReadLine();
            Console.Write("Please enter a minimum confidence (%) :");
            string minConfidenceStr = Console.ReadLine(); //"80";//Console.ReadLine();

            double minSupport = double.Parse(minSupportStr) / 100;
            double minConfidence = double.Parse(minConfidenceStr) / 100;
            string[] transactionArray = TransactionSets.ToArray();

            IApriori _apriori = new Apriori();
            Output output = _apriori.ProcessTransaction(minSupport, minConfidence, ItemSets, transactionArray);
            Console.WriteLine(string.Join("",output.StrongRules.Select(i => i.X + "-->" +i.Y +"\t" +i.Confidence*100 +"%\n").ToList()));
            Console.ReadKey();
        }

        static void InititalizeData()
        {
            //todo : get data from DATA layer
            DBConnection dbConn = new DBConnection();
            DataSet ds = dbConn.GetTransactionData();
            ItemSets = ds.Tables[0].AsEnumerable().Select(r => r["items"].ToString()).ToList();
            TransactionSets = ds.Tables[1].AsEnumerable().Select(r => r["transactions"].ToString()).ToList();
        }
    }
}
