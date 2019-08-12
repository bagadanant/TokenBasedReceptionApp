using TokenBasedReception.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Service
{
    public interface IDiseaseService
    {
        IQueryable<Disease> GetDiseases(int totalCount,
            int startPosition,
            List<OrderByColumn> orderBy,
            Expression<Func<Disease, bool>> predicate,
            Expression<Func<Disease, bool>> searchPredicate = null);

        IQueryable<Disease> GetDiseases();
        Disease GetDisease(long id);
        Disease GetDisease(string diseaseCode);
        Disease InsertDisease(Disease disease);
        void UpdateDisease(Disease disease);
        void DeleteDisease(Disease disease);

        int TotalCount(Expression<Func<Disease, bool>> predicate,
            Expression<Func<Disease, bool>> searchPredicate = null);

        IQueryable<Disease> GetTopDisease(int count);
    }
}
