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
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Turma> ListaTurmas { get; set; }
        public ObservableCollection<Turma> TurmasFiltradas { get; set; }

        public string ValorBuscado { get; set; }
        public Turma TurmaSelecionada { get; set; }
        public Window TelaCadastroNovaTurma { get; set; }
        public Window TelaAtualizarProfessor { get; set; }
        public ICommand ComandoCadastrarNovaTurma { get; private set; }
        public ICommand ComandoBuscar { get; private set; }
        public ICommand ComandoDeletar { get; private set; }
        public ICommand ComandoAtualizarDocente { get; private set; }


        public MainWindowVM()
        {
            ListaTurmas = new ObservableCollection<Turma>();
            ListaTurmas.Add(new Turma()
            {
                Codigo = "000",
                Professor = new Docente()
                {
                    Cpf = "000000000-00",
                    Nome = "Aparecido do Rio",
                    Especialidade = "Matemática"
                },
                Alunos = new ObservableCollection<Discente>()
                {
                    new Discente()
                    {
                        Cpf = "111111111-11",
                        Nome = "Carmem Lucia",
                        Cidade = "Santa Rosa"
                    },
                    new Discente()
                    {
                        Cpf = "222222222-22",
                        Nome = "Maria Do Rosario",
                        Cidade = "Cajuru"
                    }
                }
            });
            TurmasFiltradas = ListaTurmas;
            CriarComandos();
        }

        public void CriarComandos()
        {
            ComandoCadastrarNovaTurma = new RelayCommand((object param) =>
            {
                Window TelaNovaTurma = new NovaTurmaWindow();
                TelaNovaTurma.DataContext = new NovaTurmaWindowVM(this);
                TelaNovaTurma.Show();
                TelaCadastroNovaTurma = TelaNovaTurma;
            });

            ComandoBuscar  = new RelayCommand((object param) =>
            {
                ObservableCollection<Turma> ListaTeporaria = new ObservableCollection<Turma>();
                foreach (Turma turma in ListaTurmas)
                {
                    if (turma.Codigo.Contains(ValorBuscado) | turma.Professor.Nome.Contains(ValorBuscado))
                    {
                        ListaTeporaria.Add(turma);
                        TurmasFiltradas = ListaTeporaria;
                        NotificaTela("TurmasFiltradas");
                    }
                }
            });

            ComandoDeletar = new RelayCommand((object param) =>
            {
                ListaTurmas.Remove(TurmaSelecionada);
                TurmasFiltradas = ListaTurmas;
                NotificaTela("TurmasFiltradas");
            }, (object param) =>
            {
                if (ListaTurmas.Count > 0 & TurmaSelecionada != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            ComandoAtualizarDocente = new RelayCommand((object param) =>
            {
                Window TelaAtualizar = new UpdateWindow();
                TelaAtualizar.DataContext =  new UpdateWindowVM(this);
                TelaAtualizar.Show();
                TelaAtualizarProfessor = TelaAtualizar;

            }, (object param) =>
            {
                if (ListaTurmas.Count > 0 & TurmaSelecionada != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        #region NotificaTela
        public event PropertyChangedEventHandler PropertyChanged;
 
        private void NotificaTela(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

