﻿using Demo.Domain.UseCase;
using System.Text;

namespace Demo.UI
{
    public class MainMenuUI
    {

        private readonly UserConsoleUI _userConsoleUI;
        private readonly GroupConsole _groupConsole;

        public MainMenuUI(UserUseCase userUseCase, GroupUseCase groupUseCase)
        {
            _userConsoleUI = new UserConsoleUI(userUseCase);
            _groupConsole = new GroupConsole(groupUseCase);
            DisplayMenu();
        }

        public async void DisplayMenu()
        {


            string filePath = "C:\\Users\\Class_Student\\source\\demo_sch\\Demo\\putin.txt";
            string filePathTwo = "C:\\Users\\Class_Student\\source\\demo_sch\\Demo\\serp.txt";

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.WriteLine(line);
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }

            if (File.Exists(filePathTwo))
            {
                using (StreamReader srt = new StreamReader(filePathTwo))
                {
                    string lineTwo;
                    while ((lineTwo = srt.ReadLine()) != null)
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.WriteLine(lineTwo);
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }


            while (true)
            {



                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n☭☭☭☭☭☭☭☭☭☭ Главная Панель ☭☭☭☭☭☭☭☭☭☭\n");
                Console.WriteLine(" УПРАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯМИ:");
                Console.WriteLine("1. Показать список всех пользователей");
                Console.WriteLine("2. Удалить пользователя по его Guid");
                Console.WriteLine("3. Обновить данные пользователя по Guid");
                Console.WriteLine("4. Найти пользователя по его Guid");
                Console.WriteLine();


                switch (Console.ReadLine())
                {
                    case "1": _userConsoleUI.DisplayAllUsers(); break;
                    case "2": await _userConsoleUI.RemoveUserByGuid(Guid.Parse(Console.ReadLine())); break;
                    //case "3": _userConsoleUI.UpdateUserByGuid
                    //case "4": _userConsoleUI.FindUserByGuid

                    default:
                        DisplayMenu();
                        break;
                }

            }
        }

    }
}
