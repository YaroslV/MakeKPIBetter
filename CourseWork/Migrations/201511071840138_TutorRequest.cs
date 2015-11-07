namespace CourseWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TutorRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TutorRequests",
                c => new
                    {
                        TutorRequestId = c.String(nullable: false, maxLength: 128),
                        RequestUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TutorRequestId)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestUser_Id)
                .Index(t => t.RequestUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TutorRequests", "RequestUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TutorRequests", new[] { "RequestUser_Id" });
            DropTable("dbo.TutorRequests");
        }
    }
}
