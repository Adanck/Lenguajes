Imports System.Data.SqlClient
Imports System.IO

Public Class Conectado


    Private connection As New SqlConnection
    Private tblDatosPersonas As New DataTable
    Private strNombre As String
    Private strApellido1 As String
    Private strApellido2 As String

    Private Sub cargarConectado()

        Dim cadena As String = My.Settings.conn
        connection.ConnectionString = cadena



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


        For Each row In tblDatosPersonas.Rows
            Dim column As DataColumn
            For Each column In tblDatosPersonas.Columns
                Console.WriteLine(row(column))
                Dim sentencias As New SqlCommand("Insert into Nombres(Nombre, Apellido1, Apellido2) values(@nom, @ape1, @ape2)", connection)

            Next column
        Next row



        For i = 0 To tblDatosPersonas.Rows.Count
            Dim sentencias As New SqlCommand("Insert into Nombres(Nombre, Apellido1, Apellido2) values(@nom, @ape1, @ape2)", connection)
            sentencias.Parameters.AddWithValue("@nom", tblDatosPersonas.
        Next

    End Sub

End Class
