using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Gymly.UserControls
{
    public partial class UserControlTelaInicial : UserControl, INotifyPropertyChanged
    {
        private MainWindow mainWindow;
        public UserControlTelaInicial(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarPropriedadeAlterada(string propriedade)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private void BtnIniciarGymly_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("aluno");
        }
    }
}
