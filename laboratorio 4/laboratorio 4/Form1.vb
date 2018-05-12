Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Form_Desconectado
        frm.Activate()
        'frm.Invoke()
        frm.Refresh()
        frm.Show()


    End Sub
End Class
