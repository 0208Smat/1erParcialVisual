Imports EmpresaApiVB.Models
Imports System.Threading

Namespace Services
    Public Interface IClienteService
        Function GetAllAsync(cancellationToken As CancellationToken) As Task(Of List(Of Cliente))
        Function GetByIdAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Cliente)
        Function CreateAsync(cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente)
        Function UpdateAsync(id As Integer, cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente)
        Function DeleteAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Boolean)
    End Interface
End Namespace
