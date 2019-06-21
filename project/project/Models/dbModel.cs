namespace project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbModel : DbContext
    {
        public dbModel()
            : base("name=dbModel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Admin_Roles> Admin_Roles { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<Citzen> Citzens { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<Entity_Branchs> Entity_Branchs { get; set; }
        public virtual DbSet<Government> Governments { get; set; }
        public virtual DbSet<Official> Officials { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Admin_Roles)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Citzens)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.accptedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.city)
                .HasForeignKey(e => e.comCity);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.Entity)
                .HasForeignKey(e => e.comEntity_id);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Entity_Branchs)
                .WithRequired(e => e.Entity)
                .HasForeignKey(e => e.entity_id);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Officials)
                .WithOptional(e => e.Entity)
                .HasForeignKey(e => e.entityId);

            modelBuilder.Entity<Entity_Branchs>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.Entity_Branchs)
                .HasForeignKey(e => e.comEntitybranch_id);

            modelBuilder.Entity<Government>()
                .HasMany(e => e.cities)
                .WithRequired(e => e.Government)
                .HasForeignKey(e => e.gov_id);

            modelBuilder.Entity<Official>()
                .HasMany(e => e.Entities)
                .WithOptional(e => e.Official)
                .HasForeignKey(e => e.mangerId);

            modelBuilder.Entity<Official>()
                .HasMany(e => e.Officials1)
                .WithOptional(e => e.Official1)
                .HasForeignKey(e => e.leaderId);
        }
    }
}
