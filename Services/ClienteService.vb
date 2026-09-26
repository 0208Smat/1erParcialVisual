Imports EmpresaApiVB.Models
Imports EmpresaApiVB.Repositories
Imports System.Threading

Namespace Services
    Public Class ClienteService
        Implements IClienteService

        Private ReadOnly _repository As IClienteRepository

        Public Sub New(repository As IClienteRepository)
            _repository = repository
        End Sub

        Public Function GetAllAsync(cancellationToken As CancellationToken) As Task(Of List(Of Cliente)) Implements IClienteService.GetAllAsync
            Return _repository.GetAllAsync(cancellationToken)
        End Function

        Public Function GetByIdAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Cliente) Implements IClienteService.GetByIdAsync
            Return _repository.GetByIdAsync(id, cancellationToken)
        End Function

        Public Async Function CreateAsync(cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente) Implements IClienteService.CreateAsync
            Validate(cliente)
            Return Await _repository.AddAsync(cliente, cancellationToken)
        End Function

        Public Async Function UpdateAsync(id As Integer, cliente As Cliente, cancellationToken As CancellationToken) As Task(Of Cliente) Implements IClienteService.UpdateAsync
            Validate(cliente)

            Dim existing = Await _repository.GetByIdAsync(id, cancellationToken)
            If existing Is Nothing Then
                Return Nothing
            End If

            cliente.Id = id
            Return Await _repository.UpdateAsync(cliente, cancellationToken)
        End Function

        Public Function DeleteAsync(id As Integer, cancellationToken As CancellationToken) As Task(Of Boolean) Implements IClienteService.DeleteAsync
            Return _repository.DeleteAsync(id, cancellationToken)
        End Function

        Private Shared Sub Validate(cliente As Cliente)
            If cliente Is Nothing Then
                Throw New ArgumentNullException(NameOf(cliente))
            End If

            If String.IsNullOrWhiteSpace(cliente.Nombre) Then
                Throw New ArgumentException("El nombre es obligatorio.", NameOf(cliente))
            End If

            If String.IsNullOrWhiteSpace(cliente.Apellido) Then
                Throw New ArgumentException("El apellido es obligatorio.", NameOf(cliente))
            End If

            If String.IsNullOrWhiteSpace(cliente.Email) Then
                Throw New ArgumentException("El email es obligatorio.", NameOf(cliente))
            End If

            If String.IsNullOrWhiteSpace(cliente.Telefono) Then
                Throw New ArgumentException("El teléfono es obligatorio.", NameOf(cliente))
            End If
        End Sub
    End Class
End Namespace
