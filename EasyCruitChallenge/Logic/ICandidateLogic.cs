using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCruitChallenge.Models;

namespace EasyCruitChallenge.Logic
{
    public interface ICandidateLogic
    {
        /// <summary>
        /// Creates a new candidate in the database.
        /// </summary>
        /// <param name="candidate">Candidate to be created.</param>
        Candidate Create(Candidate candidate);

        /// <summary>
        /// Gets a candidate by ID.
        /// </summary>
        /// <param name="candidateId">Candidate ID.</param>
        Candidate Get(int candidateId);

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        List<Candidate> GetAll();

        /// <summary>
        /// Deletes a candidate.
        /// </summary>
        /// <param name="candidateId">Candidate ID.</param>
        bool Delete(int candidateId);
    }
}
