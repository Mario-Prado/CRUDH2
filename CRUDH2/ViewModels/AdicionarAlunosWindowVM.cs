using CRUDH2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDH2.ViewModels
{
    public class AdicionarAlunosWindowVM
    {
        public Discente AlunoNovo { get; set; }
        public AdicionarAlunosWindowVM()
        {
            AlunoNovo = new Discente()
                {
                    Cpf = "777777777-77",
                    Nome = "Bart Simpson",
                    Cidade = "Altinópolis"   
                };
        }
    }
}
