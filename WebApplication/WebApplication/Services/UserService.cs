using Application.Models;
using Application.Models.DTO;
using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Services
{
    public class UserService
    {
        private readonly DbSet<User> DBSet;
        private readonly IUnitOfWork UnitOfWork;
        private readonly AuthenticationService AuthenticationService;

        public UserService(IUnitOfWork unitOfWork, AuthenticationService authenticationService) =>
            (UnitOfWork, DBSet, AuthenticationService) = (unitOfWork, unitOfWork.Repository<User>().DBSet, authenticationService);

        public async Task<User?> GetByExpression(Expression<Func<User, bool>> expression) =>
            await DBSet.FirstOrDefaultAsync(expression);

        public async Task<User> RefreshLastSignin(string? email)
        {
            var userToUpdate = await DBSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Email.Equals(email));

            if (userToUpdate != null)
            {
                userToUpdate.LastSignin = DateTime.Now;

                DBSet.Update(userToUpdate);

                await UnitOfWork.CompletedAsync();

                return userToUpdate;
            }

            throw new ArgumentException("Entity Not Found");
        }

        public async Task<User> Authenticate(AuthenticationDTO authentication)
        {
            if (AuthenticationService.IsAuthenticated(authentication))
            {
                await AuthenticationService.SignIn(
                    await this.GetByExpression(user => user.Email.Equals(authentication.Email)) ?? 
                );
            }

            throw new ArgumentException("");
        }
    }
}
