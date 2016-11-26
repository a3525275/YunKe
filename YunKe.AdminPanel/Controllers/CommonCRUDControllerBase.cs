using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YunKe.AdminPanel.Controllers;
using YunKe.AdminPanel.Filters;
using YunKe.AdminPanel.Models;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Commands;
using YunKe.Infrastructure.Data;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Queries;
using YunKe.Infrastructure.Service;
using YunKe.Infrastructure.Validation;

namespace YunKe.AdminPanel
{
    /// <summary>
    /// 实现了通用 crud 方法的公共 <see cref="BaseController"/> 。
    /// </summary>
    /// <typeparam name="TEntity">实体模型.</typeparam>
    /// <typeparam name="TCreateDto">提供用于创建 <see cref="TEntity"/> 所需数据的 Dto 对象类型。</typeparam>
    /// <typeparam name="TUpdateDto">提供用于更新 <see cref="TEntity"/> 所需数据的 Dto 对象类型，必须包含 Id 属性。</typeparam>
    /// <typeparam name="TOverviewDto">提供用于在列表页面展示 <see cref="TEntity"/> 所需数据的 Dto 对象类型。</typeparam>
    /// <typeparam name="TQuery">提供用于查询 <see cref="TEntity"/> 所需的查询参数对象。</typeparam>
    /// <seealso cref="YunKe.AdminPanel.Controllers.BaseController" />
    public class CommonCRUDControllerBase<TEntity,
        TCreateDto,
        TUpdateDto, TOverviewDto, TQuery> : BaseController
        where TEntity : class, IBaseEntity, new()
        where TCreateDto : class, new()
        where TUpdateDto : class, new()
        where TQuery : IBaseFilter
    {
        protected readonly IMapper _mapper;
        protected readonly IQueryBus _queryBus;
        protected readonly IRepository<TEntity> _repository;

        /// <summary>
        /// 是否使用自定义查询<see cref="IQueryHandler{TQuery, TResult}"/> Handler 获取列表。设置为 true，如果需要自定义查询。默认使用 <see cref="IRepository{TEntity}"/> 的 GetDataForListPager 查询方法。
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use query handler]; otherwise, <c>false</c>.
        /// </value>
        public bool UseQueryHandler { get; set; } = false;

        public CommonCRUDControllerBase()
        {
            var dr = DependencyResolver.Current;
            _repository = dr.GetService<IRepository<TEntity>>();
            _mapper = dr.GetService<IMapper>();
            _queryBus = dr.GetService<IQueryBus>();
        }

        // GET: WuYou/FriendLinks
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Add()
        {
            return View(new TCreateDto());
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Add(TCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<TEntity>(dto);
                if (entity.Id.IsBlank())
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.CreateDateTime = DateTime.Now;
                }

                var result = _repository.Insert(entity);

                if (result)
                    return RedirectToAction("Index");
            }
            return View(dto);
        }


        public virtual ActionResult GetListWithPager(TQuery filters)
        {
            if (UseQueryHandler)
            {
                var result = _queryBus.Send<TQuery, PagedResult<TOverviewDto>>(filters); //_repository.GetDataForListPager(filters);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = _repository.GetPagedData(filters, (list) => _mapper.Map<IEnumerable<TOverviewDto>>(list));
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual ActionResult Delete(string[] ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = _repository.DeleteBatch(it => ids.Contains(it.Id));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult Edit(string id)
        {
            var model = _mapper.Map<TOverviewDto>(_repository.Get(it => it.Id == id));
            return View(model);
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateParameterBeforeExecutingFilter]
        public virtual ActionResult Edit([HasIdProperty]TUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                // Just to get the Id...
                var fake = _mapper.Map<TEntity>(dto);
                var entity = _repository.Get(it => it.Id == fake.Id);
                var createDateTime = entity.CreateDateTime;
                var id = entity.Id;

                entity= _mapper.Map(dto, entity);

                // Don't update create date time.
                entity.Id = id;
                entity.CreateDateTime = createDateTime;
                entity.ModifiedBy = User.Identity.Name;
                entity.ModifiedDate = DateTime.Now;

                var result = _repository.Update(entity, r => new object[] { entity.Id });
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(dto);
        }
    }
}