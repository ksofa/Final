//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Hosting.Internal;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using UserManagement.MVC.Data;
//using UserManagement.MVC.Models;

//namespace UserManagement.MVC.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImageProjectController : ControllerBase
//    {
//        public IHostingEnvironment hostingEnviroment;
//        private ApplicationDbContext db;
//        public ImageProjectController(ApplicationDbContext dbContext, IHostingEnvironment hosting)
//        {
//             db = dbContext;
//            hostingEnviroment = hosting;
//        }

//        [Route("upload/interior")]
//        [HttpPost]
//        public void UploadInteriorImages(int interoirId)
//        {
//            var images = UploadImage();

//            var interoir = db.Interior.Find(interoirId);
//            foreach (var image in images)
//            {
//                interoir.Pictures.Add(image);
//            }

//            db.SaveChanges();
//        }

//        private List<Image> UploadImage()
//        {
//            var result = new List<Image>();
//            try
//            {
//                var files = HttpContext.Request.Form.Files;
//                    foreach (var file in files)
//                    {
//                        FileInfo fi = new FileInfo(file.FileName);
//                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
//                        var path = Path.Combine("", hostingEnviroment.ContentRootPath + "/Images"+ newfilename);
//                        using (var stream = new FileStream(path, FileMode.Create))
//                        {
//                            file.CopyTo(stream);
//                        }
//                        Image imageupload = new Image();
//                        imageupload.ImagePath = path;
//                        imageupload.CreatedAt = DateTime.Now;
//                        db.Images.Add(imageupload);
//                        result.Add(imageupload);
//                    }

//                    db.SaveChanges();
             
//            }
//            catch (Exception el)
//            {
//            }

//            return result;
//        }

//        // GET: api/<InteriorController>
//        [HttpGet]
//        public HttpResponseMessage GetProjectImage(int id)
//        {
//            var imagePath = db.Images.Find(id).ImagePath;
//            var result = new HttpResponseMessage(HttpStatusCode.OK);
//            String filePath = Path.Combine(hostingEnviroment.ContentRootPath + "/Images" + imagePath);
//            FileStream fileStream = new FileStream(filePath, FileMode.Open);

//            result.Content = new ByteArrayContent(memoryStream.ToArray());
//            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

//            return result;
//        }
//    }
//}
