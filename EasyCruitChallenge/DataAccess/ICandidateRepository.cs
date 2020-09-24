using System.Linq;
using System.Threading.Tasks;
using EasyCruitChallenge.Models;

namespace EasyCruitChallenge.DataAccess
{
    public interface ICandidateRepository
    {
        /// <summary>
        /// Creates a new candidate.
        /// </summary>
        /// <param name="candidate">Candidate to be created.</param>
        Task<bool> Create(Candidate candidate);

        /// <summary>
        /// Gets a candidate by candidate ID.
        /// </summary>
        /// <param name="candidateId">Given candidate ID.</param>
        Candidate Get(int candidateId);

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        /// <returns></returns>
        IOrderedQueryable<Candidate> GetAll();

        /// <summary>
        /// Deletes a given candidate.
        /// </summary>
        /// <param name="candidateId">Candidate ID.</param>
        Task<bool> Delete(int candidateId);
    }
}
