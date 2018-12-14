using BasicBot.DAL;
using BasicBot.Dialogs.Quotes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBot.DALs
{
    public class QuotesDAL : IQuotesDAL
    {
        private string connectionString;

        public QuotesDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public QuoteState GetRandomQuote()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SELECT TOP 1 ")
                }
            }

        }
    }
}
