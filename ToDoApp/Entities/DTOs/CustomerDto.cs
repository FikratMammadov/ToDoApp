using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDto:IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
