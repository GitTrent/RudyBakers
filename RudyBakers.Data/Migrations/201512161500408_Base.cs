namespace RudyBakers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Apt = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HealthInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Price",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Int(nullable: false),
                        FoodItem_ID = c.Int(),
                        Item_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FoodItem", t => t.FoodItem_ID)
                .ForeignKey("dbo.Item", t => t.Item_ID)
                .Index(t => t.FoodItem_ID)
                .Index(t => t.Item_ID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Customer_ID = c.Int(),
                        PaymentMethod_ID = c.Int(),
                        ShipToAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.Customer_ID)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethod_ID)
                .ForeignKey("dbo.Address", t => t.ShipToAddress_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.PaymentMethod_ID)
                .Index(t => t.ShipToAddress_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChangeDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.Order_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ExpireDate = c.String(),
                        CVV = c.String(),
                        Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .Index(t => t.Address_ID);
            
            CreateTable(
                "dbo.FoodItemHealthInfo",
                c => new
                    {
                        FoodItem_ID = c.Int(nullable: false),
                        HealthInfo_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FoodItem_ID, t.HealthInfo_ID })
                .ForeignKey("dbo.FoodItem", t => t.FoodItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.HealthInfo", t => t.HealthInfo_ID, cascadeDelete: true)
                .Index(t => t.FoodItem_ID)
                .Index(t => t.HealthInfo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "ShipToAddress_ID", "dbo.Address");
            DropForeignKey("dbo.Order", "PaymentMethod_ID", "dbo.PaymentMethod");
            DropForeignKey("dbo.PaymentMethod", "Address_ID", "dbo.Address");
            DropForeignKey("dbo.OrderStatus", "Order_ID", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_ID", "dbo.User");
            DropForeignKey("dbo.Price", "Item_ID", "dbo.Item");
            DropForeignKey("dbo.Price", "FoodItem_ID", "dbo.FoodItem");
            DropForeignKey("dbo.FoodItemHealthInfo", "HealthInfo_ID", "dbo.HealthInfo");
            DropForeignKey("dbo.FoodItemHealthInfo", "FoodItem_ID", "dbo.FoodItem");
            DropIndex("dbo.FoodItemHealthInfo", new[] { "HealthInfo_ID" });
            DropIndex("dbo.FoodItemHealthInfo", new[] { "FoodItem_ID" });
            DropIndex("dbo.PaymentMethod", new[] { "Address_ID" });
            DropIndex("dbo.OrderStatus", new[] { "Order_ID" });
            DropIndex("dbo.Order", new[] { "ShipToAddress_ID" });
            DropIndex("dbo.Order", new[] { "PaymentMethod_ID" });
            DropIndex("dbo.Order", new[] { "Customer_ID" });
            DropIndex("dbo.Price", new[] { "Item_ID" });
            DropIndex("dbo.Price", new[] { "FoodItem_ID" });
            DropTable("dbo.FoodItemHealthInfo");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.Item");
            DropTable("dbo.Price");
            DropTable("dbo.HealthInfo");
            DropTable("dbo.FoodItem");
            DropTable("dbo.Address");
        }
    }
}
