using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployedAPI.Models
{
    [Table("Conferences")]
    public class Conference
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConferenceId { get; set; }

        public string  ConferenceName { get; set; }

        public DateTime   ConferenceDateTime { get; set; }

        [JsonIgnore]
        public List<SessionTalk> SessionTalks { get; set; }

    }
}
