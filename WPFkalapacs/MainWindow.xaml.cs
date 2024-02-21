using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFkalapacs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Versenyző> versenyzoAdatok = new List<Versenyző>();
        public MainWindow()
        {
            InitializeComponent();


            try
            {
                File.ReadAllLines("Selejtezo2012.txt").Skip(1).ToList().ForEach(adatok => versenyzoAdatok.Add(new Versenyző(adatok)));
            }
            catch (IOException e)
            {
                MessageBox.Show($"Hiba történt a fájl olvasása közben: {e.Message}");
            }
            athleteComboBox.ItemsSource = versenyzoAdatok.Select(v => v.Nev);
            athleteComboBox.SelectedItem = "Pars Krisztián";

        }

        private void athleteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string kivalasztottNev = athleteComboBox.SelectedItem as string;
            Versenyző kivalasztottVersenyzo = versenyzoAdatok.FirstOrDefault(v => v.Nev == kivalasztottNev);
            if (kivalasztottNev != null)
            {
                csoportLabel.Content = "Csoport: " + kivalasztottVersenyzo.Csoport;
                nemzetLabel.Content = "Nemzet: " + kivalasztottVersenyzo.Nemzet();
                nemzetKodLabel.Content = "Nemzet kód: " + kivalasztottVersenyzo.Kód();
                sorozatLabel.Content = "Sorozat: " + kivalasztottVersenyzo.D1.ToString() + ";" + kivalasztottVersenyzo.D2.ToString() + ";" + kivalasztottVersenyzo.D3.ToString();
                eredmenyLabel.Content = "Eredmény" + kivalasztottVersenyzo.LegnagyobbDobas();
                imgZaszlo.Source = new BitmapImage(new Uri($"Images/{kivalasztottVersenyzo.Kód()}.png", UriKind.Relative));
            }
        }
    }
}