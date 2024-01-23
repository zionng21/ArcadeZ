using ArcadeZ.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadeZ.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<CustEnquiry> CustEnquiries { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<CustOrder> CustOrders { get; }
        IGenericRepository<CustOrderItem> CustOrderItems { get; }
        IGenericRepository<ProductHardware> ProductHardwares { get; }
        IGenericRepository<ProductSoftware> ProductSoftwares { get; }
        IGenericRepository<Enterprise> Enterprises { get; }
    }
}