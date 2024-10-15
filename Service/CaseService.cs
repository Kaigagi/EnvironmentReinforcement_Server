using Server.Database;
using Server.Modal;
using System.Linq;

namespace Server.Service
{
    public class CaseService
    {
        private readonly AppDbContext _context;

        // Inject the DbContext into the service via Dependency Injection
        public CaseService(AppDbContext context)
        {
            _context = context;
        }

        // Create a new case in the database
        public void Create(Case caseObj)
        {
            _context.Case.Add(caseObj); // Add the new case
            _context.SaveChanges();     // Save changes to the database
        }

        // Read: Get a case by its ID
        public Case GetCase(long caseId)
        {
            return _context.Case.FirstOrDefault(c => c.Id == caseId); // Return a case with the matching ID
        }

        // Read: Get all cases
        public Case[] GetAllCases()
        {
            return _context.Case.ToArray(); // Return all cases in the database
        }

        // Update: Update an existing case
        public void Update(Case updatedCase)
        {
            var existingCase = _context.Case.FirstOrDefault(c => c.Id == updatedCase.Id);
            if (existingCase != null)
            {
                existingCase.Name = updatedCase.Name;
                existingCase.Address = updatedCase.Address;
                existingCase.Description = updatedCase.Description;
                existingCase.CooperatorId = updatedCase.CooperatorId;

                _context.Case.Update(existingCase);  // Update the case in the database
                _context.SaveChanges();
            }
        }

        // Delete: Delete a case by its ID
        public void Delete(long caseId)
        {
            var caseObj = _context.Case.FirstOrDefault(c => c.Id == caseId); // Find the case by ID
            if (caseObj != null)
            {
                _context.Case.Remove(caseObj); // Remove the case from the database
                _context.SaveChanges();        // Save the changes
            }
        }
    }
}