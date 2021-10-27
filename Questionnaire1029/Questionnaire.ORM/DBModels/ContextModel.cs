using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.ORM.DBModels
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnectionString")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Question_Common> Question_Common { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Userinfo> Userinfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.A_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Answer>()
                .Property(e => e.A_age)
                .IsUnicode(false);

            modelBuilder.Entity<Question_Common>()
                .Property(e => e.QC_mustKeyin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Theme>()
                .Property(e => e.T_mustKeyin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Userinfo>()
                .Property(e => e.User_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Userinfo>()
                .Property(e => e.User_account)
                .IsUnicode(false);

            modelBuilder.Entity<Userinfo>()
                .Property(e => e.User_password)
                .IsUnicode(false);
        }
    }
}
