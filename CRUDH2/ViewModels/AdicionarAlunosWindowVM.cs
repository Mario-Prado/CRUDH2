using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDH2.ViewModels
{
    public class AdicionarAlunosWindowVM
    {
        public Discente AlunoNovo { get; set; }

        public NovaTurmaWindowVM ViewModel { get; set; }

        public ICommand ComandoAdicionarAluno { get; set; }

        public ICommand AdicionarAluno(NovaTurmaWindowVM _ViewModel)
        {
            ICommand comando = new RelayCommand((object param) =>
            {
                _ViewModel.TurmaNova.Alunos.Add(AlunoNovo);
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
            ComandoAdicionarAluno = AdicionarAluno(ViewModel);
        }
       
    }
}
