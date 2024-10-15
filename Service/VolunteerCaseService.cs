using Server.Database;
using Server.Modal;
using System.Linq;

namespace Server.Service
{
    public class VolunteerCaseService
    {
        private readonly AppDbContext _context;

        public VolunteerCaseService(AppDbContext context)
        {
            _context = context;
        }

        // Assign a volunteer to a case
        public void AssignVolunteerToCase(long volunteerId, long caseId)
        {
            var volunteerCase = new VolunteerCase { volunteerId = volunteerId, caseId = caseId };
            _context.VolunteerCase.Add(volunteerCase); // No 's' here
            _context.SaveChanges();
        }

        // Get all cases assigned to a specific volunteer
        public VolunteerCase[] GetCasesByVolunteer(long volunteerId)
        {
            return _context.VolunteerCase
                           .Where(vc => vc.volunteerId == volunteerId)
                           .ToArray();
        }

        // Get all volunteers assigned to a specific case
        public VolunteerCase[] GetVolunteersByCase(long caseId)
        {
            return _context.VolunteerCase
                           .Where(vc => vc.caseId == caseId)
                           .ToArray();
        }

        // Remove a volunteer from a case
        public void RemoveVolunteerFromCase(long volunteerId, long caseId)
        {
            var volunteerCase = _context.VolunteerCase
                                        .FirstOrDefault(vc => vc.volunteerId == volunteerId && vc.caseId == caseId);
            if (volunteerCase != null)
            {
                _context.VolunteerCase.Remove(volunteerCase);
                _context.SaveChanges();
            }
        }

        // Get all volunteer-case relationships
        public VolunteerCase[] GetAllVolunteerCases()
        {
            return _context.VolunteerCase.ToArray();
        }
    }
}