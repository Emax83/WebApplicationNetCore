using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Interfaces
{
    public interface IOrderRepository
    {

        void CreateOrder(Order order);
    }
}
