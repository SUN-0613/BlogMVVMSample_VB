Imports BlogMVVMSample_VB.Forms.View

Class Application

    ''' <summary>プログラム起動</summary>
    ''' <param name="e">プログラム起動イベントデータ</param>
    Protected Overrides Sub OnStartup(e As StartupEventArgs)

        MyBase.OnStartup(e)

        Dim form As TextBoxView = New TextBoxView()

        form.ShowDialog()

    End Sub

End Class
