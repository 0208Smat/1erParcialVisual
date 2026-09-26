Imports EmpresaApiVB.Models
Imports EmpresaApiVB.Services
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports System.Threading

Namespace Controllers
    <ApiController>
    <Route("api/[controller]")>
    Public Class ClientesController
        Inherits ControllerBase

        Private ReadOnly _service As IClienteService

        Public Sub New(service As IClienteService)
            _service = service
        End Sub

        <HttpGet>
        Public Async Function GetAll(cancellationToken As CancellationToken) As Task(Of ActionResult(Of IEnumerable(Of Cliente)))
            Dim clientes = Await _service.GetAllAsync(cancellationToken)
            Return Ok(clientes)
        End Function

        <HttpGet("{id:int}")>
        Public Async Function GetById(id As Integer, cancellationToken As CancellationToken) As Task(Of ActionResult(Of Cliente))
            If id <= 0 Then
                Return BadRequest("El ID debe ser mayor que cero.")
            End If

            Dim cliente = Await _service.GetByIdAsync(id, cancellationToken)
            If cliente Is Nothing Then
                Return NotFound()
            End If

            Return Ok(cliente)
        End Function

        <HttpPost>
        Public Async Function Create(<FromBody> cliente As Cliente, cancellationToken As CancellationToken) As Task(Of ActionResult(Of Cliente))
            Try
                Dim created = Await _service.CreateAsync(cliente, cancellationToken)
                Return CreatedAtAction(NameOf(GetById), New With {.id = created.Id}, created)
            Catch ex As ArgumentException
                Return BadRequest(ex.Message)
            End Try
        End Function

        <HttpPut("{id:int}")>
        Public Async Function Update(id As Integer, <FromBody> cliente As Cliente, cancellationToken As CancellationToken) As Task(Of ActionResult(Of Cliente))
            If id <= 0 Then
                Return BadRequest("El ID debe ser mayor que cero.")
            End If

            Try
                Dim updated = Await _service.UpdateAsync(id, cliente, cancellationToken)
                If updated Is Nothing Then
                    Return NotFound()
                End If

                Return Ok(updated)
            Catch ex As ArgumentException
                Return BadRequest(ex.Message)
            End Try
        End Function

        <HttpDelete("{id:int}")>
        Public Async Function Delete(id As Integer, cancellationToken As CancellationToken) As Task(Of IActionResult)
            If id <= 0 Then
                Return BadRequest("El ID debe ser mayor que cero.")
            End If

            Dim deleted = Await _service.DeleteAsync(id, cancellationToken)
            If Not deleted Then
                Return NotFound()
            End If

            Return NoContent()
        End Function
    End Class
End Namespace
