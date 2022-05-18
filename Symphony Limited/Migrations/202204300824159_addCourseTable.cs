namespace Symphony_Limited.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(),
                        CourseContent = c.String(),
                        CourseDate = c.DateTime(nullable: false),
                        CourseDuration = c.String(),
                        CourseImage = c.String(),
                        CoursePrice = c.Double(nullable: false),
                        FieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "FieldId", "dbo.Fields");
            DropIndex("dbo.Courses", new[] { "FieldId" });
            DropTable("dbo.Courses");
        }
    }
}
