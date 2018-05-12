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
        'conn.Open()
        adapter.SelectCommand = New SqlCommand("Select * from Nombres", conn)
        table.Columns.Add("Nombre")
        table.Columns.Add("Apellido1")
        table.Columns.Add("Apellido2")
        adapter.Fill(table)
        reLoad()
        'conn.Close()
    End Sub

    Private Function createInsert()
        Dim cmdinsert As New SqlCommand("INSERT INTO Nombres (Nombre, Apellido1, Apellido2) VALUES (@nom, @ape1, @ape2)", conn)
        cmdinsert.Parameters.Add(New SqlParameter("@nom", SqlDbType.NVarChar, 20, "Nombre"))
        cmdinsert.Parameters.Add(New SqlParameter("@ape1", SqlDbType.NVarChar, 100, "Apellido1"))
        cmdinsert.Parameters.Add(New SqlParameter("@ape2", SqlDbType.NVarChar, 200, "Apellido2"))
        Return cmdinsert
    End Function
    Private Sub reLoad()
        Dim fileReader As StreamReader
        Dim line As String
        Dim time1 As Date = TimeOfDay

        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Adan\Downloads\10 Registros.txt")
        line = fileReader.ReadLine

        Do While line <> Nothing
            Dim vector = line.Split(" ")
            If (vector.Length = 3) Then
                strNombre = vector(0)
                strApellido = vector(1)
                strApellido2 = vector(2)
            ElseIf (vector.Length = 4) Then
                strNombre = vector(0) + " " + vector(1)
                strApellido = vector(2)
                strApellido2 = vector(3)
            ElseIf (vector.Length = 5) Then
                strNombre = vector(0) + " " + vector(1) + " " + vector(2)
                strApellido = vector(3)
                strApellido2 = vector(4)
            ElseIf (vector.Length = 6) Then
                strNombre = vector(0) + " " + vector(1) + " " + vector(2) + " " + vector(3)
                strApellido = vector(4)
                strApellido2 = vector(5)
            End If
            table.Rows.Add(strNombre, strApellido, strApellido2)
            line = fileReader.ReadLine
            'adapter.InsertCommand = createInsert()
            'adapter.Update(table)
        Loop
        adapter.InsertCommand = createInsert()
        adapter.Update(table)
        Dim time2 As Date = TimeOfDay

        MessageBox.Show("Tiempo en segundos" & DateDiff(DateInterval.Second, time2, time1))
    End Sub
End Class