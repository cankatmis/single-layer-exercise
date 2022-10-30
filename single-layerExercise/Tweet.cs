using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace single_layerExercise
{
    [Table("Tweets")]
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Flagged { get; set; }
        public int Year { get; set; }
        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{Content} - {Flagged} - {Year}";
        }
    }
}
