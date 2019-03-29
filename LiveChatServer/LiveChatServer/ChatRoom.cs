using System;
using System.Collections.Generic;
using System.Text;

namespace LiveChatServer
{
    public class ChatRoom
    {
        public static void EnterChatRoom()
        {
            int choice = 0;
            while (true)
            {
                Console.WriteLine("\n\nStart converstation with friends - Type 1 and press Enter");
                Console.WriteLine("See existing chat history - Type 2 and press Enter");
                Console.WriteLine("Exit chat room and log out - Type 3 and press Enter\n\n");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1");
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                    default:
                        Console.WriteLine("break");
                        break;
                }
            }
        }
    }
}
