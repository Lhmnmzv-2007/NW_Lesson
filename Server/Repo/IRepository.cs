using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Repo
{
    internal interface IRepository
    {
        Car? GetById(int id);
        List<Car>? GetAll();
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(int id);
    }
}
