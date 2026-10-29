
using VideoRent.Domain;

namespace VideoRent.Test.Domain;
[TestFixture]
public class PeliculaTest
{
    [SetUp]
    public void Setup()
    {
    }

    
    [Test]
    public void Pelicula_Constructor_Con_PropiedadesInicializadas()
    {
        //Arrange
        int peliculaIdEsperado = 123;
        string tituloEsperado = "Ladrona de libros";
        bool estrenoEsperado = false;
        bool subtituladaEsperado = false;
        Genero genero = new Genero();
        genero.NombreGenero = "Drama";
        genero.GeneroId = 100;
        List<Actor> actors = new List<Actor>();
        Actor actor = new Actor();
        actor.ActorId = 10;
        actor.ApellidosActor = "Nélisse";
        actor.NombreActor = "Sophie";
        Actor actor1 = new Actor();
        actor1.ActorId = 11;
        actor1.ApellidosActor = "Montoya";
        actor1.NombreActor = "Camila";
        actors.Add(actor);
        actors.Add(actor1);

        // Act
        Pelicula pelicula = new Pelicula(peliculaIdEsperado,
            tituloEsperado,
            estrenoEsperado, subtituladaEsperado, genero, actors);

        // Assert

        Assert.That(peliculaIdEsperado == pelicula.PeliculaId);
        Assert.That(tituloEsperado == pelicula.Titulo);
        Assert.That(estrenoEsperado == pelicula.Estreno);
        Assert.That(subtituladaEsperado == pelicula.Subtitulada);
        // Todo más assertions para otras propiedades, como genero

        //desplegar los actores del objeto pelicula con un foreach
        Console.WriteLine("Hello World, i´m using C# for 1st time");
        Console.WriteLine("Test Pelicula");
        foreach (Actor a in pelicula.Actores)
        {
            Console.WriteLine($"Actor: {a.NombreActor} {a.ApellidosActor} [ID: { a.ActorId}] ");
        }
    }



}

