Imports System.Data.SqlClient

Public Class kelola_petugas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        admin.Show()
        Me.Hide()
    End Sub

    Sub aturdgv()
        sql = "SELECT * FROM petugas"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "petugas")
        dgv_user.DataSource = ds.Tables("petugas")
    End Sub

    Sub kosong()
        txtidpeg.Text = ""
        txtnama.Text = ""
        txtpass.Text = ""
        txtpetugas.Text = ""
        Cblevel.Text = ""
        txtcari.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If txtidpeg.Text = "" Or txtnama.Text = "" Or txtpass.Text = "" Or txtpetugas.Text = "" Or Cblevel.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into petugas (id_petugas, username, password, nama_petugas, level) VALUES ('" & txtidpeg.Text & "', '" & txtnama.Text & "','" & txtpass.Text & "','" & txtpetugas.Text & "','" & Cblevel.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()
        If txtidpeg.Text = "" Or txtnama.Text = "" Or txtpass.Text = "" Or txtpetugas.Text = "" Or Cblevel.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE petugas set username='" & txtnama.Text & "',password= '" & txtpass.Text & "',nama_petugas= '" & txtpetugas.Text & "',level= '" & Cblevel.Text & "'where id_petugas='" & txtidpeg.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        connect()
        If txtidpeg.Text = "" Or txtnama.Text = "" Or txtpass.Text = "" Or txtpetugas.Text = "" Or Cblevel.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM petugas where id_petugas='" & txtidpeg.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcari.KeyPress
        sql = "SELECT * From petugas Where (nama_petugas like '%" & txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "petugas")
        dgv_user.DataSource = ds.Tables("petugas")
    End Sub

    Private Sub kelola_petugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        txtidpeg.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        txtpass.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        txtpetugas.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        Cblevel.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
    End Sub
    Private Sub txtidpeg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidpeg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan Angka Yang Di Inputkan")
            e.Handled = True
        End If
    End Sub
End Class