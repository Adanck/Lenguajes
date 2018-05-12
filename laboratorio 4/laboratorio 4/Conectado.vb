﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Data

Public Class Conectado

    Private connection As New SqlConnection
    Private tblDatosPersonas As New DataTable
    Private strNombre As String
    Private strApellido1 As String
    Private strApellido2 As String
    Private cadena As String = My.Settings.MyConnectio

    Public Sub cargarConectado()
        connection.ConnectionString = cadena

        Dim fileReader As StreamReader
        Dim line As String
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\yeric\Downloads\UCR\50000 Registros.txt")
        line = fileReader.ReadLine

        'tblDatosPersonas.Columns.Add("Nombre")
        'tblDatosPersonas.Columns.Add("Apellido1")
        'tblDatosPersonas.Columns.Add("Apellido2")


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

            ' tblDatosPersonas.Rows.Add(strNombre, strApellido1, strApellido2)
            insert()
            line = fileReader.ReadLine
        Loop
    End Sub

    Private Sub insert()
        Dim sentencia As New SqlCommand("INSERT INTO Nombres (Nombre, Apellido1, Apellido2) VALUES (@nom, @ape1, @ape2)", connection)
        sentencia.Parameters.AddWithValue("@nom", strNombre)
        sentencia.Parameters.AddWithValue("@ape1", strApellido1)
        sentencia.Parameters.AddWithValue("@ape2", strApellido2)
        openConnection()
        sentencia.ExecuteNonQuery()
        closeConnection()
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
