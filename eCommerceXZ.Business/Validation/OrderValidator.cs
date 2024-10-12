

using Azure;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Data.Repository;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using eCommerceXZ.Payment;
using System.Collections.Generic;

namespace eCommerceXZ.Business.Validation
{
    public class OrderValidator : IOrderValidator
    {
        private readonly OrderRepository _orderRepository;
        private readonly MainPayment _mainPayment;
        protected ResponseDto _response;

        public OrderValidator(OrderRepository orderRepository, ResponseDto response, MainPayment mainPayment)
        {
            _orderRepository = orderRepository;
            _mainPayment = mainPayment;
            _response = response;
        }

        public async Task<ResponseDto> addOrder(Order order)
        {
            string returnValid = await ValidateOrder(order);

            if (returnValid == "")
            {
                try
                {

                    order.Status = "Waiting payment";

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

            bool containsString = confirmaProducts.Any(value => value.ContainsValue("Have no in stock"));

            if (!containsString)
            {
                return "";
            }
            else
            {
                return "Have no itens in stock";
            }

            //return containsString : "" ? ""


            //if (!containsString)
            //{
            //    return string.Empty;             
            //}            
        }

        public void paymentValidation(Customer customer,Order order)
        {
            //Validation Customer role
            if ((customer.CustomerRole == "Silver") || ((customer.CustomerRole == "Gold")))
            {
                //Send to Stack
                //Send to payment method and wait return
                _mainPayment.MainPaymentMethod(customer,order);
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
