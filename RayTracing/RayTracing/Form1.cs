using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.WinForms;

using System.Runtime.InteropServices;

namespace RayTracing
{
    public partial class frmMain : Form
    {
        ////------------------------------------------------------------------------------------
        ChartValues<double> OrigionalData { get; set; } = new ChartValues<double>();
        ChartValues<double> OrigionalRayTraceData { get; set; } = new ChartValues<double>();
        ChartValues<double> OrigionalFileSaveData { get; set; } = new ChartValues<double>();
        ChartValues<double> ThreadedData { get; set; } = new ChartValues<double>();
        ChartValues<double> RayTraceData { get; set; } = new ChartValues<double>();
        ChartValues<double> FileSaveData { get; set; } = new ChartValues<double>();
        private PixelMap pixelMap;
        private ImageFormat imageFormat;

        //------------------------------------------------------------------------------------
        public frmMain()
        {
            InitializeComponent();
            InitializeGraph();
            ReadSphereData();
            //WriteSphereData();
            ReadConfig();

            cmbBxOptimzation.Items.Add("O1");
            cmbBxOptimzation.Items.Add("O2");
            cmbBxOptimzation.Items.Add("Ox");
            cmbBxOptimzation.SelectedIndex = 0;
        }
        //------------------------------------------------------------------------------------
        private void InitializeGraph()
        {
            chrtTimeTaken.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Origional",
                    Values = OrigionalData
                },
                new LineSeries
                {
                    Title = "Threaded",
                    Values = ThreadedData
                }
            };

