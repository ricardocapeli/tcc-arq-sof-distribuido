using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_veiculos")]
    public class Veiculo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("placa")]
        public string Placa { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("ano")]
        public int Ano { get; set; }

        [Column("cor")]
        public string Cor { get; set; }


    }
}
