﻿using Cashbox.Core;
using Cashbox.MVVM.Models;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Cashbox.MVVM.ViewModels.Data
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly Product _product;
        public ProductViewModel(Product product)
        {
            _product = product;
            Task.Run(LoadImage);
        }

        public static async Task<List<ProductViewModel>> GetProducts() => await Product.GetProducts();
        public static async Task<List<ProductViewModel>> GetAllProducts() => await Product.GetAllProducts();
        public static async Task<ProductViewModel?> CreateProduct(ProductViewModel? productVM, int Amount) => await Product.CreateProducts(productVM, Amount);
        public static async Task<ProductViewModel?> UpdateProduct(ProductViewModel? productVM, int Amount) => await Product.UpdateProducts(productVM, Amount);
        public static async Task<ProductViewModel?> RemoveProduct(int id) => await Product.AvailableProducts(id, false);
        public static async Task<ProductViewModel?> UnRemoveProduct(int id) => await Product.AvailableProducts(id, true);

        public int Id => _product.Id;

        public string? ArticulCode
        {
            get => _product.ArticulCode;
            set
            {
                _product.ArticulCode = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _product.Title;
            set
            {
                _product.Title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _product.Description;
            set
            {
                _product.Description = value;
                OnPropertyChanged();
            }
        }

        public string? Image
        {
            get => _product.Image;
            set
            {
                _product.Image = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage? _imageStr;
        public BitmapImage? ImageStr
        {
            get => _imageStr;
            set
            {
                _imageStr = value;
                OnPropertyChanged();
            }
        }

        private void LoadImage()
        {
            if (string.IsNullOrEmpty(_product.Image))
                return;
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _product.Image);
            if (!File.Exists(path))
                return;
            var uri = new Uri(path);
            Application.Current.Dispatcher.Invoke(() => ImageStr = new BitmapImage(uri));
        }

        public string Brand
        {
            get => _product.Brand;
            set
            {
                _product.Brand = value;
                OnPropertyChanged();
            }
        }

        public int CategoryId
        {
            get => _product.CategoryId;
            set
            {
                _product.CategoryId = value;
                OnPropertyChanged();
            }
        }

        public double PurchaseСost
        {
            get => _product.PurchaseСost;
            set
            {
                _product.PurchaseСost = value;
                OnPropertyChanged();
            }
        }

        public double SellCost
        {
            get => _product.SellCost;
            set
            {
                _product.SellCost = value;
                OnPropertyChanged();
            }
        }
        public bool IsAvailable
        {
            get => _product.IsAvailable;
            set
            {
                _product.IsAvailable = value;
                OnPropertyChanged();
            }
        }

        public ProductCategoryViewModel CategoryVM
        {
            get => new(_product.Category);
            set
            {
                _product.CategoryId = value.Id;
                OnPropertyChanged();
            }
        }

        public virtual ProductCategory Category
        {
            get => _product.Category;
            set
            {
                _product.Category = value;
                OnPropertyChanged();
            }
        }

        public virtual Stock? Stock
        {
            get => _product.Stock;
            set
            {
                _product.Stock = value;
                OnPropertyChanged();
            }
        }

    }
}
