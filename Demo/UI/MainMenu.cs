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

        private void DisplayMenu()
        {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1": _userConsoleUI.DisplayAllUsers(); break;
                    case "2": _userConsoleUI.RemoveUserByGuid(Guid.Parse(Console.ReadLine())); break;

                    default:
                        DisplayMenu();
                        break;
                }

            }
        }

    }
}
