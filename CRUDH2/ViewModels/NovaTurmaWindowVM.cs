using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRUDH2.ViewModels
{
    public class NovaTurmaWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM ViewModel { get; set; } 
       
        public ICommand ComandoBtnAdicionarAlunos { get; private set; }

        public ICommand ComandoBtnConcluir { get; private set; }

        public Turma TurmaNova { get; set; } 

        #region COMANDOS
        public ICommand AdicionarAlunos()
        {
            ICommand comando = new RelayCommand((object param) =>
            {
                Window TelaAdicionarAlunos = new AdicionarAlunosWindow();
                TelaAdicionarAlunos.DataContext = new AdicionarAlunosWindowVM(this);
                TelaAdicionarAlunos.Show();
            });
            return comando;
        }

        public ICommand ConcluirCadastroDeTurmaNova(MainWindowVM ViewModel)
        {
            ICommand comando = new RelayCommand((object param) =>
            {
                ViewModel.ListaTurmas.Add(TurmaNova);
                //this.TurmaNova = null;
                NotificaTela("TurmaNova");
                ViewModel.TelaCadastroNovaTurma.Close();
            });
            return comando;
        }
        #endregion

        public NovaTurmaWindowVM(MainWindowVM _ViewModel)
        {
            TurmaNova = new Turma()
            {
                Codigo = "aaa",
                Professor = new Docente()
                {
                    Cpf = "000000000-00",
                    Nome = "José Saramago",
                    Especialidade = "Lingua portuguesa"
                },
                Alunos = new ObservableCollection<Discente>()
                {
                    new Discente()
                    {
                        Cpf = "111111111-11",
                        Nome = "Orion Lima",
                        Cidade = "São Carlos"
                    },
                    new Discente()
                    {
                        Cpf = "222222222-22",
                        Nome = "Sirius Black",
                        Cidade = "Ribeirão Preto"
                    }
                }
            };
            ViewModel = _ViewModel;
            ComandoBtnAdicionarAlunos = AdicionarAlunos();
            ComandoBtnConcluir = ConcluirCadastroDeTurmaNova(ViewModel);
        }

        #region NotificaTela
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotificaTela( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
