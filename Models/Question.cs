using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPICore.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] Updated { get; set; }
    }
}
