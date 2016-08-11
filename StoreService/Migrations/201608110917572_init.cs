namespace StoreService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Algorithms",
                c => new
                    {
                        AlgorithmId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AlgorithmId);
            
            CreateTable(
                "dbo.InputDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DataBytes = c.Binary(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.OutputDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DataBytes = c.Binary(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        ResearchId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CurentState = c.Int(nullable: false),
                        Algorithm_AlgorithmId = c.Int(),
                        InputData_Id = c.Int(),
                        OutputData_Id = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ResearchId)
                .ForeignKey("dbo.Algorithms", t => t.Algorithm_AlgorithmId)
                .ForeignKey("dbo.InputDatas", t => t.InputData_Id)
                .ForeignKey("dbo.OutputDatas", t => t.OutputData_Id)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Algorithm_AlgorithmId)
                .Index(t => t.InputData_Id)
                .Index(t => t.OutputData_Id)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        SessionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UsingAlgoritms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurentAlgoritm_AlgorithmId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Algorithms", t => t.CurentAlgoritm_AlgorithmId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.CurentAlgoritm_AlgorithmId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsingAlgoritms", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UsingAlgoritms", "CurentAlgoritm_AlgorithmId", "dbo.Algorithms");
            DropForeignKey("dbo.Researches", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.OutputDatas", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.InputDatas", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Researches", "OutputData_Id", "dbo.OutputDatas");
            DropForeignKey("dbo.Researches", "InputData_Id", "dbo.InputDatas");
            DropForeignKey("dbo.Researches", "Algorithm_AlgorithmId", "dbo.Algorithms");
            DropIndex("dbo.UsingAlgoritms", new[] { "User_UserId" });
            DropIndex("dbo.UsingAlgoritms", new[] { "CurentAlgoritm_AlgorithmId" });
            DropIndex("dbo.Researches", new[] { "User_UserId" });
            DropIndex("dbo.Researches", new[] { "OutputData_Id" });
            DropIndex("dbo.Researches", new[] { "InputData_Id" });
            DropIndex("dbo.Researches", new[] { "Algorithm_AlgorithmId" });
            DropIndex("dbo.OutputDatas", new[] { "User_UserId" });
            DropIndex("dbo.InputDatas", new[] { "User_UserId" });
            DropTable("dbo.UsingAlgoritms");
            DropTable("dbo.Users");
            DropTable("dbo.Researches");
            DropTable("dbo.OutputDatas");
            DropTable("dbo.InputDatas");
            DropTable("dbo.Algorithms");
        }
    }
}
