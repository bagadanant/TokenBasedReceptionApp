using TokenBasedReception.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Service
{
    public class PatientService : IPatientService
    {
        private IRepository<Patient> patientRepository;
    
        public PatientService(IRepository<Patient> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public IQueryable<Patient> GetPatients(int totalCount,
            int startPosition,
            List<OrderByColumn> orderBy,
            Expression<Func<Patient, bool>> predicate,
            Expression<Func<Patient, bool>> searchPredicate = null)
        {
            string orderExp = OrderByHelper.GetOrderExpression(orderBy);

            if (searchPredicate == null)
                return patientRepository
                    .Table
                    .Where(predicate)
                    .OrderBy(orderExp)
                    .Skip(startPosition)
                    .Take(totalCount);
            else
                return patientRepository
                    .Table
                    .Where(predicate)
                    .Where(searchPredicate)
                    .OrderBy(orderExp)
                    .Skip(startPosition)
                    .Take(totalCount);
        }


        public IQueryable<Patient> GetPatients()
        {
            return patientRepository.Table.Where(x => x.Deleted == false);
        }

        public Patient GetPatient(string patientCode)
        {
            //IEnumerable<Patient> result = patientRepository
            //                                    .Table
            //                                    .Where(x => x.Code.ToLower() == patientCode.ToLower()
            //                                                && x.Deleted == false);

            //if (result != null && result.Count() > 0)
            //    return result.First();

            //return null;
            throw new NotImplementedException();
        }

        public Patient GetPatient(long id)
        {
            return patientRepository.GetById(id);
        }

        public IEnumerable<Patient> SearchPatient(string keyword)
        {
            IEnumerable<Patient> result = patientRepository
                                                .Table
                                                .Where(x => (x.FirstName.ToLower().Contains(keyword.ToLower())
                                                                || x.LastName.ToLower().Contains(keyword.ToLower())
                                                                || x.PhoneNumber.Contains(keyword))
                                                            && x.Deleted == false);

            return result;
        }

        public Patient InsertPatient(Patient patient)
        {
            return patientRepository.Insert(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            patientRepository.Update(patient);
        }

        public void DeletePatient(Patient patient)
        {
            patientRepository.Delete(patient);
        }

        public int TotalCount(Expression<Func<Patient, bool>> predicate,
                    Expression<Func<Patient, bool>> searchPredicate = null)
        {
            return patientRepository.TotalCount(predicate, searchPredicate);
        }
    }
}
