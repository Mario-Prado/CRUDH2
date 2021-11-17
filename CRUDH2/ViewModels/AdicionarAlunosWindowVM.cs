using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRUDH2.ViewModels
{
    public class AdicionarAlunosWindowVM : INotifyPropertyChanged
    {
        public Discente AlunoNovo { get; set; }

        public NovaTurmaWindowVM ViewModel { get; set; }

        public ICommand ComandoAdicionarAluno { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AdicionarAluno()
        {
            ICommand comando = new RelayCommand((object param) =>
            {
                ViewModel.TurmaNova.Alunos.Add(new Discente() { Cpf = AlunoNovo.Cpf,Nome = AlunoNovo.Nome, Cidade = AlunoNovo.Cidade });
                AlunoNovo.Cpf = null;
                AlunoNovo.Nome = null;
                AlunoNovo.Cidade = null;
                NotificaTela("AlunoNovo");
                MessageBoxResult result = MessageBox.Show("Cadastramento realizado com sucesso");
            });
            return comando;
        }


        public AdicionarAlunosWindowVM(NovaTurmaWindowVM _ViewModel)
        {
            ViewModel = _ViewModel;
            AlunoNovo = new Discente()
                {
                    Cpf = "777777777-77",
                    Nome = "Bart Simpson",
                    Cidade = "Altinópolis"   
                };
            ComandoAdicionarAluno = AdicionarAluno();
        }

        private void NotificaTela(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }



    
}
