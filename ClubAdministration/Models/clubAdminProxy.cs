namespace ClubAdministration.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class clubAdminProxy : DbContext
    {
        public clubAdminProxy()
            : base("name=clubadmins")
        {
        }

        public virtual DbSet<club_deposite> club_deposite { get; set; }
        public virtual DbSet<player_bodyshapes> player_bodyshapes { get; set; }
        public virtual DbSet<player_contacts> player_contacts { get; set; }
        public virtual DbSet<player_intelligences> player_intelligences { get; set; }
        public virtual DbSet<player_mindsets> player_mindsets { get; set; }
        public virtual DbSet<player_payouts> player_payouts { get; set; }
        public virtual DbSet<player_physical_fitness> player_physical_fitness { get; set; }
        public virtual DbSet<player_posts> player_posts { get; set; }
        public virtual DbSet<player_registerations> player_registerations { get; set; }
        public virtual DbSet<player_techniques> player_techniques { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<training_sessions> training_sessions { get; set; }
        public virtual DbSet<training_terms> training_terms { get; set; }
        public virtual DbSet<payment_category> payment_categories { get; set; }
        public virtual DbSet<player_sessions> player_sessions { get; set; }
        public virtual DbSet<training_fees> training_fees { get; set; }
        public virtual DbSet<coach> coaches { get; set; }
        public virtual DbSet<coach_training> coach_trainings { get; set; }
        public virtual DbSet<coach_certificates> coach_certificates { get; set; }
        public virtual DbSet<certificates_issuer> certificates_issuers { get; set; }
        public virtual DbSet<certificates_levels> certificates_levels { get; set; }
        public virtual DbSet<club_bankaccounts> club_bankaccounts { get; set; }
        public virtual DbSet<coach_sessions> coach_sessions { get; set; }
        public virtual DbSet<drill> drills { get; set; }
        public virtual DbSet<drill_emphasises> drill_emphasises { get; set; }
        public virtual DbSet<agelevel> agelevels { get; set; }
        public virtual DbSet<drill_types> drill_types { get; set; }
        public virtual DbSet<drill_patterns> drill_patterns { get; set; }
        public virtual DbSet<pattern_items> pattern_items { get; set; }
        public virtual DbSet<training_patterns> training_patterns { get; set; }
        public virtual DbSet<position> positions { get; set; }
        public virtual DbSet<drill_locations> drill_locations { get; set; }
        public virtual DbSet<drill_materials> drill_materials { get; set; }
        public virtual DbSet<material> materials { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<drill_skills> drillskills { get; set; }
        public virtual DbSet<drill_kpis> drill_kpis { get; set; }
        public virtual DbSet<metrics> metrics { get; set; }
        public virtual DbSet<metric_instances> metric_instances { get; set; }
        public virtual DbSet<metric_values> metric_values { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
//Club financial related data model configurations
            modelBuilder.Entity<club_assets>()
                .HasMany(e => e.player_assets)
                .WithRequired(e => e.club_assets)
                .HasForeignKey(e => e.asset_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<club_bankaccounts>()
                .HasMany(e => e.deposites)
                .WithRequired(e => e.club_bankaccount)
                .HasForeignKey(e => e.bankaccount_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<club_deposite>()
                .Property(e => e.payment_item)
                .IsUnicode(false);

            modelBuilder.Entity<club_deposite>()
                .HasMany(e => e.player_payouts)
                .WithRequired(e => e.club_deposite)
                .HasForeignKey(e => e.clubdeposite_id);

            modelBuilder.Entity<payment_category>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.payment_category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<player_payouts>()
                .HasMany(e => e.player_assets)
                .WithRequired(e => e.player_payouts)
                .HasForeignKey(e => e.playerpayment_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<training_terms>()
                .HasMany(e => e.training_fees)
                .WithRequired(e => e.training_term)
                .HasForeignKey(e => e.trainingterm_id);

//Coaches related data model configurations
            modelBuilder.Entity<coach>()
                .HasMany(e => e.coach_certificates)
                .WithRequired(e => e.coach)
                .HasForeignKey(e => e.coach_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<coach>()
                .HasMany(e => e.coach_trainings)
                .WithRequired(e => e.coach)
                .HasForeignKey(e => e.coach_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<certificates_issuer>()
                .HasMany(e => e.certificates)
                .WithRequired(e => e.issuer)
                .HasForeignKey(e => e.issuer_id)
                .WillCascadeOnDelete(false);

//Training programs related data model configurations
            modelBuilder.Entity<training_terms>()
                .HasMany(e => e.coach_training)
                .WithRequired(e => e.training_terms)
                .HasForeignKey(e => e.training_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<player_contacts>()
                .Property(e => e.address)
                .IsUnicode(true);

            modelBuilder.Entity<player>()
                .Property(e => e.name)
                .IsUnicode(true);

            modelBuilder.Entity<player>()
                .Property(e => e.familiy)
                .IsUnicode(true);

            modelBuilder.Entity<player>()
                .Property(e => e.Technical_Foot)
                .IsUnicode(true);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_bodyshapes)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_contacts)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_intelligences)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_mindsets)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_payouts)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_physical_fitness)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_posts)
                .WithOptional(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_registerations)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_sessions)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<player>()
                .HasMany(e => e.player_techniques)
                .WithRequired(e => e.player)
                .HasForeignKey(e => e.player_id);

            modelBuilder.Entity<training_sessions>()
                .HasMany(e => e.participants)
                .WithRequired(e => e.session)
                .HasForeignKey(e => e.session_id);

            modelBuilder.Entity<training_terms>()
                .Property(e => e.term_title)
                .IsUnicode(true);

            modelBuilder.Entity<training_terms>()
                .Property(e => e.weekdays)
                .IsUnicode(true);

            modelBuilder.Entity<training_terms>()
                .HasMany(e => e.player_registerations)
                .WithRequired(e => e.training_terms)
                .HasForeignKey(e => e.training_id);

            modelBuilder.Entity<training_terms>()
                .HasMany(e => e.training_sessions)
                .WithRequired(e => e.training_terms)
                .HasForeignKey(e => e.trainingterms_id);

            modelBuilder.Entity<training_sessions>()
                .HasMany(e => e.coaches)
                .WithRequired(e => e.session)
                .HasForeignKey(e => e.session_id);
        }

    }
}
