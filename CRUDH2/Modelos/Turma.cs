using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDH2.Modelos
{
    public class Turma
    { 
      public string Codigo { get; set; }
      public Docente Professor { get; set; }
      public ObservableCollection<Discente> Alunos { get; set;}

    }
}
