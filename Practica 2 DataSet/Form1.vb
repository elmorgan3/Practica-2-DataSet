Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Form1
    Private con As SqlConnection
    Private ds As DataSet
    Private ada, ada2 As SqlDataAdapter

    Private registroActual As Integer
    Public dvCP, dvContacte As DataView
    Dim datosPorHacerPersistencia As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Abrimos la conexion con la base de datos
        con = New SqlConnection
        con.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CIUTATS; Trusted_Connection=True;"
        con.Open()

        ' Creamos el dataset, que es la base de datos virtual, con la que trabajaremos cargada en memoria
        ds = New DataSet()

        ' Creamos un adapter para hablar con la tabla de CONTACTO
        ada = New SqlDataAdapter("select CODI, NOM, CP, TELEFON, CATEGORIA, EMAIL, RISCMAXIM from CONTACTE", con)
        ' Creamos otro adapter para preguntar a la tabla de CIUTATS
        ada2 = New SqlDataAdapter("select CP, NOM_CIUTAT from CIUTAT", con)

        ' Generamos las sentencias de insert, update, delete ...
        ' si no hacemos esto no funcionara el update del adapter
        Dim cmBase As SqlCommandBuilder = New SqlCommandBuilder(ada)
        Dim cmBase2 As SqlCommandBuilder = New SqlCommandBuilder(ada2)

        ' Ejecutamos el adapter y cargamos en memoria la información y la estructura 
        ada.Fill(ds, "CONTACTE")
        ada2.Fill(ds, "CIUTAT")

        'Indicamos en la tabla cargada en menoria (DataSet), cual es la PK
        Dim pk(1) As DataColumn
        pk(0) = ds.Tables("contacte").Columns("CODI")
        ds.Tables("CONTACTE").PrimaryKey = pk

        'Indicamos cual es la FK
        Dim parentColumn As DataColumn = ds.Tables("CIUTAT").Columns("CP")
        Dim childColumn As DataColumn = ds.Tables("CONTACTE").Columns("CP")

        Dim foreignKeyConstraint As ForeignKeyConstraint
        foreignKeyConstraint = New ForeignKeyConstraint _
        ("SupplierForeignKeyConstraint", parentColumn, childColumn)
        ds.Tables("CONTACTE").Constraints.Add(foreignKeyConstraint)

        ' Vista de ciudades para usarla en el formListaCP
        dvCP = New DataView(ds.Tables("CIUTAT"))
        dvContacte = New DataView(ds.Tables("CONTACTE"))

        ' ordenar en memoria ram la vista
        'dv.Sort = "NOMBRECOMPANIA"

        ' filtrar el dataview en memoria ram
        ' s'escriu igual que el where de la consulta
        'dv.RowFilter = "saldo > 100 and antiguedad = 10"

        registroActual = 0
        MostrarRegistroActual()
    End Sub

    '------------------------------------------------------------------------------------------
    'Metodo que carga en los textbox los datos del valor que haya en la variable registroActual
    '------------------------------------------------------------------------------------------
    Private Sub MostrarRegistroActual()
        TextBoxCodigo.Text = ds.Tables("CONTACTE").Rows(registroActual)(0).ToString
        TextBoxNombre.Text = ds.Tables("CONTACTE").Rows(registroActual)(1).ToString
        TextBoxCP.Text = ds.Tables("CONTACTE").Rows(registroActual)(2).ToString
        TextBoxTelefono.Text = ds.Tables("CONTACTE").Rows(registroActual)(3).ToString
        TextBoxCategoria.Text = ds.Tables("CONTACTE").Rows(registroActual)(4).ToString
        TextBoxEmail.Text = ds.Tables("CONTACTE").Rows(registroActual)(5).ToString
        TextBoxRiesgoMax.Text = ds.Tables("CONTACTE").Rows(registroActual)(6).ToString
    End Sub

    '-------------------------------------------------
    'Metodo que muestra el primer registro de la tabla
    '-------------------------------------------------
    Private Sub ButtonPrimero_Click(sender As Object, e As EventArgs) Handles ButtonPrimero.Click
        registroActual = 0

        'Controlamos que el primer registro no este eliminado
        While ds.Tables("CONTACTE").Rows(registroActual).RowState = DataRowState.Deleted
            registroActual = registroActual + 1
        End While

        MostrarRegistroActual()
    End Sub

    '-------------------------------------------------
    'Metodo que muestra el anterior registro al actual
    '-------------------------------------------------
    Private Sub ButtonAnterior_Click(sender As Object, e As EventArgs) Handles ButtonAnterior.Click
        'Comprobamos que el registro actual no se el primero de la tabla
        If registroActual > 0 Then
            'Controlamos que el anterior registro no se haya eliminado
            Dim original As Integer = registroActual
            registroActual = registroActual - 1

            'En este bucle controlamos que el anterior registro no sea el primero y que el anterior no este eliminado
            While registroActual > 0 And ds.Tables("CONTACTE").Rows(registroActual).RowState = DataRowState.Deleted
                registroActual = registroActual - 1
            End While

            If registroActual >= 0 Then
                MostrarRegistroActual()
            Else
                registroActual = original
                MostrarRegistroActual()
            End If
        End If
    End Sub

    '--------------------------------------------------
    'Metodo que muestra el siguiente registro al actual
    '--------------------------------------------------
    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click
        'Comprobamos que el registro actual no se el ultimo de la tabla
        If registroActual < ds.Tables("CONTACTE").Rows.Count - 1 Then
            'Controlamos que el siguiente registro no se haya eliminado
            Dim original As Integer = registroActual
            registroActual = registroActual + 1

            'En este bucle controlamos que el siguiente registro no sea el ultimo y que el siguiente no este eliminado
            While registroActual < ds.Tables("CONTACTE").Rows.Count - 1 And ds.Tables("CONTACTE").Rows(registroActual).RowState = DataRowState.Deleted
                registroActual = registroActual + 1
            End While

            If registroActual <= ds.Tables("CONTACTE").Rows.Count - 1 Then
                MostrarRegistroActual()
            Else
                registroActual = original
                MostrarRegistroActual()
            End If
        End If
    End Sub

    '-------------------------------------------------
    'Metodo que muestra el ultimo registro de la tabla
    '-------------------------------------------------
    Private Sub ButtonUltimo_Click(sender As Object, e As EventArgs) Handles ButtonUltimo.Click
        'Guardamos en la variable cuantos registros hay y le restamos uno porque el DataSet funciona en base 0
        registroActual = ds.Tables("CONTACTE").Rows.Count - 1

        'Controlamos que el ultimo registro no este eliminado
        While ds.Tables("CONTACTE").Rows(registroActual).RowState = DataRowState.Deleted
            registroActual = registroActual - 1
        End While

        MostrarRegistroActual()
    End Sub

    '------------------------------------------------------
    'Metodo que muestra los datos del registro que indiquen
    '------------------------------------------------------
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Dim encontrado As Boolean = False
        registroActual = 0

        'En este bucle controlamos que el siguiente registro no sea el ultimo 
        While registroActual <= ds.Tables("CONTACTE").Rows.Count - 1
            If ds.Tables("CONTACTE").Rows(registroActual)(0).ToString = TextBoxBuscar.Text Then
                MostrarRegistroActual()
                encontrado = True
            End If
            registroActual = registroActual + 1
        End While

        If encontrado = False Then
            MsgBox("Este registro no existe")
        End If
    End Sub

    '---------------------------------
    'Metodo que crea un nuevo registro 
    '---------------------------------
    Private Sub ButtonNuevoContacto_Click(sender As Object, e As EventArgs) Handles ButtonNuevoContacto.Click
        Dim dr As DataRow

        dr = ds.Tables("CONTACTE").NewRow

        dr("CODI") = "Campo obligatorio"
        dr("NOM") = "Nombre desconocido"
        dr("CP") = DBNull.Value
        dr("TELEFON") = ""
        dr("CATEGORIA") = 0
        dr("EMAIL") = ""
        dr("RISCMAXIM") = 0

        ds.Tables("CONTACTE").Rows.Add(dr)

        registroActual = ds.Tables("CONTACTE").Rows.Count - 1
        MostrarRegistroActual()
    End Sub

    Private Sub ButtonGuardarCambios_Click(sender As Object, e As EventArgs) Handles ButtonGuardarCambios.Click
        GuardarCambios()
        datosPorHacerPersistencia = datosPorHacerPersistencia + 1
    End Sub

    '-------------------------------------------------------------
    'Metodo que guarda los cambios, en la tabla cargada en memoria 
    '-------------------------------------------------------------
    Private Sub GuardarCambios()


        If TextBoxNombre.Text = "" Then
            MsgBox("No puedes dejar el nombre vacio.")
            TextBoxNombre.Select()
            Exit Sub
        ElseIf IsNumeric(TextBoxRiesgoMax.Text) = False Then
            MsgBox("El riesgo maximo debe ser un valor numerico.")
            TextBoxRiesgoMax.Select()

        ElseIf TextBoxRiesgoMax.Text < 0 Then
            MsgBox("El riesgo maximo debe ser 0 o mayor.")
            TextBoxRiesgoMax.Select()

        ElseIf ValidateEmail(TextBoxEmail.Text) = True Or TextBoxEmail.Text = "" Then
            ds.Tables("CONTACTE").Rows(registroActual)(0) = TextBoxCodigo.Text
            ds.Tables("CONTACTE").Rows(registroActual)(1) = TextBoxNombre.Text
            If TextBoxCP.Text = "" Then
                ds.Tables("CONTACTE").Rows(registroActual)(2) = DBNull.Value
            Else
                Try
                    ds.Tables("CONTACTE").Rows(registroActual)(2) = TextBoxCP.Text
                Catch ex As Exception
                    MsgBox("Este codigo postal no existe")
                End Try

            End If

            ds.Tables("CONTACTE").Rows(registroActual)(3) = TextBoxTelefono.Text

            If TextBoxCategoria.Text = "" Then
                ds.Tables("CONTACTE").Rows(registroActual)(4) = DBNull.Value
            Else
                Try
                    ds.Tables("CONTACTE").Rows(registroActual)(4) = TextBoxCategoria.Text
                Catch ex As Exception
                    MsgBox("La categoria tiene que ser un valor numerico")
                End Try

            End If

            ds.Tables("CONTACTE").Rows(registroActual)(5) = TextBoxEmail.Text

            ds.Tables("CONTACTE").Rows(registroActual)(6) = TextBoxRiesgoMax.Text
        Else
            MsgBox("El email tiene un formato incorrecto.")
            TextBoxEmail.Select()
        End If
    End Sub

    '----------------------------------------------------------
    'Metodo que comprueba si el email tiene un formato correcto
    '----------------------------------------------------------
    Function ValidateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex(
        "^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match =
       emailRegex.Match(email)
        Return emailMatch.Success
    End Function

    '----------------------------------------------------------------------------------------------------------
    'Metodo que llama al metodo de GuardarCambios para comprobar si todo esta bien y luego al HacerPersistencia
    '-----------------------------------------------------------------------------------------------------------
    Private Sub ButtonPersistencia_Click(sender As Object, e As EventArgs) Handles ButtonPersistencia.Click

        HacerPersistencia()
    End Sub

    '-----------------------------------------------------------------------
    'Metodo que guarda los cambios, en la tabla de la base de datos original 
    '-----------------------------------------------------------------------
    Private Sub HacerPersistencia()
        ' METODO 1. Actualitzar toda la tabla
        'ada.Update(ds, "CONTACTE")

        ' METODO 2. Actualitzar solo los cambios, es mas eficiente
        Dim dt As DataTable
        dt = ds.Tables("CONTACTE").GetChanges()
        If IsNothing(dt) Then
            MsgBox("No hay nada que guardar")
        Else
            ada.Update(dt)
        End If


        ds.Tables("CONTACTE").AcceptChanges()
        datosPorHacerPersistencia = 0
    End Sub

    '----------------------------------------------------------------
    'Metodo que elimina el registro seleccionado de la base de datos
    '----------------------------------------------------------------
    Private Sub ButtonEliminarContacto_Click(sender As Object, e As EventArgs) Handles ButtonEliminarContacto.Click
        Dim result As Integer = MessageBox.Show("¿Seguro que desea eliminar este contacto?", "Atención", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            'MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.No Then
            'MessageBox.Show("No pressed")
        ElseIf result = DialogResult.Yes Then
            ds.Tables("CONTACTE").Rows(registroActual).Delete()
        End If

        HacerPersistencia()

        registroActual = 0
        MostrarRegistroActual()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If datosPorHacerPersistencia <> 0 Then
            Select Case MsgBox("Tienes datos pendientes de guardar ¿Seguro que quieres salir?", MsgBoxStyle.YesNo, "caption")
                Case MsgBoxResult.Yes
                    e.Cancel = False

                Case MsgBoxResult.No
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub TextBoxCodigo_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCodigo.TextChanged
        Dim contador As Integer = 0

        If dvContacte.RowFilter = "CODI like '%" & TextBoxCodigo.Text & "%'" Then
            contador = contador + 1
        End If
        If contador = 2 Then
            MsgBox("Este codigo ya existe debes cambiarlo para poder guardar")
            ButtonGuardarCambios.Enabled = False
            ButtonPersistencia.Enabled = False
        End If

        'Dim repetido As Integer = 1
        'Dim contador As Integer = 0

        'While contador < ds.Tables("CONTACTE").Rows.Count - 1


        '    If ds.Tables("CONTACTE").Rows(contador)(0).ToString = TextBoxCodigo.Text Then
        '        'MostrarRegistroActual()
        '        repetido = +1
        '    End If
        '    contador = contador + 1
        'End While

        'If repetido >1 Then
        '    MsgBox("Este codigo ya existe debes cambiarlo para poder guardar")
        '    ButtonGuardarCambios.Enabled = False
        '    ButtonPersistencia.Enabled = False
        'Else
        '    ButtonGuardarCambios.Enabled = True
        '    ButtonPersistencia.Enabled = True
        'End If
    End Sub

    '-------------------------------
    'Metodo que abre otro formulario 
    '-------------------------------
    Private Sub ButtonMostrarCP_Click(sender As Object, e As EventArgs) Handles ButtonMostrarCP.Click
        FormListaCP.ShowDialog()

    End Sub

End Class
