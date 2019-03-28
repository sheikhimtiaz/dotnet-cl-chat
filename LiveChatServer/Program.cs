using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveChatServer.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LiveChatServer
{
    class Program
    {
        static void Main(string[] args)
        {

            //DBConnection.EstablishConnection();
            Task t1 = DBConnection.EstablishConnection();

            Task.WaitAll(t1);

            Console.WriteLine("# Program Ends #");
        }

        
    }
}
