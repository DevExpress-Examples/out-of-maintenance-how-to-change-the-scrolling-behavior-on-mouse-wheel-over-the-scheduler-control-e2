Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace ChangeScrollValue
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			AddHandler schedulerControl1.MouseWheel, AddressOf schedulerControl1_MouseWheel
		End Sub

		Private Sub schedulerControl1_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim topRowTime As TimeSpan = schedulerControl1.DayView.TopRowTime
			Dim ti As New TimeInterval(schedulerControl1.ActiveView.SelectedInterval.Start.Date, topRowTime)
			If (e.Delta > 0 AndAlso ti.Duration.TotalSeconds = 0) OrElse (e.Delta < 0 AndAlso ti.Duration.TotalHours = 24) Then
				Return
			End If
			Dim delta As TimeSpan = TimeSpan.FromMinutes(schedulerControl1.DayView.TimeScale.TotalMinutes * 2)
			If e.Delta > 0 Then
				If topRowTime.TotalMinutes < delta.TotalMinutes Then
					schedulerControl1.DayView.TopRowTime = delta
				Else
					schedulerControl1.DayView.TopRowTime = topRowTime.Subtract(delta)
				End If
			Else
				Dim day As TimeSpan = TimeSpan.FromDays(1)
				If (day.Subtract(topRowTime)).TotalMinutes < delta.TotalMinutes Then
					schedulerControl1.DayView.TopRowTime = day
				Else
					schedulerControl1.DayView.TopRowTime = topRowTime.Add(delta)
				End If
			End If
		End Sub
	End Class
End Namespace
