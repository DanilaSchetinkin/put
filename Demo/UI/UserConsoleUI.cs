using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class UserConsoleUI
    {
        UserUseCase _userUseCase;
        public UserConsoleUI(UserUseCase userUseCase) {
            _userUseCase = userUseCase;
        }

        public void RemoveUserByGuid(Guid guidUser) {

            string output = _userUseCase.RemoveUserByGuid(guidUser) ? "Пользователь удален" : "Пользователь не удален";
            Console.WriteLine(output);
        }

        public void DisplayAllUsers()
        {
            StringBuilder userOutput = new StringBuilder();
            foreach (var user in _userUseCase.GetAllUsers())
            {
                userOutput.AppendLine($"{user.Guid}\t{user.FIO}\t{user.Group.Name}");
            }
            Console.WriteLine(userOutput);
        }

        //public void UpdateByGuid(Guid guidUser)
        //{
        //    string update = _userUseCase.UpdateUser(guidUser);
        //}
    }
}
