namespace CourseWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletetutorrequest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TutorRequests", "RequestUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TutorRequests", new[] { "RequestUser_Id" });
            DropTable("dbo.TutorRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TutorRequests",
                c => new
                    {
                        TutorRequestId = c.String(nullable: false, maxLength: 128),
                        RequestUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TutorRequestId);
            
            CreateIndex("dbo.TutorRequests", "RequestUser_Id");
            AddForeignKey("dbo.TutorRequests", "RequestUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
