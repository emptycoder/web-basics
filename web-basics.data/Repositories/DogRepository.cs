using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace web_basics.data.Repositories
{
	public class DogRepository
	{
        private readonly WebBasicsDBContext _context;

        public DogRepository(IConfiguration configuration)
        {
            _context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Dog> Get() =>
            _context.Dogs.ToList();

        public int? Add(Entities.Dog dog)
		{
            _ = dog ?? throw new ArgumentNullException($"{nameof(dog)} can't be null.");

            _context.Dogs.Add(dog);
            return _context.SaveChanges() > 0 ? (int?)dog.Id : null;
        }
    }
}
