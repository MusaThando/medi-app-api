using Dapper;
using MedicalAPI.Model;
using System.Data;

using System.Data.SqlClient;

namespace MedicalAPI.DAL
{
    public class MediAppDAL
    {

        #region User Registering
        public async Task<Guid> PostRegistration(CRegisterViewModel cRegisterViewModel)
        {

            string query = "[dbo].[PostPerson]";

            int res = 0;

            Guid personGuid = Guid.NewGuid();

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PersonGUIDfld", personGuid, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@FirstNamefld", cRegisterViewModel.FirstNamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@Lastnamefld", cRegisterViewModel.LastNamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@Contactfld", cRegisterViewModel.Contactfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@Addressfld", cRegisterViewModel.Addressfld, DbType.String, ParameterDirection.Input, -1);
                parameter.Add("@Emailfld", cRegisterViewModel.Emailfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@PrimaryDoctorGUIDfld", cRegisterViewModel.PrimaryDoctorGUIDfld, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@UserTypeGUIDfld", cRegisterViewModel.UserTypeGUIDfld, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@PracticeGUIDfld", cRegisterViewModel.PracticeGUIDfld, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@IDNumberfld", cRegisterViewModel.IDNumberfld, DbType.String, ParameterDirection.Input, 13);

                res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            }

