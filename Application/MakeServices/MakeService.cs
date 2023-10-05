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
                Dictionary<string, string> conditions = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(makeFilterDto.Make_Name))
                    conditions.Add(MemberInfoGetting.GetMemberName(() => makeFilterDto.Make_Name) , makeFilterDto.Make_Name);
                
                var make = await _makeReadRepositoryCSV.FirstOrDefaultAsync(conditions);
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
