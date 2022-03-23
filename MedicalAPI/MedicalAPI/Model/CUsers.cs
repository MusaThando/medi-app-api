namespace MedicalAPI.Model
{
    public class CUsers
    {
        public Nullable<Guid> PersonGUIDfld { get; set; }
        public Nullable<Guid> UserTypeGUIDfld { get; set; }
        public string FullNamefld { get; set; }
        public string FirstNamefld { get; set; }
        public string LastNamefld { get; set; }
        public string Contactfld { get; set; }
        public string IDNumberfld { get; set; }
        public string Addressfld { get; set; }
        public string Emailfld { get; set; }

        public int IDfld { get; set; }
        public DateTime DateTimeLastUpdatedfld { get; set; }

        public List<CUsers> UsersList { get; set; }

        public CUsers()
        {
            UsersList = new List<CUsers>();
            FullNamefld = "";
            FirstNamefld = "";
            LastNamefld = "";
            Contactfld = "";
            IDNumberfld = "";
            Addressfld = "";
            Emailfld = "";
        }
    }
}
