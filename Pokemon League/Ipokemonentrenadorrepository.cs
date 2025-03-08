using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_League
{
    interface Ipokemonentrenadorrepository
    {
        void Crear(Entrenadores entrenador);
        List<Entrenadores> Leer();
        void Actualizar(Entrenadores entrenador);
        void Eliminar(int identrenador);
    }
}
