using System;
using System.Linq;
using System.Threading.Tasks;
using EasyCruitChallenge.DatabaseContext;
using EasyCruitChallenge.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCruitChallenge.DataAccess
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IServiceScope _scope;
        private readonly CandidateDatabaseContext _databaseContext;
        public CandidateRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _databaseContext = _scope.ServiceProvider.GetRequiredService<CandidateDatabaseContext>();
        }

        /// <summary>
        /// Creates a new candidate.
        /// </summary>
        /// <param name="candidate">Candidate to be created.</param>
        public async Task<bool> Create(Candidate candidate)
        {
            var success = false;

            _databaseContext.Candidates.Add(candidate);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated > 0)
                success = true;

            return success;
        }

        /// <summary>
        /// Gets a candidate by candidate ID.
        /// </summary>
        /// <param name="candidateId">Given candidate ID.</param>
        public Candidate Get(int candidateId)
        {
            var result = _databaseContext.Candidates
                .Where(x => x.CandidateId == candidateId)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        /// <returns></returns>
        public IOrderedQueryable<Candidate> GetAll()
        {
            return _databaseContext.Candidates.OrderBy(X => X.CandidateId);
        }

        /// <summary>
        /// Deletes a given candidate.
        /// </summary>
        /// <param name="candidateId">Candidate ID.</param>
        public async Task<bool> Delete(int candidateId)
        {
            var success = false;
            var existingCandidate = Get(candidateId);

            if (existingCandidate != null)
            {
                _databaseContext.Candidates.Remove(existingCandidate);
                var numberOfItemsDeleted = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsDeleted > 0)
                    success = true;
            }

            return success;
        }
    }
}
