using TokenBasedReception.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Service
{
    public class DiseaseService : IDiseaseService
    {
        private IRepository<Disease> diseaseRepository;

        public DiseaseService(IRepository<Disease> diseaseRepository)
        {
            this.diseaseRepository = diseaseRepository;
        }

        public IQueryable<Disease> GetDiseases(int totalCount,
            int startPosition,
            List<OrderByColumn> orderBy,
            Expression<Func<Disease, bool>> predicate,
            Expression<Func<Disease, bool>> searchPredicate = null)
        {
            string orderExp = OrderByHelper.GetOrderExpression(orderBy);

            if (searchPredicate == null)
                return diseaseRepository
                    .Table
                    .Where(predicate)
                    .OrderBy(orderExp)
                    .Skip(startPosition)
                    .Take(totalCount);
            else
                return diseaseRepository
                    .Table
                    .Where(predicate)
                    .Where(searchPredicate)
                    .OrderBy(orderExp)
                    .Skip(startPosition)
                    .Take(totalCount);
        }


        public IQueryable<Disease> GetDiseases()
        {
            return diseaseRepository.Table.Where(x => x.Deleted == false);
        }

        public Disease GetDisease(string diseaseCode)
        {
            IEnumerable<Disease> result = diseaseRepository
                                                .Table
                                                .Where(x => x.Code.ToLower() == diseaseCode.ToLower()
                                                            && x.Deleted == false);

            if (result != null && result.Count() > 0)
                return result.First();

            return null;
        }

        public Disease GetDisease(long id)
        {
            return diseaseRepository.GetById(id);
        }

        public Disease InsertDisease(Disease disease)
        {
            return diseaseRepository.Insert(disease);
        }

        public void UpdateDisease(Disease disease)
        {
            diseaseRepository.Update(disease);
        }

        public void DeleteDisease(Disease disease)
        {
            diseaseRepository.Delete(disease);
        }

        public int TotalCount(Expression<Func<Disease, bool>> predicate,
                    Expression<Func<Disease, bool>> searchPredicate = null)
        {
            return diseaseRepository.TotalCount(predicate, searchPredicate);
        }

        public IQueryable<Disease> GetTopDisease(int count)
        {
            throw new NotImplementedException();
        }
    }
}
