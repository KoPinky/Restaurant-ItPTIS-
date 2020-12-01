using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace RestApp.windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    /// public string ImagePath =null; 
    public partial class AdminWindow : Window
    {
        public string ImagePath = null;
        RestDBEntities1 db = new RestDBEntities1();
        public AdminWindow()
        {
            InitializeComponent();
            OutPutList();


        }

        public void OutPutList()
        {

            UsersDG.ItemsSource = db.Users.Where(w => w.Status != "Уволен").ToList();
        }

        private void Dismiss_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = Int32.Parse(button.Tag.ToString());


            TextBlock SName = UsersDG.Columns[0].GetCellContent(UsersDG.Items[index]) as TextBlock;
            TextBlock FName = UsersDG.Columns[1].GetCellContent(UsersDG.Items[index]) as TextBlock;
            if (SName != null && FName != null)
            {
                Users u = db.Users.Where(w => w.FirstName == FName.Text && w.SurName == SName.Text).FirstOrDefault();
                u.Status = "Уволен";
                db.SaveChanges();
            }
            OutPutList();
        }



        private void Photo_Drop(object sender, DragEventArgs e)
        {
            //Добаление фото по перетаскиванию
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ImagePath = files[0];
                string uriString = $"{files[0]}";
                ImgPhoto.Source = new BitmapImage(new Uri(@uriString));
            }

            e.Effects = DragDropEffects.Copy;
        }

        private void AddImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                ImgPhoto.Source = new BitmapImage(new Uri(@filename));
                HelpL.Opacity = 0;
                MessageBox.Show(ImgPhoto.Source.ToString());
            }

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

}