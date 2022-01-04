using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GitRobot.Model
{
    class Simulacio
    {
        private Posicio[,] taulaPosicions;
        private Posicio[,] taulaPosicionsBuides;
        private Grid taula;
        private Tresor tresor;
        private Robot robot;
        private List<Posicio> posicionsBuides;

        private int files;
        private int columnes;

        private Random random;

        public Simulacio(int fil, int col)
        {
            random = new Random();

            files = fil;
            columnes = col;
            taulaPosicions = new Posicio[fil, col];
            taulaPosicionsBuides = new Posicio[fil, col];
            CreaGrid();
            OmplirPosicions();

            CreaRobot();
            CreaTresor();
        }

        #region Propietats

        #endregion

        #region Mètodes
        private void CreaGrid()
        {
            taula = new Grid();
            for (int fila = 0; fila < files; fila++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                taula.RowDefinitions.Add(rowDefinition);
            }
            for (int columna = 0; columna < columnes; columna++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                taula.ColumnDefinitions.Add(columnDefinition);
            }
        }   
        
        private void OmplirPosicions()
        {
            Posicio posicio;
            posicionsBuides = new List<Posicio>();

            for (int fila = 0; fila < taulaPosicions.GetLength(0); fila++)
            {
                for (int columna = 0; columna < taulaPosicions.GetLength(1); columna++)
                {
                    posicio = new Posicio(fila, columna);

                    posicionsBuides.Add(posicio);
                    taulaPosicions[fila, columna] = posicio;
                    taulaPosicionsBuides[fila, columna] = posicio;
                    taula.Children.Add(posicio);
                }
            }
        }

        private void CreaRobot()
        {            
            int idx = random.Next(posicionsBuides.Count());
            Posicio posicio = posicionsBuides[idx];
            posicionsBuides.Remove(posicio);

            robot = new Robot(posicio.Fila, posicio.Columna);            
            taulaPosicions[posicio.Fila, posicio.Columna] = robot;
            taula.Children.Add(robot);

            idx = random.Next(4);
            switch (idx)
            {
                case 0:
                    robot.Direccio = Direccio.Nord;
                    break;
                case 1:
                    robot.Direccio = Direccio.Sud;
                    break;
                case 2:
                    robot.Direccio = Direccio.Est;
                    break;
                default:
                    robot.Direccio = Direccio.Oest;
                    break;
            }
        }

        private void CreaTresor()
        {
            int idx = random.Next(posicionsBuides.Count());
            Posicio posicio = posicionsBuides[idx];
            posicionsBuides.Remove(posicio);

            tresor = new Tresor(posicio.Fila, posicio.Columna);
            taulaPosicions[posicio.Fila, posicio.Columna] = tresor;
            taula.Children.Add(tresor);            
        }

        private bool PosicioValida(int fil, int col)
        {
            bool posValida = false;

            if(fil >= 0 && fil < files && col >= 0 && col < columnes)
            {
                Posicio posicio = taulaPosicions[fil, col];
                posValida = posicio.TipusPosicio != TipusPosicio.Robot;
            }

            return posValida;
        }
        #endregion
    }
}
