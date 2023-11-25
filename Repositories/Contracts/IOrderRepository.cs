using Entities.Models;

namespace Repositories.Contracts
{
    public interface IOrderRepository
    {


        IQueryable<Order> Orders { get; }


        // Tek bir sipariş bilgisi
        Order? GetOneOrder(int id);

        void Complete(int id);



        void SaveOrder(Order order);


        int NumberOfInProcess { get; }



    }
}