Imports System.Data.SqlClient
Imports System.IO

Public Class ConectadoUna
    Private connection As New SqlConnection
    Private strNombre As String
    Private strApellido1 As String
    Private strApellido2 As String
    Private cadena As String = My.Settings.MyConnectio

    Public Sub cargarConectadoUnaVez()

        connection.ConnectionString = cadena
        Dim fileReader As StreamReader
        Dim line As String
        Dim time As Date = TimeOfDay
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Adan\Downloads\50000 Registros.txt")
        line = fileReader.ReadLine

        openConnection()
        Do While line <> Nothing
            Dim vector = line.Split(" ")
            If (vector.Length = 3) Then
                strNombre = vector(0)
                strApellido1 = vector(1)
                strApellido2 = vector(2)
            ElseIf (vector.Length = 4) Then
                strNombre = vector(0) + " " + vector(1)
                strApellido1 = vector(2)
                strApellido2 = vector(3)
            ElseIf (vector.Length = 5) Then
                strNombre = vector(0) + " " + vector(1) + " " + vector(2)
                strApellido1 = vector(3)
                strApellido2 = vector(4)
            ElseIf (vector.Length = 6) Then
                strNombre = vector(0) + " " + vector(1) + " " + vector(2) + " " + vector(3)
                strApellido1 = vector(4)
                strApellido2 = vector(5)
            End If

            insert()
            line = fileReader.ReadLine
        Loop
        closeConnection()
        Dim time2 As Date = TimeOfDay

        MessageBox.Show("Tiempo en segundos" & DateDiff(DateInterval.Second, time2, time))
    End Sub

    Private Sub insert()
        Dim sentencia As New SqlCommand("INSERT INTO Nombres (Nombre, Apellido1, Apellido2) VALUES (@nom, @ape1, @ape2)", connection)
        sentencia.Parameters.AddWithValue("@nom", strNombre)
        sentencia.Parameters.AddWithValue("@ape1", strApellido1)
        sentencia.Parameters.AddWithValue("@ape2", strApellido2)
        sentencia.ExecuteNonQuery()
    End Sub

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
