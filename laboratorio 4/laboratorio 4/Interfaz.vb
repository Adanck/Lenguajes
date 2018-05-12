Public Class Interfaz


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConectada.Click
        Dim classe As New Conectado
        classe.cargarConectado()
    End Sub

    Private Sub btnDesconectada_Click(sender As Object, e As EventArgs) Handles btnDesconectada.Click
        Dim frm As New Form_Desconectado
        frm.Activate()
        frm.Refresh()
        frm.Show()
    End Sub

    Private Sub btnConectadaUna_Click(sender As Object, e As EventArgs) Handles btnConectadaUna.Click
        Dim classe As New ConectadoUna
        classe.cargarConectadoUnaVez()
    End Sub
End Class
