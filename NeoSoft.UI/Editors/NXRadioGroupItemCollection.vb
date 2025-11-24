Imports System.Collections.ObjectModel
Imports System.ComponentModel

Namespace Controls

    ''' <summary>
    ''' Colección de items para NXRadioGroup
    ''' </summary>
    Public Class NXRadioGroupItemCollection
        Inherits Collection(Of NXRadioGroupItem)

        Private ReadOnly _owner As NXRadioGroup

        Public Sub New(owner As NXRadioGroup)
            _owner = owner
        End Sub

        Protected Overrides Sub InsertItem(index As Integer, item As NXRadioGroupItem)
            MyBase.InsertItem(index, item)
            _owner.OnItemsChanged()
        End Sub

        Protected Overrides Sub RemoveItem(index As Integer)
            MyBase.RemoveItem(index)
            _owner.OnItemsChanged()
        End Sub

        Protected Overrides Sub SetItem(index As Integer, item As NXRadioGroupItem)
            MyBase.SetItem(index, item)
            _owner.OnItemsChanged()
        End Sub

        Protected Overrides Sub ClearItems()
            MyBase.ClearItems()
            _owner.OnItemsChanged()
        End Sub

    End Class

End Namespace