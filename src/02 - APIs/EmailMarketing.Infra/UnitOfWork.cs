﻿using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmailMarketingContext _context;
        public IEmpresaRepository Empresas { get; }
        public IPermissoesRepository Permissoes { get; }
        public IUsuarioRepository Usuarios { get; }
        public IMensagemRepository Mensagens { get; }
        public ICampanhaRepository Campanhas { get; }
        public UnitOfWork(EmailMarketingContext context,
            IEmpresaRepository empresa,
            IPermissoesRepository permissoes,
            IUsuarioRepository usuario,
            IMensagemRepository mensagens,
            ICampanhaRepository campanhas)
        {
            _context = context;
            Empresas = empresa;
            Permissoes = permissoes;
            Usuarios = usuario;
            Mensagens = mensagens;
            Campanhas = campanhas;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
