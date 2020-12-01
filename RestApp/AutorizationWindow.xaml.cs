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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestDBEntities1 db = new RestDBEntities1();
        public MainWindow()
        {
            InitializeComponent();
            //photo.Source = new BitmapImage(new Uri("/source/photo/Bethala.jpg", UriKind.Relative)) ; 
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            Users Users = db.Users.Where(w => Login.Text == w.Login).FirstOrDefault();
            if (Users.Login == Login.Text && Users.Password == Password.Text)
            {
                switch(Users.Position)
                {
                    case "Администратор":
                        windows.AdminWindow aw = new windows.AdminWindow();
                        aw.Show();
                        this.Close();
                        break;
                    case "Повар":
                        windows.ChiefWindow cw = new windows.ChiefWindow();
                        cw.Show();
                        this.Close();
                        break;
                    case "Официант":
                        windows.WeiterWindow ww = new windows.WeiterWindow();
                        ww.Show();
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("Ошибка баз данных");
                        break;
                }
            }
            else MessageBox.Show("Неверный логин или пароль!");
        }
    }
}
