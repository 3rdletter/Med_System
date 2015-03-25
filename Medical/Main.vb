Imports System.Data.SqlClient
Public Class Main
    Dim con As SqlConnection = New SqlConnection("Data Source=ADMIN-PC\SQLEXPRESS; Database=db_medical; Trusted_Connection =yes;")
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dr As SqlDataReader
    Friend ID As String
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listviewOne()
        listviewtwo()
        listviewthree()
    End Sub
    
    Private Sub TabControl1_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics
        Dim sText As String
        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF
        Dim ctlTab As TabControl

        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

        ctlTab = CType(sender, TabControl)

        g = e.Graphics
        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)
        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2

        If TabControl1.SelectedIndex = e.Index Then 'Selected Tab
            g.FillRectangle(SystemBrushes.ControlLightLight, e.Bounds) '<--- My modification
            'Else
            'This code is unnecessary because the control will automatically paint non-selected tabs
            '    g.FillRectangle(New SolidBrush(Color.LightBlue), e.Bounds)
        End If

        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    End Sub
    Private Sub listviewOne()
        Dim str As String = "Select * From tbl_login"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With

        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView1.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView1
                .Items.Add(TABLE.Rows(i)("username"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("password"))

                End With
            End With
        Next

    End Sub
    Private Sub listviewtwo()
        Dim str As String = "Select * From tbl_patient_info"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With

        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView2.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView2
                .Items.Add(TABLE.Rows(i)("p_id"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("p_fname"))

                End With
            End With
        Next
    End Sub
    Private Sub listviewthree()
        Dim str As String = "Select * From tbl_patient_info"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With

        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView3.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView3
                .Items.Add(TABLE.Rows(i)("p_id"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("p_fname"))
                    .Add(TABLE.Rows(i)("p_lastname"))

                End With
            End With
        Next
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        LoginForm1.Show()
        Me.Hide()
        con.Dispose()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ID = Nothing Then
            MsgBox("Please choose a record to delete.", MsgBoxStyle.Exclamation)
        Else
            Dim result As Integer = MessageBox.Show("Do you want to delete this table with ID#" + ListView1.SelectedItems(0).Text + "?", "caption", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Try

                    Dim str As String = "DELETE from tbl_login where username = '" + ListView1.SelectedItems(0).Text + "'"
                    Dim da As New SqlDataAdapter(str, con)
                    Dim ds As New DataSet
                    da.Fill(ds, "db_medical")
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                MsgBox("Information Deleted!")
            ElseIf result = DialogResult.No Then
                MsgBox("Information Not Deleted!")
            End If

            listviewOne()

        End If
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        ID = ListView1.SelectedItems(0).Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim str As String = "Select * From tbl_login where username = '" + txtbx_search1.Text + "'"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With

        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView1.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView1
                .Items.Add(TABLE.Rows(i)("username"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("password"))

                End With
            End With
        Next
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Add_patient.Show()
        Me.Hide()

    End Sub

    Private Sub btn_search2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search2.Click
        Dim str As String = "Select * From tbl_patient_info where p_fname = '" + txtbx_search1.Text + "'"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With

        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView2.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView2
                .Items.Add(TABLE.Rows(i)("p_id"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("p_fname"))

                End With
            End With
        Next
    End Sub
End Class
