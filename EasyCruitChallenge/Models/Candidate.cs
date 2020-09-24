using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCruitChallenge.Models
{
    /// <summary>
    /// EasyCruit challenge candidate.
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// Candidate identifier.
        /// </summary>
        public int CandidateId { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Link to motivational letter.
        /// </summary>
        /// <remarks>
        /// To not use the same variable for link and text, we seperate it out. 
        /// When using this POCO for POST to create a new candidate Text is filled, but when returning a candidate - Link is filled.
        /// </remarks>
        public string MotivationLetterLink { get; set; }

        /// <summary>
        /// Motivational letter text.
        /// </summary>
        /// <remarks>
        /// To not use the same variable for link and text, we seperate it out. 
        /// When using this POCO for POST to create a new candidate Text is filled, but when returning a candidate - Link is filled.
        /// </remarks>
        public string MotivationLetterText { get; set; }
    }
}
