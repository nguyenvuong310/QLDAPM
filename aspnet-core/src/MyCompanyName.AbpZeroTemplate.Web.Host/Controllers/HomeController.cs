﻿using Abp.Auditing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MyCompanyName.AbpZeroTemplate.Configuration;

namespace MyCompanyName.AbpZeroTemplate.Web.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IConfigurationRoot _appConfiguration;
        
        public HomeController(
            IWebHostEnvironment webHostEnvironment, 
            IAppConfigurationAccessor appConfigurationAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _appConfiguration = appConfigurationAccessor.Configuration;
        }

        [DisableAuditing]
        public IActionResult Index()
        {
            if (_webHostEnvironment.IsDevelopment())
            {
                return RedirectToAction("Index", "Ui");
            }

            var homePageUrl = _appConfiguration["App:HomePageUrl"];
            if (string.IsNullOrEmpty(homePageUrl))
            {
                return RedirectToAction("Index", "Ui");
            }

            return Redirect(homePageUrl);
        }
    }
}
