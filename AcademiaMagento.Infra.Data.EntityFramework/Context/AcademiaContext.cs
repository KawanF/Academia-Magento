using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AcademiaMagento.Domain.Entities;


namespace AcademiaMagento.Infra.Data.EntityFramework.Context
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<MatriculaServico> MatriculaServicos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<AvaliacaoFisica> AvaliacoesFisicas { get; set; }
        public DbSet<RegistroAcesso> RegistrosAcesso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração Aluno
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nome).IsRequired().HasMaxLength(200);
                entity.Property(a => a.Email).IsRequired().HasMaxLength(150);
                entity.Property(a => a.CPF).IsRequired().HasMaxLength(11);
                entity.HasIndex(a => a.CPF).IsUnique();
                entity.HasIndex(a => a.Email).IsUnique();
            });

            // Configuração Servico
            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Nome).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Valor).HasColumnType("decimal(10,2)");
                entity.Property(s => s.Descricao).HasMaxLength(500);
            });

            // Configuração Matricula
            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.ValorTotal).HasColumnType("decimal(10,2)");

                entity.HasOne(m => m.Aluno)
                    .WithMany(a => a.Matriculas)
                    .HasForeignKey(m => m.AlunoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração MatriculaServico (N:N)
            modelBuilder.Entity<MatriculaServico>(entity =>
            {
                entity.HasKey(ms => ms.Id);
                entity.Property(ms => ms.ValorCobrado).HasColumnType("decimal(10,2)");

                entity.HasOne(ms => ms.Matricula)
                    .WithMany(m => m.MatriculaServicos)
                    .HasForeignKey(ms => ms.MatriculaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ms => ms.Servico)
                    .WithMany(s => s.MatriculaServicos)
                    .HasForeignKey(ms => ms.ServicoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração Pagamento
            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Valor).HasColumnType("decimal(10,2)");
                entity.Property(p => p.Metodo).IsRequired().HasMaxLength(50);

                entity.HasOne(p => p.Matricula)
                    .WithOne(m => m.Pagamento)
                    .HasForeignKey<Pagamento>(p => p.MatriculaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração AvaliacaoFisica
            modelBuilder.Entity<AvaliacaoFisica>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Observacoes).HasMaxLength(1000);

                entity.HasOne(a => a.Aluno)
                    .WithMany(al => al.AvaliacoesFisicas)
                    .HasForeignKey(a => a.AlunoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração RegistroAcesso
            modelBuilder.Entity<RegistroAcesso>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasOne(r => r.Aluno)
                    .WithMany(a => a.RegistrosAcesso)
                    .HasForeignKey(r => r.AlunoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}