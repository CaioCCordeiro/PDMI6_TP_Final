using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDMI6_TP_Final.Model;

namespace PDMI6_TP_Final.MercadoriasViewModel
{
    public class MercadoriaViewModel
    {
        public MercadoriaViewModel() { }
        #region Propriedades
        public string Nome { get; set; }
        public float Peso { get; set; }
        public string NomeProdutor { get; set; }
        public string EmailProdutor { get; set; }
        public int NCM { get; set; }
        public List<Mercadoria> Mercadorias
        {
            get
            {
                return
                App.MercadoriaModel.GetMercadorias().ToList();
            }
        }
        #endregion
    }
}
