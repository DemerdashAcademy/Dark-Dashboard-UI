Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf
Imports System.Windows.Media
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Guna2MouseStateHandler1.Add(pn_earn)
        InitializePanelBorders()
        ConfigureRevenueChart()
        ConfigureCashflowChart()

    End Sub

    Private Sub InitializePanelBorders()
        Dim panels = New Guna.UI2.WinForms.Guna2Panel() {pn_data, pn_overview, pn_city, pn_today, pn_earn, PN_1}

        For Each panel In panels
            panel.BorderColor = Color.FromArgb(64, 64, 64)
            panel.BorderThickness = 1
        Next
    End Sub

    Private Sub ConfigureRevenueChart()
        CartesianChart1.Series = New SeriesCollection From {
            New LineSeries With {
                .Title = "Revenue",
                .Values = New ChartValues(Of ObservablePoint) From {
                    New ObservablePoint(1, 4.8),
                    New ObservablePoint(2, 6.2),
                    New ObservablePoint(3, 7.6),
                    New ObservablePoint(4, 9.1)
                },
                .StrokeThickness = 3,
                .PointGeometrySize = 10,
                .Stroke = New SolidColorBrush(Color.FromRgb(69, 183, 245)),
                .Fill = New SolidColorBrush(Color.FromArgb(60, 69, 183, 245))
            }
        }

        CartesianChart1.AxisX = New AxesCollection From {
            New Axis With {
                .Title = "Quarter",
                .MinValue = 1,
                .MaxValue = 4,
                .LabelFormatter = Function(value) $"Q{CInt(value)}",
                .Foreground = New SolidColorBrush(Color.FromRgb(200, 205, 215))
            }
        }

        CartesianChart1.AxisY = New AxesCollection From {
            New Axis With {
                .Title = "Revenue (USD)",
                .LabelFormatter = Function(value) String.Format("${0:0.0}M", value),
                .Foreground = New SolidColorBrush(Color.FromRgb(200, 205, 215)),
                .Separator = New Separator With {
                    .StrokeThickness = 0
                }
            }
        }

        CartesianChart1.LegendLocation = LegendLocation.Bottom
        CartesianChart1.Background = New SolidColorBrush(Color.FromRgb(23, 25, 37))
    End Sub

    Private Sub ConfigureCashflowChart()
        CartesianChart2.Series = New SeriesCollection From {
            New LineSeries With {
                .Title = "Projected",
                .Values = New ChartValues(Of ObservablePoint) From {
                    New ObservablePoint(1, 3.5),
                    New ObservablePoint(2, 4.1),
                    New ObservablePoint(3, 4.6),
                    New ObservablePoint(4, 5.1),
                    New ObservablePoint(5, 5.7)
                },
                .StrokeThickness = 3,
                .PointGeometrySize = 9,
                .Stroke = New SolidColorBrush(Color.FromRgb(130, 89, 255)),
                .Fill = New SolidColorBrush(Color.FromArgb(50, 130, 89, 255))
            },
            New LineSeries With {
                .Title = "Actual",
                .Values = New ChartValues(Of ObservablePoint) From {
                    New ObservablePoint(1, 3.2),
                    New ObservablePoint(2, 4.4),
                    New ObservablePoint(3, 4.9),
                    New ObservablePoint(4, 5.5),
                    New ObservablePoint(5, 6.3)
                },
                .StrokeThickness = 3,
                .PointGeometrySize = 11,
                .Stroke = New SolidColorBrush(Color.FromRgb(69, 183, 245)),
                .Fill = New SolidColorBrush(Color.FromArgb(50, 69, 183, 245))
            }
        }

        CartesianChart2.AxisX = New AxesCollection From {
            New Axis With {
                .Title = "Week",
                .MinValue = 1,
                .MaxValue = 5,
                .LabelFormatter = Function(value) $"Week {CInt(value)}",
                .Foreground = New SolidColorBrush(Color.FromRgb(200, 205, 215))
            }
        }

        CartesianChart2.AxisY = New AxesCollection From {
            New Axis With {
                .Title = "Cash Flow (USD)",
                .LabelFormatter = Function(value) String.Format("${0:0.0}M", value),
                .Foreground = New SolidColorBrush(Color.FromRgb(200, 205, 215)),
                .Separator = New Separator With {
                    .StrokeThickness = 0
                }
            }
        }

        CartesianChart2.LegendLocation = LegendLocation.Bottom
        CartesianChart2.Background = New SolidColorBrush(Color.FromRgb(23, 25, 37))
    End Sub

    Private Sub Guna2MouseStateHandler1_HoverState(sender As Object, e As EventArgs) Handles Guna2MouseStateHandler1.HoverState
        pn_earn.BorderColor = Color.FromArgb(45, 156, 252)

    End Sub
    Private Sub Guna2MouseStateHandler1_IdleState(sender As Object, e As EventArgs) Handles Guna2MouseStateHandler1.IdleState
        pn_earn.BorderColor = Color.Gray

    End Sub
    Private Sub Guna2MouseStateHandler1_PressedState(sender As Object, e As EventArgs) Handles Guna2MouseStateHandler1.PressedState
        pn_earn.BorderColor = Color.Gray

    End Sub

    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        Application.ExitThread()
    End Sub
End Class
