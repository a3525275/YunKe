using System;
using System.Collections.Generic;
using System.Linq;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure.Utilities;
using YunKe.AdminPanelCore.Interfaces;
using Mehdime.Entity;

namespace YunKe.AdminPanelCore.Services.AppServices
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public class DatabaseInitService : IDatabaseInitService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly BaseIdGenerator _instance = BaseIdGenerator.Instance;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContextScopeFactory"></param>
        public DatabaseInitService(IDbContextScopeFactory dbContextScopeFactory)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            InitData.Init();

            //InitPathCode();
        }

        /// <summary>
        /// 初始化路径码
        /// </summary>
        public bool InitPathCode()
        {
            using (var scope = _dbContextScopeFactory.Create())
            {
                var db = scope.DbContexts.Get<JuCheapContext>();
                var dbSet = db.Set<PathCodeEntity>();

                //生成路径码
                var codes = new List<string>(26);
                for (int i = 65; i <= 90; i++)
                {
                    codes.Add(((char)i).ToString());
                }
                int len = 2;
                //求组合
                List<string[]> ermutation = PermutationAndCombination<string>.GetCombination(codes.ToArray(), len);
                List<PathCodeEntity> list = new List<PathCodeEntity>();
                ermutation.ForEach(item =>
                {
                    list.Add(new PathCodeEntity
                    {
                        Id = _instance.GetId(),
                        Code = string.Join(string.Empty, item),
                        Len = len
                    });
                    list.Add(new PathCodeEntity
                    {
                        Id = _instance.GetId(),
                        Code = string.Join(string.Empty, item.Reverse()),
                        Len = len
                    });
                });
                Func<IEnumerable<PathCodeEntity>> getSameKeyFunc = () =>
                {
                    return codes.Select(key => new PathCodeEntity
                    {
                        Id = _instance.GetId(),
                        Code = string.Join(string.Empty, key, key),
                        Len = len
                    });
                };
                list.AddRange(getSameKeyFunc());
                list = list.OrderBy(item => item.Code).ToList();

                db.Database.ExecuteSqlCommand("DELETE FROM PathCodes");
                dbSet.AddRange(list);

                return scope.SaveChanges() > 0;
            }
        }
    }
}
