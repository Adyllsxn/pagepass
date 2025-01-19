﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagePass.Infrastructure.Data;

#nullable disable

namespace PagePass.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241119124616_CREATEUSUARIOS")]
    partial class CREATEUSUARIOS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PagePass.Domain.Entities.ClienteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CliBI")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliBairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliCidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliEndereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliNome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliNumero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliTelefoneCelular")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CliTelefoneFixo")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("TBL_CLIENTES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CliBI = "007623437LD032",
                            CliBairro = "Benfica",
                            CliCidade = "Luanda",
                            CliEndereco = "Benfica Casa N 01",
                            CliNome = "Pedro Narciso",
                            CliNumero = "12",
                            CliTelefoneCelular = "+244 914 765 765",
                            CliTelefoneFixo = "+244 986 322 000"
                        },
                        new
                        {
                            Id = 2,
                            CliBI = "007623437LD032",
                            CliBairro = "Zango",
                            CliCidade = "Luanda",
                            CliEndereco = "Zango Casa N 01",
                            CliNome = "Maria Sousa",
                            CliNumero = "10",
                            CliTelefoneCelular = "+244 934 654 765",
                            CliTelefoneFixo = "+244 986 111 123"
                        },
                        new
                        {
                            Id = 3,
                            CliBI = "007623437ZE032",
                            CliBairro = "Soyo",
                            CliCidade = "Soyo",
                            CliEndereco = "Soyo Casa N 01",
                            CliNome = "Luisa Bernada",
                            CliNumero = "10",
                            CliTelefoneCelular = "+244 934 000 000",
                            CliTelefoneFixo = "+244 924 123 987"
                        });
                });

            modelBuilder.Entity("PagePass.Domain.Entities.EmprestimoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Entrega")
                        .HasColumnType("bit");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdLivro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdLivro");

                    b.ToTable("TBL_EMPRESTIMOS", (string)null);
                });

            modelBuilder.Entity("PagePass.Domain.Entities.LivroEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LivroAnoPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("LivroAutor")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LivroEdicao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LivroEditora")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LivroNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("TBL_LIVROS", (string)null);
                });

            modelBuilder.Entity("PagePass.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("TBL_USUARIOS", (string)null);
                });

            modelBuilder.Entity("PagePass.Domain.Entities.EmprestimoEntity", b =>
                {
                    b.HasOne("PagePass.Domain.Entities.ClienteEntity", "Cliente")
                        .WithMany("Emprestimos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PagePass.Domain.Entities.LivroEntity", "Livro")
                        .WithMany("Emprestimos")
                        .HasForeignKey("IdLivro")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("PagePass.Domain.Entities.ClienteEntity", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("PagePass.Domain.Entities.LivroEntity", b =>
                {
                    b.Navigation("Emprestimos");
                });
#pragma warning restore 612, 618
        }
    }
}
