using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository
    {
        /// <summary>
        /// Returns a list with all orders from the database
        /// </summary>
        /// <returns></returns>
        static public List<Orders> GetAllOrders()
        {
            List<Orders> orders = new List<Orders>();

            using (NorthwindContext context = new NorthwindContext())
            {
                orders = context.Orders.Include(s => s.OrderDetails).Include(s => s.Customer).Include(s => s.Employee).Include(s => s.ShipViaNavigation).ToList();
            }

            return orders;
        }

        /// <summary>
        /// Returns the order details of a specific order
        /// </summary>
        /// <param name="order">Order to get order details from</param>
        /// <returns></returns>
        static public List<OrderDetails> GetOrderDetails(Orders order)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            using (NorthwindContext context = new NorthwindContext())
            {
                orderDetails = context.OrderDetails.Where(s => s.OrderId == order.OrderId).Include(s => s.Product).ToList();
            }

            return orderDetails;
        }

        /// <summary>
        /// Gets the product of a specific order detail
        /// </summary>
        /// <param name="orderDetails">order detail to get product from</param>
        /// <returns></returns>
        static public Products GetProduct(OrderDetails orderDetails)
        {
            Products product = new Products();

            using(NorthwindContext context = new NorthwindContext())
            {
                product = context.Products.Where(s => s.ProductId == orderDetails.ProductId).FirstOrDefault();
            }

            return product;
        }

        /// <summary>
        /// Returns a list with all products from the database
        /// </summary>
        /// <returns></returns>
        static public List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();
            using(NorthwindContext context = new NorthwindContext())
            {
                products = context.Products.ToList();
            }

            return products;
        }

        /// <summary>
        /// Returns a list with all customers from the database
        /// </summary>
        /// <returns></returns>
        static public List<Customers> GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            using(NorthwindContext context = new NorthwindContext())
            {
                customers = context.Customers.ToList();
            }

            return customers;
        }

        /// <summary>
        /// Returns a list with all employees from the database
        /// </summary>
        /// <returns></returns>
        static public List<Employees> GetAllEmployees()
        {
            List<Employees> employees = new List<Employees>();
            using (NorthwindContext context = new NorthwindContext())
            {
                employees = context.Employees.ToList();
            }

            return employees;
        }

        /// <summary>
        /// Returns a list of all shippers from the database
        /// </summary>
        /// <returns></returns>
        static public List<Shippers> GetAllShippers()
        {
            List<Shippers> shippers = new List<Shippers>();
            using (NorthwindContext context = new NorthwindContext())
            {
                shippers = context.Shippers.ToList();
            }

            return shippers;
        }

        /*public void AddOrderDetail(Products product, Orders order)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                context.Add()
            }
        }*/


        /// <summary>
        /// Adds an object of any type to the database
        /// </summary>
        /// <param name="objectToAdd">Object to add to the database</param>
        static public void AddToDatabase(Object objectToAdd)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Add(objectToAdd);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an object of any type in the database
        /// </summary>
        /// <param name="objectToUpdate">Object to update</param>
        static public void UpdateDatabase(Object objectToUpdate)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Entry(objectToUpdate).State = EntityState.Modified;
                context.Update(objectToUpdate);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes an object of any type from the database
        /// </summary>
        /// <param name="objectToRemove">object to remove</param>
        static public void RemoveFromDatabase(Object objectToRemove)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Remove(objectToRemove);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// returns a specific order specified by order ID
        /// </summary>
        /// <param name="id">order ID to get order from</param>
        /// <returns></returns>
        static public Orders GetOrder(int id)
        {
            Orders order;
            using (NorthwindContext context = new NorthwindContext())
            {
                order = context.Orders.Where(s => s.OrderId == id).Include(s => s.OrderDetails).Include(s => s.Customer).Include(s => s.Employee).Include(s => s.ShipViaNavigation).First();
            }
            return order;
        }

        static public Orders GetFirstOrder()
        {
            Orders order;
            using (NorthwindContext context = new NorthwindContext())
            {
                order = context.Orders.First();
            }
            return order;
        }
    }
}
