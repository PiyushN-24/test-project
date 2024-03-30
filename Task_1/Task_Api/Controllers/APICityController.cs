using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Api.Interface;
using Task_Api.Service;
using Task_Api.VMModel;

namespace Task_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICityController : ControllerBase
    {

        ICityService _ICityService;

        public APICityController(ICityService sai)
        {
            _ICityService = sai;
        }


        [HttpPost]
        public async Task<ActionResult> APIPostCity(VMCity vMCity)
        {
            try
            {
                long ret = 0;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ret = await _ICityService.CitySave(vMCity);
                return Ok(ret);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
