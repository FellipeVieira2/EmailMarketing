﻿using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Contato : Entity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public ICollection<ContatoPasta> ContatoPastas { get; set; }
    }
}
