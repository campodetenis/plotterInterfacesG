using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace pruebaProyecto2
{
    class viewmodel
    {
        private ObservableCollection<ObservableCollection<Point>> colecciones { get; set;}
        private ObservableCollection<Line> barras;
        public viewmodel()
        {
            colecciones = new ObservableCollection<ObservableCollection<Point>>();
            barras = new ObservableCollection<Line>();
        }

        public ObservableCollection<ObservableCollection<Point>> devolverColecciones()
        {
            return colecciones;
        }

        public void añadirTabla(ObservableCollection<Point> tabla)
        {
            colecciones.Add(tabla);
        }

        public void quitarTabla(ObservableCollection<Point> tabla)
        {
            colecciones.Remove(tabla);
        }

        public ObservableCollection<Line> getBarras()
        {
            return barras;
        }

        public void añadirLinea(Line barra)
        {
            barras.Add(barra);
        }

        public void quitarLinea(Line barra)
        {
            barras.Remove(barra);
        }

        public void limpiarBarras()
        {
            barras.Clear();
        }

        public void limpiarTablas()
        {
            colecciones.Clear();
        }

    }
}
