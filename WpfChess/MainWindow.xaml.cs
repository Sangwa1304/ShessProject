using System.Diagnostics;
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
using ChessTeam.ChessLogical;
using ChessTeam.ChessLogical.Tableaux;
using static ChessTeam.ChessLogical.Tableaux.Tableaux;

namespace WpfChess
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Chess? ActualChess;
        private readonly ChessCamp WhiteCamp;
        private readonly ChessCamp BlackCamp;
        private static IEnumerable<Chess> Chesses 
        {
            get
            {
                return Conservateur.Initialisateur.AllsPiecesAtCamps;
            }
        }

        private static IEnumerable<ChessPosition> ChessNextPosition(Chess? chess)
        {
            try
            {
                return chess?.NextPositions?? []; 
            }
            catch(Exception)
            {
                return [];
            }
        }
        private static Chess? ChessInstance(ChessPosition position)
        {
            try
            {
                return Conservateur.Initialisateur.GetInstanceChess(position);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() => { Conservateur.Initialisateur.EnablesButtons(); });
            DataContext = new Selections();
            WhiteCamp = new();
            BlackCamp = new();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height == MinHeight)
            {
                rowMenu1.Height = new GridLength(0);
                rowMenu2.Height = new GridLength(0);
                return;

            }
            if (Width < Tableau.ActualHeight)
            {
                Width = Tableau.ActualHeight + 10;
            }
            else if (e.NewSize.Height <= MinHeight + 40 && e.NewSize.Height != MinHeight)
            {
                if (e.NewSize.Height <= MinHeight + 20)
                {
                    var r = MinHeight + 20 - e.NewSize.Height;
                    rowMenu1.Height = new GridLength(r);
                    rowMenu2.Height = new GridLength(r);
                    return;
                }
                else
                {
                    var r = MinHeight + 40 - e.NewSize.Height;
                    rowMenu1.Height = new GridLength(r);
                    rowMenu1.Height = new GridLength(20);
                    return;

                }
            }
            else
            {
                if (rowMenu1.Height == new GridLength(40)) return;
                rowMenu1.Height = new GridLength(40);
                rowMenu2.Height = new GridLength(20);
                return;
            }
        }
        

        private void Tableau_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            if (Tableau.ActualWidth < Tableau.ActualHeight)
            {
                if(Width < Tableau.ActualHeight)
                {
                    Width = Tableau.ActualHeight + 40;
                }
                Tableau.Width = Tableau.ActualHeight;
                return;
            }
            else if (Tableau.ActualWidth > Tableau.ActualHeight)
            {
                Tableau.Width = Tableau.ActualHeight;
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n = ((e.Source as Button)?.Parent as Border)?.Name??"";

            var pos = Tableaux.GetPosition(n);

            var chess = ChessInstance(pos);
            if (chess != null && chess.Camp == ActualChess?.Camp) ActualChess = null;
            //DataContext as CarreauElement;
            if (ActualChess != null)
            {
                ActualChess.Move(position:pos);
                ActualChess = null;
                Conservateur.Initialisateur.EnablesButtons();
                return;
            }
            if (chess == null) return;

            var exc = chess.NextPositions;

            exc.AddRange(chess.GetAnotherChessPositionsFromThisCamp());
            Conservateur.Initialisateur.DisableButtons(exc);
            ActualChess = chess;
        }
    }
}