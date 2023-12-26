using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Test
{
    public class testService : IDynamicApiController
    {
        [HttpGet]
        public string Testaaa()
        {
            return $"Hello {nameof(Furion)}";
        }

    }
}
