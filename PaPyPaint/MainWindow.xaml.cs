using Contract;
using Fluent;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaPyPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Defaut
        bool _isDrawing = false;
        List<IShape> _shapes = new List<IShape>();
        List<IShape> _trash = new List<IShape>();
        IShape _preview;
        string _selectedShapeName = "";
        Dictionary<string, IShape> _prototypes =
            new Dictionary<string, IShape>();

        System.Windows.Media.Color color = Colors.Black;


        //Thickness
        BindingList<double> Thickness = new BindingList<double>();
        public string imgPath;

        private void canvas_MouseDown(object sender,
            MouseButtonEventArgs e)
        {
            // Sinh ra đối tượng mẫu kế
            _preview = _prototypes[_selectedShapeName].Clone(color, Thickness[thickness.SelectedIndex]);

            _isDrawing = true;

            System.Windows.Point pos = e.GetPosition(canvas);

            _preview.HandleStart(pos.X, pos.Y);
        }

        private void canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDrawing)
            {
                System.Windows.Point pos = e.GetPosition(canvas);
                _preview.HandleEnd(pos.X, pos.Y);

                // Xoá hết các hình vẽ cũ
                canvas.Children.Clear();

                // Vẽ lại các hình trước đó
                foreach (var shape in _shapes)
                {
                    UIElement element = shape.Draw();
                    canvas.Children.Add(element);
                }

                // Vẽ hình preview đè lên
                canvas.Children.Add(_preview.Draw());
            }
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDrawing = false;

            // Thêm đối tượng cuối cùng vào mảng quản lí
            System.Windows.Point pos = e.GetPosition(canvas);
            _preview.HandleEnd(pos.X, pos.Y);
            _shapes.Add(_preview);



            // Ve lai Xoa toan bo
            canvas.Children.Clear();

            // Ve lai tat ca cac hinh
            foreach (var shape in _shapes)
            {
                var element = shape.Draw();
                canvas.Children.Add(element);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Thickness
            Thickness.Add(1);
            Thickness.Add(2);
            Thickness.Add(3);
            Thickness.Add(4);
            Thickness.Add(5);
            Thickness.Add(6);
            Thickness.Add(7);


            thickness.ItemsSource = Thickness;
            thickness.SelectedIndex = 0;

            //Load dlls
            var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            var dlls = new DirectoryInfo(exeFolder).GetFiles("*.dll");
            foreach (var dll in dlls)
            {

                var assembly = Assembly.LoadFile(dll.FullName);
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsClass)
                    {
                        if (typeof(IShape).IsAssignableFrom(type))
                        {
                            var shape = Activator.CreateInstance(type) as IShape;
                            _prototypes.Add(shape.Name, shape);
                        }
                    }
                }
            }

            // Tạo ra các nút bấm hàng mẫu
            foreach (var item in _prototypes)
            {
                var shape = item.Value as IShape;
                var button = new Fluent.Button()
                {
                    //Content = shape.Name,
                    //Width = 80,
                    //Height = 35,
                    Margin = new Thickness(4, 2, 4, 2),
                    Padding = new System.Windows.Thickness(5,5,5,5),
                    BorderBrush = new SolidColorBrush(Colors.Gray),
                    BorderThickness = new Thickness(2),
                Tag = shape.Name
                };
                button.Click += prototypeButton_Click;
                button.Header = shape.Name;
                prototypesStackPanel.Items.Add(button);
            }

            _selectedShapeName = _prototypes.First().Value.Name;
            _preview = _prototypes[_selectedShapeName].Clone(color, Thickness[thickness.SelectedIndex]);


            // Khoi phuc cac shape da ve truoc do
            if (!File.Exists("./data.txt"))
            {
                return;
            }
            using (StreamReader readtext = new StreamReader("./data.txt"))
            {

                try
                {
                    while (!readtext.EndOfStream)
                    {
                        string readText = readtext.ReadLine();
                        string[] data = readText.Split(' ');
                        IShape restored = _prototypes[data[0]].Clone((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(data[6]),
                            Double.Parse(data[5]));
                        restored.HandleStart(Double.Parse(data[1]), Double.Parse(data[2]));
                        restored.HandleEnd(Double.Parse(data[3]), Double.Parse(data[4]));

                        _shapes.Add(restored);
                        foreach (var shape in _shapes)
                        {
                            var element = shape.Draw();
                            canvas.Children.Add(element);
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("xxx");
                }
            }

        }

        private void prototypeButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedShapeName = (sender as Fluent.Button).Tag as string;

            PreviewCanvas.Children.Clear();
            IShape PV = _prototypes[_selectedShapeName].Clone(color, Thickness[thickness.SelectedIndex]);
            PV.HandleStart(15, 20);
            PV.HandleEnd(60, 55);
            PreviewCanvas.Children.Add(PV.Draw());

            _preview = _prototypes[_selectedShapeName];
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void canvas_MouseDown2(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseMove2(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void canvas_MouseUp2(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //string folderPath = "";
            //FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            //if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    folderPath = folderBrowserDialog1.SelectedPath;
            //    RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,
            //    (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            //    rtb.Render(canvas);

            //    var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, (int)canvas.ActualWidth, (int)canvas.ActualHeight));

            //    BitmapEncoder pngEncoder = new PngBitmapEncoder();
            //    pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            //    using (var fs = System.IO.File.OpenWrite(folderPath))
            //    {
            //        pngEncoder.Save(fs);
            //    }
            //}
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,
                (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                rtb.Render(canvas);

                //var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, (int)canvas.ActualWidth, (int)canvas.ActualHeight));
                MemoryStream stream = new MemoryStream();
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(stream);

                Bitmap bitmap = new Bitmap(stream);
                //BitmapEncoder pngEncoder = new PngBitmapEncoder();

                //int width = Convert.ToInt32(canvas.Width);
                //int height = Convert.ToInt32(canvas.Height);
                //Bitmap bmp = new Bitmap(width, height);

                //canvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bitmap.Save(dialog.FileName, ImageFormat.Png);
                MessageBox.Show("Save successfully!");
            }

        }

        private void _colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colorPicker.SelectedColor.ToString());

            PreviewCanvas.Children.Clear();
            IShape PV = _prototypes[_selectedShapeName].Clone(color, Thickness[thickness.SelectedIndex]);
            PV.HandleStart(15, 20);
            PV.HandleEnd(60, 55);
            PreviewCanvas.Children.Add(PV.Draw());
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            //Browse PNG IMAGE
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                canvas.Children.Clear();
                imgPath = openFileDialog.FileName;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                canvas.Background = brush;
                _shapes.Clear();
            }

            //Load PNG to Canvas
            //canvas = new Canvas();
            //BitmapImage bm = new BitmapImage(new Uri(imgPath, UriKind.Absolute));
            //Image img = new Image();
            //img.Source = bm;
            //img.Width = bm.Width;
            //img.Height = bm.Height;
            //Canvas.SetLeft(img, 0);
            //Canvas.SetRight(img, 0);
            //canvas.Children.Add(img);
            
        }

        private void thickness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PreviewCanvas.Children.Clear();
                IShape PV = _prototypes[_selectedShapeName].Clone(color, Thickness[thickness.SelectedIndex]);
                PV.HandleStart(15, 20);
                PV.HandleEnd(60, 55);
                PreviewCanvas.Children.Add(PV.Draw());
            }
            catch
            {

            }

        }

        private void RibbonWindow_Closing(object sender, CancelEventArgs e)
        {
            using (StreamWriter writetext = new StreamWriter("data.txt"))
            {
                foreach(var shape in _shapes)
                {
                    writetext.WriteLine(shape.Name + " " + shape.GetStart().GetX() + " " + shape.GetStart().GetY() + " " + 
                        shape.GetEnd().GetX() + " " + shape.GetEnd().GetY() + " " + shape.thickness + " " + shape.color);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            _shapes.Clear();
            _trash.Clear();
            canvas.Children.Clear();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if(_shapes.Count() <= 0)
            {
                return;
            }
            _trash.Add(_shapes[_shapes.Count() - 1]);
            _shapes.RemoveAt(_shapes.Count() - 1);

            canvas.Children.Clear();
            foreach (var shape in _shapes)
            {
                var element = shape.Draw();
                canvas.Children.Add(element);
            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (_trash.Count() <= 0)
            {
                return;
            }
            _shapes.Add(_trash[_trash.Count() - 1]);
            _trash.RemoveAt(_trash.Count() - 1);

            canvas.Children.Clear();
            foreach (var shape in _shapes)
            {
                var element = shape.Draw();
                canvas.Children.Add(element);
            }
        }
    }
}
