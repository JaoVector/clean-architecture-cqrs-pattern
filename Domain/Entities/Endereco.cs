﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        [Key]
        public Guid EnderecoId { get; set; }
        [Required]
        [StringLength(9)]
        public string? Cep { get; set; }
        [Required]
        [StringLength(100)]
        public string? Rua { get; set; }
        [Required]
        [StringLength(100)]
        public string? Bairro { get; set; }
        [Required]
        public int Numero { get; set; }
    }
}
