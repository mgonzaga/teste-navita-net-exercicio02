
using MGonzaga.IoC.NETCore.Domain.Models;
using System;
using System.Linq;

namespace MGonzaga.IoC.NETCore.Domain.Models.Filters
{
    public static class MarcaFilter
    {
        public static IQueryable<Marca> WithNome(this IQueryable<Marca> query, string nome)
        {
            if (!string.IsNullOrEmpty(nome)) query = query.Where(_ => _.Nome == nome);
            return query;
        }
        public static IQueryable<Marca> WithId(this IQueryable<Marca> query, int id)
        {
            if (id > 0) query = query.Where(_ => _.Id == id);
            return query;
        }
    }
}
