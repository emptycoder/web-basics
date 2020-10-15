using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data.Repositories
{
    public class CatRepository
    {
        WebBasicsDBContext context;

        public CatRepository(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Cat> Get()
        {
            var cats = context.Cats.ToList();
            return cats;
        }
    }
}
