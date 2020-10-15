using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using web_basics.business.ViewModels;
using web_basics.data.Entities;

namespace web_basics.business.Domains
{
	public class DogDomain
	{
        private readonly data.Repositories.DogRepository _repository;
        private readonly IMapper _mapper;

        public DogDomain(IConfiguration configuration)
        {
            _repository = new data.Repositories.DogRepository(configuration);
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Dog, DogView>();
                cfg.CreateMap<DogView, Dog>();
            }).CreateMapper();
        }

        public IEnumerable<DogView> Get()
        {
            var dogs = _repository.Get();
            return dogs.Select(dog => _mapper.Map<Dog, DogView>(dog));
        }

        public int? Add(DogView dogView)
		{
            Dog dog = _mapper.Map<DogView, Dog>(dogView);

            return _repository.Add(dog);
        }
    }
}
