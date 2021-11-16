using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRUDH2.ViewModels
{
    public class NovaTurmaWindowVM
    {

        public ICommand ComandoBtnAdicionarAlunos { get; private set; }

        public Turma TurmaNova { get; set; } 

        #region COMANDOS
        public ICommand AdicionarAlunos()
        {
            ICommand comando = new RelayCommand((object param) =>
            {
                Window TelaAdicionarAlunos = new AdicionarAlunosWindow();
                TelaAdicionarAlunos.DataContext = new AdicionarAlunosWindowVM();
                TelaAdicionarAlunos.Show();
            });
            return comando;
        }
        #endregion

        public NovaTurmaWindowVM()
        {
            ComandoBtnAdicionarAlunos = AdicionarAlunos();
            TurmaNova = new Turma()
            {
                Codigo = "aaa",
                Professor = new Docente()
                {
                    Cpf = "000000000-00",
                    Nome = "José Saramago",
                    Especialidade = "Lingua portuguesa"
                },
                Alunos = new List<Discente>()
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
        } 
    }
}
