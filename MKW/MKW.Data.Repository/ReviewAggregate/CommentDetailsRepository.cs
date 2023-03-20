﻿using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;

namespace MKW.Data.Repository.ReviewAggregate
{
    /// <summary>
    /// Repositório para a entidade CommentDetails. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class CommentDetailsRepository : BaseRepository<CommentDetails>, ICommentDetailsRepository
    {
        public CommentDetailsRepository(MKWContext context) : base(context)
        {
        }
    }
}
