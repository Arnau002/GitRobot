using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GitRobot.Model
{
    class Posicio : Image
    {
        protected int fila;
        protected int columna;  
        
        public Posicio(int fil, int col)
        {
            fila = fil;
            columna = col;

            this.SetValue(Grid.RowProperty, fila);
            this.SetValue(Grid.ColumnProperty, columna);
        }

        public Posicio(int fil, int col, string clauImatge) : this(fil, col)
        {
            this.Source = (ImageSource)Application.Current.FindResource(clauImatge);
        }

        #region Propietats
        /// <summary> 
        /// Assigna o obté la columna de la posició 
        /// </summary> 
        public int Columna { get => this.columna; set => this.columna = value; }

        /// <summary> 
        /// Assigna o obté la fila de la posició 
        /// </summary> 
        public int Fila { get => this.fila; set => this.fila = value; }

        /// <summary> 
        /// Retorna que el tipus de posició és Buida
        /// </summary> 
        public virtual TipusPosicio TipusPosicio { get => TipusPosicio.Buida; }
        #endregion
    }
}
