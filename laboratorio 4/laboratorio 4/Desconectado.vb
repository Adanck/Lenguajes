Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Public Class Desconectado

    Dim strNombre As String
    Dim strApellido As String
    Dim strApellido2 As String

    Dim conn As New SqlConnection(My.Settings.conn)
    Dim adapter As SqlDataAdapter
    Dim table As New DataTable

    'Private Sub load()

    'End Sub
    Private Function createInsert() As SqlClient.SqlCommand

        Dim cmdInsert As New SqlClient.SqlCommand
        cmdInsert.Connection = conn
        cmdInsert.CommandText = "Insert into persona(nombre, Apellido1, Apellido2)" & "values (@nom,@ape1,@ape2)"
        cmdInsert.Parameters.Add(New SqlClient.SqlParameter("@nom", SqlDbType.NVarChar, 50, "nombre"))
        cmdInsert.Parameters.Add(New SqlClient.SqlParameter("@ape1", SqlDbType.NVarChar, 50, "Apellido1"))
        cmdInsert.Parameters.Add(New SqlClient.SqlParameter("@ape2", SqlDbType.NVarChar, 50, "Apellido2"))
        Return cmdInsert

    End Function
    Private Sub load()
        Dim fileReader As StreamReader
        Dim line As String

        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\yeric\Downloads\UCR\50000 Registros.txt")
        line = fileReader.ReadLine


    End Sub

End Class
