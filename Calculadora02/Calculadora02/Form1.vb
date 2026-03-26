Public Class Form1
    ' Variáveis para armazenar os cálculos
    Dim valor1 As Double
    Dim operacao As String
    Dim limparTela As Boolean = False

    ' Este evento cuida de TODOS os botões que você listou
    Private Sub Botoes_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click

        Dim botao As Button = CType(sender, Button)
        Dim textoBotao As String = botao.Text

        ' 1. Lógica para Números
        If IsNumeric(textoBotao) Then
            If limparTela Then
                TextBox1.Text = ""
                limparTela = False
            End If
            TextBox1.Text &= textoBotao

            ' 2. Lógica para a Vírgula/Ponto decimal
        ElseIf textoBotao = "," Or textoBotao = "." Then
            If Not TextBox1.Text.Contains(",") Then
                TextBox1.Text &= ","
            End If

            ' 3. Lógica para Operadores (+, -, *, /)
        ElseIf textoBotao = "+" Or textoBotao = "-" Or textoBotao = "*" Or textoBotao = "/" Or textoBotao = "x" Then
            valor1 = Val(TextBox1.Text)
            operacao = textoBotao
            limparTela = True

            ' 4. Lógica para o Botão de Igual (=)
        ElseIf textoBotao = "=" Then
            Dim valor2 As Double = Val(TextBox1.Text)
            Dim resultado As Double

            Select Case operacao
                Case "+"
                    resultado = valor1 + valor2
                Case "-"
                    resultado = valor1 - valor2
                Case "*", "x"
                    resultado = valor1 * valor2
                Case "/"
                    If valor2 <> 0 Then
                        resultado = valor1 / valor2
                    Else
                        MsgBox("Não é possível dividir por zero!")
                    End If
            End Select

            TextBox1.Text = resultado.ToString()
            limparTela = True

            ' 5. Lógica para Limpar (C ou CE)
        ElseIf textoBotao.ToUpper() = "C" Or textoBotao.ToUpper() = "CE" Then
            TextBox1.Clear()
            valor1 = 0
            operacao = ""
        End If

    End Sub

    ' Eventos do TextBox (podem ficar vazios, mas mantive para não dar erro)
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class