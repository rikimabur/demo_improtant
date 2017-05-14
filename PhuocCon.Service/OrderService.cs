using System;
using System.Collections.Generic;
using PhuocCon.Data.infrastructure;
using PhuocCon.Data.Repositories;
using PhuocCon.Model.Models;

namespace PhuocCon.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAll(string keyword);
        IEnumerable<Order> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        Order GetById(int id);
        Order Delete(int id);
        Order GetByUser(string name);
        Order Create(ref Order order, List<OrderDetail> orderDetails);
        void UpdateStatus(int id);
        void Save();
    }
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepositoty;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitofwork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepositoty = orderDetailRepository;
            this._unitOfWork = unitofwork;
        }

        public Order Create(ref Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailRepositoty.Add(orderDetail);
                }
                return order;
            }
            catch (Exception excep)
            {
                throw;
            }
        }

        public void UpdateStatus(int id)
        {
            var order = _orderRepository.GetSingleById(id);
            order.Status = true;
            _orderRepository.Update(order);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _orderRepository.GetMulti(x => x.CustomerID == keyword || x.CustomerName == keyword);
            }
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public Order GetByUser(string name)
        {
            throw new NotImplementedException();
        }
    }
}
