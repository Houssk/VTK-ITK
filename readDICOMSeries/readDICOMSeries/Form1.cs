using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kitware.VTK;
using itk.simple;


namespace readDICOMSeries
{
    
    public partial class Form1 : Form
    {
        public vtkProp3D imgProp = null;
        vtkImageViewer2 _ImageViewer;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {        
                string fileName = openFileDialog1.FileName;
                vtkDICOMImageReader reader = vtkDICOMImageReader.New();
                reader.SetFileName(fileName);
                reader.Update();
                _ImageViewer = vtkImageViewer2.New();
                _ImageViewer.SetInputConnection(reader.GetOutputPort());
                vtkRenderWindow renderWindow = renderWindowControl1.RenderWindow;
                _ImageViewer.SetRenderWindow(renderWindow);
                _ImageViewer.Render();
            }
        }
       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgProp != null)
            {
                imgProp.Dispose();
            }
            if (this.renderWindowControl1 != null)
            {
                this.renderWindowControl1.Dispose();
            }
            System.GC.Collect();
        }

        private void renderWindowControl1_Load(object sender, EventArgs e)
        {

        }

        private void renderWindowControl2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            itk.simple.Image image = SimpleITK.ReadImage(this.openFileDialog1.FileName);
            image = SimpleITK.DiscreteGaussian(image);
            string fileName = "C:\\Users\\Utilisateur\\Desktop\\matlab\\test101.dcm";
            SimpleITK.WriteImage(image, fileName);
            vtkDICOMImageReader reader = vtkDICOMImageReader.New();
            reader.SetFileName(fileName);
            reader.Update();
            _ImageViewer = vtkImageViewer2.New();
            _ImageViewer.SetInputConnection(reader.GetOutputPort());
            vtkRenderWindow renderWindow = renderWindowControl2.RenderWindow;
            _ImageViewer.SetRenderWindow(renderWindow);
            _ImageViewer.Render();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}