

using Azure;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Data.Repository;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using System.Collections.Generic;

namespace eCommerceXZ.Business.Validation
{
    public class OrderValidator : IOrderValidator
    {
        private readonly OrderRepository _orderRepository;
        protected ResponseDto _response;

        public OrderValidator(OrderRepository orderRepository, ResponseDto response)
        {
            _orderRepository = orderRepository;
            _response = response;
        }

        public async Task<ResponseDto> addOrder(Order order)
        {
            if (ValidateOrder(order) == "")
            {
                try
                {
                    bool addCustomer = await _orderRepository.CreateOrder(order);

                    if (addCustomer)
                    {
                        _response.IsSuccess = true;
                        _response.Result = "Order added success";
                    }
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Result = ex.Message;
                }
            }
            else
            {
                _response.IsSuccess = false;
                _response.Result = ValidateOrder(order);
            }

            return _response;
        }

        public async Task<IEnumerable<Order>> listAllOrders()
        {
            try
            {
                return await _orderRepository.GetOrders();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Order> searchOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> updateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ValidateOrder(Order order)
        {
            //Check if all products exist in the database with the correct quantity
            List<Dictionary<int, string>> confirmaProducts = new List<Dictionary<int, string>>();

            confirmaProducts = await _orderRepository.CheckProducts(order.OrderItems);

            Customer checkUser = await _orderRepository.checkCustomer(order.CustomerId);

            //Check if the customer exists in the database
            if (checkUser != null)
            {
                paymentValidation(checkUser);
            }
            else
            {
                throw new Exception("User not found");
            }                                           

            //Validation Customer role

            //Send to shipping method and wait return

            throw new NotImplementedException();
        }

        public void paymentValidation(Customer customer)
        {
            //Validation Customer role
            if ((customer.CustomerRole == "Silver") || ((customer.CustomerRole == "Gold")))
            {
                //Send to Stack
                //Send to payment method and wait return

                //Check if the payment was successful
            }
            else
            {
                //Send to queue
                //Send to payment method and wait return

                //Check if the payment was successful
            }
        }

        public Task<ResponseDto> deleteOrder(int OrderId)
        {
            throw new NotImplementedException();
        }              
    }
}
