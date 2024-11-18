
using Demo.Data.RemoteData.RemoteDataBase;
using Demo.Data.Repository;
using Demo.Domain.UseCase;
using Demo.UI;
using Microsoft.Extensions.DependencyInjection;



//MainMenuUI mainMenuUI = new MainMenuUI(userUseCase, groupUseCase);

IServiceCollection services = new ServiceCollection();

services.AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IGroupRepository, SQLGroupRepositoryImpl>()
    .AddSingleton<IUserRepository, SQLUserRepositoryImpl>()
    .AddSingleton<IPresenceRepository, SQLPresenceRepositoryImpl>()
    .AddSingleton<UserUseCase>()
    .AddSingleton<GroupUseCase>()
    .AddSingleton<UseCaseGeneratePresence>()
    .AddSingleton<GroupConsole>()
    .AddSingleton<PresenceConsole>()
    .AddSingleton<UserConsoleUI>()
    .AddSingleton<MainMenuUI>();

var servicePorvider  = services.BuildServiceProvider();

var menu = servicePorvider.GetService<MainMenuUI>();

menu.DisplayMenu();