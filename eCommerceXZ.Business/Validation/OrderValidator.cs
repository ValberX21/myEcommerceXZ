

using Azure;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Data.Repository;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;

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

        public Task<ResponseDto> updateCustomer(Order order)
        {
            throw new NotImplementedException();
        }

        public string ValidateOrder(Order customer)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> deleteOrder(int OrderId)
        {
            throw new NotImplementedException();
        }
              
    }
}
