using System;
using System.Threading.Tasks;

namespace Weinstore
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
