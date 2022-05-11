using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Task1;
using Microsoft.EntityFrameworkCore;

namespace Homework12_5._7
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController:ControllerBase
    {
        private readonly OrderServiceContext orderDB;

        public List<Order> OrderList { get; set; } = new List<Order>();       //订单服务类里的订单列表,测试时为public属性
        public List<Customer> CustomerList { get; set; } = new List<Customer>();
        public List<Cargo> CargoList { get; set; } = new List<Cargo>();

        public OrderController(OrderServiceContext context)
        {
            orderDB = context;
        }

        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)                       //添加订单，参数为Order类型对象
        {
            try
            {
                orderDB.Orders.Add(order);
                orderDB.SaveChanges();
            }catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return Accepted();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)                         //删除id号订单
        {
            try
            {
                var item = orderDB.Orders.FirstOrDefault(i => i.ID == id);  
                if(item != null)
                {
                    orderDB.RemoveRange(item.Details);
                    orderDB.Remove(item);
                    orderDB.SaveChanges();
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(int id, Order order)//修改订单
        {
            if (id != order.ID)
                return BadRequest("ID connot be modified!");
            try
            {
                orderDB.Entry(order).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Order>> QueryOrder(int id)                               //按照id查询订单
        {
            var result =  orderDB.Orders.Include("Details").Include("OrderCustomer").Include("Details.OrderCargo").Where(i => i.ID == id).ToList();
            if (result == null)
                return NotFound();
            return result.ToList();
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            try
            {
                var result = orderDB.Customers.Add(customer);
                orderDB.SaveChanges();
                return result.Entity;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                var item = orderDB.Customers.FirstOrDefault(i => i.ID == id);
                if (item != null)
                {
                    orderDB.Remove(item);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }

 
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.ID)
                return BadRequest("ID connot be modified!");
            try
            {
                orderDB.Entry(customer).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> QueryCustomer(int id)
        {
            var result = orderDB.Customers.FirstOrDefault(i => i.ID == id);
            if (result == null)
                return NotFound();
            return result;
        }
        [HttpPost]
        public ActionResult<Cargo> AddCargo(Cargo cargo)
        {
            try
            {
                var result = orderDB.Cargos.Add(cargo);
                orderDB.SaveChanges();
                return result.Entity;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCargo(int id)
        {
            try
            {
                var item = orderDB.Cargos.FirstOrDefault(i => i.ID == id);
                if (item != null)
                {
                    orderDB.Remove(item);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCargo(int id, Cargo cargo)
        {
            if (id != cargo.ID)
                return BadRequest("ID connot be modified!");
            try
            {
                orderDB.Entry(cargo).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<Cargo> QueryCargo(int id)
        {
            var result = orderDB.Cargos.FirstOrDefault(i => i.ID == id);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public ActionResult<OrderDetails> AddOrderDetail(OrderDetails orderDetails)
        {
            try
            {
                var result = orderDB.OrderDetails.Add(orderDetails);
                orderDB.SaveChanges();
                return result.Entity;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOrderDetail(int id)
        {
            try
            {
                var item = orderDB.OrderDetails.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    orderDB.Remove(item);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<OrderDetails> UpdateOrderdetailes(int id, OrderDetails orderDetails)
        {
            if (id != orderDetails.Id)
                return BadRequest("ID connot be modified!");
            try
            {
                orderDB.Entry(orderDetails).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDetails> QueryOoderDetails(int id)
        {
            var result = orderDB.OrderDetails.Include("Cargo").FirstOrDefault(i => i.Id == id);
            if (result == null)
                return NotFound();
            return result;
        }
    }
}
