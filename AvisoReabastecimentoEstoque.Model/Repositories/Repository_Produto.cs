using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisoReabastecimentoEstoque.Model.Repositories
{
    public class Repository_Produto : IDisposable
    {
        private readonly ServiceAvisoReabastecimentoEntities context;

        public Repository_Produto()
        {
            context = new ServiceAvisoReabastecimentoEntities();
            context.Configuration.ProxyCreationEnabled = false;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        #region Metodos

        public List<vw_PendenteAviso> ListaPendencias()
        {
            return (from p in context.vw_PendenteAviso orderby p.ProCodigo select p).ToList();

        }

        #endregion
    }
}
