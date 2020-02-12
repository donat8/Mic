using Mic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
