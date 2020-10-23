using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFProductLibrary;

namespace ProductWebAPIs.Controllers
{
    public class ProductController : ApiController
    {
        IProductOperations prodop = new EFProductOperations();                          
        //To call api/product
        public HttpResponseMessage GetAll()
        {
            var prods = prodop.GetAllProducts();

            return Request.CreateResponse<List<Product>>(HttpStatusCode.OK, prods);
        }
        //to call api/product/2
        public HttpResponseMessage GetByid(int id)
        {
            try
            {
                var prod = prodop.GetAllProductById(id);
                return Request.CreateResponse<Product>(HttpStatusCode.OK, prod);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        [HttpPost]
        public HttpResponseMessage PostProd(Product prod)
        {
            prodop.InsertProduct(prod);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage UpdateProd(int id, Product prod)
        {
            prodop.UpdateProduct(id,prod);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage DeleteProd(int id)
        {
            prodop.DeleteProduct(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
