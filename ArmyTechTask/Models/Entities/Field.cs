using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyTechTask.Models.Entities
    {
        [Table("Field")]
        public partial class Field
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Field()
            {
                Students = new HashSet<Student>();
            }

            public int ID { get; set; }

            [Required] [StringLength(50)] public string Name { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Student> Students { get; set; }
        }
    }