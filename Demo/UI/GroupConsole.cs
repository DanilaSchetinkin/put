using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI;

public class GroupConsole
{
    private readonly GroupUseCase _groupUseCase;

    public GroupConsole(GroupUseCase groupUseCase)
    {
        _groupUseCase = groupUseCase;
    }
}
