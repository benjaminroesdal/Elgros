﻿using ElgrosWeb.Server.Data.Db;
using ElgrosWeb.Server.Repositories.Interfaces;
using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;
using ElgrosWeb.Shared.Tools;
using Microsoft.EntityFrameworkCore;

namespace ElgrosWeb.Server.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ElgrosContext _context;
        public OrderRepository(ElgrosContext ctx)
        {
            _context = ctx;
        }

        public async Task<OrderModel> CreateAsync(OrderModel orderModel)
        {
            var dao = orderModel.CreateDao();
            var daoProducts = await _context.Product.Include(x => x.SubCategoryList).Where(p => dao.Products.Contains(p)).ToListAsync();
            dao.Products = daoProducts;
            var result = await _context.Order.AddAsync(dao);
            _context.SaveChanges();
            return dao.CreateModel();
        }

        public async Task<OrderModel> GetAsync(int id)
        {
            var order = await _context.Order
                .Include(e => e.Products)
                .ThenInclude(e => e.SubCategoryList)
                .Include(e => e.User)
                .Include(e => e.PaymentDetails)
                .FirstOrDefaultAsync(e => e.Id == id);
            return order.CreateModel();
        }
    }
}
