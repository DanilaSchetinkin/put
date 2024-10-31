
using Demo.Data.RemoteData.RemoteDataBase;
using Demo.Data.Repository;
using Demo.Domain.UseCase;
using Demo.UI;
using Microsoft.Extensions.DependencyInjection;

GroupRepositoryImpl groupRepositoryImpl = new GroupRepositoryImpl();
UserRepositoryImpl userRepositoryImpl = new UserRepositoryImpl();
UserUseCase userUseCase = new UserUseCase(userRepositoryImpl, groupRepositoryImpl);
GroupUseCase groupUseCase = new GroupUseCase(groupRepositoryImpl);

MainMenuUI mainMenuUI = new MainMenuUI(userUseCase, groupUseCase);

IServiceCollection services = new ServiceCollection();

services.AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IGroupRepository, SQLGroupRepositoryImpl>();