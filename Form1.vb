Imports System

Public Class Form1
    Dim arrNums(100000) As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initArray()
        Dim s As New Stopwatch
        s.Reset()
        s.Start()
        method1()
        s.Stop()
        ListBox1.Items.Add(s.ElapsedMilliseconds & " mseconds " & "m1")
        initArray()
        s.Reset()
        s.Start()
        method2()
        s.Stop()
        ListBox1.Items.Add(s.ElapsedMilliseconds & " mseconds " & "m2")
        initArray()
        s.Reset()
        s.Start()
        method3()
        s.Stop()
        ListBox1.Items.Add(s.ElapsedMilliseconds & " mseconds " & "m3")
    End Sub

    Private Sub initArray()
        Randomize()
        For i = 1 To 100000
            arrNums(i) = i
        Next i
    End Sub
    Private Sub method1()
        Dim temp As Integer
        Dim found As Boolean
        Dim maxNumber As Integer = 100000

        For i = 1 To maxNumber
            arrNums(i) = i
        Next i

        For i = 2 To maxNumber
            Do
                temp = Int(Rnd() * maxNumber) + 1
                found = False
                For j = 1 To i - 1
                    If temp = arrNums(j) Then
                        found = True
                        Exit For
                    End If
                Next j
            Loop Until Not found
            arrNums(i) = temp
        Next i
    End Sub

    Private Sub method2()
        Dim rand As Integer
        Dim temp As Integer
        For i = 1 To 100000
            rand = Int(Rnd() * 100000) + 1
            temp = arrNums(i)
            arrNums(i) = arrNums(rand)
            arrNums(rand) = temp
        Next i
    End Sub

    Private Sub method3()
        Dim r As Integer
        Dim flags(100000) As Boolean
        For i = 1 To 100000
            flags(i) = False
        Next i
        For i = 1 To 100000
            Do
                r = Int(Rnd() * 100000) + 1
            Loop While flags(r)
            flags(r) = True
            arrNums(i) = arrNums(r)
        Next i
    End Sub
End Class
