using System;
using System.Media;
using System.Threading;
using System.IO; // ✅ Added for file path handling

namespace CyberSecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayHeader();
            PlayGreeting();

            Console.Write("\nEnter your name: ");
            string userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Name cannot be empty. Please enter your name: ");
                userName = Console.ReadLine();
            }

            TypeText($"\nHello {userName}! 👋 Welcome to the Cybersecurity Awareness Bot.");

            StartChat(userName);
        }

        // ================= CHATBOT LOGIC =================
        static void StartChat(string userName)
        {
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Respond("Please enter something so I can help you.");
                    continue;
                }

                switch (input)
                {
                    case "hi":
                    case "hello":
                        Respond($"Hello {userName}! How can I help you stay safe online?");
                        break;

                    case "how are you":
                        Respond("I'm just a bot, but I'm here to help you stay safe online!");
                        break;

                    case "what is your purpose":
                        Respond("My purpose is to educate you about cybersecurity.");
                        break;

                    case "what can i ask you":
                        Respond("You can ask me about passwords, phishing, and safe browsing.");
                        break;

                    case "password":
                        Respond("Use strong passwords with letters, numbers, and symbols. Never share them.");
                        break;

                    case "phishing":
                        Respond("Phishing tricks you into giving personal info. Always verify emails and links.");
                        break;

                    case "safe browsing":
                        Respond("Only visit secure websites (https) and avoid suspicious links.");
                        break;

                    case "exit":
                        Respond("Goodbye! Stay safe online 👋");
                        running = false;
                        break;

                    default:
                        Respond("I didn't quite understand that. Could you rephrase?");
                        break;
                }
            }
        }

        // RESPONSE METHOD
        static void Respond(string message)
        {
            TypeText("\nBot: " + message);
        }

        // UI METHODS 
        static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==============================================");
            Console.WriteLine("   CYBERSECURITY AWARENESS CHATBOT");
            Console.WriteLine("==============================================");

            Console.WriteLine(@"
   _______  __   __  _______  _______  ______
  |       ||  | |  ||       ||       ||    _
  |       ||  |_|  ||    ___||    ___||   | |
  |       ||       ||   |___ |   |___ |   |_|
  |      _||       ||    ___||    ___||    __
  |     |_ |   _   ||   |___ |   |___ |   |  |
  |_______||__| |__||_______||_______||___|  |
");

            Console.ResetColor();
        }

        static void TypeText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        // ================= AUDIO (FIXED) =================
        static void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting1.wav");

                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Load();
                    player.PlaySync(); // waits for sound to finish
                }
                else
                {
                    Console.WriteLine("Audio file not found. Make sure 'greeting1.wav' is in the project.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio error: " + ex.Message);
            }
        }
    }
}