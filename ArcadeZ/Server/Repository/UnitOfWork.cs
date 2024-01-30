using ArcadeZ.Server.Data;
using ArcadeZ.Server.IRepository;
using ArcadeZ.Server.Models;
using ArcadeZ.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArcadeZ.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<CustEnquiry> _custEnquiries;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<CustOrder> _custOrders;
        private IGenericRepository<CustOrderItem> _custOrderItems;
        private IGenericRepository<ProductHardware> _productHardwares;
        private IGenericRepository<ProductSoftware> _productSoftwares;
        private IGenericRepository<Enterprise> _enterprises;
        private IGenericRepository<TempCart> _tempCarts;


        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<CustEnquiry> CustEnquiries
            => _custEnquiries ??= new GenericRepository<CustEnquiry>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<CustOrder> CustOrders
            => _custOrders ??= new GenericRepository<CustOrder>(_context);
        public IGenericRepository<CustOrderItem> CustOrderItems
            => _custOrderItems ??= new GenericRepository<CustOrderItem>(_context);
        public IGenericRepository<ProductHardware> ProductHardwares
            => _productHardwares ??= new GenericRepository<ProductHardware>(_context);
        public IGenericRepository<ProductSoftware> ProductSoftwares
            => _productSoftwares ??= new GenericRepository<ProductSoftware>(_context);
        public IGenericRepository<Enterprise> Enterprises
            => _enterprises ??= new GenericRepository<Enterprise>(_context);
        public IGenericRepository<TempCart> TempCarts
            => _tempCarts ??= new GenericRepository<TempCart>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {

            await _context.SaveChangesAsync();
        }
    }
}