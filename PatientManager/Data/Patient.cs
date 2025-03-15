namespace PatientManager.Models // Namespace for models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime DateOfBirth {get; set; }
        public List<string>? Conditions { get; set; } = new List<string>();

        public Patient()
        {
            Conditions = new List<string>();    // Initialize to avoid null
        }
    }
}