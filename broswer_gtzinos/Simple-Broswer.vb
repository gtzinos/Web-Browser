Imports System.IO

Public Class Form1
    Dim path As String = ""

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

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click, tool_save.Click
        ' Create a file to write to.
        Try
            If (path = "") Then
                openfile.ShowDialog()
                path = openfile.FileName
            End If

            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine(notes.Text)
                sw.Flush()
            End Using
        Catch ex As Exception
            MsgBox("Cannot save your file.Something going wrong : " & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click, tool_open.Click, tool_new.Click
        Try
            Dim warningFile As Integer
            If (path Is "" = False Or notes.Text Is "" = False) Then
                warningFile = MessageBox.Show("You have some notes. Are you sure ?", "Warning <Open File>", MessageBoxButtons.YesNoCancel)
            End If

            If (warningFile = DialogResult.Yes Or notes.Text Is "" = True) Then
                openfile.ShowDialog()
                path = openfile.FileName
                ' Open the file to read from.
                Using sr As StreamReader = File.OpenText(path)
                    Do While sr.Peek() >= 0
                        notes.Text = sr.ReadToEnd
                    Loop
                End Using
            End If
        Catch ex As Exception
            MsgBox("Cannot open your file.Something going wrong : " & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click, tool_cut.Click
        notes.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        notes.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click, tool_paste.Click
        notes.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        notes.Undo()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            Dim warningFile As Integer
            If (path Is "" = False) Then
                warningFile = MessageBox.Show("You have an opened file. Are you sure ?", "Warning <Close File>", MessageBoxButtons.YesNoCancel)
            End If

            If (warningFile = DialogResult.Yes Or notes.Text Is Nothing = True) Then
                path = ""
                notes.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Cannot close your file.Something going wrong : " & vbCrLf & ex.Message)
        End Try
        
    End Sub
End Class
