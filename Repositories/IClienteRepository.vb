Imports System.Threading
Imports EmpresaApiVB.Models

Namespace Repositories
    Public Interface IClienteRepository
        Function GetAllAsync(cancellationToken As CancellationToken) As Task(Of List(Of Cliente))
        Function GetByIdAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Cliente)
        Function AddAsync(cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente)
        Function UpdateAsync(cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente)
        Function DeleteAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Boolean)
    End Interface
End Namespace
