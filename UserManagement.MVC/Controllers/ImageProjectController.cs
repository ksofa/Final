﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageProjectController : ControllerBase
    {
        public IHostingEnvironment hostingEnviroment;
        private ApplicationDbContext db;
        public ImageProjectController(ApplicationDbContext dbContext, IHostingEnvironment hosting)
        {
            db = dbContext;
            hostingEnviroment = hosting;
        }

        //[Route("upload/interior")]
        //[HttpPost]
        //public void UploadInteriorImages(int interoirId)
        //{
        //    var images = UploadImage();

        //    var interoir = db.Interior.Find(interoirId);
        //    foreach (var image in images)
        //    {
        //        interoir.Pictures.Add(image);
        //    }

        //    db.SaveChanges();
        //}
        [HttpPost]
        public ActionResult<string> UploadImage()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine("", hostingEnviroment.ContentRootPath + "\\Images\\" + newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        ProjectImage imageupload = new ProjectImage();
                        imageupload.ImagePath = path;
                        imageupload.CreatedAt = DateTime.Now;
                        db.ProjectImages.Add(imageupload);
                        db.SaveChanges();
                    }
                    return "Saved";
                }
                else
                {
                    return "Select files";
                }
            }
            catch (Exception el)
            {
                return el.Message;
            }
        }

        // GET: api/<InteriorController>
        [HttpGet]
        public ActionResult<List<ProjectImage>> GetProjectImage(int id)
        {
            var res = db.ProjectImages.ToList();
            return res;
            //var imagePath = db.Images.Find(id).ImagePath;
            //var result = new HttpResponseMessage(HttpStatusCode.OK);
            //String filePath = Path.Combine(hostingEnviroment.ContentRootPath + "/Images" + imagePath);
            //FileStream fileStream = new FileStream(filePath, FileMode.Open);

            //result.Content = new ByteArrayContent(memoryStream.ToArray());
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            //return result;
        }
    }
}