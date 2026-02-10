using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEFDepartamentos.Models
{
    [Table("DEPT")]
    public class Departamento
    {
        [Key]
        [Column("DEPT_NO")]
        public int deptNo { get; set; }
        [Column("DNOMBRE")]
        public string dNombre { get; set; }
        [Column("LOC")]
        public string localidad { get; set; }
    }
}
