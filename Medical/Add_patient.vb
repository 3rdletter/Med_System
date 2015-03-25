Imports System.Data.SqlClient
Public Class Add_patient
    Dim gender As String
    Dim con As SqlConnection = New SqlConnection("Data Source=ADMIN-PC\SQLEXPRESS; Database=db_medical; Trusted_Connection =yes;")
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dr As SqlDataReader
    Private Sub Add_patient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        cmd = New SqlCommand("Insert Into tbl_patient_info (p_fname, p_mname, p_lastname, p_age, p_tnumber, p_religion, p_gender, p_cstatus, p_nationaliy, p_bloodtype, p_birthplace, p_address) Values ('" + txb_fname.Text + "','" + txb_mname.Text + "','" + txb_lname.Text + "','" + txb_age.Text + "','" + txb_tnumber.Text + "','" + txb_religion.Text + "','" + gender + "','" + cbx_cstatus.Text + "','" + txb_nationality.Text + "','" + cbx_btype.Text + "','" + txb_birthplace.Text + "','" + txb_paddress.Text + "')", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds, "db_medical")
        MsgBox("Save")
        Main.Show()
        Me.Hide()

    End Sub

End Class