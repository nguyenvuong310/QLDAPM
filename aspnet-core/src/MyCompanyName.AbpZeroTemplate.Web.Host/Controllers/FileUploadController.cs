using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.ERP;
using MyCompanyName.AbpZeroTemplate.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_FileUpload)]
    public class FileUploadController : AbpZeroTemplateControllerBase
    {
        private readonly IHostEnvironment _env;
        private readonly ExamFileAppService _examFileAppService;
        public FileUploadController(IHostEnvironment env, ExamFileAppService examFileAppService)
        {
            _env = env;
            _examFileAppService = examFileAppService;   
        }

        [HttpPost]
        public async Task<string> UploadFile(FileUploadViewModel model)
        {
            var image = Request.Form.Files.First();
            var uniqueFileName = GetUniqueFileName(image.FileName);
            var dir = Path.Combine(_env.ContentRootPath, "Images");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var filePath = Path.Combine(dir, uniqueFileName);
            await image.CopyToAsync(new FileStream(filePath, FileMode.Create));
            SaveImagePathToDb(model.Description, filePath, model.QuestionId);
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

        private async void SaveImagePathToDb(string description, string filepath, int questionId)
        {
            //todo: description and file path to db
            await _examFileAppService.CreateExamFile(new CreateExamFileInput(questionId,description, filepath));
        }
    }

}
