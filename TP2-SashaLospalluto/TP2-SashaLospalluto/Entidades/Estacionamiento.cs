using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"

        /// <summary>
        /// Inicializa la lista de Vehiculos
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Inicializa la lista de Vehiculos y asigna el espacion disponible pasado por parametro
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Devuelve la cadena con los datos solicitados</returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("\n");

            foreach (Vehiculo v in c.vehiculos)
            {                
               
                switch (tipo)
                {
                    case ETipo.Camioneta:

                        if(v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;

                    case ETipo.Moto:

                        if(v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;

                    case ETipo.Automovil:

                        if(v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;

                    default:

                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary> 
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator + (Estacionamiento c, Vehiculo p)
        {
            int estaRepetido = 0;

            while (c.espacioDisponible > c.vehiculos.Count)
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        //return c;
                        estaRepetido = 1;
                    }
                }

                if (estaRepetido == 0)
                {
                    c.vehiculos.Add(p);
                }

                break;
            }
            
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator - (Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.Remove(p);
                    break;
                }
            }

            return c;
        }        
        
        #endregion
    }
}
