Imports EmpresaApiVB.Data
Imports EmpresaApiVB.Models
Imports Microsoft.EntityFrameworkCore
Imports System.Threading

Namespace Repositories
    Public Class ClienteRepository
        Implements IClienteRepository

        Private ReadOnly _context As EmpresaDbContext

        Public Sub New(context As EmpresaDbContext)
            _context = context
        End Sub

        Public Async Function GetAllAsync(cancellationToken As CancellationToken) As Task(Of List(Of Cliente)) Implements IClienteRepository.GetAllAsync
            Return Await _context.Clientes.AsNoTracking().ToListAsync(cancellationToken)
        End Function

        Public Async Function GetByIdAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Cliente) Implements IClienteRepository.GetByIdAsync
            Return Await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(Function(c) c.Id = id, cancellationToken)
        End Function

        Public Async Function AddAsync(cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente) Implements IClienteRepository.AddAsync
            _context.Clientes.Add(cliente)
            Await _context.SaveChangesAsync(cancellationToken)
            Return cliente
        End Function

        Public Async Function UpdateAsync(cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente) Implements IClienteRepository.UpdateAsync
            _context.Clientes.Update(cliente)
            Await _context.SaveChangesAsync(cancellationToken)
            Return cliente
        End Function

        Public Async Function DeleteAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Boolean) Implements IClienteRepository.DeleteAsync
            Dim cliente = Await _context.Clientes.FirstOrDefaultAsync(Function(c) c.Id = id, cancellationToken)

            If cliente Is Nothing Then
                Return False
            End If

            _context.Clientes.Remove(cliente)
            Await _context.SaveChangesAsync(cancellationToken)
            Return True
        End Function
    End Class
End Namespace
