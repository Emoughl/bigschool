﻿namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LecturedId = c.String(nullable: false),
                        Place = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Category_Id = c.Byte(),
                        Lectuter_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Lectuter_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Lectuter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lectuter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Lectuter_Id" });
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}