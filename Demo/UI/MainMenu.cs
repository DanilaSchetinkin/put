using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DisplayMenu()
        {
            while (true)
            {
                
                Console.WriteLine("\n☭☭☭☭☭☭☭☭☭☭ Главная Панель ☭☭☭☭☭☭☭☭☭☭\n");


                //Console.WriteLine("\n ⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n");
                // Console.WriteLine("\n⣿⣿⣿⣵⣿⣿⣿⠿⡟⣛⣧⣿⣯⣿⣝⡻⢿⣿⣿⣿⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⣿⣿⣿⣿⣿⠋⠁⣴⣶⣿⣿⣿⣿⣿⣿⣿⣦⣍⢿⣿⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⣿⣿⣿⣿⢷⠄⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⢼⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⢹⣿⣿⢻⠎⠔⣛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⢸⣿⣿⠇⡶⠄⣿⣿⠿⠟⡛⠛⠻⣿⡿⠿⠿⣿⣗⢣⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠐⣿⣿⡿⣷⣾⣿⣿⣿⣾⣶⣶⣶⣿⣁⣔⣤⣀⣼⢲⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠄⣿⣿⣿⣿⣾⣟⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⢟⣾⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠄⣟⣿⣿⣿⡷⣿⣿⣿⣿⣿⣮⣽⠛⢻⣽⣿⡇⣾⣿⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠄⢻⣿⣿⣿⡷⠻⢻⡻⣯⣝⢿⣟⣛⣛⣛⠝⢻⣿⣿⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠄⠸⣿⣿⡟⣹⣦⠄⠋⠻⢿⣶⣶⣶⡾⠃⡂⢾⣿⣿⣿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠄⠄⠟⠋⠄⢻⣿⣧⣲⡀⡀⠄⠉⠱⣠⣾⡇⠄⠉⠛⢿⣿⣿⣿\n");
                //Console.WriteLine("\n ⠄⠄⠄⠄⠄⠈⣿⣿⣿⣷⣿⣿⢾⣾⣿⣿⣇⠄⠄⠄⠄⠄⠉⠉\n");



 Console.WriteLine("\n_________________8¶88111111111____________________\n");
 Console.WriteLine("\n____________1¶¶¶¶¶81111__1111111818_______________\n");
 Console.WriteLine("\n_________1¶¶¶¶¶888881111______118¶¶¶¶¶8___________\n");
 Console.WriteLine("\n_______¶¶¶¶¶¶¶¶¶811____________18¶8¶¶¶¶¶¶_________\n");
 Console.WriteLine("\n_____¶¶¶¶88811181111_____1_________88¶818¶1_______\n");
 Console.WriteLine("\n____¶¶¶¶_________11_____________________11________\n");
 Console.WriteLine("\n__1¶¶¶8_________________________________1_1__1____\n");
 Console.WriteLine("\n_8¶¶¶8__________________________________118888¶___\n");
 Console.WriteLine("\n_¶¶¶8___________________________________1188¶¶¶¶__\n");
 Console.WriteLine("\n¶¶¶¶811__________________________________18¶¶¶¶¶__\n");
 Console.WriteLine("\n¶¶¶¶811__________________________________18¶¶¶¶¶__\n");
 Console.WriteLine("\n¶¶¶8111_________________________________18¶¶¶¶¶¶¶_\n");
 Console.WriteLine("\n¶¶¶¶1111_______________________________11¶¶¶¶¶¶¶¶_\n");
 Console.WriteLine("\n¶¶¶88111________________________________8¶¶¶¶¶¶¶8_\n");
 Console.WriteLine("\n¶¶¶88111_______________________________1_8¶¶¶¶¶¶8¶\n");
 Console.WriteLine("\n¶¶¶88811_1____________________________11_8¶¶¶¶¶¶8¶\n");
 Console.WriteLine("\n¶¶¶818¶¶¶¶¶¶¶¶¶¶¶1111188¶¶¶¶¶¶¶¶¶8__111___¶¶¶¶¶¶18\n");
 Console.WriteLine("\n_1¶118¶¶¶¶¶¶¶¶¶¶¶¶¶88¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶81____8¶¶¶¶¶18\n");
 Console.WriteLine("\n_11111188181¶¶¶¶¶1¶81¶¶¶8811¶¶¶88¶¶11_____1¶1881__\n");
 Console.WriteLine("\n__811__11881188188¶1_¶¶81181___1__________181__¶__\n");
 Console.WriteLine("\n__1181____18881_1_81_1¶_1_8818811_______111¶¶8____\n");
 Console.WriteLine("\n____¶881_________¶1___8________________1111_______\n");
 Console.WriteLine("\n____8¶8811______¶1_____11__________11118111_______\n");
 Console.WriteLine("\n_____¶8881_____188____1__8______11111888111_______\n");
 Console.WriteLine("\n_____¶¶8811____1¶8______18_____11888888¶818_______\n");
 Console.WriteLine("\n_____8¶¶¶811____8¶¶¶¶¶¶¶¶1_____118¶¶888881________\n");
 Console.WriteLine("\n______¶¶¶¶811_111¶¶¶¶¶¶11_______8888888888________\n");
 Console.WriteLine("\n_______¶¶¶¶¶¶¶88111¶¶888888¶¶88888¶8¶¶8¶¶_¶¶______\n");
 Console.WriteLine("\n________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶8¶¶¶¶¶¶_¶¶¶¶____\n");
 Console.WriteLine("\n__1¶¶¶¶¶¶¶¶¶88¶¶¶818818¶¶¶¶888¶8¶¶8¶¶¶¶¶__¶¶¶¶¶¶8_\n");
 Console.WriteLine("\n¶¶¶¶¶¶¶¶¶8¶¶¶818¶¶¶88¶¶8811818¶¶¶¶¶¶¶¶¶___¶¶¶¶¶¶¶¶\n");
 Console.WriteLine("\n¶¶¶¶¶¶¶¶___¶¶¶81111111__11188¶¶¶¶¶¶¶¶_____¶¶¶¶¶¶¶¶\n");
 Console.WriteLine("\n¶¶¶¶¶¶¶_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶¶\n");
 Console.WriteLine("\n¶¶¶¶¶¶_______¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶8_______¶¶¶¶¶¶¶¶¶¶\n");



                Console.WriteLine(" УПРАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯМИ:");
                Console.WriteLine("1. Показать список всех пользователей");
                Console.WriteLine("2. Удалить пользователя по его Guid");
                Console.WriteLine("3. Обновить данные пользователя по Guid");
                Console.WriteLine("4. Найти пользователя по его Guid");
                Console.WriteLine();


                switch (Console.ReadLine())
                {
                    case "1": _userConsoleUI.DisplayAllUsers(); break;
                    case "2": _userConsoleUI.RemoveUserByGuid(Guid.Parse(Console.ReadLine())); break;
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
