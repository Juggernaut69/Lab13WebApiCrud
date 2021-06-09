using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPIService.Repository;
using WebAPIService.Services;

namespace WebAPIService.Controllers
{
    public class ShowroomController : ApiController
    {
        private ProductService service = new ProductService();

        [HttpGet]
        public JsonResult<List<Models.Product>> GetAllProducts()
        {
            return service.GetAllProductsService();
        }

        [HttpPost]
        public bool Post(Models.Product product)
        {
            return service.InsertProductService(product);
        }

        [HttpPut]
        public bool Update(Models.Product product)
        {
            return service.UpdateProductService(product);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return service.DeleteProductService(id);
        }
    }
}
