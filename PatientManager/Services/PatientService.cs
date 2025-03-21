using PatientManager.Models; // Import namespace where Patient is defiend

namespace PatientManager.Services
{
    public class PatientService
    {
        private List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            patient.Id = patients.Count > 0 ? patients.Max(p => p.Id) + 1 : 1;
            patients.Add(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return patients;
        }

        public Patient GetPatientById(int id)
        {
            return patients.FirstOrDefault(p => p.Id == id);
        }

        public Patient GetPatientByName(string name)
        {
            return patients.FirstOrDefault(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        // Delete a patient by Id
        public bool DeletePatient(int id)
        {
            var patient = GetPatientById(id);
            if (patient != null)
            {
                patients.Remove(patient);
                return true;    // patient successfully removed
            }
            return false;   // patient not found
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) age--;  // Adjust if their birthday hasn't happened yet this year

            return age;
        }
    }
}

