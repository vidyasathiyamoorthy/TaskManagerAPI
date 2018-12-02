namespace TaskManagerAPIService.Migrationstask
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentTasks",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        ParentTaskName = c.String(),
                    })
                .PrimaryKey(t => t.ParentID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.ParentTasks", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ParentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ParentID", "dbo.ParentTasks");
            DropIndex("dbo.Tasks", new[] { "ParentID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.ParentTasks");
        }
    }
}
