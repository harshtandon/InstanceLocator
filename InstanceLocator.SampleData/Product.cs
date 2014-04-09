using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.SampleData
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool NiceProduct { get; set; }
        public DateTime IntroducedDate { get; set; }
        public ProductType ProductType { get; set; }
        private int _Margin { get; set; }


        public Product(int Margin)
        {
            this._Margin = Margin;
        }
    }

    public enum ProductType
    {
        FOOD = 1,
        CLEANING,
        FROZEN
    }

    public class Sale
    {
        public Product ProductSold { get; set; }
    }

    public class Checkout
    {
        public Sale[] Sale { get; set; }
    }
}