using System;
using System.Collections.Generic;

#nullable disable

namespace Atena.EntityFramework.Lesson.Persistence
{
    public partial class Studente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePublished { get; set; }
        public int? CorsoId { get; set; }
        public string Email { get; set; }

        public virtual Corso Corso { get; set; }
    }
}
