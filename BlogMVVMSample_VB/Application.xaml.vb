Imports BlogMVVMSample_VB.Forms.View

Class Application

    ''' <summary>プログラム起動</summary>
    ''' <param name="e">プログラム起動イベントデータ</param>
    Protected Overrides Sub OnStartup(e As StartupEventArgs)

        MyBase.OnStartup(e)

        Dim form As ComboBox2View = New ComboBox2View()

        form.ShowDialog()

    End Sub

End Class
