using System.Windows;

namespace filmekwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Film
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
        public double Ertekeles { get; set; }

        public Film(string cim, string mufaj, int hossz, double ertekeles)
        {
            Cim = cim;
            Mufaj = mufaj;
            Hossz = hossz;
            Ertekeles = ertekeles;
        }
    }

    public partial class MainWindow : Window
    {
        List<Film> filmek = new List<Film>()
    {
        new Film("Csillagok háborúja", "sci-fi", 121, 8.6),
        new Film("Titanic", "dráma", 195, 7.8),
        new Film("A Gyűrűk Ura", "fantasy", 201, 8.8),
        new Film("Mátrix", "sci-fi", 136, 8.7),
        new Film("Shrek", "animáció", 90, 7.9)
    };

        public MainWindow()
        {
            InitializeComponent();


            int pgmin = filmek[0].Hossz;
            int pgmax = filmek[0].Hossz;

            foreach (var item in filmek)
            {
                if (pgmin > item.Hossz)
                {
                    pgmin = item.Hossz;
                }

                if (pgmax < item.Hossz)
                {
                    pgmax = item.Hossz;
                }
            }

            pgHossz.Maximum = pgmax;
            pgHossz.Minimum = pgmin;
        }


        private void filmbetolt(object sender, RoutedEventArgs e)
        {
            dgFilmek.ItemsSource = filmek;
            dgFilmek.Items.Refresh();
        }


        private void leghosszabb(object sender, RoutedEventArgs e)
        {
            int leghosszabb = filmek[0].Hossz;
            string legHosszabbCim = filmek[0].Cim;

            foreach (var item in filmek)
            {
                if (leghosszabb < item.Hossz)
                {
                    leghosszabb = item.Hossz;
                    legHosszabbCim = item.Cim;
                }
            }

            MessageBox.Show($"A leghoszabb film: {legHosszabbCim}");
        }


        private void atlagertekeles(object sender, RoutedEventArgs e)
        {
            double tempAtlag = 0.0;
            foreach (var item in filmek)
            {
                tempAtlag += item.Ertekeles;
            }
            var atlag = tempAtlag / filmek.Count;
            MessageBox.Show($"Átlag: {atlag}");
        }


        private void csakscifi(object sender, RoutedEventArgs e)
        {
            List<Film> csakScifi = new List<Film>();

            foreach (var item in filmek)
            {
                if (item.Mufaj == "sci-fi")
                {
                    csakScifi.Add(item);
                }
            }


            dgFilmek.ItemsSource = csakScifi;
            dgFilmek.Items.Refresh();
        }


        public class CSAKCIM
        {
            public string Cim { get; set; }
        }
        private void csakcimek(object sender, RoutedEventArgs e)
        {
            List<CSAKCIM> cimek = new List<CSAKCIM>();

            foreach (var item in filmek)
            {
                CSAKCIM temp = new CSAKCIM();
                temp.Cim = item.Cim;
                cimek.Add(temp);
            }

            dgFilmek.ItemsSource = cimek;
            dgFilmek.Items.Refresh();
        }



        private void rendezes(object sender, RoutedEventArgs e)
        {
            List<Film> rendezett = new List<Film>();

            rendezett = filmek.OrderBy(a => a.Cim).ToList();

            dgFilmek.ItemsSource = rendezett;
            dgFilmek.Items.Refresh();
        }

        private void hosszKiir(object sender, RoutedEventArgs e)
        {
            var hossz = dgFilmek.SelectedItem as Film;
            pgHossz.Value = hossz.Hossz;
            MessageBox.Show($"Kiválasztott film:\n" +
                            $"{hossz.Cim}\n" +
                            $"{hossz.Ertekeles}\n");
        }
    }
}