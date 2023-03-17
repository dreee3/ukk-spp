Imports System.Data.SqlClient

Public Class kelola_spp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        admin.Show()
        Me.Hide()
    End Sub

    Sub aturdgv()
        sql = "SELECT * FROM spp"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "spp")
        dgv_user.DataSource = ds.Tables("spp")
    End Sub

    Sub kosong()
        cbidspp.Text = ""
        txtthn.Text = ""
        txtnom.Text = ""
    End Sub

    Private Sub kelola_spp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If cbidspp.Text = "" Or txtthn.Text = "" Or txtnom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into spp (id_spp, tahun, nominal) VALUES ('" & cbidspp.Text & "', '" & txtthn.Text & "','" & txtnom.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()
        If cbidspp.Text = "" Or txtthn.Text = "" Or txtnom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE spp set tahun='" & txtthn.Text & "',nominal= '" & txtnom.Text & "'where id_spp='" & cbidspp.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        connect()
        If cbidspp.Text = "" Or txtthn.Text = "" Or txtnom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM spp where id_spp='" & cbidspp.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcari.KeyPress
        sql = "SELECT * From spp Where (tahun like '%" & Txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "spp")
        dgv_user.DataSource = ds.Tables("spp")
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        cbidspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txtthn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        txtnom.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value

    End Sub
    Private Sub cbidspp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbidspp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan Angka Yang Di Inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnom.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan Angka Yang Di Inputkan")
            e.Handled = True
        End If
    End Sub
    Private Sub txtthn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtthn.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan Angka Yang Di Inputkan")
            e.Handled = True
        End If
    End Sub
End Class