using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyCruitChallenge.DataAccess;
using EasyCruitChallenge.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;

namespace EasyCruitChallenge.Logic
{
    public class CandidateLogic : ICandidateLogic
    {
        private readonly ICandidateRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidateLogic(ICandidateRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Creates a new candidate in the database.
        /// </summary>
        /// <param name="candidate">Candidate to be created.</param>
        public async Task<Candidate> Create(Candidate candidate)
        {
            var success = await _repository.Create(candidate);

            // In a real world scenario I would use Hangfire. I have experience using Hangfire for years at work.
            var fileName = $"candidate{candidate.CandidateId}.txt";
            candidate.MotivationLetterLink = fileName;

            var state = new
            {
                Candidate = candidate,
                Path = $"{_webHostEnvironment.WebRootPath}/{fileName}"
            };

            ThreadPool.QueueUserWorkItem(info =>
            {
                File.WriteAllText(info.Path, info.Candidate.MotivationLetterText);

            }, state, preferLocal: true);

            if (success)
                return candidate;
            else
                return null;
        }

        /// <summary>
        /// Gets a candidate by ID.
        /// </summary>
        /// <param name="candidateId">Candidate ID.</param>
        public Candidate Get(int candidateId)
        {
            return _repository.Get(candidateId);
        }

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        public List<Candidate> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        /// <summary>
        /// Deletes a candidate.
        /// </summary>
        /// <param name="candidateId">Candidate ID.</param>
        public async Task<bool> Delete(int candidateId)
        {
            var fileName = $"candidate{candidateId}.txt";

            var state = new
            {
                Path = $"{_webHostEnvironment.WebRootPath}/{fileName}"
            };

            ThreadPool.QueueUserWorkItem(info =>
            {
                File.Delete(info.Path);

            }, state, preferLocal: true);

            return await _repository.Delete(candidateId);
        }
    }
}
