Imports System.IO
Imports System.Data.SqlClient
Imports System.Data


Public Class Form_Desconectado

    Dim strNombre As String
    Dim strApellido As String
    Dim strApellido2 As String

    Dim conn As New SqlConnection(My.Settings.conn)
    Dim adapter As New SqlDataAdapter
    Dim table As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '  table.Columns.Add()
        reLoad()
    End Sub

    Public Function createInsert() As SqlClient.SqlCommand

        Dim cmdInsert As New SqlClient.SqlCommand
        cmdInsert.Connection = conn
        cmdInsert.CommandText = "Insert into persona(nombre, Apellido1, Apellido2)" & "values (@nom,@ape1,@ape2)"
        cmdInsert.Parameters.Add(New SqlClient.SqlParameter("@nom", SqlDbType.NVarChar, 50, "nombre"))
        cmdInsert.Parameters.Add(New SqlClient.SqlParameter("@ape1", SqlDbType.NVarChar, 50, "Apellido1"))
        cmdInsert.Parameters.Add(New SqlClient.SqlParameter("@ape2", SqlDbType.NVarChar, 50, "Apellido2"))
        Return cmdInsert

    End Function
    Private Sub reLoad()
        Dim fileReader As StreamReader
        Dim line As String

        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Adan\Downloads\10 Registros.txt")
        line = fileReader.ReadLine

        Do While line <> Nothing
            Dim vector = line.Split(" ")
            If (vector.Length > 3) Then
                strNombre = vector(0) + " " + vector(1)
                strApellido = vector(2)
                strApellido2 = vector(3)
            Else
                strNombre = vector(0)
                strApellido = vector(1)
                strApellido2 = vector(2)
            End If
            'table.Rows.Add(strNombre, strApellido, strApellido2)
            line = fileReader.ReadLine
            adapter.InsertCommand = createInsert()
        Loop



    End Sub
End Class