using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisoReabastecimentoEstoque.Model.Repositories
{
    public class Repository_AvisoReabastecimento : IDisposable
    {
        private readonly ServiceAvisoReabastecimentoEntities context;

        public Repository_AvisoReabastecimento()
        {
            context = new ServiceAvisoReabastecimentoEntities();
            context.Configuration.ProxyCreationEnabled = false;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        #region Metodos

        public void Incluir(AvisoReabastecimento novoAviso)
        {
            context.AvisoReabastecimento.Add(novoAviso);
            context.SaveChanges();
        }

        #endregion
    }
}
