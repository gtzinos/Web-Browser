Imports System.IO

Public Class Form1
    Dim path As String = "c:\temp\MyTest.txt"

    Private Sub go_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles go_button.Click
        broswer.Navigate(url_textbox.Text)
    End Sub

    Private Sub home_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles home_button.Click
        broswer.Navigate("http://aetos.it.teithe.gr/~gtzinos")
        url_textbox.Text = "http://aetos.it.teithe.gr/~gtzinos"


    End Sub

    Private Sub refresh_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh_button.Click
        broswer.Refresh()
    End Sub

    Private Sub stop_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stop_button.Click
        broswer.Stop()
    End Sub

    Private Sub broswer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles broswer.ProgressChanged
        progress.Value = e.CurrentProgress
        If (broswer.CanGoBack) Then
            back_button.Enabled = True
        Else
            back_button.Enabled = False
        End If

        If (broswer.CanGoForward) Then
            forward_button.Enabled = True
        Else

            forward_button.Enabled = False
        End If
    End Sub

    Private Sub forward_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forward_button.Click
        broswer.GoForward()
    End Sub

    Private Sub back_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles back_button.Click
        broswer.GoBack()
    End Sub

    Private Sub url_textbox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles url_textbox.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            If (url_textbox.Text = "") Then
                broswer.Navigate("http://aetos.it.teithe.gr/~gtzinos")
                url_textbox.Text = "http://aetos.it.teithe.gr/~gtzinos"
            Else
                broswer.Navigate(url_textbox.Text)
            End If
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        If File.Exists(path) = False Then
            ' Create a file to write to.
            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine("Hello")
                sw.WriteLine("And")
                sw.WriteLine("Welcome")
                sw.Flush()
            End Using
        End If

    End Sub
End Class
