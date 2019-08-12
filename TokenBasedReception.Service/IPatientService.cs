using TokenBasedReception.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Service
{
    public interface IPatientService
    {
        IQueryable<Patient> GetPatients(int totalCount,
            int startPosition,
            List<OrderByColumn> orderBy,
            Expression<Func<Patient, bool>> predicate,
            Expression<Func<Patient, bool>> searchPredicate = null);

        IQueryable<Patient> GetPatients();
        Patient GetPatient(long id);
        Patient GetPatient(string patientCode);
        IEnumerable<Patient> SearchPatient(string keyword);
        Patient InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
        
        int TotalCount(Expression<Func<Patient, bool>> predicate,
            Expression<Func<Patient, bool>> searchPredicate = null);
    }
}
