using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using ProjectKapwa.Models;

namespace ProjectKapwa.Controllers
{
    public class a_xformController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> ReadAll()
        {
            var rest = await RepositoryOperation<xforms>.GetItemsAsync();
            return Ok(rest);
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> Read(string id, string category)
        {
            xforms item = await RepositoryOperation<xforms>.GetItemAsync(id, category);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Create(xforms item)
        {
            if (ModelState.IsValid)
            {
                await RepositoryOperation<xforms>.CreateItemAsync(item);
                return Ok();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(xforms item)
        {
            if (ModelState.IsValid)
            {
                await RepositoryOperation<xforms>.UpdateItemAsync(item.Id, item);
                return Ok("Index");
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id, string category)
        {
            await RepositoryOperation<xforms>.DeleteItemAsync(id, category);
            return Ok();
        }
    }
}
