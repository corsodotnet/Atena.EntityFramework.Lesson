using System;
using System.Collections.Generic;

#nullable disable

namespace Atena.EntityFramework.Lesson.Persistence
{
    public partial class Corso
    {
        public Corso()
        {
            Studentes = new HashSet<Studente>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePublished { get; set; }

        public virtual ICollection<Studente> Studentes { get; set; }
    }
}
