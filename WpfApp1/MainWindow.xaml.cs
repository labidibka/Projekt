using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double Srednia_gestosc = 200;
        public MainWindow()
        {
            InitializeComponent();

        }
        public class Glowa
        {
            private double gestoscWlosow;
            private double obwodGlowy;
            private double wysokoscCzola;
            private const double PowierzchniaGlowyDomyslna = 600.0;
            public Glowa(double gestosc, double obwod, double wysokosc)
                {
                 this.gestoscWlosow = gestosc;
                 this.obwodGlowy = obwod;
                 this.wysokoscCzola = wysokosc;
               }
            private double ObliczPowierzchnieGlowy() 
            {
                return (obwodGlowy * wysokoscCzola) / 2.0 + PowierzchniaGlowyDomyslna;
            }
            public double ObliczLiczbeWlosow() 
            {
                double powierzchniaGlowy = ObliczPowierzchnieGlowy();
                return gestoscWlosow * powierzchniaGlowy;
            }
            
        }
        private void Wyslij_click(object sender, RoutedEventArgs e) 
        {
            try 
            {
                double gestoscWlosow = Convert.ToDouble(Gestosc.Text);
                double obwodGlowy = Convert.ToDouble(Obwod.Text);
                double wysokoscCzola = Convert.ToDouble(Wysokosc.Text);

                Glowa glowa = new Glowa(gestoscWlosow, obwodGlowy, wysokoscCzola);

                double liczbaWlosow = glowa.ObliczLiczbeWlosow();
                Wynik.Text = $"Szacunkowa liczba włosów: {liczbaWlosow:N0}";
            }
            catch(Exception ex)
            {
                Wynik.Text = "Błąd danych: upewnij się, że podałeś liczby.";
            }
        }
    }
}
