using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AvisoReabastecimentoEstoque.Model;

namespace AvisoReabastecimentoEstoque.Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1.Enabled = true;
            timer1_Tick(null, null);
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            AvisoEmail avisoEmail = new AvisoEmail();
            avisoEmail.EnviarEmail();

            timer1.Enabled = true;
        }
    }
}
