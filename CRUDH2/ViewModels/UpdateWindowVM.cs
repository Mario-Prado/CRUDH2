using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDH2.ViewModels
{
    public class UpdateWindowVM : INotifyPropertyChanged
    {
        public ICommand ComandoConfirmar { get; private set; }
        public Docente Prof { get; set; }
        public MainWindowVM ViewModel { get; set;}
        public UpdateWindowVM(MainWindowVM _ViewModel)
        {
            ViewModel = _ViewModel;
            Prof = ViewModel.TurmaSelecionada.Professor;
            ComandoConfirmar = new RelayCommand((object param) =>
            {
                Docente ProfessorAtualizado = new Docente(){Cpf = Prof.Cpf, Nome = Prof.Nome, Especialidade = Prof.Especialidade};
                ViewModel.ListaTurmas[ViewModel.ListaTurmas.IndexOf(ViewModel.TurmaSelecionada)].Professor = ProfessorAtualizado;
                ViewModel.TurmasFiltradas = ViewModel.ListaTurmas;
                NotificaTela("ViewModel.TurmasFiltradas");
                ViewModel.TelaAtualizarProfessor.Close();
            });

        }

        #region NotificaTela
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificaTela(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
