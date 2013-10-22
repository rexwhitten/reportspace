namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = "Administrator")]
    public class FileController : Controller
    {
        private const string UploadsFolder = "content\\uploads";

        public ActionResult Create()
        {
            var postedFileBase = Request.Files[0];
            
            var fileName = GetFileName(postedFileBase);
            var savedFileName = Path.Combine(GetFolderPath(), fileName);
            postedFileBase.SaveAs(savedFileName);

            return Json(new { fileName = "content/uploads/" + fileName });
        }

        private static string GetFileName(HttpPostedFileBase postedFileBase)
        {
            var fileName = Path.GetFileName(postedFileBase.FileName);
            var newFileName = Path.ChangeExtension(CalculateSha1(fileName, Encoding.ASCII), fileName);
            return newFileName;
        }

        private string GetFolderPath()
        {
            var folderPath = this.Server.MapPath(UploadsFolder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        private static string CalculateSha1(string text, Encoding enc)
        {
            text = string.Concat(text, DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture));
            var buffer = enc.GetBytes(text);
            var cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            var hash = BitConverter.ToString(cryptoTransformSha1.ComputeHash(buffer)).Replace("-", string.Empty);
            return hash;
        }
    }
}