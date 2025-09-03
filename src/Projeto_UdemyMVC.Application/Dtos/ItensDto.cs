using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_UdemyMVC.Application.Dtos
{
    public class ItensDto
    {
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public long RegistroVendaId { get; set; }
    }
}
