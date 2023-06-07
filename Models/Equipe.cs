using System.ComponentModel.DataAnnotations;

namespace gamer_beck.Controllers
{
    public class Equipe
    {
        [Key]//DATA ANNOTATION - IdEquipe
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; } 

        //REFERENCIA QUE A CLASSE EQUIPE VAI TER ACESSO 
        //A COLLECTION "JOGADOR"
        public ICollection<Jogador> Jogador {get;set;} 

    }
}