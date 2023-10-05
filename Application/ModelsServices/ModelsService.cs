using Application.BaseServices;
using Application.Common;
using Application.ExceptionType;
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

        public async Task<ModelDto> GetAllModels(string modelyear,string make)
        {
            try
            {
                var makeEntity = await _makeService.GetMake(new MakeFilterDto() { Make_Name = make });
                if (makeEntity == null)
                {
                    throw new ValidationException("Make Name " + make + " does not exist");
                }
                Dictionary<string, string> conditions = new Dictionary<string, string>();
                conditions.Add("makeId", makeEntity.make_id.ToString());
                conditions.Add(nameof(modelyear), modelyear);
                
                var models = await _modelReadRepositoryApi.List(conditions);
                var result = _mapper.Map<ModelDto>(models);
                return result;
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
