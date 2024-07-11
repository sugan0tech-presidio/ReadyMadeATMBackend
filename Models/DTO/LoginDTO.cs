using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Models.DTO
{
    public class LoginDTO
    {
        public string AtmNumber { get; set; }
        public int Pin { get; set; }
    }
}
