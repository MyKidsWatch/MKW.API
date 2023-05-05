using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Entities.Base;
using MKW.Domain.Interface.Services.AppServices.Base;

namespace MKW.API.Controllers.Base
{
    public class CrudBaseController<T> : BaseController where T : BaseEntity
    {
        protected readonly IBaseService<T> _service;

        public CrudBaseController(IBaseService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.Get());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) => Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T entity) => Ok(await _service.Add(entity));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T entity) => Ok(await _service.Update(entity));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) => Ok(await _service.Delete(id));
    }
}
