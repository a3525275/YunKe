using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YunKe.Weixin.Dtos;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Service;
using YunKe.AdminPanel.Controllers;
using YunKe.Weixin.Entity;

namespace YunKe.AdminPanel.Areas.Wx.Controllers
{
    public class OfficalAccountsController : BaseController
    {
        private IRepository<WxOfficalAccount> _repository;
        private IMapper _mapper;

        public OfficalAccountsController(IRepository<WxOfficalAccount> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: wx/OfficalAccounts
        public ActionResult Index()
        {
            var firstOne = _repository.Query().FirstOrDefault();
            if (firstOne == null)
            {
                firstOne = new WxOfficalAccount();
                firstOne.Token = CreateKey(8);
            }

            return View(firstOne);
        }

        private string CreateKey(int len)
        {
            byte[] data = new byte[len];
            new RNGCryptoServiceProvider().GetBytes(data);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(string.Format("{0:X2}", data[i]));
            }
            return builder.ToString();
        }

        [HttpPost]
        public ActionResult Edit(WxOfficalAccount model)
        {
            if (ModelState.IsValid)
            {
                var isOk = RunWithCatch((ms) =>
                {
                    var isNew = false;
                    var entity = _repository.Query().FirstOrDefault();
                    if (entity == null)
                    {
                        isNew = true;
                        entity = _mapper.Map<WxOfficalAccount>(model);
                    }
                    else
                    {
                        entity.AppId = model.AppId;
                        entity.AppSecret = model.AppSecret;
                        entity.Token = model.Token;
                        entity.EndPoint = model.EndPoint;
                        entity.UsingWxLoginFunction = model.UsingWxLoginFunction;
                        entity.MediaSourceServerPath = model.MediaSourceServerPath;
                        entity.MicroSiteHeaderImages = model.MicroSiteHeaderImages;
                        entity.MicroSiteName = model.MicroSiteName;
                    }

                    if (isNew)
                    {
                        return _repository.Insert(entity);
                    }
                    else
                    {
                        return _repository.Update(entity, p => new object[] { entity.Id });
                    }
                });

                if (isOk)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index", model);
        }
    }
}