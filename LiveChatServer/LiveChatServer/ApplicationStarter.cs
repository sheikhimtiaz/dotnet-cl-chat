using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using LiveChatServer.Helpers;
using System.Threading.Tasks;

namespace LiveChatServer
{
    public class ApplicationStarter
    {
        static int choice = 0;

        static Task t1;

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static void StartApplication()
        {

            t1 = DBConnection.EstablishConnection();

            Task.WaitAll(t1);

            while (true)
            {
                Console.WriteLine("\n\nSignUp           - Type 1 and press Enter!");
                Console.WriteLine("SignIn           - Type 2 and press Enter!");
                Console.WriteLine("Exit Application - Type 3 and press Enter!\n\n");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("\nEnter your username: \n");
                    string username = Console.ReadLine(); 
                    Console.WriteLine("\nEnter your password: \n");
                    string password = Console.ReadLine();
                    string hashedPass = ComputeSha256Hash(password);
                    if(Authentication.RegistrationSucceed(username, hashedPass))
                    {
                        Console.WriteLine("Registration Completed. Please Sign In.");
                    }
                    else
                    {
                        Console.WriteLine("An error occurred to sign up. Please try again.");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\nUsername: \n");
                    string username = Console.ReadLine();
                    Console.WriteLine("\nPassword: \n");
                    string password = Console.ReadLine();
                    string hashedPass = ComputeSha256Hash(password);

                    if (Authentication.LoginSucceed(username, hashedPass))
                    {
                        ChatRoom.EnterChatRoom();
                    }
                    else
                    {
                        Console.WriteLine("Wrong username or password!!!");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Have a 3 good day!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please give a valid input.");
                }
            }

        }
    }
}
