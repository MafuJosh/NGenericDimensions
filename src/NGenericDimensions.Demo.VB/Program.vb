Imports NGenericDimensions.Extensions
Imports NGenericDimensions.Extensions.Numbers
Imports NGenericDimensions.Lengths.MetricSI

Module Program
    Sub Main()
        Dim myspeed = 10.miles.per.hour
        Dim yourspeed = 20.kilometres / 2.minutes
        Dim mylength1 As New Length(Of Metres, Double)(100.0)
        Dim mylength2 As New Length(Of Metres, Double)(200.0)
        Dim mylength3 As Length(Of Metres, Double) = 300.0
        Dim mylenght4 = mylength1 + mylength2
        Dim myarea = mylength1 * mylength2
        Dim myarea2 As Area(Of Metres, Double) = myarea
        Dim myduration As New Duration(Of Durations.Minutes, Integer)(100)
    End Sub
End Module
