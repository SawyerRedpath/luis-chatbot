using BasicBot.Dialogs.Quotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBot.DAL
{
    public interface IQuotesDAL
    {
        RandomQuote GetRandomQuote();
    }
}