            chrtSubTimes.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Ray Trace Time",
                    Values = RayTraceData
                },
                new LineSeries
                {
                    Title = "File Save Time",
                    Values = FileSaveData
                },
                new LineSeries
                {
                    Title = "Origional Ray Trace Time",
                    Values = OrigionalRayTraceData
                },
                new LineSeries
                {
                    Title = "Origional File Save Time",
                    Values = OrigionalFileSaveData
                }
            };

            UpdateOrigionalData();
            UpdateThreadedData();
        }
        //------------------------------------------------------------------------------------
        public List<double> ReadInData(string filename)
        {
            List<double> data = new List<double>();

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (sr.EndOfStream == false)
                    {
                        String line = sr.ReadLine();
                        data.Add(double.Parse(line));
                    }
                }
            }
            catch (Exception e)
            {
                txtbxLog.AppendText("The file could not be read:");
                txtbxLog.AppendText(e.Message + "\n");
            }

            return data;
        }
        //------------------------------------------------------------------------------------
        public void UpdateOrigionalData()
        {
            List<double> OrigionalFrame = ReadInData("Data/OrigionalData.txt");
            List<double> OrigionalRayTrace = ReadInData("Data/OrigionalRaytraceTimeData.txt");
            List<double> OrigionalFileSave = ReadInData("Data/OrigionalFileSaveData.txt");

            OrigionalData.Clear();
            OrigionalRayTraceData.Clear();
            OrigionalFileSaveData.Clear();

            OrigionalData.AddRange(OrigionalFrame);            
            OrigionalRayTraceData.AddRange(OrigionalRayTrace);
            OrigionalFileSaveData.AddRange(OrigionalFileSave);
        }
        //------------------------------------------------------------------------------------
        public void UpdateThreadedData()
        {
            List<double> data = ReadInData("Data/ThreadedData.txt");
            List<double> RaytraceTimeData = ReadInData("Data/RaytraceTimeData.txt");
            List<double> FilesSaveData = ReadInData("Data/FileSaveData.txt");

            ThreadedData.Clear();
            RayTraceData.Clear();
            FileSaveData.Clear();

            ThreadedData.AddRange(data);
            RayTraceData.AddRange(RaytraceTimeData);
            FileSaveData.AddRange(FilesSaveData);
        }
        //------------------------------------------------------------------------------------
        public void ClearFileData()
        {
            System.IO.File.WriteAllText("Data/ThreadedData.txt", "");
            System.IO.File.WriteAllText("Data/RaytraceTimeData.txt", "");
            System.IO.File.WriteAllText("Data/FileSaveData.txt", "");
        }
        //------------------------------------------------------------------------------------
        public void ClearFileDataOrigional()
        {
            System.IO.File.WriteAllText("Data/OrigionalData.txt", "");
            System.IO.File.WriteAllText("Data/OrigionalRaytraceTimeData.txt", "");
            System.IO.File.WriteAllText("Data/OrigionalFileSaveData.txt", "");
        }
        //------------------------------------------------------------------------------------
        private string PickExe()
        {
            string path = "";

            if (chckbxThreaded.Checked == true)
            {
                if  (cmbBxOptimzation.SelectedItem.ToString() == "O1")
                {
                    ReadToLog(txtbxLog, "RayTracerThreadedO1 picked" + Environment.NewLine);
                    path = "RayTracerPrograms/RayTracerThreadedO1.exe";
                }
                else if (cmbBxOptimzation.SelectedItem.ToString() == "O2")
                {
                    ReadToLog(txtbxLog, "RayTracerThreadedO2 picked" + Environment.NewLine);
                    path = "RayTracerPrograms/RayTracerThreadedO2.exe";
                }
                else if (cmbBxOptimzation.SelectedItem.ToString() == "Ox")
                {
                    ReadToLog(txtbxLog, "RayTracerThreadedOx picked" + Environment.NewLine);
                    path = "RayTracerPrograms/RayTracerThreadedOx.exe";
                }
                else
                {
                    ReadToLog(txtbxLog, "No optimzation picked" + Environment.NewLine);
                }

                ClearFileData();
            }
            else
            {
                if (cmbBxOptimzation.SelectedItem.ToString() == "O1")
                {
                    ReadToLog(txtbxLog, "RayTracerOrigionalO1 picked" + Environment.NewLine);
                    path = "RayTracerPrograms/RayTracerOrigionalO1.exe";
                }
                else if (cmbBxOptimzation.SelectedItem.ToString() == "O2")
                {
                    ReadToLog(txtbxLog, "RayTracerOrigionalO2 picked" + Environment.NewLine);
                    path = "RayTracerPrograms/RayTracerOrigionalO2.exe";
                }
                else if (cmbBxOptimzation.SelectedItem.ToString() == "Ox")
                {
                    ReadToLog(txtbxLog, "RayTracerOrigionalOx picked" + Environment.NewLine);
                    path = "RayTracerPrograms/RayTracerOrigionalOx.exe";
                }
                else
                {
                    ReadToLog(txtbxLog, "No optimzation picked" + Environment.NewLine);
                }

                ClearFileDataOrigional();
            }

            return path;
        }
        //------------------------------------------------------------------------------------
        private void RunRayTracer()
        {
            Process proc = new Process();

            proc.StartInfo.FileName = PickExe();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.OutputDataReceived += new DataReceivedEventHandler(InterProcOutputHandler);
            proc.Exited += new EventHandler( UpdateData);
            proc.EnableRaisingEvents = true;
            bool started = proc.Start();

            proc.BeginOutputReadLine();
        }
        //------------------------------------------------------------------------------------
        private void UpdateData(object sender, EventArgs e)
        {
            UpdateOrigionalData();
            UpdateThreadedData();

            ReadToLog(txtbxLog, "Graph Data updated!!!" + Environment.NewLine);
        }
        //------------------------------------------------------------------------------------
        private void ReadToLog(RichTextBox box, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action<RichTextBox, string>)ReadToLog, txtbxLog, text);
            }
            else
            {
                box.AppendText(text);
                box.ScrollToCaret();
            }
        }
        //------------------------------------------------------------------------------------
        private void DisableElements()
        {
            SettingsBox.Enabled = false;
            btnRayTracer.Enabled = false;
        }
        //------------------------------------------------------------------------------------
        private void EnableElements()
        {
            SettingsBox.Enabled = true;
            btnRayTracer.Enabled = true;
        }
        //------------------------------------------------------------------------------------
        private void InterProcOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            ReadToLog(txtbxLog, outLine.Data + Environment.NewLine);
        }
        //------------------------------------------------------------------------------------
        private void WriteConfig()
        {
            string[] data =
            {
                "Threads =" + numOfThreads.Value.ToString(),
                "ScreenX =" + txtbxPicWidth.Text,
                "ScreenY =" + txtbxPicHeight.Text,
                "FrameCount =" + txtbxFrames.Text,
                "SphereCount =" + (SphereDataGrid.RowCount -1),
                "Fps =" + txtbxFps.Text
            };

            System.IO.File.WriteAllLines("Data/Config.cfg", data);

            ReadToLog(txtbxLog, "Config Data updated!!!" + Environment.NewLine);
        }
        //------------------------------------------------------------------------------------
        private void ReadConfig()
        {
            string[] data = System.IO.File.ReadAllLines("Data/Config.cfg");

            numOfThreads.Value = Convert.ToInt32(data[0].Split('=').Last());
            txtbxPicWidth.Text = data[1].Split('=').Last();
            txtbxPicHeight.Text = data[2].Split('=').Last();
            txtbxFrames.Text = data[3].Split('=').Last();
            txtbxFps.Text = data[5].Split('=').Last();
        }
        //------------------------------------------------------------------------------------
        private void ReadSphereData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Pos X", typeof(float));
            dt.Columns.Add("Pos Y", typeof(float));
            dt.Columns.Add("Pos Z", typeof(float));
            dt.Columns.Add("Radius", typeof(float));
            dt.Columns.Add("Colour R", typeof(float));
            dt.Columns.Add("Colour G", typeof(float));
            dt.Columns.Add("Colour B", typeof(float));
            dt.Columns.Add("Reflectivity", typeof(float));
            dt.Columns.Add("Transparency", typeof(float));
            dt.Columns.Add("Emission Colour", typeof(float));
            dt.Columns.Add("Parent", typeof(string));
            dt.Columns.Add("Rotation Speed", typeof(float));

            using (CsvFileReader reader = new CsvFileReader("Data/Spheres.csv"))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    if (!row.LineText.Contains("Name"))
                    {
                        DataRow sphere = dt.NewRow();
                        sphere["Name"] = row[0];
                        sphere["Pos X"] = row[1];
                        sphere["Pos Y"] = row[2];
                        sphere["Pos Z"] = row[3];
                        sphere["Radius"] = row[4];
                        sphere["Colour R"] = row[5];
                        sphere["Colour G"] = row[6];
                        sphere["Colour B"] = row[7];
                        sphere["Reflectivity"] = row[8];
                        sphere["Transparency"] = row[9];
                        sphere["Emission Colour"] = row[10];
                        sphere["Parent"] = row[11];
                        sphere["Rotation Speed"] = row[12];

                        dt.Rows.Add(sphere);
                    }
                }

                SphereDataGrid.DataSource = dt;
            }
        }
        //------------------------------------------------------------------------------------
        private void WriteSphereData()
        {
            using (CsvFileWriter writer = new CsvFileWriter("Data/Spheres.csv"))
            {
                for (int i = 0; i < SphereDataGrid.RowCount; i++)
                {
                    CsvRow row = new CsvRow();

                    for (int j = 0; j < SphereDataGrid.ColumnCount; j++)
                    {
                        if (i == 0)
                        {
                            string value = SphereDataGrid.Columns[j].HeaderCell.Value.ToString();
                            row.Add(value);
                        }
                        else
                        {
                            string value = SphereDataGrid.Rows[i-1].Cells[j].Value.ToString();
                            row.Add(value);
                        }
                    }

                    writer.WriteRow(row);
                }
            }

            ReadToLog(txtbxLog, "Sphere Data updated!!!" + Environment.NewLine);
        }
        //------------------------------------------------------------------------------------
        private void btnRayTracer_Click(object sender, EventArgs e)
        {
            RunRayTracer();
        }
        //------------------------------------------------------------------------------------
        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            WriteConfig();
            WriteSphereData();
        }
        //------------------------------------------------------------------------------------
        private void btnPause_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string location = openFileDialog1.FileName;
                pixelMap = new PixelMap(location);
                pctbxRender.SizeMode = PictureBoxSizeMode.StretchImage;
                pctbxRender.Image = pixelMap.BitMap;
            }
        }
        //------------------------------------------------------------------------------------
        private void ShowException(Exception ex)
        {
            string message = ex.InnerException.Message;
            string caption = "PixelMap Error! " + ex.Message;
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //------------------------------------------------------------------------------------
        private void btnBmp_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Sphere";
            saveFileDialog1.Filter = "Bmp Image|*.bmp";
            saveFileDialog1.Title = "Save an Image File";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                this.pctbxRender.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
        //------------------------------------------------------------------------------------
        private void btnPng_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Sphere";
            saveFileDialog1.Filter = "Png Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                this.pctbxRender.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        //------------------------------------------------------------------------------------
        private void btnJpeg_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Sphere";
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Save an Image File";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                this.pctbxRender.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string location = openFileDialog1.FileName;
                Process.Start(location);
            }
        }
        //------------------------------------------------------------------------------------
    }
}