using Lelu.Helpers.Dtos;
using Lelu.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lelu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : Controller
    {
        private IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("GetModels")]
        public IActionResult GetModels()
        {
            var models = _modelService.GetModels();

            if (models == null || models.Count < 1)
                return NotFound();
            else
                return Ok(models);
        }

        [HttpGet("GetModel")]
        public IActionResult GetModel(int id)
        {
            var model = _modelService.GetModel(id);

            if (model == null)
                return NotFound();
            else
                return Ok(model);
        }

        [HttpGet("Search")]
        public IActionResult SearchModels(string? name)
        {
            var models = _modelService.SearchModels(name);

            if (models == null || models.Count < 1)
                return NotFound();
            else
                return Ok(models);
        }

        [HttpGet("GetHyperlink")]
        public IActionResult GetHyperlink(int id)
        {
            string result = _modelService.GetHyperlink(id);

            if (string.IsNullOrEmpty(result))
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost("CreateModel")]
        public IActionResult CreateModel(NewModelDto dto)
        {
            var model = _modelService.CreateModel(dto);

            if (model == null)
                return NotFound();
            else
                return Ok(model);
        }

        [HttpDelete("DeleteModel")]
        public IActionResult DeleteModel(int id)
        {
            bool result = _modelService.DeleteModel(id);

            if (result == false)
                return BadRequest();
            else
                return Ok();
        }


   
        [HttpPut("UpdateModel")]
        public IActionResult UpdateModel(UpdateModelDto dto)
        {
            var model = _modelService.UpdateModel(dto);

            if (model == null)
                return NotFound();
            else
                return Ok(model);
        }

    }
}
