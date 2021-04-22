using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApp.ApiControllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ErUserPicturesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public ErUserPicturesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ErUserPictures
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.ErUserPicture>>> GetErUserPictures()
        {
            return Ok(await _uow.ErUserPictures.GetAllAsync());
        }

        // GET: api/ErUserPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.ErUserPicture>> GetErUserPicture(Guid id)
        {
            var erUserPicture = await _uow.ErUserPictures.FirstOrDefaultAsync(id);

            if (erUserPicture == null)
            {
                return NotFound();
            }

            return erUserPicture;
        }

        // PUT: api/ErUserPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="erUserPicture"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUserPicture(Guid id, DAL.App.DTO.ErUserPicture erUserPicture)
        {
            if (id != erUserPicture.Id)
            {
                return BadRequest();
            }

            _uow.ErUserPictures.Update(erUserPicture);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErUserPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="erUserPicture"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.ErUserPicture>> PostErUserPicture(DAL.App.DTO.ErUserPicture erUserPicture)
        {
            _uow.ErUserPictures.Add(erUserPicture);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetErUserPicture", new { id = erUserPicture.Id }, erUserPicture);
        }

        // DELETE: api/ErUserPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUserPicture(Guid id)
        {
            var erUserPicture = await _uow.ErUserPictures.FirstOrDefaultAsync(id);
            if (erUserPicture == null)
            {
                return NotFound();
            }

            _uow.ErUserPictures.Remove(erUserPicture);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
