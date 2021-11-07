using System.Threading.Tasks;
using web_lab2.Models;

namespace web_lab2.Abstractions
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IOrderRepository Orders { get; }
        ISageRepository Sages { get; }

        IUserRepository Users { get; }

        IRoleRepository Roles { get; }
        Task<int> SaveAsync();
    }
}