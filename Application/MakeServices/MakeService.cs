using Application.BaseServices;
using Application.Common;
using Application.Repository;
using Domain.Makes;
using DTOs.MakeDtos;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MakeServices
{
    public class MakeService : BaseService, IMakeService
    {
        private readonly IReadRepositoryCSV<Make> _makeReadRepositoryCSV;

        public MakeService(IReadRepositoryCSV<Make> makeReadRepositoryCSV, IMapper mapper) : base(mapper)
        {
            _makeReadRepositoryCSV = makeReadRepositoryCSV;
        }

        public async Task<MakeDto> GetMake(MakeFilterDto makeFilterDto)
        {
            try
            {
                var make = await _makeReadRepositoryCSV.FirstOrDefault("CarMake.csv", x=>(string.IsNullOrEmpty(makeFilterDto.Make_Name) || x.make_name.ToLower().Trim() == makeFilterDto.Make_Name.ToLower().Trim()));
                var result = _mapper.Map<MakeDto>(make);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
