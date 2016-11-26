namespace YunKe.Commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                        SenderId = c.String(),
                        Link = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 128),
                        ShortDescription = c.String(maxLength: 128),
                        Content = c.String(),
                        ArticleCategoryId = c.String(nullable: false, maxLength: 128),
                        Author = c.String(maxLength: 128),
                        AuthorLink = c.String(maxLength: 256),
                        SourceUrl = c.String(maxLength: 256),
                        VoteAmount = c.Int(nullable: false),
                        ViewAmount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 256),
                        AllowComment = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCategories", t => t.ArticleCategoryId, cascadeDelete: true)
                .Index(t => t.ArticleCategoryId);
            
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        Code = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleComments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Content = c.String(maxLength: 500),
                        Author = c.String(maxLength: 128),
                        AuthorLink = c.String(maxLength: 256),
                        VoteAmount = c.Int(nullable: false),
                        ViewAmount = c.Int(nullable: false),
                        ArticleId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Commissions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PricingUnit = c.Int(nullable: false),
                        IncomeDate = c.DateTime(nullable: false),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Domain = c.String(nullable: false, maxLength: 128),
                        SeoInfo_DomainAge = c.Int(nullable: false),
                        SeoInfo_BaiduWeight = c.Int(nullable: false),
                        SeoInfo_IncludeAmount = c.Int(nullable: false),
                        SeoInfo_LinksAmount = c.Int(nullable: false),
                        SeoInfo_SitesAmountWithSameIP = c.Int(nullable: false),
                        SeoInfo_ServeRecord = c.String(maxLength: 128),
                        SeoInfo_SnapshotDate = c.DateTime(nullable: false),
                        SeoInfo_HasFtp = c.Boolean(nullable: false),
                        SeoInfo_Area = c.String(maxLength: 128),
                        Address_Country = c.String(maxLength: 128),
                        Address_City = c.String(maxLength: 128),
                        Address_Province = c.String(maxLength: 128),
                        Address_DetailAddress = c.String(maxLength: 512),
                        Address_Zip = c.String(maxLength: 128),
                        RankingStatus = c.Int(nullable: false),
                        Industry = c.String(maxLength: 128),
                        PricingUnit = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        FinishDate = c.DateTime(),
                        CancleReason = c.String(maxLength: 128),
                        Praise = c.Int(nullable: false),
                        AllowTendingAmount = c.Int(nullable: false),
                        SearchEngine = c.Int(nullable: false),
                        EndTendingDate = c.DateTime(),
                        StartTendingDate = c.DateTime(nullable: false),
                        OrderNumber = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Mobile = c.String(maxLength: 11),
                        Name = c.String(maxLength: 16),
                        NickName = c.String(maxLength: 32),
                        Password = c.String(maxLength: 256),
                        PayPassword = c.String(maxLength: 1024),
                        Email = c.String(maxLength: 256),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        Identity = c.String(maxLength: 20),
                        Address_Country = c.String(maxLength: 128),
                        Address_City = c.String(maxLength: 128),
                        Address_Province = c.String(maxLength: 128),
                        Address_DetailAddress = c.String(maxLength: 512),
                        Address_Zip = c.String(maxLength: 128),
                        MemberType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        OpenId = c.String(maxLength: 256),
                        IsRealNameValidated = c.Boolean(nullable: false),
                        IsEmailValidated = c.Boolean(nullable: false),
                        IsMobilePhoneValidated = c.Boolean(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmailActiveCode = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        VipLevel = c.Int(),
                        TeamId = c.String(maxLength: 128),
                        CompletingRate = c.Decimal(precision: 18, scale: 2),
                        Praise = c.Int(),
                        Level = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        OptimizatorTeam_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OptimizatorTeams", t => t.OptimizatorTeam_Id)
                .ForeignKey("dbo.OptimizatorTeams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.OptimizatorTeam_Id);
            
            CreateTable(
                "dbo.EducationHistories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                        SchoolName = c.String(maxLength: 128),
                        MajorIn = c.String(maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsFull = c.Boolean(nullable: false),
                        IsOutSea = c.Boolean(nullable: false),
                        Level = c.String(maxLength: 128),
                        Description = c.String(maxLength: 500),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MemberAddresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                        Address_Country = c.String(maxLength: 128),
                        Address_City = c.String(maxLength: 128),
                        Address_Province = c.String(maxLength: 128),
                        Address_DetailAddress = c.String(maxLength: 512),
                        Address_Zip = c.String(maxLength: 128),
                        IsDefault = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.PaymentProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                        BankName = c.String(maxLength: 64),
                        CardNumber = c.String(maxLength: 64),
                        Province = c.String(maxLength: 64),
                        City = c.String(maxLength: 64),
                        State = c.String(maxLength: 64),
                        SubBankName = c.String(maxLength: 256),
                        IsPayTestPass = c.Boolean(nullable: false),
                        PassDate = c.DateTime(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.ValidationRecords",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                        ValidationType = c.Int(nullable: false),
                        IdentityCardImage = c.String(),
                        IdentityCardImageSecondary = c.String(),
                        Name = c.String(),
                        BusinessCreditNumber = c.String(maxLength: 64),
                        BusinessLicenceNumber = c.String(maxLength: 64),
                        BusinessLicenceScanImage = c.String(),
                        IsSeoerCooperationAgreementChecked = c.Boolean(nullable: false),
                        CompanyOwner = c.String(maxLength: 128),
                        CompanyPhone = c.String(maxLength: 128),
                        Industry = c.String(maxLength: 128),
                        CheckedDate = c.DateTime(),
                        PostCheckingDate = c.DateTime(),
                        IsPass = c.Boolean(nullable: false),
                        LastStatusReason = c.String(maxLength: 200),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.OptimizatorTeams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        TeamOwnerId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.TeamOwnerId, cascadeDelete: true)
                .Index(t => t.TeamOwnerId);
            
            CreateTable(
                "dbo.Tenders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSettled = c.Boolean(nullable: false),
                        TendingDate = c.DateTime(nullable: false),
                        PlanCompleteDate = c.DateTime(nullable: false),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OptimizatorId = c.String(maxLength: 128),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.OptimizatorId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.OptimizatorId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.OptimizationKeyWords",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        KeyWord = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PricingUnit = c.Int(nullable: false),
                        RankingStatus = c.Int(nullable: false),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        SystemPriceModel_PriceOfBaidu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfBaiduPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfBaiduPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfGoogle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfGooglePage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfGooglePage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOf360 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOf360Page1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOf360Page2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfSouGou = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfSouGouPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfSouGouPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfMobileBaidu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfMobileBaiduPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfMobileBaiduPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfShengMa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfShengMaPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfShengMaPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfBing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfBingPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SystemPriceModel_PriceOfBingPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfBaidu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfBaiduPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfBaiduPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfGoogle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfGooglePage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfGooglePage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOf360 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOf360Page1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOf360Page2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfSouGou = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfSouGouPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfSouGouPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfMobileBaidu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfMobileBaiduPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfMobileBaiduPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfShengMa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfShengMaPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfShengMaPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfBing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfBingPage1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceModel_PriceOfBingPage2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OriginalRanking_PageOfBaidu = c.Int(nullable: false),
                        OriginalRanking_PageOfGoogle = c.Int(nullable: false),
                        OriginalRanking_PageOf360 = c.Int(nullable: false),
                        OriginalRanking_PageOfSouGou = c.Int(nullable: false),
                        OriginalRanking_PageOfMobileBaidu = c.Int(nullable: false),
                        OriginalRanking_PageOfShengMa = c.Int(nullable: false),
                        OriginalRanking_PageOfBing = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.KeyWordRankHistories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ComputeDate = c.DateTime(nullable: false),
                        Page = c.Int(nullable: false),
                        LastDayPage = c.Int(nullable: false),
                        UpDownRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SearchEngineId = c.String(nullable: false, maxLength: 128),
                        SearchEngineName = c.String(),
                        Ranking_PageOfBaidu = c.Int(nullable: false),
                        Ranking_PageOfGoogle = c.Int(nullable: false),
                        Ranking_PageOf360 = c.Int(nullable: false),
                        Ranking_PageOfSouGou = c.Int(nullable: false),
                        Ranking_PageOfMobileBaidu = c.Int(nullable: false),
                        Ranking_PageOfShengMa = c.Int(nullable: false),
                        Ranking_PageOfBing = c.Int(nullable: false),
                        OptimizationKeyWordId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OptimizationKeyWords", t => t.OptimizationKeyWordId, cascadeDelete: true)
                .ForeignKey("dbo.SearchPlatforms", t => t.SearchEngineId, cascadeDelete: true)
                .Index(t => t.SearchEngineId)
                .Index(t => t.OptimizationKeyWordId);
            
            CreateTable(
                "dbo.SearchPlatforms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 32),
                        Icon = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FriendLinks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(maxLength: 128),
                        Link = c.String(maxLength: 1024),
                        Image = c.String(maxLength: 1024),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HelpArticles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 128),
                        ShortDescription = c.String(maxLength: 128),
                        Content = c.String(),
                        HelpArticleCategoryId = c.String(nullable: false, maxLength: 128),
                        Author = c.String(maxLength: 128),
                        AuthorLink = c.String(maxLength: 256),
                        ViewAmount = c.Int(nullable: false),
                        SourceUrl = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HelpArticleCategories", t => t.HelpArticleCategoryId, cascadeDelete: true)
                .Index(t => t.HelpArticleCategoryId);
            
            CreateTable(
                "dbo.HelpArticleCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        Code = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndustryInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 64),
                        Code = c.String(maxLength: 64),
                        Icon = c.String(maxLength: 64),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderNumber = c.String(),
                        PaymentProvider = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false),
                        QuestionCatalog = c.Int(nullable: false),
                        IsAnswered = c.Boolean(nullable: false),
                        Closed = c.Boolean(nullable: false),
                        Reply = c.String(maxLength: 500),
                        RaiseDate = c.DateTime(nullable: false),
                        ReplyDate = c.DateTime(),
                        OptimizatorId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        Domain = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Domain = c.String(nullable: false, maxLength: 128),
                        FtpAddress = c.String(nullable: false, maxLength: 128),
                        FtpPassword = c.String(nullable: false, maxLength: 128),
                        RdpAccount = c.String(maxLength: 128),
                        RdpPassword = c.String(maxLength: 128),
                        SiteTemplateId = c.String(maxLength: 128),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.SiteTemplates", t => t.SiteTemplateId)
                .Index(t => t.SiteTemplateId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.SiteTemplates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 256),
                        Color = c.String(maxLength: 32),
                        Industry = c.String(maxLength: 64),
                        CoverImage = c.String(maxLength: 512),
                        Images = c.String(maxLength: 1024),
                        TemplateFileUrl = c.String(maxLength: 1024),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SiteName = c.String(maxLength: 128),
                        Author = c.String(maxLength: 128),
                        FrontEndDomain = c.String(maxLength: 256),
                        Settings = c.String(),
                        SmsAccount = c.String(maxLength: 256),
                        SmsApiUrl = c.String(maxLength: 256),
                        SmsSecurity = c.String(maxLength: 256),
                        SmptAccount = c.String(maxLength: 128),
                        SmptPort = c.String(maxLength: 128),
                        Pop3 = c.String(maxLength: 128),
                        Pop3Port = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxMembers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OpenId = c.String(nullable: false, maxLength: 128),
                        Icon = c.String(maxLength: 512),
                        NickName = c.String(maxLength: 64),
                        Birthday = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        Province = c.String(maxLength: 128),
                        City = c.String(maxLength: 128),
                        IsSubscribed = c.Boolean(nullable: false),
                        Country = c.String(maxLength: 128),
                        SubscribedDate = c.DateTime(),
                        Sex = c.Int(nullable: false),
                        Language = c.String(maxLength: 16),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxMenus",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(maxLength: 50),
                        ParentId = c.String(maxLength: 128),
                        ReplyId = c.String(maxLength: 128),
                        Bind = c.Int(nullable: false),
                        Content = c.String(maxLength: 300),
                        Client = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxMessages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ReplyId = c.String(maxLength: 128),
                        Title = c.String(maxLength: 200),
                        ImageUrl = c.String(maxLength: 255),
                        Url = c.String(maxLength: 255),
                        Description = c.String(maxLength: 2000),
                        Content = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxOfficalAccounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AppId = c.String(nullable: false, maxLength: 200),
                        AppSecret = c.String(nullable: false, maxLength: 200),
                        UsingWxLoginFunction = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 128),
                        EndPoint = c.String(nullable: false, maxLength: 128),
                        Token = c.String(nullable: false, maxLength: 128),
                        MediaSourceServerPath = c.String(maxLength: 128),
                        MicroSiteHeaderImages = c.String(),
                        MicroSiteName = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxSiteMenus",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Icon = c.String(maxLength: 512),
                        Link = c.String(maxLength: 512),
                        Text = c.String(maxLength: 32),
                        WxAccountId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WxOfficalAccounts", t => t.WxAccountId, cascadeDelete: true)
                .Index(t => t.WxAccountId);
            
            CreateTable(
                "dbo.WxReplies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Keys = c.String(maxLength: 200),
                        MatchType = c.Int(nullable: false),
                        ReplyType = c.Int(nullable: false),
                        MessageType = c.Int(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                        LastModified = c.DateTime(),
                        LastModifier = c.String(),
                        Type = c.Int(nullable: false),
                        ActivityId = c.String(maxLength: 128),
                        Content = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxTopics",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 200),
                        IconUrl = c.String(maxLength: 300),
                        IsRelease = c.Boolean(nullable: false),
                        ShortBrief = c.String(nullable: false, maxLength: 200),
                        ViewCount = c.Int(nullable: false),
                        Content = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WxSiteMenus", "WxAccountId", "dbo.WxOfficalAccounts");
            DropForeignKey("dbo.Sites", "SiteTemplateId", "dbo.SiteTemplates");
            DropForeignKey("dbo.Sites", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Questions", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.HelpArticles", "HelpArticleCategoryId", "dbo.HelpArticleCategories");
            DropForeignKey("dbo.Commissions", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.KeyWordRankHistories", "SearchEngineId", "dbo.SearchPlatforms");
            DropForeignKey("dbo.KeyWordRankHistories", "OptimizationKeyWordId", "dbo.OptimizationKeyWords");
            DropForeignKey("dbo.OptimizationKeyWords", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CustomerId", "dbo.Members");
            DropForeignKey("dbo.EducationHistories", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Tenders", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tenders", "OptimizatorId", "dbo.Members");
            DropForeignKey("dbo.Members", "TeamId", "dbo.OptimizatorTeams");
            DropForeignKey("dbo.OptimizatorTeams", "TeamOwnerId", "dbo.Members");
            DropForeignKey("dbo.Members", "OptimizatorTeam_Id", "dbo.OptimizatorTeams");
            DropForeignKey("dbo.ValidationRecords", "MemberId", "dbo.Members");
            DropForeignKey("dbo.PaymentProfiles", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MemberAddresses", "MemberId", "dbo.Members");
            DropForeignKey("dbo.ArticleComments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ArticleCategoryId", "dbo.ArticleCategories");
            DropIndex("dbo.WxSiteMenus", new[] { "WxAccountId" });
            DropIndex("dbo.Sites", new[] { "ProjectId" });
            DropIndex("dbo.Sites", new[] { "SiteTemplateId" });
            DropIndex("dbo.Questions", new[] { "ProjectId" });
            DropIndex("dbo.HelpArticles", new[] { "HelpArticleCategoryId" });
            DropIndex("dbo.KeyWordRankHistories", new[] { "OptimizationKeyWordId" });
            DropIndex("dbo.KeyWordRankHistories", new[] { "SearchEngineId" });
            DropIndex("dbo.OptimizationKeyWords", new[] { "ProjectId" });
            DropIndex("dbo.Tenders", new[] { "ProjectId" });
            DropIndex("dbo.Tenders", new[] { "OptimizatorId" });
            DropIndex("dbo.OptimizatorTeams", new[] { "TeamOwnerId" });
            DropIndex("dbo.ValidationRecords", new[] { "MemberId" });
            DropIndex("dbo.PaymentProfiles", new[] { "MemberId" });
            DropIndex("dbo.MemberAddresses", new[] { "MemberId" });
            DropIndex("dbo.EducationHistories", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "OptimizatorTeam_Id" });
            DropIndex("dbo.Members", new[] { "TeamId" });
            DropIndex("dbo.Projects", new[] { "CustomerId" });
            DropIndex("dbo.Commissions", new[] { "ProjectId" });
            DropIndex("dbo.ArticleComments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "ArticleCategoryId" });
            DropTable("dbo.WxTopics");
            DropTable("dbo.WxReplies");
            DropTable("dbo.WxSiteMenus");
            DropTable("dbo.WxOfficalAccounts");
            DropTable("dbo.WxMessages");
            DropTable("dbo.WxMenus");
            DropTable("dbo.WxMembers");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.SiteTemplates");
            DropTable("dbo.Sites");
            DropTable("dbo.Questions");
            DropTable("dbo.Orders");
            DropTable("dbo.IndustryInfoes");
            DropTable("dbo.HelpArticleCategories");
            DropTable("dbo.HelpArticles");
            DropTable("dbo.FriendLinks");
            DropTable("dbo.SearchPlatforms");
            DropTable("dbo.KeyWordRankHistories");
            DropTable("dbo.OptimizationKeyWords");
            DropTable("dbo.Tenders");
            DropTable("dbo.OptimizatorTeams");
            DropTable("dbo.ValidationRecords");
            DropTable("dbo.PaymentProfiles");
            DropTable("dbo.MemberAddresses");
            DropTable("dbo.EducationHistories");
            DropTable("dbo.Members");
            DropTable("dbo.Projects");
            DropTable("dbo.Commissions");
            DropTable("dbo.ArticleComments");
            DropTable("dbo.ArticleCategories");
            DropTable("dbo.Articles");
            DropTable("dbo.Activities");
        }
    }
}
