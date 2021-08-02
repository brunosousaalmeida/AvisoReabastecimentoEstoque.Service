using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisoReabastecimentoEstoque.Model.Repositories
{
    public class Repository_EmailAuto : IDisposable
    {
        private readonly ServiceAvisoReabastecimentoEntities context;

        public Repository_EmailAuto()
        {
            context = new ServiceAvisoReabastecimentoEntities();
            context.Configuration.ProxyCreationEnabled = false;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        #region Metodos

        public List<EmailAuto> SelecionarTodos()
        {
            return (from p in context.EmailAuto select p).ToList();
        }


        #endregion
    }
}
