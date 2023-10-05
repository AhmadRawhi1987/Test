using Application.BaseServices;
using Application.MakeServices;
using Application.Repository;
using Domain.Makes;
using Domain.Models;
using DTOs.MakeDtos;
using DTOs.ModelsDtos;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelsServices
{
    public class ModelsService : BaseService, IModelsService
    {
        private readonly IReadRepositoryApi<Model> _modelReadRepositoryApi;
        private readonly IMakeService _makeService;

        public ModelsService(IReadRepositoryApi<Model> modelReadRepositoryApi, IMakeService makeService,IMapper mapper) : base(mapper)
        {
            _modelReadRepositoryApi = modelReadRepositoryApi;
            _makeService = makeService;
        }

        public async Task<List<ModelDto>> GetAllModels(string modelyear,string make)
        {
            var makeEntity = await _makeService.GetMake(new MakeFilterDto() { Make_Name = make });
            Dictionary<string, string> conditions = new Dictionary<string, string>();
            var models = await _modelReadRepositoryApi.ListAsync(conditions);
            var result = _mapper.Map<List<ModelDto>>(models);
            return result;
        }
    }
}
