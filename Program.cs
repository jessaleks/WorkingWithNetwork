using System;
using System.Net;
using static System.Console;

namespace WorkingWithNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            Write("Enter a valid web address and press enter: ");
            string url = ReadLine();
			if(string.IsNullOrWhiteSpace(url))
			{
                while (isValid == false)
				{
                    WriteLine("Try again");
                    Write("Enter a valid web address and press enter: ");
                    url = ReadLine();
					if(string.IsNullOrWhiteSpace(url))
					{
                        continue;
                    } 
					else {
                        isValid = true;
                        break;
                    }
                }
            }
            Uri uri = new Uri(url);
			IPHostEntry entry = Dns.GetHostEntry(uri.Host);

            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine("======");
            WriteLine("Some basic info about the DNS entry for your page:");
            WriteLine($"{url}'s host name is {entry.HostName}");
            WriteLine($"{entry.HostName} has the following IP addresses:");
			foreach (IPAddress address in entry.AddressList)
			{
                WriteLine($"{address}");
            }
    		
        }
    }
}
