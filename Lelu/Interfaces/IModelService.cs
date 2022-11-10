using Lelu.Entities;
using Lelu.Helpers.Dtos;

namespace Lelu.Interfaces
{
    public interface IModelService
    {
        List<Model> GetModels();
        Model GetModel(int id);
        List<Model> SearchModels(string? name);

        string GetHyperlink(int id);

        Model CreateModel(NewModelDto dto);

        bool DeleteModel(int id);

        Model UpdateModel(UpdateModelDto dto);
    }
}

