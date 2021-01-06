using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Provagas.Domains;

#nullable disable

namespace Api.Provagas.Contexts
{
    public partial class ProVagasContext : DbContext
    {
        public ProVagasContext()
        {
        }

        public ProVagasContext(DbContextOptions<ProVagasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Beneficio> Beneficio { get; set; }
        public virtual DbSet<BeneficioXvaga> BeneficioXvaga { get; set; }
        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estagio> Estagio { get; set; }
        public virtual DbSet<ExperienciaProfissional> ExperienciaProfissional { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<HabilidadeXcandidato> HabilidadeXcandidato { get; set; }
        public virtual DbSet<Inscricao> Inscricao { get; set; }
        public virtual DbSet<NivelEscolaridade> NivelEscolaridade { get; set; }
        public virtual DbSet<NivelVaga> NivelVaga { get; set; }
        public virtual DbSet<Requisito> Requisito { get; set; }
        public virtual DbSet<RequisitoXvaga> RequisitoXvaga { get; set; }
        public virtual DbSet<StatusInscricao> StatusInscricao { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<TipoVaga> TipoVaga { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vaga> Vagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PGC5401\\SQLEXPRESS; Initial Catalog=ProVagas; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A822F3A2E1");

                entity.ToTable("Administrador");

                entity.HasIndex(e => e.Nif, "UQ__Administ__C7DEC3306B43F011")
                    .IsUnique();

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nif)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("NIF")
                    .IsFixedLength(true);

                entity.Property(e => e.NomeCompletoAdmin)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadeSenai)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Administr__IdUsu__4F7CD00D");
            });

            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio)
                    .HasName("PK__Benefici__14B7CA0C23BE2494");

                entity.ToTable("Beneficio");

