using Application.Models;
using Application.Repositories;
using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Application.Services
{
    public class UserService
    {

        private readonly DbSet<User> DBSet;
        private readonly IUnitOfWork UnitOfWork;

        public UserService(IUnitOfWork unitOfWork) =>
            (UnitOfWork, DBSet) = (unitOfWork, unitOfWork.Repository<User>().DBSet);

        public User? GetByExpression(Expression<Func<User, bool>> expression) =>
            DBSet.Where(expression).FirstOrDefault();

        public async Task<User> RefreshLastSignin(User user)
        {
            var userToUpdate = await DBSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == user.Id);

            if (userToUpdate != null)
            {
                userToUpdate.LastSignin = DateTime.Now;

                DBSet.Update(userToUpdate);

                await UnitOfWork.CompletedAsync();

                return userToUpdate;
            }

            throw new ArgumentException("Entity Not Found");
        }

    }
}
