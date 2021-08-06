using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Services
{
    public interface ILogins<T>
    {
        IEnumerable<T> GetAll();
        void Add(T t);
        int UserLogin(T t);
    }
}
