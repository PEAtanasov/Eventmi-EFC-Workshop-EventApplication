using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmi.Core.Models
{
    public class TownDto
    {
        /// <summary>
        /// Town identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Town name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
