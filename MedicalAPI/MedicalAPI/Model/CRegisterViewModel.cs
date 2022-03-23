namespace MedicalAPI.Model
{
    public class CRegisterViewModel
    {
        public Nullable<Guid> DocumentRepositoryGUIDfld { get; set; }
        public Nullable<Guid> SourceRecordGUIDfld { get; set; }
        public Nullable<Guid> PrimaryDoctorGUIDfld { get; set; }
        public Nullable<Guid> UserTypeGUIDfld { get; set; }
        public Nullable<Guid> PracticeGUIDfld { get; set; }
        public Nullable<Guid> PersonGUIDfld { get; set; }
        public Nullable<Guid> NextOfKinGUIDfld { get; set; }
        public string FullNamefld { get; set; }
        public string FirstNamefld { get; set; }
        public string Authorise { get; set; }
        public string Typefld { get; set; }
        public int StatusCode { get; set; }
        public string PasswordCheck { get; set; }
        public string NextOfKinLastNamefld { get; set; }
        public string NextOfKinContactfld { get; set; }
        public string NextOfKinFirstNamefld { get; set; }
        public string LastNamefld { get; set; }
        public string Contactfld { get; set; }
        public string Emailfld { get; set; }
        public string IDNumberfld { get; set; }
        public string Addressfld { get; set; }
        public string PracticeAddressfld { get; set; }
        public string Usernamefld { get; set; }
        public string Passwordfld { get; set; }
        public string RegistrationNumberfld { get; set; }
        public string PracticeRegistration { get; set; }
        public string PracticeNamefld { get; set; }
        public string ConfirmPasswordfld { get; set; }
        public string MedicalAidPlanfld { get; set; }
        public string MedicalAidNumberfld { get; set; }
        public string MedicalAidEmailfld { get; set; }
        public string MedicalAidContactfld { get; set; }
        public List<CRegisterViewModel> UsersList { get; set; }
        public List<CRegisterViewModel> DoctorList { get; set; }
        public List<CRegisterViewModel> AdminList { get; set; }
        public List<CRegisterViewModel> Transations { get; set; }
        public int IDfld { get; set; }

        public string FileNamefld { get; set; }
        public string FileTypefld { get; set; }
        public byte[]? FileContentfld { get; set; }
        public bool Publicfld { get; set; }

        public CRegisterViewModel()
        {
            UsersList = new List<CRegisterViewModel>();
            DoctorList = new List<CRegisterViewModel>();
            AdminList = new List<CRegisterViewModel>();
            Transations = new List<CRegisterViewModel>();

            MedicalAidEmailfld = "";
            MedicalAidPlanfld = "";
            MedicalAidNumberfld = "";
            MedicalAidContactfld = "";
            PracticeAddressfld = "";
            PracticeRegistration = "";
            PracticeNamefld = "";
            NextOfKinContactfld = "";
            NextOfKinFirstNamefld = "";
            NextOfKinLastNamefld = "";
            Typefld = "";
            Authorise = "";

            FullNamefld = "";
            FirstNamefld = "";
            LastNamefld = "";
            Contactfld = "";
            IDNumberfld = "";
            Addressfld = "";
            Emailfld = "";
            RegistrationNumberfld = "";
            Publicfld = false;
            
            FileTypefld = "";
            FileNamefld = "";
            IDfld = 0;
            PasswordCheck = "";
            Usernamefld = "";
            Passwordfld = "";
            ConfirmPasswordfld = "";
        }
    }

}
