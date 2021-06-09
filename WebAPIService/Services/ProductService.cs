﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPIService.Repository;
using DataAccessLayer;

namespace WebAPIService.Services
{
    public class ProductService : ApiController
    {

        public JsonResult<List<Models.Product>> GetAllProductsService()
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = 
                new EntityMapper<DataAccessLayer.Product, Models.Product>();
            List<DataAccessLayer.Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in prodList)
            {
                products.Add(mapObj.Translate(item));
            }
            return Json<List<Models.Product>>(products);
        }
        public bool InsertProductService(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();
                DataAccessLayer.Product productObj = new DataAccessLayer.Product();
                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);
            }
            return status;
        }

        public bool UpdateProductService(Models.Product product)
        {
            EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();
            DataAccessLayer.Product productObj = new DataAccessLayer.Product();
            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            return status;
        }
        public bool DeleteProductService(int id)
        {
            var status = DAL.DeleteProduct(id);
            return status;
        }

    }
}