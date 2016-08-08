namespace BureauAppServiceService.Migrations.Business
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnsBusiness1Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "CreatedAt", c => c.DateTimeOffset(precision: 7,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                    },
                }));
            AddColumn("dbo.Activity", "Deleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "Deleted")
                    },
                }));
            AddColumn("dbo.Activity", "UpdatedAt", c => c.DateTimeOffset(precision: 7,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                    },
                }));
            AddColumn("dbo.Activity", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "Version")
                    },
                }));
            AddColumn("dbo.ProjectTasks", "CreatedAt", c => c.DateTimeOffset(precision: 7,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                    },
                }));
            AddColumn("dbo.ProjectTasks", "Deleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "Deleted")
                    },
                }));
            AddColumn("dbo.ProjectTasks", "UpdatedAt", c => c.DateTimeOffset(precision: 7,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                    },
                }));
            AddColumn("dbo.ProjectTasks", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ServiceTableColumn",
                        new AnnotationValues(oldValue: null, newValue: "Version")
                    },
                }));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectTasks", "Version",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "Version" },
                });
            DropColumn("dbo.ProjectTasks", "UpdatedAt",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "UpdatedAt" },
                });
            DropColumn("dbo.ProjectTasks", "Deleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "Deleted" },
                });
            DropColumn("dbo.ProjectTasks", "CreatedAt",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "CreatedAt" },
                });
            DropColumn("dbo.Activity", "Version",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "Version" },
                });
            DropColumn("dbo.Activity", "UpdatedAt",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "UpdatedAt" },
                });
            DropColumn("dbo.Activity", "Deleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "Deleted" },
                });
            DropColumn("dbo.Activity", "CreatedAt",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "ServiceTableColumn", "CreatedAt" },
                });
        }
    }
}
