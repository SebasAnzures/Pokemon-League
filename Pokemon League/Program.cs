namespace Pokemon_League
{
    class Program
    {
        static void Main()
        {
            Conexión conexión = new Conexión();
            Ipokemonentrenadorrepository repository = new Pokemonentrenadorrepository(conexión);

            bool loop = true;
            while(loop)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Sistema de Entrenadores de la Liga Pokemon de Hoenn");
                Console.WriteLine("1) Agregar un entrenador");
                Console.WriteLine("2) Ver entrenadores registrados");
                Console.WriteLine("3) Actualizar la informacion de algun entrenador");
                Console.WriteLine("4) Elimniar un entrenador");
                Console.WriteLine("5) Salir");
                Console.WriteLine("-----------------------------------------------------");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------");

                switch (opcion)
                {
                    case 1:
                        Entrenadores entrenador = new Entrenadores();

                        Console.WriteLine("Nombre del Entrenador:");
                        entrenador.nombre = Console.ReadLine();

                        Console.WriteLine("Ciudad de Origen:");
                        entrenador.ciudad = Console.ReadLine();

                        Console.WriteLine("Pokemon Insignia del Entrenador:");
                        entrenador.pokemon = Console.ReadLine();

                        Console.WriteLine("Tipo(s) del Pokemon:");
                        entrenador.tipo = Console.ReadLine();

                        Console.WriteLine("Nivel del Pokemon:");
                        entrenador.nivel = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Movimiento 1:");
                        entrenador.m1 = Console.ReadLine();

                        Console.WriteLine("Movimiento 2:");
                        entrenador.m2 = Console.ReadLine();

                        Console.WriteLine("Movimiento 3:");
                        entrenador.m3 = Console.ReadLine();

                        Console.WriteLine("Movimiento 4:");
                        entrenador.m4 = Console.ReadLine();

                        Console.WriteLine("Liga Ganada:");
                        entrenador.ligadanada = Console.ReadLine();

                        repository.Crear(entrenador);
                        break;
                    case 2:
                        var listapokemon = repository.Leer();

                        foreach (var p in listapokemon)
                        {
                            Console.WriteLine($"{p.identrenador} - {p.nombre} - {p.pokemon}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Entrenador a eliminar:");
                        int identrenador = Convert.ToInt32(Console.ReadLine());
                        repository.Eliminar(identrenador);
                        break;
                    case 4:
                        Console.WriteLine("Opcion no disponible");
                        break;
                    case 5:
                        loop = false;
                        break;
                }
            }
            Console.WriteLine("Hasta luego :)");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}