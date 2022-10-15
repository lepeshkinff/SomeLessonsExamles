using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Renderino.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      [HttpGet("[action]")]
      public async Task<IEnumerable<string>> GetNames(int count = 100)
      {
         if(count <= 0 || count >= int.MaxValue)
         {
            count = 100;
         }
         var rnd = new Random();

         return Enumerable.Range(0, count).Select(_ => rnd.Next().ToString());

		}
    }
}
