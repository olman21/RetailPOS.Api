namespace RetailStore.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class All_Classes_are_NOT_baseEntity : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ParentCategoryID = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
        }
        
        public override void Down()
        {
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ParentCategoryID = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedByID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedByID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedByID = c.Int(),
                        DeletedDate = c.DateTime(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
