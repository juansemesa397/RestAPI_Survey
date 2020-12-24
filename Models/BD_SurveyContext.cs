using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPICore.Models
{
    public partial class BD_SurveyContext : DbContext
    {
        public BD_SurveyContext()
        {
        }

        public BD_SurveyContext(DbContextOptions<BD_SurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOrder> QuestionOrders { get; set; }
        public virtual DbSet<Respondent> Respondents { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("text");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("updated");
            });

            modelBuilder.Entity<QuestionOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("question_order");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.HasOne(d => d.Question)
                    .WithMany()
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_question_order_question");

                entity.HasOne(d => d.Survey)
                    .WithMany()
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_question_order_survey");
            });

            modelBuilder.Entity<Respondent>(entity =>
            {
                entity.ToTable("respondent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Hashedpassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hashedpassword");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("response");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("answer");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.RespondentId).HasColumnName("respondent_id");

                entity.Property(e => e.SurveyResponseId).HasColumnName("survey_response_id");

                entity.HasOne(d => d.Respondent)
                    .WithMany()
                    .HasForeignKey(d => d.RespondentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_response_respondent");

                entity.HasOne(d => d.SurveyResponse)
                    .WithMany()
                    .HasForeignKey(d => d.SurveyResponseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_response_survey_response");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("survey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("updated");
            });

            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.ToTable("survey_response");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RespondentId).HasColumnName("respondent_id");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("updated");

                entity.HasOne(d => d.Respondent)
                    .WithMany(p => p.SurveyResponses)
                    .HasForeignKey(d => d.RespondentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_survey_response_respondent");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyResponses)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_survey_response_survey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
