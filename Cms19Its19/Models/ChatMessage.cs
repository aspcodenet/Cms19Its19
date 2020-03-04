using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cms19Its19.Models
{
    public class ChatMessageModel
    {
        public List<ChatMessage> List { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string From { get; set; }
    }

    public class ChatMessage
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string From { get; set; }
    }
}
