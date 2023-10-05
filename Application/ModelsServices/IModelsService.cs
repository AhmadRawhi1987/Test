using DTOs.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelsServices
{
    public interface IModelsService
    {
        Task<List<ModelDto>> GetAllModels(string modelyear, string make);
    }
}
