using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        //imzalar dto kullanmadığımız için repodakilerle aynı

        IQueryable<Order> Orders { get; }


        // Tek bir sipariş bilgisi
        Order? GetOneOrder(int id);

        void Complete(int id);

        void SaveOrder(Order order);


        int NumberOfInProcess { get; }


    }
}