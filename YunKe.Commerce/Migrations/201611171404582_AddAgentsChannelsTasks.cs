namespace YunKe.Commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgentsChannelsTasks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptimizationTasks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ReceiveDate = c.DateTime(nullable: false),
                        TotalIncomes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalFree = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OptimizatorId = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.OptimizatorId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.OptimizatorId);
            
            CreateTable(
                "dbo.OptimizationLogs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TaskId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 128),
                        Content = c.String(maxLength: 500),
                        OptimizatorId = c.String(maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OptimizationTasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            AddColumn("dbo.Projects", "OptimizatorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Members", "ChannelId", c => c.String(maxLength: 128));
            AddColumn("dbo.Members", "AgentId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tenders", "Plan", c => c.String(maxLength: 1024));
            CreateIndex("dbo.Members", "ChannelId");
            CreateIndex("dbo.Members", "AgentId");
            CreateIndex("dbo.Projects", "OptimizatorId");
            AddForeignKey("dbo.Members", "AgentId", "dbo.Members", "Id");
            AddForeignKey("dbo.Projects", "OptimizatorId", "dbo.Members", "Id");
            AddForeignKey("dbo.Members", "ChannelId", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "ChannelId", "dbo.Members");
            DropForeignKey("dbo.Projects", "OptimizatorId", "dbo.Members");
            DropForeignKey("dbo.OptimizationTasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.OptimizationTasks", "OptimizatorId", "dbo.Members");
            DropForeignKey("dbo.OptimizationLogs", "TaskId", "dbo.OptimizationTasks");
            DropForeignKey("dbo.Members", "AgentId", "dbo.Members");
            DropIndex("dbo.OptimizationLogs", new[] { "TaskId" });
            DropIndex("dbo.OptimizationTasks", new[] { "OptimizatorId" });
            DropIndex("dbo.OptimizationTasks", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "OptimizatorId" });
            DropIndex("dbo.Members", new[] { "AgentId" });
            DropIndex("dbo.Members", new[] { "ChannelId" });
            DropColumn("dbo.Tenders", "Plan");
            DropColumn("dbo.Members", "AgentId");
            DropColumn("dbo.Members", "ChannelId");
            DropColumn("dbo.Projects", "OptimizatorId");
            DropTable("dbo.OptimizationLogs");
            DropTable("dbo.OptimizationTasks");
        }
    }
}
