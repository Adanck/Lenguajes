Imports System.Data.SqlClient
Imports System.IO
Imports System.Data

Public Class Conectado


    Private connection As New SqlConnection
    Private tblDatosPersonas As New DataTable
    Private strNombre As String
    Private strApellido1 As String
    Private strApellido2 As String
    Private adpAdaptador As SqlDataAdapter
    Private cadena As String = My.Settings.MyConnectio

    Private Sub cargarConectado()

        connection.ConnectionString = cadena

        Dim fileReader As StreamReader
        Dim line As String
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\yeric\Downloads\UCR\10 Registros.txt")
        line = fileReader.ReadLine

        tblDatosPersonas.Columns.Add("Nombre")
        tblDatosPersonas.Columns.Add("Apellido1")
        tblDatosPersonas.Columns.Add("Apellido2")

        openConnection()
        adpAdaptador.Fill(tblDatosPersonas)
        closeConnection()

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

            adpAdaptador.InsertCommand = createInsert()
            openConnection()
            adpAdaptador.Update(tblDatosPersonas)
            closeConnection()
        Loop


    End Sub

    Private Function createInsert()
        Dim cmdinsert As New SqlCommand("INSERT INTO Nombres (Nombre, Apellido1, Apellido2) VALUES (@nom, @ape1, @ape2)", connection)
        cmdinsert.Parameters.Add(New SqlParameter("@nom", SqlDbType.NVarChar, 20, "Nombre"))
        cmdinsert.Parameters.Add(New SqlParameter("@ape1", SqlDbType.NVarChar, 100, "Apellido1"))
        cmdinsert.Parameters.Add(New SqlParameter("@ape2", SqlDbType.NVarChar, 200, "Apellido2"))
        Return cmdinsert
    End Function

    Private Sub openConnection()
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If
    End Sub

    Private Sub closeConnection()
        If connection.State <> ConnectionState.Closed Then
            connection.Close()
        End If
    End Sub


End Class
