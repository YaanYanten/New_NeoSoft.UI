Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design

Namespace Controls

    ''' <summary>
    ''' Editor personalizado para la colección de items del RadioGroup
    ''' </summary>
    Public Class NXRadioGroupItemCollectionEditor
        Inherits CollectionEditor

        Public Sub New(type As Type)
            MyBase.New(type)
        End Sub

        Protected Overrides Function CreateCollectionItemType() As Type
            Return GetType(NXRadioGroupItem)
        End Function

        Protected Overrides Function CreateInstance(itemType As Type) As Object
            Dim item As New NXRadioGroupItem()
            item.Text = $"Item {Me.Context.Instance.Items.Count + 1}"
            Return item
        End Function

        Protected Overrides Function GetDisplayText(value As Object) As String
            If TypeOf value Is NXRadioGroupItem Then
                Dim item As NXRadioGroupItem = DirectCast(value, NXRadioGroupItem)
                Return item.Text
            End If
            Return MyBase.GetDisplayText(value)
        End Function

    End Class

End Namespace