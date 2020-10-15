using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
    public class CatDomain
    {
        data.Repositories.CatRepository repository;
        IMapper mapper;

        public CatDomain(IConfiguration configuration)
        {
            this.repository = new data.Repositories.CatRepository(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Cat, ViewModels.CatView>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.CatView> Get()
        {
            var cats = repository.Get();
            return cats.Select(cat => mapper.Map<data.Entities.Cat, ViewModels.CatView>(cat));
        }
    }
}
