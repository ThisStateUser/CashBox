﻿using Cashbox.Core;
using Cashbox.MVVM.Models;

namespace Cashbox.MVVM.ViewModels.Data
{
    public class OrderProductViewModel(OrderProduct orderProduct) : ViewModelBase
    {
        private readonly OrderProduct _orderProduct = orderProduct;

        public static List<OrderProduct> OrderProducts => OrderProduct.OrderProducts;
        public static void AddListOrderInDataBase(List<OrderProductViewModel> orderProducts) => OrderProduct.AddListOrderInDataBase(orderProducts);
        public static async Task<List<OrderProductViewModel>> GetInOrderProduct(int OrderId) => await OrderProduct.GetInOrderProduct(OrderId);
        public static async Task<List<OrderProductViewModel>> GetOrderProduct(DateTime StartDate, DateTime EndDate) => await OrderProduct.GetOrderProduct(StartDate, EndDate);

        public int Id => _orderProduct.Id;

        public int OrderId
        {
            get => _orderProduct.OrderId;
            set
            {
                _orderProduct.OrderId = value;
                OnPropertyChanged();
            }
        }
        public int ProductId
        {
            get => _orderProduct.ProductId;
            set
            {
                _orderProduct.ProductId = value;
                OnPropertyChanged();
            }
        }
        public int Amount
        {
            get => _orderProduct.Amount;
            set
            {
                _orderProduct.Amount = value;
                OnPropertyChanged();
            }
        }

        public double SellCost
        {
            get => _orderProduct.SellCost;
            set
            {
                if (value < 0)
                    value *= -1;
                _orderProduct.SellCost = value;
                OnPropertyChanged();
            }
        }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product
        {
            get => _orderProduct.Product;
            set
            {
                _orderProduct.Product = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel ProductVM { get; set; } = null!;

    }
}