            if (res == 1)
            { return personGuid; }
            else { return Guid.Empty; }
        }
        public async Task<int> PostMedicalAidInformation(CMedicalAid cMedicalAid)
        {
            string query = "[dbo].[PostMedicalAidInformation]";

            int res;

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@MedicalAidNumberfld", cMedicalAid.MedicalAidNumberfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@MedicalAidContactfld", cMedicalAid.MedicalAidContactfld, DbType.String, ParameterDirection.Input, 13);
                parameter.Add("@MedicalAidPlanfld", cMedicalAid.MedicalAidPlanfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@PersonGUIDfld", cMedicalAid.PersonGUIDfld, DbType.Guid, ParameterDirection.Input);

                res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<int> PostUserPassword(CCredentials cCredentials, string encryptedPassword)
        {
            string query = "[dbo].[PostAuthenticationInformation]";

            int res;

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@Passwordfld", encryptedPassword, DbType.String, ParameterDirection.Input);
                parameter.Add("@ConfirmPasswordfld", encryptedPassword, DbType.String, ParameterDirection.Input);
                parameter.Add("@Usernamefld", cCredentials.Usernamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@PersonGUIDfld", cCredentials.PersonGUIDfld, DbType.Guid, ParameterDirection.Input);

                res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
        #endregion
        #region User Login
        public async Task<CRegisterViewModel> GetAuthorization(string username, string password)
        {
            var register = new CRegisterViewModel();

            string query = "[dbo].[GetAuthorization]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@Usernamefld", username, DbType.String, ParameterDirection.Input);
                parameter.Add("@Passwordfld", password, DbType.String, ParameterDirection.Input);

                register = await db.QueryFirstAsync<CRegisterViewModel>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return register;
        }
        #endregion

        #region Get List Functions
        public async Task<List<CRegisterViewModel>> GetDoctors()
        {
            var res = new List<CRegisterViewModel>();

            string query = "[dbo].[GetAllDoctors]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                res = (List<CRegisterViewModel>)await db.QueryAsync<CRegisterViewModel>(query, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<List<CRegisterViewModel>> GetUsers()
        {
            var res = new List<CRegisterViewModel>();

            string query = "[dbo].[GetAllUsers]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                res = (List<CRegisterViewModel>)await db.QueryAsync<CRegisterViewModel>(query, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<List<CRegisterViewModel>> GetAdmin()
        {
            var res = new List<CRegisterViewModel>();

            string query = "[dbo].[GetAllAdmins]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                res = (List<CRegisterViewModel>)await db.QueryAsync<CRegisterViewModel>(query, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<List<CDisease>> GetTransaction()
        {
            var res = new List<CDisease>();

            string query = "[dbo].[GetTransaction]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                res = (List<CDisease>)await db.QueryAsync<CDisease>(query, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<List<CDocumentRepository>> GetUserDocuments(Guid personGuid)
        {
            var res = new List<CDocumentRepository>();

            string query = "[dbo].[GetAllUserDocuments]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@SourceRecordGUIDfld", personGuid, DbType.Guid, ParameterDirection.Input);

                res = (List<CDocumentRepository>)await db.QueryAsync<CDocumentRepository>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<List<CDocumentRepository>> GetPublicDocuments(Guid personGuid)
        {
            var res = new List<CDocumentRepository>();

            string query = "[dbo].[GetPublicDocuments]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@SourceRecordGUIDfld", personGuid, DbType.Guid, ParameterDirection.Input);

                res = (List<CDocumentRepository>)await db.QueryAsync<CDocumentRepository>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<List<CDisease>> GetDiseaseByICDCode(string code) 
        {
            var res = new List<CDisease>();

            string query = "[dbo].[GetDiseasesByICDCode]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@ICD10Codefld", code, DbType.String, ParameterDirection.Input);

                res = (List<CDisease>)await db.QueryAsync<CDisease>(query,parameter,commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<List<CDisease>> GetDiseaseByDescription(string description)
        {
            var res = new List<CDisease>();

            string query = "[dbo].[GetDiseasesByDescription]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@DiagnosisDescriptionfld", description, DbType.String, ParameterDirection.Input);

                res = (List<CDisease>)await db.QueryAsync<CDisease>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        #endregion

        #region Get Object Functions
        public async Task<CRegisterViewModel> GetProfileDetails(Guid personGuid)
        {
            var res = new CRegisterViewModel();

            string query = "[dbo].[GetUserProfileDetails]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PersonGuid", personGuid, DbType.Guid, ParameterDirection.Input);

                res = await db.QueryFirstAsync<CRegisterViewModel>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<CRegisterViewModel> GetUsersDetails(Guid personGuid)
        {
            var res = new CRegisterViewModel();

            string query = "[dbo].[GetUsersDetailsByID]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PersonGuid", personGuid, DbType.Guid, ParameterDirection.Input);

                res = await db.QueryFirstAsync<CRegisterViewModel>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<CRegisterViewModel> GetDoctorDetails(Guid personGuid)
        {
            var res = new CRegisterViewModel();

            string query = "[dbo].[GetDoctorDetailsByID]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PersonGuid", personGuid, DbType.Guid, ParameterDirection.Input);

                res = await db.QueryFirstAsync<CRegisterViewModel>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<string> GetPersonType(Guid personGuid)
        {
            string res = "";

            string query = "[dbo].[GetPersonType]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PersonGUIDfld", personGuid, DbType.Guid, ParameterDirection.Input);

                res = await db.QueryFirstAsync<string>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        public async Task<CDocumentRepository> GetDocumentByID(Guid documentRepository)
        {
            var res = new CDocumentRepository();

            string query = "[dbo].[GetDocumentByID]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@DocumentRepositoryGUIDfld", documentRepository, DbType.Guid, ParameterDirection.Input);

                res = await db.QueryFirstAsync<CDocumentRepository>(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        #endregion

        #region Post Functions
        public async Task<Guid> PostPractice(CPractice obj)
        {
            Guid practiceGuid = Guid.NewGuid();
            int res;
            string query = "[dbo].[PostDoctorPractice]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PracticeGUIDfld", practiceGuid, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@PracticeNamefld", obj.PracticeNamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@PracticeRegistration", obj.PracticeRegistration, DbType.String, ParameterDirection.Input);
                parameter.Add("@Addressfld", obj.Addressfld, DbType.String, ParameterDirection.Input);

                res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            }
            if (res == 1)
                return practiceGuid;
            else
                return Guid.Empty;

        }
        public async Task<int> PostDocument(CDocumentRepository obj)
        {
            string query = "[dbo].[PostDocument]";
            int res;

            using IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString());
            var parameter = new DynamicParameters();

            parameter.Add("@FileNamefld", obj.FileNamefld, DbType.String, ParameterDirection.Input);
            parameter.Add("@FileTypefld", obj.FileTypefld, DbType.String, ParameterDirection.Input);
            parameter.Add("@Publicfld", obj.Publicfld, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@FileContentfld", obj.FileContentfld, DbType.Binary, ParameterDirection.Input);
            parameter.Add("@SourceRecordGUIDfld", obj.SourceRecordGUIDfld, DbType.Guid, ParameterDirection.Input);

            res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            return res;
        }
        public async Task<int> PostTransaction(CDisease cDisease) 
        {
            string query = "[PostTransactions]";
            int res;

            using IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString());
            var parameter = new DynamicParameters();

            parameter.Add("@DiagnosisGUIDfld", cDisease.DiagnosisGUIDfld, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@DoctorGUIDfld", cDisease.DoctorGUIDfld, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@PatientGUIDfld", cDisease.PatientGUIDfld, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@TreatmentDescriptionfld", cDisease.TreatmentDescriptionfld, DbType.String, ParameterDirection.Input);
            parameter.Add("@DiagnosisDescriptionfld", cDisease.DiagnosisDescriptionfld, DbType.String, ParameterDirection.Input);
            parameter.Add("@Costfld", cDisease.Costfld, DbType.String, ParameterDirection.Input);


            res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            return res;
        }
        #endregion

        #region Put Functions
        public async Task<int> PutProfileDetails(CRegisterViewModel obj)
        {
            int res = 0;

            string query = "[dbo].[PutUserProfileDetails]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@PersonGUIDfld", obj.PersonGUIDfld, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@Contactfld", obj.Contactfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@Addressfld", obj.Addressfld, DbType.String, ParameterDirection.Input, -1);
                parameter.Add("@Emailfld", obj.Emailfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@MedicalAidPlanfld", obj.MedicalAidPlanfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@MedicalAidNumberfld", obj.MedicalAidNumberfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@MedicalAidContactfld", obj.MedicalAidContactfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@Usernamefld", obj.Usernamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@Passwordfld", obj.Passwordfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@ConfirmPasswordfld", obj.Passwordfld, DbType.String, ParameterDirection.Input);
                parameter.Add("@NOKFirstNamefld", obj.NextOfKinFirstNamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@NOKLastNamefld", obj.NextOfKinLastNamefld, DbType.String, ParameterDirection.Input);
                parameter.Add("@NOKContactfld", obj.NextOfKinContactfld, DbType.String, ParameterDirection.Input);
                res = await db.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
        #endregion

        #region Get Dropdown Lists
        public async Task<List<CRegisterViewModel>> GetDropdownUserList()
        {
            var list = new List<CRegisterViewModel>();

            string query = "[dbo].[GetDropdownUserList]";

            using (IDbConnection db = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                list = (List<CRegisterViewModel>)await db.QueryAsync<CRegisterViewModel>(query, commandType: CommandType.StoredProcedure);
            }
            return list;
        }

        #endregion


    }
}
