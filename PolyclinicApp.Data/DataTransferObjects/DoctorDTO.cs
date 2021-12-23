namespace PolyclinicApp.Data.DataTransferObjects
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public int SpecializationId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string FullName => Surname + " " + FirstName + " " + Patronymic + " " + SpecializationName;

        public string SpecializationName { get; set; }
    }
}