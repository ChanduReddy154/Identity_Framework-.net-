using Hrms.Business.BusinessInterfaces;
using HRMS.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace HrmsWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoInterface _personalInfoInterface;
      //  private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;

        
        public PersonalInfoController(IPersonalInfoInterface personalInfoInterface, IWebHostEnvironment webHostEnvironment)
        {
            _personalInfoInterface = personalInfoInterface;
            // _hostingEnvironment = hostingEnvironment;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Upload Image")]
        public async Task<IActionResult> UploadImages([FromForm]PersonalInfoViewModel personalInfo)
        {
            if(personalInfo.ProfilePicturePath.Length > 0)
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Upload\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Upload\\");
                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Upload\\" + personalInfo.ProfilePicturePath.FileName)) 
                {
                    personalInfo.ProfilePicturePath.CopyTo(fileStream);
                    fileStream.Flush();
                }

            }
            var result = await _personalInfoInterface.postPersonalInfo(personalInfo);
            return Ok(result);
        }

        //[HttpPost("Images")]
        //public async Task<IActionResult> uploadImages(PersonalInfoViewModel personalInfo)
        //{
        //    var path =  UploadingImages(personalInfo.ProfilePicturePath);
        //    var result = await _personalInfoInterface.postPersonalInfo(personalInfo);
        //    return Ok(new ApiResponse(200, "Image uploaded successfully", result));
        //}

        //[HttpPost("ImagesUpload")]
        //public ActionResult<string> UploadingImages(string fileName)
        //{
        //    try
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        if (files != null && files.Count > 0)
        //        {
        //            foreach (var item in files)
        //            {
        //                FileInfo fileInfo = new FileInfo(item.FileName);
        //                fileName ="'Image_' + DateTime.Now.TimeOfDay.Milliseconds + fileInfo.Extension";
        //                var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "\\Images\\" + fileName);
        //                using (var stream = new FileStream(path, FileMode.Create))
        //                {
        //                    item.CopyTo(stream);
        //                }
                        
        //            }
        //            return "Image Upload success";
        //        }
        //        else
        //        {
        //            return "Image upload failed";
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return "Failed";
        //        throw;
        //    }

        //}

    }
}
