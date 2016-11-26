/*******************************************************************************
* Copyright (C) JuCheap.Com
* 
* Author: dj.wong
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Utilities;

namespace YunKe.AdminPanelCore
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    internal sealed class DbConfiguration : DbMigrationsConfiguration<JuCheapContext>
    {
        private readonly DateTime _now = new DateTime(2015, 5, 1, 23, 59, 59);
        private readonly BaseIdGenerator _instance = BaseIdGenerator.Instance;

        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = true;//启用自动迁移
            AutomaticMigrationDataLossAllowed = true;//是否允许接受数据丢失的情况，false=不允许，会抛异常；true=允许，有可能数据会丢失
        }

        protected override void Seed(JuCheapContext context)
        {
            if (!context.Set<SystemConfigEntity>().Any(item => item.IsDataInited))
            {
                #region 用户

                var admin = new UserEntity
                {
                    Id = _instance.GetId(),
                    LoginName = "root",
                    RealName = "超级管理员",
                    Password = "admin!@#".ToMd5(),
                    Email = "service@103studio.com",
                    IsSuperMan = true,
                    CreateDateTime = _now
                };
                var guest = new UserEntity
                {
                    Id = _instance.GetId(),
                    LoginName = "guest",
                    RealName = "游客",
                    Password = "123123".ToMd5(),
                    Email = "service@103studio.com",
                    CreateDateTime = _now
                };
                //用户
                var user = new List<UserEntity>
                {
                    admin,
                    guest
                };

                #endregion

                #region 菜单

                var system = new MenuEntity
                {
                    Id = _instance.GetId(),
                    Name = "系统设置",
                    Url = "#",
                    CreateDateTime = _now,
                    Order = 1,
                    Code = "AA",
                    PathCode = "AA",
                    Type = 1
                }; //1
                var menuMgr = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = system.Id,
                    Name = "菜单管理",
                    Url = "/Menu/Index",
                    CreateDateTime = _now,
                    Order = 2,
                    Code = "AA",
                    PathCode = "AAAA",
                    Type = 2
                }; //2
                var roleMgr = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = system.Id,
                    Name = "角色管理",
                    Url = "/Role/Index",
                    CreateDateTime = _now,
                    Order = 3,
                    Code = "AB",
                    PathCode = "AAAB",
                    Type = 2
                }; //3
                var userMgr = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = system.Id,
                    Name = "用户管理",
                    Url = "/User/Index",
                    CreateDateTime = _now,
                    Order = 4,
                    Code = "AC",
                    PathCode = "AAAC",
                    Type = 2
                }; //4
                var userRoleMgr = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = system.Id,
                    Name = "用户授权",
                    Url = "/User/Authen",
                    CreateDateTime = _now,
                    Order = 4,
                    Code = "AD",
                    PathCode = "AAAD",
                    Type = 2
                }; //5
                var roleMenuMgr = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = system.Id,
                    Name = "角色授权",
                    Url = "/Role/Authen",
                    CreateDateTime = _now,
                    Order = 4,
                    Code = "AE",
                    PathCode = "AAAE",
                    Type = 2
                }; //6
                var sysConfig = new MenuEntity
                {

                    Id = _instance.GetId(),
                    ParentId = system.Id,
                    Name = "系统配置",
                    Url = "/System/Index",
                    CreateDateTime = _now,
                    Order = 4,
                    Code = "AF",
                    PathCode = "AAAF",
                    Type = 2
                }; //7
                var sysConfigReloadPathCode = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = sysConfig.Id,
                    Name = "重置路径码",
                    Url = "/System/ReloadPathCode",
                    CreateDateTime = _now,
                    Order = 1,
                    Code = "AAAF",
                    PathCode = "AAAFAA",
                    Type = 3
                }; //8
                var log = new MenuEntity
                {
                    Id = _instance.GetId(),
                    Name = "日志查看",
                    Url = "#",
                    CreateDateTime = _now,
                    Order = 9,
                    Code = "AB",
                    PathCode = "AB",
                    Type = 1
                }; //9
                var logLogin = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = log.Id,
                    Name = "登录日志",
                    Url = "/Log/Logins",
                    CreateDateTime = _now,
                    Order = 9,
                    Code = "AA",
                    PathCode = "ABAA",
                    Type = 2
                }; //10
                var logView = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = log.Id,
                    Name = "访问日志",
                    Url = "/Log/Visits",
                    CreateDateTime = _now,
                    Order = 10,
                    Code = "AB",
                    PathCode = "ABAB",
                    Type = 2
                }; //11

                var logChart = new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = log.Id,
                    Name = "图表统计",
                    Url = "/Log/Charts",
                    CreateDateTime = _now,
                    Order = 11,
                    Code = "AC",
                    PathCode = "ABAC",
                    Type = 2
                };

                //菜单
                var menus = new List<MenuEntity>
                {
                    system,
                    menuMgr,
                    roleMgr,
                    userMgr,
                    userRoleMgr,
                    roleMenuMgr,
                    sysConfig,
                    sysConfigReloadPathCode,
                    log,
                    logLogin,
                    logView,
                    logChart
                };
                var menuBtns = GetMenuButtons(menuMgr.Id, "Menu", "菜单", "AAAA"); //14
                var rolwBtns = GetMenuButtons(roleMgr.Id, "Role", "角色", "AAAB"); //17
                var userBtns = GetMenuButtons(userMgr.Id, "User", "用户", "AAAC"); //20

                menus.AddRange(menuBtns); //14
                menus.AddRange(rolwBtns); //17
                menus.AddRange(userBtns); //20
                menus.Add(new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = roleMenuMgr.Id,
                    Order = 6,
                    Name = "授权",
                    Type = 3,
                    Url = "/Role/SetRoleMenus",
                    CreateDateTime = _now,
                    Code = "AA",
                    PathCode = "AAACAA"
                });
                menus.Add(new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = roleMenuMgr.Id,
                    Order = 6,
                    Name = "清空权限",
                    Type = 3,
                    Url = "/Role/ClearRoleMenus",
                    CreateDateTime = _now,
                    Code = "AB",
                    PathCode = "AAACAB"
                });

                #endregion

                #region 角色

                var superAdminRole = new RoleEntity
                {
                    Id = _instance.GetId(),
                    Name = "超级管理员",
                    Description = "超级管理员"
                };
                var guestRole = new RoleEntity
                {
                    Id = _instance.GetId(),
                    Name = "guest",
                    Description = "游客"
                };
                var roles = new List<RoleEntity>
                {
                    superAdminRole,
                    guestRole
                };

                #endregion

                #region 用户角色关系

                var userRoles = new List<UserRoleEntity>
                {
                    new UserRoleEntity
                    {
                        Id = _instance.GetId(),
                        UserId = admin.Id,
                        RoleId = superAdminRole.Id,
                        CreateDateTime = _now
                    },
                    new UserRoleEntity
                    {
                        Id = _instance.GetId(),
                        UserId = guest.Id,
                        RoleId = guestRole.Id,
                        CreateDateTime = _now
                    }
                };

                #endregion

                #region 角色菜单权限关系

                var roleMenus = menus.Select(m => new RoleMenuEntity
                {
                    Id = _instance.GetId(),
                    RoleId = superAdminRole.Id,
                    MenuId = m.Id,
                    CreateDateTime = _now
                }).ToList();

                roleMenus.AddRange(menus.Where(item => item.Type != 3)
                    .Select(m => new RoleMenuEntity
                    {
                        Id = _instance.GetId(),
                        RoleId = guestRole.Id,
                        MenuId = m.Id,
                        CreateDateTime = _now
                    }));
                //超级管理员授权
                //游客授权

                #endregion

                #region 系统配置

                var systemConfig = new List<SystemConfigEntity>
                {
                    new SystemConfigEntity
                    {
                        Id = _instance.GetId(),
                        SystemName = "JuCheap",
                        IsDataInited = true,
                        DataInitedDate = _now,
                        CreateDateTime = _now,
                        IsDeleted = false
                    }
                };

                #endregion

                AddOrUpdate(context, m => m.LoginName, user.ToArray());

                AddOrUpdate(context, m => new {m.ParentId, m.Name}, menus.ToArray());

                AddOrUpdate(context, m => m.Name, roles.ToArray());

                AddOrUpdate(context, m => new {m.UserId, m.RoleId}, userRoles.ToArray());

                AddOrUpdate(context, m => new {m.MenuId, m.RoleId}, roleMenus.ToArray());

                AddOrUpdate(context, m => new {m.SystemName}, systemConfig.ToArray());
            }
        }

        #region Private

        /// <summary>
        /// 获取菜单的基础按钮
        /// </summary>
        /// <param name="parentId">父级ID</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="controllerShowName">菜单显示名称</param>
        /// <param name="parentPathCode">父级路径码</param>
        /// <returns></returns>
        private IEnumerable<MenuEntity> GetMenuButtons(string parentId, string controllerName,string controllerShowName,string parentPathCode)
        {
            return new List<MenuEntity>
            {
                new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = parentId,
                    Name = string.Concat("添加",controllerShowName),
                    Url = string.Format("/{0}/Add",controllerName),
                    CreateDateTime = _now,
                    Order = 1,
                    Code = "AA",
                    PathCode = parentPathCode+"AA",
                    Type = 3
                },
                new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = parentId,
                    Name = string.Concat("修改",controllerShowName),
                    Url = string.Format("/{0}/Edit",controllerName),
                    CreateDateTime = _now,
                    Order = 2,
                    Code = "AB",
                    PathCode = parentPathCode+"AB",
                    Type = 3
                },
                new MenuEntity
                {
                    Id = _instance.GetId(),
                    ParentId = parentId,
                    Name = string.Concat("删除",controllerShowName),
                    Url = string.Format("/{0}/Delete",controllerName),
                    CreateDateTime = _now,
                    Order = 3,
                    Code = "AC",
                    PathCode = parentPathCode+"AC",
                    Type = 3
                }
            };
        }

        /// <summary>
        /// 添加更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="exp"></param>
        /// <param name="param"></param>
        void AddOrUpdate<T>(DbContext context, Expression<Func<T, object>> exp, T[] param) where T : class
        {
            var set = context.Set<T>();
            set.AddOrUpdate(exp, param);
        }

        #endregion
    }
}
