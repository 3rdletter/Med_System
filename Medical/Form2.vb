Imports System.Data.SqlClient
Public Class Form2
    Dim con As SqlConnection = New SqlConnection("Data Source=ADMIN-PC\SQLEXPRESS; Database=db_medical; Trusted_Connection =yes;")
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dr As SqlDataReader

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      
    End Sub
End Class