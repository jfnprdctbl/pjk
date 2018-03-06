using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using ProjectKapwa.Models;


namespace ProjectKapwa.Controllers.API
{
    public class a_WorkAcceptanceController : ApiController
    {

        [HttpGet]
        public async Task<IHttpActionResult> ReadAll()
        {
            var rest = await RepositoryOperation<WorkAcceptance>.GetItemsAsync();
            return Ok(rest);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Read(string id, string category)
        {
            WorkAcceptance item = await RepositoryOperation<WorkAcceptance>.GetItemAsync(id, category);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Create(WorkAcceptance item)
        {
            if (ModelState.IsValid)
            {
                await RepositoryOperation<WorkAcceptance>.CreateItemAsync(item);
                return Ok();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(WorkAcceptance item)
        {
            if (ModelState.IsValid)
            {
                await RepositoryOperation<WorkAcceptance>.UpdateItemAsync(item.Id, item);
                return Ok("Index");
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id, string category)
        {
            await RepositoryOperation<WorkAcceptance>.DeleteItemAsync(id, category);
            return Ok();
        }


    }
}
