﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo)
        {
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData product = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate();

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                //get the info about this product
                var productInfo = product.GetProductById(detail.ProductId);
                if (productInfo == null)
                {
                    throw new Exception($"the product{detail.ProductId} could not be found");
                }
                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);
                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }
                details.Add(detail);
            }
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax), 

            };
            sale.Total = sale.SubTotal + sale.Tax;
        }
        //public List<ProductModel> GetProducts()
        //{
        //    SqlDataAccess sql = new SqlDataAccess();
        //    var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "EFData");
        //    return output;
        //}
    }
}