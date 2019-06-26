namespace project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbProject : DbContext
    {
        public dbProject()
            : base("name=dbProject1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Admin_Roles> Admin_Roles { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<Citzen> Citzens { get; set; }
        public virtual DbSet<Common_Qustion> Common_Qustion { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Complaint_Catgories> Complaint_Catgories { get; set; }
        public virtual DbSet<defaulttext> defaulttexts { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<EntityBranchs> Entity_Branchs { get; set; }
        public virtual DbSet<Government> Governments { get; set; }
        public virtual DbSet<OfficialJob> OfficialJobs { get; set; }
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
                .WithOptional(e => e.Admin)
                .HasForeignKey(e => e.accptedBy);

            modelBuilder.Entity<city>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.city)
                .HasForeignKey(e => e.comCity);

            modelBuilder.Entity<Citzen>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.Citzen)
                .HasForeignKey(e => e.comCitzen);

            modelBuilder.Entity<Complaint_Catgories>()
                .HasMany(e => e.Complaints)
                .WithRequired(e => e.Complaint_Catgories)
                .HasForeignKey(e => e.comCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Entity_Branchs)
                .WithRequired(e => e.Entity)
                .HasForeignKey(e => e.entity_id);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Officials)
                .WithOptional(e => e.Entity)
                .HasForeignKey(e => e.entityId);

            modelBuilder.Entity<EntityBranchs>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.Entity_Branchs)
                .HasForeignKey(e => e.comEntitybranch);

            modelBuilder.Entity<Government>()
                .HasMany(e => e.cities)
                .WithRequired(e => e.Government)
                .HasForeignKey(e => e.gov_id);

            modelBuilder.Entity<OfficialJob>()
                .HasMany(e => e.Officials)
                .WithOptional(e => e.OfficialJob)
                .HasForeignKey(e => e.job_id);

            modelBuilder.Entity<Official>()
                .HasMany(e => e.Complaints)
                .WithOptional(e => e.Official)
                .HasForeignKey(e => e.solveby);

            modelBuilder.Entity<Official>()
                .HasMany(e => e.Complaints1)
                .WithOptional(e => e.Official1)
                .HasForeignKey(e => e.readby);

            modelBuilder.Entity<Official>()
                .HasMany(e => e.Entities)
                .WithRequired(e => e.Official)
                .HasForeignKey(e => e.mangerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Official>()
                .HasMany(e => e.Officials1)
                .WithOptional(e => e.Official1)
                .HasForeignKey(e => e.leaderId);
        }
    }
}
