Imports System.Data.SqlClient

Public Class FormListaCP
    Private dvCP As DataView

    '------------------------------------------------------------------------
    ' Capturo el evento de carga inicial del formulario, pongo un
    'radioButton a True y llamo a un metodo que cargue los datos en la lista
    '------------------------------------------------------------------------
    Private Sub FormListaCP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Copiamos la vista de la tabla de Ciudades
        dvCP = Form1.dvCP

        RadioButtonCP.Checked = true
        CargarListBox()
    End Sub

    '---------------------------------------------
    'Relleno el listBox con los datos del dataView
    '---------------------------------------------
    Private Sub CargarListBox()
        ListBoxCP.Items.Clear()

        Dim contador As Integer = 0

        If RadioButtonCP.Checked = True Then
            dvCP.Sort = "CP"
            While contador < dvCP.Count - 1
                ListBoxCP.Items.Add(dvCP(contador)("CP").ToString & " - " & dvCP(contador)("NOM_CIUTAT").ToString)

                contador = contador + 1
            End While
        Else
            dvCP.Sort = "NOM_CIUTAT"
            While contador < dvCP.Count - 1
                ListBoxCP.Items.Add(dvCP(contador)("CP").ToString & " - " & dvCP(contador)("NOM_CIUTAT").ToString)

                contador = contador + 1
            End While
        End If





    End Sub

    Private Sub RadioButtonPoblacion_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonPoblacion.CheckedChanged
        CargarListBox()

    End Sub

    Private Sub ButtonCerrar_Click(sender As Object, e As EventArgs) Handles ButtonCerrar.Click
        Me.Close()
    End Sub

    '-------------------------------------------------------------
    ' Cojo el CP selecionado y lo meto en el textbox del otro form
    '-------------------------------------------------------------
    Private Sub ButtonEscogerCodigo_Click(sender As Object, e As EventArgs) Handles ButtonEscogerCodigo.Click
        Dim cpSelecionado As String() = ListBoxCP.SelectedItem.split(" - ")
        Form1.TextBoxCP.Text = cpSelecionado(0)
        Me.Close()
    End Sub

    '----------------------------------------------------------
    'Metodo que va filtrando el listBox a medida que escribimos
    '----------------------------------------------------------
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBuscar.TextChanged
        Dim i As Integer
        For i = 0 To ListBoxCP.Items.Count - 1
            If i > ListBoxCP.Items.Count - 1 Then Exit For
            If Not ListBoxCP.Items(i).Contains(TextBoxBuscar.Text) Then
                ListBoxCP.Items.Remove(ListBoxCP.Items(i))
                i -= 1
            End If
        Next
        If TextBoxBuscar.Text = "" Then
            CargarListBox()

        End If
    End Sub
End Class