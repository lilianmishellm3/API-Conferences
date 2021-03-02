using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployedAPI.Models
{
    [Table("SessionTalk")]
    public class SessionTalk
    {
        public int SessionTalkId { get; set; }

        public string  SessionTalkName { get; set; }

        public string  SpeakerName { get; set; }


        //llave foranea
        [ForeignKey("FK_Conference")]
        public int ConferenceId { get; set; }

        [JsonIgnore]
        public Conference FK_Conference { get; set; }

    }
}
