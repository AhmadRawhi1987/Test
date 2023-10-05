using Domain.Models;
using DTOs.ModelsDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<List<Model>, ModelDto>()
                .Map(des => des.Models, src => (src.Select(x=>x.Model_Name)));
        }
    }
}
