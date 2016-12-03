namespace RetailStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ParentCategoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 80),
                        FirstName = c.String(maxLength: 60),
                        LastName = c.String(maxLength: 60),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Description = c.String(maxLength: 1000),
                        Cost = c.Decimal(nullable: false, precision: 19, scale: 4),
                        PreTaxPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        Price = c.Decimal(nullable: false, precision: 19, scale: 4),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DefaultPercentDiscount = c.Decimal(precision: 18, scale: 2),
                        MeasureID = c.Int(),
                        BarCode = c.String(maxLength: 250),
                        CategoryID = c.Int(),
                        Lot = c.String(maxLength: 300),
                        ExpirationDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.MeasureUnits", t => t.MeasureID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.MeasureID)
                .Index(t => t.BarCode, unique: true, name: "IX_Product_BarCode")
                .Index(t => t.CategoryID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.MeasureUnits",
                c => new
                    {
                        MeasureID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Symbol = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MeasureID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 19, scale: 4),
                        PreTaxPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        Price = c.Decimal(nullable: false, precision: 19, scale: 4),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PercentDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountDiscount = c.Decimal(nullable: false, precision: 19, scale: 4),
                        TotalPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        ClientID = c.Guid(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        PretaxPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        TotalPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        TypeID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        PercentDiscount = c.Decimal(precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(precision: 19, scale: 4),
                        CardNumber = c.String(maxLength: 25),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Contacts", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .ForeignKey("dbo.OrderTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.TypeID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Guid(nullable: false),
                        PersonID = c.Guid(nullable: false),
                        TypeID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.ContactTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.TypeID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.ContactMethodValues",
                c => new
                    {
                        ContactID = c.Guid(nullable: false),
                        ContactMethodID = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ContactID, t.ContactMethodID })
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .ForeignKey("dbo.ContactMethodTypes", t => t.ContactMethodID, cascadeDelete: true)
                .Index(t => t.ContactID)
                .Index(t => t.ContactMethodID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.ContactMethodTypes",
                c => new
                    {
                        MethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.MethodID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .Index(t => t.Name, unique: true, name: "IX_ContactMethodTypeName")
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 80),
                        LastName = c.String(maxLength: 80),
                        DNI = c.String(maxLength: 100),
                        Address = c.String(maxLength: 500),
                        Comments = c.String(),
                        BirthDay = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TypeID)
                .ForeignKey("dbo.Users", t => t.CreatedByID)
                .ForeignKey("dbo.Users", t => t.DeletedByID)
                .ForeignKey("dbo.Users", t => t.ModifiedByID)
                .Index(t => t.Name, unique: true, name: "IX_ContactTypeName")
                .Index(t => t.CreatedByID)
                .Index(t => t.ModifiedByID)
                .Index(t => t.DeletedByID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        OrderTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Credit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderTypeID);
            
            CreateTable(
                "dbo.OrderPaymentMethods",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        PaymentMethod_PaymentMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.PaymentMethod_PaymentMethodID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_PaymentMethodID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.PaymentMethod_PaymentMethodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "TypeID", "dbo.OrderTypes");
            DropForeignKey("dbo.OrderPaymentMethods", "PaymentMethod_PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.OrderPaymentMethods", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.Orders", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.Orders", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.Orders", "ClientID", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "TypeID", "dbo.ContactTypes");
            DropForeignKey("dbo.ContactTypes", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.ContactTypes", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.ContactTypes", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.Contacts", "PersonID", "dbo.People");
            DropForeignKey("dbo.People", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.People", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.People", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.Contacts", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.Contacts", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.Contacts", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodValues", "ContactMethodID", "dbo.ContactMethodTypes");
            DropForeignKey("dbo.ContactMethodTypes", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodTypes", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodTypes", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodValues", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodValues", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodValues", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.ContactMethodValues", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.OrderDetails", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.Products", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.Products", "MeasureID", "dbo.MeasureUnits");
            DropForeignKey("dbo.Products", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.Products", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.Categories", "ModifiedByID", "dbo.Users");
            DropForeignKey("dbo.Categories", "DeletedByID", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreatedByID", "dbo.Users");
            DropIndex("dbo.OrderPaymentMethods", new[] { "PaymentMethod_PaymentMethodID" });
            DropIndex("dbo.OrderPaymentMethods", new[] { "Order_OrderID" });
            DropIndex("dbo.ContactTypes", new[] { "DeletedByID" });
            DropIndex("dbo.ContactTypes", new[] { "ModifiedByID" });
            DropIndex("dbo.ContactTypes", new[] { "CreatedByID" });
            DropIndex("dbo.ContactTypes", "IX_ContactTypeName");
            DropIndex("dbo.People", new[] { "DeletedByID" });
            DropIndex("dbo.People", new[] { "ModifiedByID" });
            DropIndex("dbo.People", new[] { "CreatedByID" });
            DropIndex("dbo.ContactMethodTypes", new[] { "DeletedByID" });
            DropIndex("dbo.ContactMethodTypes", new[] { "ModifiedByID" });
            DropIndex("dbo.ContactMethodTypes", new[] { "CreatedByID" });
            DropIndex("dbo.ContactMethodTypes", "IX_ContactMethodTypeName");
            DropIndex("dbo.ContactMethodValues", new[] { "DeletedByID" });
            DropIndex("dbo.ContactMethodValues", new[] { "ModifiedByID" });
            DropIndex("dbo.ContactMethodValues", new[] { "CreatedByID" });
            DropIndex("dbo.ContactMethodValues", new[] { "ContactMethodID" });
            DropIndex("dbo.ContactMethodValues", new[] { "ContactID" });
            DropIndex("dbo.Contacts", new[] { "DeletedByID" });
            DropIndex("dbo.Contacts", new[] { "ModifiedByID" });
            DropIndex("dbo.Contacts", new[] { "CreatedByID" });
            DropIndex("dbo.Contacts", new[] { "TypeID" });
            DropIndex("dbo.Contacts", new[] { "PersonID" });
            DropIndex("dbo.Orders", new[] { "DeletedByID" });
            DropIndex("dbo.Orders", new[] { "ModifiedByID" });
            DropIndex("dbo.Orders", new[] { "CreatedByID" });
            DropIndex("dbo.Orders", new[] { "TypeID" });
            DropIndex("dbo.Orders", new[] { "ClientID" });
            DropIndex("dbo.OrderDetails", new[] { "DeletedByID" });
            DropIndex("dbo.OrderDetails", new[] { "ModifiedByID" });
            DropIndex("dbo.OrderDetails", new[] { "CreatedByID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "DeletedByID" });
            DropIndex("dbo.Products", new[] { "ModifiedByID" });
            DropIndex("dbo.Products", new[] { "CreatedByID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", "IX_Product_BarCode");
            DropIndex("dbo.Products", new[] { "MeasureID" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Categories", new[] { "DeletedByID" });
            DropIndex("dbo.Categories", new[] { "ModifiedByID" });
            DropIndex("dbo.Categories", new[] { "CreatedByID" });
            DropTable("dbo.OrderPaymentMethods");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.People");
            DropTable("dbo.ContactMethodTypes");
            DropTable("dbo.ContactMethodValues");
            DropTable("dbo.Contacts");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.MeasureUnits");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
