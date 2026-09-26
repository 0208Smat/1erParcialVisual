Imports EmpresaApiVB.Models
Imports Microsoft.EntityFrameworkCore

Namespace Data
    Public Class EmpresaDbContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of EmpresaDbContext))
            MyBase.New(options)
        End Sub

        Public Property Clientes As DbSet(Of Cliente)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            modelBuilder.Entity(Of Cliente)(
                Sub(entity)
                    entity.ToTable("Clientes")
                    entity.HasKey(Function(c) c.Id)

                    entity.Property(Function(c) c.Id) _
                        .ValueGeneratedOnAdd()

                    entity.Property(Function(c) c.Nombre) _
                        .HasMaxLength(100) _
                        .IsRequired()

                    entity.Property(Function(c) c.Apellido) _
                        .HasMaxLength(100) _
                        .IsRequired()

                    entity.Property(Function(c) c.Email) _
                        .HasMaxLength(150) _
                        .IsRequired()

                    entity.Property(Function(c) c.Telefono) _
                        .HasMaxLength(30) _
                        .IsRequired()
                End Sub)
        End Sub
    End Class
End Namespace
