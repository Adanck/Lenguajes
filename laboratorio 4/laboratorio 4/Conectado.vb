Imports System.Data.SqlClient
Imports System.IO

Public Class Conectado


    Dim connection As New SqlConnection
    Dim tblDatosPersonas As New DataTable
    Dim strNombre As String
    Dim strApellido1 As String
    Dim strApellido2 As String

    Private Sub cargarConectado()


        connection.ConnectionString = My.Settings.conn
        Dim sentencias As New SqlCommand("", connection)

        Dim fileReader As StreamReader
        Dim line As String

        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\yeric\Downloads\UCR\10 Registros.txt")
        line = fileReader.ReadLine

        tblDatosPersonas.Columns.Add("Nombre")
        tblDatosPersonas.Columns.Add("Apellido1")
        tblDatosPersonas.Columns.Add("Apellido2")

        Do While line <> Nothing
            Dim vector = line.Split(" ")
            If (vector.Length > 3) Then
                strNombre = vector(0) + " " + vector(1)
                strApellido1 = vector(2)
                strApellido2 = vector(3)
            Else
                strNombre = vector(0)
                strApellido1 = vector(1)
                strApellido2 = vector(2)
            End If

            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If
            tblDatosPersonas.Rows.Add(strNombre, strApellido1, strApellido2)

            line = fileReader.ReadLine
        Loop
    End Sub

End Class
