using YunKe.AdminPanelCore.Interfaces;
using YunKe.AdminPanel.Filters;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace YunKe.AdminPanel.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [IgnoreRightFilter]
    public class FileUploadController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;

        public FileUploadController(IUserService userSvr, IMenuService menuService)
        {
            _userService = userSvr;
            _menuService = menuService;
        }

        [HttpPost]
        public ActionResult UploadAvater()
        {
            Result result = new Result();
            result.avatarUrls = new ArrayList();
            result.success = false;
            result.msg = "Failure!";
            //取服务器时间+8位随机码作为部分文件名，确保文件名无重复。
            string fileName = DateTime.Now.ToString("yyyyMMddhhmmssff") + CreateRandomCode(8);
            //定义一个变量用以储存当前头像的序号
            int avatarNumber = 1;
            //遍历所有文件域
            foreach (string fieldName in Request.Files.AllKeys)
            {
                var file = Request.Files[fieldName];
                //处理原始图片（默认的 file 域的名称是__source，可在插件配置参数中自定义。参数名：src_field_name）
                //如果在插件中定义可以上传原始图片的话，可在此处理，否则可以忽略。
                if (fieldName == "__source")
                {
                    //文件名，如果是本地或网络图片为原始文件名（不含扩展名）、如果是摄像头拍照则为 *FromWebcam
                    //fileName = file.FileName;
                    //当前头像基于原图的初始化参数（即只有上传原图时才会发送该数据），用于修改头像时保证界面的视图跟保存头像时一致，提升用户体验度。
                    //修改头像时设置默认加载的原图url为当前原图url+该参数即可，可直接附加到原图url中储存，不影响图片呈现。
                    string initParams = Request.Form["__initParams"];

                    var local = string.Format("/upload/avater/csharp_source_{0}.jpg", fileName);


                    var fullPath = Server.MapPath(local);

                    if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                    }

                    file.SaveAs(fullPath);

                    result.sourceUrl = GetAbsPath(local);

                    result.sourceUrl += initParams;
                    /*
                        可在此将 result.sourceUrl 储存到数据库，如果有需要的话。
                    */
                }
                //处理头像图片(默认的 file 域的名称：__avatar1,2,3...，可在插件配置参数中自定义，参数名：avatar_field_names)
                else if (fieldName.StartsWith("__avatar"))
                {
                    var local = string.Format("/upload/avater/csharp_avatar{0}_{1}.jpg", avatarNumber, fileName);

                    string virtualPath = local;//
                    result.avatarUrls.Add(GetAbsPath(virtualPath));

                    var fullPath = Server.MapPath(virtualPath);

                    if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                    }

                    file.SaveAs(fullPath);
                    /*
                        可在此将 virtualPath 储存到数据库，如果有需要的话。
                    */
                    avatarNumber++;
                }
                /*
                else
                {
                    如下代码在上传接口Upload.aspx中定义了一个user=xxx的参数：
                    var swf = new fullAvatarEditor('swf', {
                        id: 'swf',
                        upload_url: 'Upload.aspx?user=xxx'
                    });
                    在此即可用Request.Form["user"]获取xxx。
                }
                */
            }
            result.success = true;
            result.msg = "Success!";
            //返回图片的保存结果（返回内容为json字符串，可自行构造，该处使用Newtonsoft.Json构造）
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                var file = Request.Files["Filedata"];
                string str = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo);
                string str2 = "/Storage/master/reply/";
                string str3 = str + Path.GetExtension(file.FileName);

                var fileToSave = Server.MapPath(str2 + str3);

                var folder = Path.GetDirectoryName(fileToSave);

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                file.SaveAs(fileToSave);
                base.Response.StatusCode = 200;

                return Content(GetAbsPath(str2 + str3));
            }
            catch (Exception)
            {
                base.Response.StatusCode = 500;
                return Content("服务器错误");
            }
        }

        private string GetAbsPath(string relatrivePath)
        {
            return string.Format("http://{0}{1}", HttpContext.Request.Url.Host, relatrivePath);
        }


        /// <summary>
        /// 生成指定长度的随机码。
        /// </summary>
        private string CreateRandomCode(int length)
        {
            string[] codes = new string[36] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            StringBuilder randomCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                randomCode.Append(codes[rand.Next(codes.Length)]);
            }
            return randomCode.ToString();
        }
        /// <summary>
        /// 表示图片的上传结果。
        /// </summary>
        private struct Result
        {
            /// <summary>
            /// 表示图片是否已上传成功。
            /// </summary>
            public bool success;
            /// <summary>
            /// 自定义的附加消息。
            /// </summary>
            public string msg;
            /// <summary>
            /// 表示原始图片的保存地址。
            /// </summary>
            public string sourceUrl;
            /// <summary>
            /// 表示所有头像图片的保存地址，该变量为一个数组。
            /// </summary>
            public ArrayList avatarUrls;
        }
    }
}