using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Commerce.Articles.Domain;
using YunKe.Commerce.Commissions.Domain;
using YunKe.Commerce.Customers.Domain;
using YunKe.Commerce.Indutries.Domain;
using YunKe.Commerce.KeyWordRank.Domain;
using YunKe.Commerce.Members.Domain;
using YunKe.Commerce.Optimizators.Domain;
using YunKe.Commerce.OptimizatorTeams.Domain;
using YunKe.Commerce.Orders.Domain;
using YunKe.Commerce.SearchPlatforms.Domain;
using YunKe.Commerce.Projects.Domain;
using YunKe.Commerce.Sites.Domain;
using YunKe.Commerce.SiteTemplates.Domain;
using YunKe.Commerce.Tenders.Domain;
using YunKe.Infrastructure.Utilities;
using YunKe.Weixin.Entity;
using YunKe.Commerce.Questions.Domain;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Activities.Domain;
using YunKe.Commerce.OptimizationKeyWords.Domain;
using YunKe.Commerce.Agents.Domain;
using YunKe.Commerce.Channels.Domain;

namespace YunKe.Commerce.EfDbContext
{
    public class YunKeDbContext : DbContext
    {
        public YunKeDbContext()
            : base("YunKeDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Address>();
            modelBuilder.ComplexType<SiteSeoInfo>();
            modelBuilder.ComplexType<KeyWordPrice>();
            modelBuilder.ComplexType<SearchEngineRanking>();
            base.OnModelCreating(modelBuilder);
        }

        #region Weixin
        public virtual DbSet<WxMenu> WxMenus { get; set; }

        public virtual DbSet<WxMessage> WxMessages { get; set; }

        public virtual DbSet<WxReply> WxReplies { get; set; }

        public virtual DbSet<WxTopic> WxTopics { get; set; }

        public virtual DbSet<WxOfficalAccount> WxOfficalAccounts { get; set; }

        public virtual DbSet<WxMember> WxMembers { get; set; }

        public virtual DbSet<WxSiteMenu> WxSiteMenus { get; set; }

        #endregion

        public DbSet<Member> Members { get; set; }

        public DbSet<Optimizator> Optimizators { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<OptimizatorTeam> OptimizatorTeams { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Tender> Tenders { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<SiteTemplate> SiteTemplates { get; set; }

        public DbSet<Commission> Commissions { get; set; }
        
        public DbSet<Articles.Domain.ArticleCategory> ArticleCategorys { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<IndustryInfo> IndustryInfoes { get; set; }

        public DbSet<SearchPlatform> SearchPlatforms { get; set; }

        public DbSet<KeyWordRankHistory> KeyWordRankHistorys { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SiteSetting> SiteSetting { get; set; }

        public DbSet<FriendLink> FriendLinks { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<OptimizationTask> Tasks { get; set; }

        public DbSet<OptimizationLog> OptimizationLogs { get; set; }

        public DbSet<Agent> Agents { get; set; }

    }
}
