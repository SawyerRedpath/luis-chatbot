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

        public QuotesDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public RandomQuote GetRandomQuote()
        {
            RandomQuote q = new RandomQuote();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SELECT TOP 1 quote, quote_source FROM motivational_quotes ORDER BY NEWID()", conn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        q.Quote = Convert.ToString(reader["quote"]);
                        q.QuoteSource = Convert.ToString(reader["quote_source"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return q;
        }
    }
}
