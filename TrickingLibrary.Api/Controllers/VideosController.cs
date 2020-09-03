using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Api.BackgroundServices;
using TrickingLibrary.Api.BackgroundServices.VideoEditing;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly VideoManager _videoManager;

        public VideosController(VideoManager videoManager)
        {
            _videoManager = videoManager;
        }

        [HttpGet("{video}")]
        public IActionResult GetVideo(string video)
        {
            var savePath = _videoManager.DevVideoPath(video);
            if (string.IsNullOrEmpty(savePath)) return BadRequest();

            return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read), "video/*");
        }

        [HttpPost]
        public Task<string> UploadResult(IFormFile video)
        {
            return _videoManager.SaveTemporaryVideo(video);
        }

        [HttpDelete("{fileName}")]
        public IActionResult DeleteTemporaryVideo(string fileName)
        {
            if (!_videoManager.Temporary(fileName))
            {
                return BadRequest();
            }

            if (!_videoManager.TemporaryFileExists(fileName))
            {
                return NotFound();
            }
            
            _videoManager.DeleteTemporaryFile(fileName);

            return Ok();
        }
    }
}