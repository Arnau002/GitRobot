using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRobot.Model
{
    class Robot : Posicio
    {
        static int idx = 0;
        private Direccio direccio;
        int nMoviments;

        public Robot(int fil, int col) : base(fil, col, "imgSkelly_" + idx++)
        {
            nMoviments = 0;
        }

        #region Propietats
        /// <summary> 
        /// Retorna que el tipus de posició és Robot
        /// </summary> 
        public override TipusPosicio TipusPosicio { get => TipusPosicio.Robot; }

        /// <summary>
        /// Retorna o assigna la direcció del robot
        /// </summary>
        public Direccio Direccio { get => direccio; set => direccio = value; }

        /// <summary>
        /// Retorna o assigna el número de moviments del robot
        /// </summary>
        public int NMoviments { get => nMoviments; set => nMoviments = value; }
        #endregion
    }
}
