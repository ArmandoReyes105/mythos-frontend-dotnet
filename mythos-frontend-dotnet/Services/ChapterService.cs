using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public class ChapterService : IChapterService
    {
        private readonly HttpClient _httpClient;

        public ChapterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Chapter?> GetChapterAsync(int id)
        {
            try
            {
                // Simulamos datos ya que es standalone
                await Task.Delay(500); // Simular latencia de red

                return GetSimulatedChapter(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> MarkAsReadAsync(int id)
        {
            try
            {
                // Simular llamada a API
                await Task.Delay(200);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Chapter GetSimulatedChapter(int id)
        {
            var chapters = new List<Chapter>
            {
                new Chapter
                {
                    Id = 1,
                    Title = "El Despertar de los Antiguos",
                    BookTitle = "Crónicas de Mythos",
                    ChapterNumber = 1,
                    Content = @"En las profundidades del océano, donde la luz del sol jamás ha tocado el lecho marino, yacen ciudades que desafían toda comprensión humana. R'lyeh, la ciudad sumergida, aguarda en silencio el momento de su despertar.

                    Los antiguos textos hablan de criaturas que una vez dominaron la Tierra, seres cuyo poder trascendía las leyes de la física y la realidad tal como la conocemos. Cthulhu, el Gran Sacerdote de los Antiguos, duerme en su casa de piedra, pero su sueño no es eterno.

                    Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn - 'En su casa de R'lyeh, el muerto Cthulhu espera soñando'. Estas palabras, grabadas en tablillas de piedra negra, han sido encontradas en los rincones más remotos del mundo, desde las montañas de la Antártida hasta los desiertos de Arabia.

                    Los investigadores que han estudiado estos textos han reportado sueños extraños, visiones de ciudades imposibles con geometrías que duelen a la mente humana. Algunos han desaparecido sin dejar rastro, otros han sido encontrados en estado catatónico, murmurando palabras en idiomas que no deberían existir.

                    El profesor Armitage de la Universidad de Miskatonic ha dedicado su vida al estudio de estos fenómenos. Sus investigaciones lo han llevado a conclusiones que desafían todo lo que creemos saber sobre nuestro mundo y nuestro lugar en el universo.

                    'No somos los primeros en habitar este planeta', escribió en sus notas privadas, 'y ciertamente no seremos los últimos. Los Antiguos esperan, y cuando las estrellas se alineen correctamente, regresarán para reclamar lo que una vez fue suyo.'

                    Los signos están por todas partes para aquellos que saben cómo leer las señales. Las mareas cambian de manera inexplicable, los animales marinos se comportan de forma errática, y en las noches más oscuras, algunos pescadores juran haber visto luces extrañas bajo las aguas del Pacífico.

                    El tiempo se agota, y la humanidad permanece ignorante del peligro que se cierne sobre ella. Pero hay quienes vigilan, quienes conocen la verdad y se preparan para lo inevitable. La pregunta no es si los Antiguos despertarán, sino cuándo, y si estaremos preparados para enfrentar una realidad que está más allá de nuestra comprensión."
                },
                new Chapter
                {
                    Id = 2,
                    Title = "Los Susurros de Dunwich",
                    BookTitle = "Crónicas de Mythos",
                    ChapterNumber = 2,
                    Content = @"El pueblo de Dunwich siempre ha sido un lugar extraño, anidado entre colinas cubiertas de bosques antiguos donde los árboles crecen de formas imposibles y las sombras se mueven independientemente de sus fuentes de luz.

                    Wilbur Whateley nació en una noche sin luna, cuando las estrellas formaban patrones que los astrónomos no podían explicar. Su madre, Lavinia, había sido vista hablando con figuras que nadie más podía ver, y su abuelo, el viejo Whateley, poseía libros que estaban escritos en idiomas que predataban a la civilización humana.

                    Desde temprana edad, Wilbur mostró un crecimiento anormal. A los diez años, tenía la estatura de un adolescente, y su inteligencia superaba la de muchos adultos. Pero había algo más, algo que los habitantes del pueblo preferían no mencionar en voz alta.

                    Los animales huían de él, los perros aullaban cuando se acercaba, y las plantas se marchitaban bajo su toque. En las noches, los vecinos reportaban haber escuchado voces extrañas provenientes de la granja de los Whateley, conversaciones en idiomas que hacían que sus oídos sangraran.

                    El Necronomicón, ese libro maldito que el viejo Whateley guardaba celosamente, contenía los secretos que Wilbur necesitaba para completar su propósito. Las páginas, escritas en piel humana con tinta hecha de sangre de criaturas innombrables, describían rituales que podían abrir puertas entre dimensiones.

                    'Los Antiguos fueron, los Antiguos son, y los Antiguos serán', recitaba Wilbur mientras trazaba símbolos en el suelo de tierra de su habitación. 'No en los espacios que conocemos, sino entre ellos, caminan serenos y primordiales, sin dimensiones y para nosotros invisibles.'

                    La biblioteca de la Universidad de Miskatonic poseía una copia del Necronomicón, pero estaba bajo llave, protegida por aquellos que entendían su peligro. Wilbur sabía que necesitaba acceso a esas páginas faltantes, los pasajes que su abuelo había arrancado de su propia copia antes de morir.

                    Cuando finalmente llegó a Arkham, su presencia fue sentida inmediatamente por aquellos sensibles a las fuerzas sobrenaturales. El Dr. Armitage, guardián de los textos prohibidos, reconoció inmediatamente la amenaza que representaba este joven extraño.

                    Pero Wilbur no era el verdadero peligro. En las colinas de Dunwich, algo más grande, algo más terrible, esperaba el momento de su liberación. Su hermano gemelo, invisible a los ojos humanos, crecía en las sombras, alimentándose de la esencia vital de todo lo que lo rodeaba."
                }
            };

            return chapters.FirstOrDefault(c => c.Id == id) ?? chapters.First();
        }
    }
}
