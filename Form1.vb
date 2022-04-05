Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckedListBox1.Items.Add(InputBox("Sicil Numarası Giriniz")) 'Buton her tıklandığında yeni eleman eklemek için
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(CheckedListBox1.Items.Count.ToString()) 'Soruda textbox demiş oraya da yazılabilir. ToString() ' i sakın unutma!!!!!
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CheckedListBox1.CheckedItems.Count = 0 Then 'Seçim yapılmazsa silme olmayacağı için uyarı ver
            MsgBox("Seçim Yapmadınız")
        Else
            For i As Integer = CheckedListBox1.CheckedItems.Count - 1 To 0 Step -1
                CheckedListBox1.Items.Remove(CheckedListBox1.CheckedItems(i)) 'İşaretlenmiş Bütün elemanları silen for döngüsü
            Next
            MsgBox("Silindi") 'işlemin bittiği zaman uyarı vermesi için for döngüsünün dışına yazdım
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CheckedListBox1.Items.Insert(CInt(TextBox1.Text) - 1, TextBox2.Text) 'İstenilen eleman sırasına göre eleman ekleme 
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If CheckedListBox1.CheckedItems.Count = 0 Then 'Seçim yapılmazsa aktaramayacağı için uyarı verdim
            MsgBox("Seçim Yapmadınız")
        Else
            For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1 'Seçilmiş eleman sayısı kadar for döngüsü kurdum
                If ListBox1.Items.Contains(CheckedListBox1.CheckedItems(i)) = False Then 'ListBox içinde seçili eleman bulunmuyorsa
                    ListBox1.Items.Add(CheckedListBox1.CheckedItems(i)) 'Ekleme işlemi yaptı
                End If
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Add("Ad", 50)
        ListView1.Columns.Add("Soyad", 50)
        ListView1.Columns.Add("TC", 50)
        ListView1.Columns.Add("Yaş", 50)
        ListView1.Columns.Add("Uyruk", 50)

        CheckedListBox2.Items.Add("Takım1") '2. Soru için checkedlistbox'a değerler ekliyorum
        CheckedListBox2.Items.Add("Takım2") '2. Soru için checkedlistbox'a değerler ekliyorum
        CheckedListBox2.Items.Add("Takım3") '2. Soru için checkedlistbox'a değerler ekliyorum
        CheckedListBox2.Items.Add("Takım4") '2. Soru için checkedlistbox'a değerler ekliyorum
        RadioButton1.Checked = True 'Form açıldığında Radiobuttonların biri işaretli olsun diye ekledim
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress 'Ad alınacak. Sadece harf ve delete tuşu kullanılabilir
        If (Char.IsLetter(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) = False) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress 'Soyad alınacak. Sadece harf ve delete tuşu kullanılabilir
        If (Char.IsLetter(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) = False) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress 'TC Alınacak. Sadece rakam ve delete kullanılabilir.
        If (Char.IsDigit(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) = False) Then
            e.Handled = True
        End If
        TextBox5.MaxLength = 11 'TC 11 haneli olacağı için en fazla 11 hane izni veriyorum
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress 'Yaş alınacak. Sadece rakam ve delete kullanılabilir.
        If (Char.IsDigit(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) = False) Then
            e.Handled = True
        End If
        TextBox6.MaxLength = 3 'Soruda yaş en fazla 3 haneli olsun dediği için 3 ile kısıtlıyorum
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        'Adını boş girememesi için kontrol ekledim. TextBox'dan çıkış yapmaya çalışırken kontrol edilecek
        If TextBox3.Text = "" Then
            MsgBox("Adınızı Giriniz")
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        'Ad ile aynı mantık burda de geçerli. İçerisi boş olduğu sürece çıkış yapmasına izin vermicek
        If TextBox4.Text = "" Then
            MsgBox("Soyadınızı Giriniz")
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        'TC 11 haneli olacağını için 11 haneden farklı giriş varsa çıkış yaptırmıyorum
        If TextBox5.Text.Length <> 11 Then
            MsgBox("11 Haneli TC Giriniz")
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        'Yaş en az 1, en fazla 3 haneli olacak. Soruda koşul olarak verilmişti
        If TextBox6.Text.Length = 0 Then
            MsgBox("Yaşınızı Giriniz")
            TextBox6.Focus()
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim veri As New ListViewItem()
        veri = New ListViewItem(TextBox3.Text) 'Ad ekliyorum
        veri.SubItems.Add(TextBox4.Text) ' Soyad ekliyorum
        veri.SubItems.Add(TextBox5.Text) ' TC Ekliyorum
        veri.SubItems.Add(TextBox6.Text) 'Yaş ekliyorum
        'Alttaki if döngüsü checkboxtan uyruk almak için
        If RadioButton1.Checked Then
            veri.SubItems.Add(RadioButton1.Text)
        Else
            veri.SubItems.Add(RadioButton2.Text)
        End If
        ListView1.Items.Add(veri) 'Bilgileri doldurduktan sonra ekleme işlemi yapıyorum
    End Sub
End Class
