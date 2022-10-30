using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace single_layerExercise
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [Required]
        [ContainsCharacter("@.")]
        public string UserEmail { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public User()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public override string ToString()
        {
            return $"{UserName} - {UserEmail}";
        }
    }
}
