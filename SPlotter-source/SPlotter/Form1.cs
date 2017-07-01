using System;
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
using LiveCharts.Geared;
using System.Threading;
using System.Threading.Tasks;

namespace SPlotter
{
    public partial class Form1 : Form
    {
        private HighPerformanceHandler Handler = new HighPerformanceHandler();

        List<LineSeries> PointSeries = new List<LineSeries>();
        List<StepLineSeries> LineSeries = new List<StepLineSeries>();
        List<ChartValues<int>> Axles = new List<ChartValues<int>>();
        public string[] SerialBufferList = { };
        string SerialBuffer = "";

        int PortStateIterator = 0;
        int PortStateIndex = 2;

        public bool isSettingsOpen = false;
        public bool isCPUMonitorOpen = false;
        public bool isRangeAddEnabled = false;
        List<ChartValues<int>> BufferRangeList = new List<ChartValues<int>>();
        public bool isHighPerformanceEnabled = true;

        public int ThreadSleepTime = 1;

        public Form1()
        {
            InitializeComponent();

            DataReceiveImage = SetImage(DataReceiveImage, 2);
            DataSendImage = SetImage(DataSendImage, 2);

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

            Graph.DisableAnimations = true;
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
            PortStateIndex = 0;

            try
            {
                SerialBuffer = serialPort1.ReadLine();
                SerialBufferList = SerialBuffer.Split('&');

                if (!UpdateGraphTimer.Enabled && !isRangeAddEnabled && !isHighPerformanceEnabled)
                {
                    for (int i = 0; i < Axles.Count; ++i)
                    {
                        try { Axles[i].Add(Convert.ToInt32(SerialBufferList[i])); }
                        catch { }
                    }
                }
                else if (isRangeAddEnabled && !isHighPerformanceEnabled)
                {
                    for (int i = 0; i < Axles.Count; ++i)
                    {
                        try { BufferRangeList[i].Add(Convert.ToInt32(SerialBufferList[i])); }
                        catch { }
                    }
                }
                else if (isHighPerformanceEnabled)
                {

                    Thread.Sleep(ThreadSleepTime);

                    for (int i = 0; i < SerialBufferList.Length; ++i)
                    {
                        Handler._trend[i] = Convert.ToDouble(SerialBufferList[i]);
                    }

                    //when multi threading avoid indexed calls like -> Values[0] 
                    //instead enumerate the collection
                    //ChartValues/GearedValues returns a thread safe copy once you enumerate it.
                    //TIPS: use foreach instead of for
                    //LINQ methods also enumerate the collections

                    for (int i = 0; i < Handler.Values.Count; ++i)
                    {
                        Handler.Values[i].Add(Handler._trend[i]);
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
            if (FromPoints_RadioButton.Checked && !isHighPerformanceEnabled)
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
            else if (FromLines_RadioButton.Checked && !isHighPerformanceEnabled)
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

                LineSeries[LineSeries.Count - 1].StrokeThickness = Convert.ToSingle(LineThickness_InputField.Text);

                LineSeries[LineSeries.Count - 1].PointGeometrySize = Convert.ToSingle(PointSize_InputField.Text);

                LineSeries[LineSeries.Count - 1].Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B));
                LineSeries[LineSeries.Count - 1].AlternativeStroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B));

