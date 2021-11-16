using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRUDH2.ViewModels
{
    public class MainWindowVM
    {
        public ObservableCollection<Turma> ListaTurmas { get; set; }

        public ICommand ComandoCadastrarNovaTurma { get; private set; }


        #region COMANDOS
        public ICommand CadastrarNovaTurma()
        {
            ICommand comando = new RelayCommand((object param) =>
            {
                Window TelaNovaTurma = new NovaTurmaWindow();
                TelaNovaTurma.DataContext = new NovaTurmaWindowVM();
                TelaNovaTurma.Show();
            });
            return comando;
        }
        #endregion

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
                Alunos = new List<Discente>()
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

            ComandoCadastrarNovaTurma = CadastrarNovaTurma();
        }
    }
}
