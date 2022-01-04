using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRobot.Model
{
    class Tresor : Posicio
    {
        public Tresor(int fil, int col) : base(fil, col, "imgChest") { }
        
        #region Propietats
        /// <summary> 
        /// Retorna que el tipus de posició és Tresor
        /// </summary> 
        public override TipusPosicio TipusPosicio { get => TipusPosicio.Tresor; }
        #endregion
    }
}
