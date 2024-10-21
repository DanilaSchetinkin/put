
using Demo.Data.Repository;
using Demo.Domain.UseCase;
using Demo.UI;

GroupRepositoryImpl groupRepositoryImpl = new GroupRepositoryImpl();
UserRepositoryImpl userRepositoryImpl = new UserRepositoryImpl();
UserUseCase userUseCase = new UserUseCase(userRepositoryImpl, groupRepositoryImpl);
GroupUseCase groupUseCase = new GroupUseCase(groupRepositoryImpl);

MainMenuUI mainMenuUI = new MainMenuUI(userUseCase, groupUseCase);