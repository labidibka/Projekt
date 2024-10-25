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
        public MainWindow()
        {
            InitializeComponent();

        }
        public class Glowa
        {
            private double gestoscWlosow;
            private double obwodGlowy;
            private double wysokoscCzola;
            private const  double SredniaIloscWlosow = 125000.0;

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
            public double SredniaWlosow() 
            {
                double SredniaLiczba = SredniaIloscWlosow;
                return SredniaLiczba * 1;
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
                
                double SredniaLiczbaWlosow = glowa.SredniaWlosow();
                double liczbaWlosow = glowa.ObliczLiczbeWlosow();
                double SredniaIloscProcent = (liczbaWlosow * 100) / SredniaLiczbaWlosow; 
                Wynik.Text = $"Szacunkowa liczba włosów: {liczbaWlosow:N0}, Oraz jest ona Równa {SredniaIloscProcent}% W porownaniu do średniej liczbie włosów";
            }
            catch(Exception ex)
            {
                Wynik.Text = "Błąd danych: upewnij się, że podałeś liczby.";
            }
        }
        private void Reset_click(object sender, RoutedEventArgs e) 
        {
            Gestosc.Text = string.Empty;
            Obwod.Text = string.Empty;
            Wysokosc.Text = string.Empty;
            Wynik.Text = string.Empty;
        }
    }
}
