using Application.Models;
using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    }
}
