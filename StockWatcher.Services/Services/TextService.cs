using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.Services.Services
{
    public class TextService : ITextService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