                entity.Property(e => e.NomeBeneficio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BeneficioXvaga>(entity =>
            {
                entity.HasKey(e => e.IdBeneficioVaga)
                    .HasName("PK__Benefici__44F955EBD12E7A84");

                entity.ToTable("BeneficioXVaga");

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.BeneficioXvagas)
                    .HasForeignKey(d => d.IdBeneficio)
                    .HasConstraintName("FK__Beneficio__IdBen__6FE99F9F");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.BeneficioXvagas)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Beneficio__IdVag__70DDC3D8");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.IdCandidato)
                    .HasName("PK__Candidat__D5598905DBAFF719");

                entity.ToTable("Candidato");

                entity.HasIndex(e => e.Cpf, "UQ__Candidat__C1F89731BEDFBD58")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.Curriculo)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.FotoPerfil).HasColumnType("image");

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompletoCandidato)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeDeficiencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeGenero)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeIdioma)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeNivel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TesteDePersonalidade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Candidato__IdEnd__4222D4EF");

                entity.HasOne(d => d.IdNivelEscolaridadeNavigation)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.IdNivelEscolaridade)
                    .HasConstraintName("FK__Candidato__IdNiv__4316F928");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK__Contrato__8569F05AA89FE07F");

                entity.Property(e => e.Candidato)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataAlertar).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033E718F7399");

                entity.ToTable("Empresa");

                entity.HasIndex(e => e.Cnpj, "UQ__Empresa__AA57D6B4F44B7BB7")
                    .IsUnique();

                entity.Property(e => e.Cnae)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CNAE")
                    .IsFixedLength(true);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.DescricaoEmpresa)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeParaContato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomePorte)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Empresa__IdEnder__534D60F1");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__0B7C7F17842B8F75");

                entity.ToTable("Endereco");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CEP")
                    .IsFixedLength(true);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Endereco__IdUsua__3C69FB99");
            });

            modelBuilder.Entity<Estagio>(entity =>
            {
                entity.HasKey(e => e.IdEstagio)
                    .HasName("PK__Estagio__C70AD76C9D3BB490");

                entity.ToTable("Estagio");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInscricaoNavigation)
                    .WithMany(p => p.Estagios)
                    .HasForeignKey(d => d.IdInscricao)
                    .HasConstraintName("FK__Estagio__IdInscr__6B24EA82");
            });

            modelBuilder.Entity<ExperienciaProfissional>(entity =>
            {
                entity.HasKey(e => e.IdExperienciaProfissional)
                    .HasName("PK__Experien__7772B9DEC78A52D9");

                entity.ToTable("ExperienciaProfissional");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DescricaoAtividade).HasColumnType("text");

                entity.Property(e => e.NomeEmpresa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeExperiencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.ExperienciaProfissionals)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Experienc__IdCan__45F365D3");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__0DD4B30DE362A211");

                entity.ToTable("Habilidade");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HabilidadeXcandidato>(entity =>
            {
                entity.HasKey(e => e.IdHabilidadeCandidato)
                    .HasName("PK__Habilida__F8880B5E1A367528");

                entity.ToTable("HabilidadeXCandidato");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.HabilidadeXcandidatos)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Habilidad__IdCan__4BAC3F29");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadeXcandidatos)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Habilidad__IdHab__4AB81AF0");
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__Inscrica__6209444B359F0310");

                entity.ToTable("Inscricao");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Inscricaos)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Inscricao__IdCan__68487DD7");

                entity.HasOne(d => d.IdStatusInscricaoNavigation)
                    .WithMany(p => p.Inscricaos)
                    .HasForeignKey(d => d.IdStatusInscricao)
                    .HasConstraintName("FK__Inscricao__IdSta__6754599E");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Inscricaos)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Inscricao__IdVag__66603565");
            });

            modelBuilder.Entity<NivelEscolaridade>(entity =>
            {
                entity.HasKey(e => e.IdNivelEscolaridade)
                    .HasName("PK__NivelEsc__8D4745273DA18E2C");

                entity.ToTable("NivelEscolaridade");

                entity.Property(e => e.Escolaridade)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelVaga>(entity =>
            {
                entity.HasKey(e => e.IdNivelVaga)
                    .HasName("PK__NivelVag__465CED7E5FB187DE");

                entity.ToTable("NivelVaga");

                entity.Property(e => e.NomeNivelVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requisito>(entity =>
            {
                entity.HasKey(e => e.IdRequisito)
                    .HasName("PK__Requisit__661FC7C21E52E134");

                entity.ToTable("Requisito");

                entity.Property(e => e.NomeRequisito)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequisitoXvaga>(entity =>
            {
                entity.HasKey(e => e.IdRequisitoVaga)
                    .HasName("PK__Requisit__A350B02327FB9B3F");

                entity.ToTable("RequisitoXVaga");

                entity.HasOne(d => d.IdRequisitoNavigation)
                    .WithMany(p => p.RequisitoXvagas)
                    .HasForeignKey(d => d.IdRequisito)
                    .HasConstraintName("FK__Requisito__IdReq__60A75C0F");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.RequisitoXvagas)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Requisito__IdVag__619B8048");
            });

            modelBuilder.Entity<StatusInscricao>(entity =>
            {
                entity.HasKey(e => e.IdStatusInscricao)
                    .HasName("PK__StatusIn__4F419FD782ACAE8E");

                entity.ToTable("StatusInscricao");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B0BA2F2A6");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVaga>(entity =>
            {
                entity.HasKey(e => e.IdTipoVaga)
                    .HasName("PK__TipoVaga__763461BC4FFCE161");

                entity.ToTable("TipoVaga");

                entity.Property(e => e.NomeTipoVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97963A4CC0");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053497C26992")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__398D8EEE");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__A848DC3E0520351B");

                entity.ToTable("Vaga");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Localizacao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__IdEmpresa__59FA5E80");

                entity.HasOne(d => d.IdNivelVagaNavigation)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.IdNivelVaga)
                    .HasConstraintName("FK__Vaga__IdNivelVag__5BE2A6F2");

                entity.HasOne(d => d.IdTipoVagaNavigation)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.IdTipoVaga)
                    .HasConstraintName("FK__Vaga__IdTipoVaga__5AEE82B9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
