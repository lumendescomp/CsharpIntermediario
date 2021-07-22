using System;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nome = "TreinaWeb"
            };
            /*Animal animal = new Animal
            {
                Id = 1,
                Especie = "Cachorro"
            };*/

            RepositorioGenerico<Pessoa> repositorioPessoa = new RepositorioGenerico<Pessoa>();

            //RepositorioGenerico<Animal> repositorioAnimal = new RepositorioGenerico<Animal>;

            repositorioPessoa.Insert(pessoa);
            //repositorioAnimal.Insert(animal);

            foreach (Pessoa p in repositorioPessoa.Get())
            {
                Console.WriteLine("Nome da pessoa: " + p.Nome);
            }
        }
    }
}
