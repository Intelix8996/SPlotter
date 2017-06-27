﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using LiveCharts; 
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.WinForms;

namespace SPlotter
{
    public partial class Form1 : Form
    {
        List<LineSeries> PointSeries = new List<LineSeries>();
        List<StepLineSeries> LineSeries = new List<StepLineSeries>();
        List<ChartValues<int>> Axles = new List<ChartValues<int>>();
        string[] SerialBufferList = { };
        string SerialBuffer = "";

        public bool isSettingsOpen = false;
        public bool isRangeAddEnabled = false;
        List<ChartValues<int>> BufferRangeList = new List<ChartValues<int>>();

        public Form1()
        {
            InitializeComponent();

            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.ReadTimeout = 500;
            serialPort1.WriteTimeout = 500;

            SerialMonitor_Text.Text = "";
            StatusLabel1.Text = "";

            Graph.Hoverable = false;

            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   
                .Y(model => model.Value);           

            Charting.For<MeasureModel>(mapper);

            Graph.DisableAnimations = false;
            Graph.AnimationsSpeed = new System.TimeSpan(0,0,0,0,150);

            Graph.Zoom = ZoomingOptions.Xy;
            Graph.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49));
            Graph.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(2),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
            Graph.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(4),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });

            for (int i = 0; i < PointSeries.Count; ++i)
            {
                Graph.Series.Add(PointSeries[i]);
                PointSeries[i] = ConfigurePointSeries(PointSeries[i]);
                PointSeries[i].Values = Axles[i];
            }
        }

        private void Open_Button_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
            }
            catch (System.UnauthorizedAccessException)
            {
                StatusLabel1.Text = "Error: port is busy";
            }
            catch (System.InvalidOperationException)
            {
                StatusLabel1.Text = "Error: port is already open";
            }
            catch (System.IO.IOException)
            {
                StatusLabel1.Text = "Error: port doesn't exist";
            }
            catch
            {
                StatusLabel1.Text = "Error: unidentified error";
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialBuffer = serialPort1.ReadLine();
            SerialBuffer.IsNormalized(NormalizationForm.FormKC);
            SerialBufferList = SerialBuffer.Split('&');

            try
            {
                if (!UpdateGraphTimer.Enabled && !isRangeAddEnabled)
                {
                    for (int i = 0; i < Axles.Count; ++i)
                    {
                        try { Axles[i].Add(Convert.ToInt32(SerialBufferList[i])); }
                        catch { }
                    }
                }
                else if (isRangeAddEnabled)
                {
                    for (int i = 0; i < Axles.Count; ++i)
                    {
                        try { BufferRangeList[i].Add(Convert.ToInt32(SerialBufferList[i])); }
                        catch { }
                    }
                }
            }
            catch { }

            BeginInvoke(new LineReceivedEvent(LineReceived), SerialBuffer);
        }

        private delegate void LineReceivedEvent(string str);

        private void LineReceived(string str)
        {
            str = str.Replace('&',' ');
            SerialMonitor_Text.AppendText(str + "\n");
            StatusLabel1.Text = str;
        }

        private LineSeries ConfigurePointSeries(LineSeries Ser)
        {
            Ser.Name = "Axle";
            Ser.StrokeThickness = 2.5f;
            Ser.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196));
            Ser.Fill = System.Windows.Media.Brushes.Transparent;
            Ser.LineSmoothness = 0.4f;
            Ser.PointGeometrySize = 5;
            Ser.PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49));

            return Ser;
        }

        private StepLineSeries ConfigureLineSeries(StepLineSeries Ser)
        {
            Ser.Name = "Axle";
            Ser.StrokeThickness = 2.5f;
            Ser.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196));
            Ser.Fill = System.Windows.Media.Brushes.Transparent;
            Ser.PointGeometrySize = 5;
            Ser.PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49));

            return Ser;
        }

        private void UpdateGraphTimer_Tick(object sender, EventArgs e)
        {
            if (UpdateGraphTimer.Enabled && serialPort1.IsOpen && !isRangeAddEnabled)
            {
                for (int i = 0; i < Axles.Count; ++i)
                {
                    try { Axles[i].Add(Convert.ToInt32(SerialBufferList[i])); }
                    catch { }
                }
            }
            else if (UpdateGraphTimer.Enabled && serialPort1.IsOpen && isRangeAddEnabled)
            {
                for (int i = 0; i < Axles.Count; ++i)
                {
                    try { Axles[i].AddRange(BufferRangeList[i]); BufferRangeList[i].Clear(); }
                    catch { }
                }
            }
        }

        private void AddAxle_Button_Click(object sender, EventArgs e)
        {
            if (FromPoints_RadioButton.Checked)
            {
                PointSeries.Add(new LineSeries());
                Axles.Add(new ChartValues<int>());
                BufferRangeList.Add(new ChartValues<int>());

                Graph.Series.Add(PointSeries[PointSeries.Count - 1]);
                PointSeries[PointSeries.Count - 1] = ConfigurePointSeries(PointSeries[PointSeries.Count - 1]);
                PointSeries[PointSeries.Count - 1].Values = Axles[PointSeries.Count - 1];

                if (NameInput.Text == "")
                    PointSeries[PointSeries.Count - 1].Name = "Axle" + Convert.ToString(PointSeries.Count);
                else
                    PointSeries[PointSeries.Count - 1].Name = NameInput.Text;

                PointSeries[PointSeries.Count - 1].StrokeThickness = Convert.ToSingle(LineThickness_InputField.Text);

                PointSeries[PointSeries.Count - 1].PointGeometrySize = Convert.ToSingle(PointSize_InputField.Text);

                PointSeries[PointSeries.Count - 1].Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B));

                AxleSelect.Items.Add(PointSeries[PointSeries.Count - 1].Name);
            }
            else if (FromLines_RadioButton.Checked)
            {
                LineSeries.Add(new StepLineSeries());
                Axles.Add(new ChartValues<int>());
                BufferRangeList.Add(new ChartValues<int>());

                Graph.Series.Add(LineSeries[LineSeries.Count - 1]);
                LineSeries[LineSeries.Count - 1] = ConfigureLineSeries(LineSeries[LineSeries.Count - 1]);
                LineSeries[LineSeries.Count - 1].Values = Axles[LineSeries.Count - 1];

                if (NameInput.Text == "")
                    LineSeries[LineSeries.Count - 1].Name = "LineAxle" + Convert.ToString(LineSeries.Count);
                else
                    LineSeries[LineSeries.Count - 1].Name = NameInput.Text;

                PointSeries[PointSeries.Count - 1].StrokeThickness = Convert.ToSingle(LineThickness_InputField.Text);

                PointSeries[PointSeries.Count - 1].PointGeometrySize = Convert.ToSingle(PointSize_InputField.Text);

                LineSeries[LineSeries.Count - 1].Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B));
                LineSeries[LineSeries.Count - 1].AlternativeStroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B));

                AxleSelect.Items.Add(LineSeries[LineSeries.Count - 1].Name);
            }
        }

        private void RemoveAxle_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (AxleSelect.Items.Count > 0)
                {
                    if (PointSeries.Count > 0)
                    {
                        PointSeries.RemoveAt(PointSeries.Count - 1);
                        Axles.RemoveAt(PointSeries.Count - 1);
                        BufferRangeList.RemoveAt(PointSeries.Count - 1);

                        Graph.Series.RemoveAt(PointSeries.Count - 1);

                        AxleSelect.Items.RemoveAt(AxleSelect.Items.Count - 1);
                    }
                    else
                    {
                        LineSeries.RemoveAt(LineSeries.Count - 1);
                        Axles.RemoveAt(LineSeries.Count - 1);
                        BufferRangeList.RemoveAt(PointSeries.Count - 1);

                        Graph.Series.RemoveAt(LineSeries.Count - 1);

                        AxleSelect.Items.RemoveAt(AxleSelect.Items.Count - 1);
                    }
                }
            }
            catch { }
        }

        private void ClearPlot_Button_Click(object sender, EventArgs e)
        {
            foreach (ChartValues<int> cv in Axles)
            {
                cv.Clear();
            }

            SerialMonitor_Text.Text = "";
        }

        private void ColorPicker_Button_MouseDown(object sender, MouseEventArgs e)
        {
            ColorSelectDialog.ShowDialog();
            ColorSelectDialog.AllowFullOpen = true;
            ColorSelectDialog.FullOpen = true;
            
            ColorPicker_Button.BackColor = ColorSelectDialog.Color;
        }

        private void ResetView_Button_Click(object sender, EventArgs e)
        {
            Graph.AxisX[0].MinValue = double.NaN;
            Graph.AxisX[0].MaxValue = double.NaN;
            Graph.AxisY[0].MinValue = double.NaN;
            Graph.AxisY[0].MaxValue = double.NaN;
        }

        private void ApplyCOMPortChanges_Button_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = COMPortNameText.Text;
                serialPort1.BaudRate = Convert.ToInt32(COMPortBaudRateText.Text);
                serialPort1.ReadTimeout = Convert.ToInt32(COMPortReadTimeoutText.Text);
                serialPort1.WriteTimeout = Convert.ToInt32(COMPortWriteTimeoutText.Text);
            }
            catch (System.InvalidOperationException)
            {
                StatusLabel1.Text = "Error: port is open";
            }
        }

        private void Settings_Button_Click(object sender, EventArgs e)
        {
            if (!isSettingsOpen)
            {
                isSettingsOpen = true;
                Form2 Form2 = new Form2();
                Form2.Show();
            }
        }

        private void SendToPort_Button_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(PortSendInputField.Text);
                PortSendInputField.Text = "";
            }
            catch { }
        }

        private void PortSendInputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    serialPort1.Write(PortSendInputField.Text);
                    PortSendInputField.Text = "";
                }
                catch { }
            }
        }
    }
}

public class MeasureModel
{
    public System.DateTime DateTime { get; set; }
    public double Value { get; set; }
}