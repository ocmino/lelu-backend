using Lelu.Entities;
using Lelu.Helpers;
using Lelu.Helpers.Dtos;
using Lelu.Interfaces;
#pragma warning disable CS8600 
#pragma warning disable CS8603 

namespace Lemmikki.Services
{
    public class ModelService : IModelService
    {
        private DataContext _context;

        public ModelService(DataContext context)
        {
            _context = context;
        }

        public List<Model> GetModels()
        {
            List<Model> models = _context.Models.ToList();
            return models;
        }

        public Model GetModel(int id)
        {
            Model m = _context.Models.Where(x => x.ID == id).FirstOrDefault();
            return m;
        }

        public List<Model> SearchModels(string? name)
        {
            List<Model> models = _context.Models.ToList();

            if (!string.IsNullOrEmpty(name))
                models = models.Where(x => x.ModelName.ToLower().Contains(name.ToLower())).ToList();

            return models;
        }

        public string GetHyperlink(int id)
        {
            string hp = _context.Models.Where(x => x.ID == id).Select(x => x.HyperLink).FirstOrDefault();
            return hp;
        }

        public Model CreateModel(NewModelDto dto)
        {
            Model m = new Model
            {
                ModelName = dto.ModelName,
                HyperLink = dto.Hyperlink
            };

            _context.Models.Add(m);
            _context.SaveChanges();

            var newModel = _context.Models.Where(x => x.ModelName == dto.ModelName).FirstOrDefault();

            return newModel;
        }

        public bool DeleteModel(int id)
        {
            var model = _context.Models.Where(x => x.ID == id).FirstOrDefault();

            if (model == null)
                return false;

            _context.Models.Remove(model);
            _context.SaveChanges();
            var modelCheck = _context.Models.Where(x => x.ID == id).FirstOrDefault();

            if (modelCheck != null)
                return true;
            else
                return false;
        }

        
        public Model UpdateModel(UpdateModelDto dto)
        {
            var model = _context.Models.Where(x => x.ID == dto.ID).FirstOrDefault();

            if (model == null)
                return null;

            model.ModelName = dto.ModelName;
            model.HyperLink = dto.Hyperlink;

            _context.Models.Update(model);
            _context.SaveChanges();

            return model;
            
            
        }


    }
}