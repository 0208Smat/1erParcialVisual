Imports EmpresaApiVB.Data
Imports EmpresaApiVB.Repositories
Imports EmpresaApiVB.Services
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Configuration

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        builder.Services.AddDbContext(Of EmpresaDbContext)(
            Sub(options)
                options.UseSqlServer(builder.Configuration.GetConnectionString("EmpresaDB"))
            End Sub)

        builder.Services.AddScoped(Of IClienteRepository, ClienteRepository)()
        builder.Services.AddScoped(Of IClienteService, ClienteService)()

        Dim app = builder.Build()

        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()
        app.MapControllers()

        app.Run()
    End Sub
End Module