                AxleSelect.Items.Add(LineSeries[LineSeries.Count - 1].Name);
            }
            else if (FromPoints_RadioButton.Checked && isHighPerformanceEnabled)
            {
                Handler.Values.Add(new GearedValues<double>().WithQuality(Quality.High));
                Handler._trend.Add(new int());

                Graph.Series.Add(new GLineSeries
                {
                    Values = Handler.Values[Handler.Values.Count - 1],

                    Name = "NewGAxle",
                    StrokeThickness = Convert.ToSingle(LineThickness_InputField.Text),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    LineSmoothness = 0.4f,
                    PointGeometrySize = Convert.ToSingle(PointSize_InputField.Text),
                    PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49)),
                });

                if (NameInput.Text == "")
                    AxleSelect.Items.Add("NewGAxle");
                else
                    AxleSelect.Items.Add(NameInput.Text);
            }
            else if (FromLines_RadioButton.Checked && isHighPerformanceEnabled)
            {
                Handler.Values.Add(new GearedValues<double>().WithQuality(Quality.High));
                Handler._trend.Add(new int());

                Graph.Series.Add(new GStepLineSeries
                {
                    Values = Handler.Values[Handler.Values.Count - 1],

                    Name = "NewGLineAxle",
                    StrokeThickness = Convert.ToSingle(LineThickness_InputField.Text),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(ColorPicker_Button.BackColor.R, ColorPicker_Button.BackColor.G, ColorPicker_Button.BackColor.B)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = Convert.ToSingle(PointSize_InputField.Text),
                    PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49)),
                });

                if (NameInput.Text == "")
                    AxleSelect.Items.Add("NewGAxle");
                else
                    AxleSelect.Items.Add(NameInput.Text);
            }
        }

        private void RemoveAxle_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (AxleSelect.Items.Count > 0 && Graph.Series.Count > 0)
                {
                    Graph.Series.RemoveAt(Graph.Series.Count - 1);

                    AxleSelect.Items.RemoveAt(AxleSelect.Items.Count - 1);

                    if (isHighPerformanceEnabled)
                    {
                        Handler.Values.RemoveAt(Handler.Values.Count - 1);
                        Handler._trend.RemoveAt(Handler._trend.Count - 1);
                    }
                }
            }
            catch { }
        }

        private void ClearPlot_Button_Click(object sender, EventArgs e)
        {
            if (!isHighPerformanceEnabled)
            {
                foreach (ChartValues<int> cv in Axles)
                {
                    cv.Clear();
                }
            }
            else
                Handler.Clear();

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
            PortStateIndex = 1;

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
                if (PortSendInputField.Text != "")
                    PortStateIndex = 1;

                try
                {
                    serialPort1.Write(PortSendInputField.Text);
                    PortSendInputField.Text = "";
                }
                catch { }
            }
        }

        private void CPUButton_Click(object sender, EventArgs e)
        {
            if (!isCPUMonitorOpen)
            {
                isCPUMonitorOpen = true;
                Form3 Form3 = new Form3();
                Form3.Show();
            }
        }

        public PictureBox SetImage(PictureBox obj, int indx)
        {
            obj.Image = PortStates.Images[indx];
            obj.InitialImage = PortStates.Images[indx];
            obj.ErrorImage = PortStates.Images[indx];

            return obj;
        }

        public PictureBox BlinkImage(PictureBox obj, int indx)
        {
            obj.Image = PortStates.Images[indx];
            obj.InitialImage = PortStates.Images[indx];
            obj.ErrorImage = PortStates.Images[indx];

            obj.Image = PortStates.Images[2];
            obj.InitialImage = PortStates.Images[2];
            obj.ErrorImage = PortStates.Images[2];

            return obj;
        }

        private void UpdatePortStateTimer_Tick(object sender, EventArgs e)
        {
            if (PortStateIndex == 0)
            {
                DataReceiveImage.Image = PortStates.Images[PortStateIndex];
                DataReceiveImage.InitialImage = PortStates.Images[PortStateIndex];
                DataReceiveImage.ErrorImage = PortStates.Images[PortStateIndex];

                PortStateIterator = 0;
                PortStateIndex = 2;
            }
            else if (PortStateIndex == 1)
            {
                DataSendImage.Image = PortStates.Images[PortStateIndex];
                DataSendImage.InitialImage = PortStates.Images[PortStateIndex];
                DataSendImage.ErrorImage = PortStates.Images[PortStateIndex];

                PortStateIterator = 0;
                PortStateIndex = 2;
            }

            if (PortStateIterator >= 4)
            {
                DataReceiveImage.Image = PortStates.Images[2];
                DataReceiveImage.InitialImage = PortStates.Images[2];
                DataReceiveImage.ErrorImage = PortStates.Images[2];

                DataSendImage.Image = PortStates.Images[2];
                DataSendImage.InitialImage = PortStates.Images[2];
                DataSendImage.ErrorImage = PortStates.Images[2];

                PortStateIterator = 0;
            }
            PortStateIterator++;
        }
    }
}

public class MeasureModel
{
    public System.DateTime DateTime { get; set; }
    public double Value { get; set; }
}