using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models
{
    public class ApplicationData
    {

        public ApplicationData()
        {
            SiblingsList = new List<Sibling>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userEmail")]
        [JsonProperty(PropertyName = "userEmail")]
        public string UserEmail { get; set; }

        [BsonElement("userPassword")]
        [JsonProperty(PropertyName = "userPassword")]
        public string UserPassword { get; set; }

        [BsonElement("isAuthenticated")]
        [JsonProperty(PropertyName = "isAuthenticated")]
        public bool IsAuthenticated { get; set; }

        [BsonElement("userToken")]
        [JsonProperty(PropertyName = "userToken")]
        public string UserToken { get; set; }

        [BsonElement("step")]
        [JsonProperty(PropertyName = "step")]
        public int Step { get; set; }

        [BsonElement("name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [BsonElement("gender")]
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [BsonElement("dateOfBirth")]
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("idNo")]
        [JsonProperty(PropertyName = "idNo")]
        public string IdNo { get; set; }

        [BsonElement("levelOfStudy")]
        [JsonProperty(PropertyName = "levelOfStudy")]
        public string LevelOfStudy { get; set; }

        [BsonElement("institutionName")]
        [JsonProperty(PropertyName = "institutionName")]
        public string InstitutionName { get; set; }

        [BsonElement("admissionNumber")]
        [JsonProperty(PropertyName = "admissionNumber")]
        public string AdmissionNumber { get; set; }

        [BsonElement("institutionBranch")]
        [JsonProperty(PropertyName = "institutionBranch")]
        public string InstitutionBranch { get; set; }

        [BsonElement("department")]
        [JsonProperty(PropertyName = "department")]
        public string Department { get; set; }

        [BsonElement("course")]
        [JsonProperty(PropertyName = "course")]
        public string Course { get; set; }

        [BsonElement("modeOfStudy")]
        [JsonProperty(PropertyName = "modeOfStudy")]
        public string ModeOfStudy { get; set; }

        [BsonElement("grade")]
        [JsonProperty(PropertyName = "grade")]
        public string Grade { get; set; }

        [BsonElement("courseDuration")]
        [JsonProperty(PropertyName = "courseDuration")]
        public string CourseDuration { get; set; }

        [BsonElement("yearOfCompletion")]
        [JsonProperty(PropertyName = "yearOfCompletion")]
        public DateTime yearOfCompletion { get; set; }

        [BsonElement("phoneNumber")]
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("pollingStation")]
        [JsonProperty(PropertyName = "pollingStation")]
        public string PollingStation { get; set; }

        [BsonElement("ward")]
        [JsonProperty(PropertyName = "ward")]
        public string Ward { get; set; }

        [BsonElement("location")]
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [BsonElement("subLocation")]
        [JsonProperty(PropertyName = "subLocation")]
        public string SubLocation { get; set; }

        [BsonElement("physicalAddress")]
        [JsonProperty(PropertyName = "physicalAddress")]
        public string PhysicalAddress { get; set; }

        [BsonElement("permanentAddress")]
        [JsonProperty(PropertyName = "permanentAddress")]
        public string PermanentAddress { get; set; }

        [BsonElement("institutionAddress")]
        [JsonProperty(PropertyName = "institutionAddress")]
        public string InstitutionAddress { get; set; }

        [BsonElement("institutionPhoneNumber")]
        [JsonProperty(PropertyName = "institutionPhoneNumber")]
        public string InstitutionPhoneNumber { get; set; }

        [BsonElement("amountApplied")]
        [JsonProperty(PropertyName = "amountApplied")]
        public string AmountApplied { get; set; }

        [BsonElement("familyStatus")]
        [JsonProperty(PropertyName = "familyStatus")]
        public string FamilyStatus { get; set; }

        [BsonElement("otherFamilyStatus")]
        [JsonProperty(PropertyName = "otherFamilyStatus")]
        public string OtherFamilyStatus { get; set; }

        [BsonElement("numberOfSiblings")]
        [JsonProperty(PropertyName = "numberOfSiblings")]
        public int NumberOfSiblings { get; set; }

        [BsonElement("estimatedFamilyIncome")]
        [JsonProperty(PropertyName = "estimatedFamilyIncome")]
        public double EstimateFamilyIncome { get; set; }

        [BsonElement("estimatedFamilyExpenses")]
        [JsonProperty(PropertyName = "estimatedFamilyExpenses")]
        public double EstimateFamilyExpenses { get; set; }

        [BsonElement("livingParent")]
        [JsonProperty(PropertyName = "livingParent")]
        public string LivingParent { get; set; }

        [BsonElement("fatherName")]
        [JsonProperty(PropertyName = "fatherName")]
        public string FatherName { get; set; }

        [BsonElement("fatherAddress")]
        [JsonProperty(PropertyName = "fatherAddress")]
        public string FatherAddress { get; set; }

        [BsonElement("fatherTelephone")]
        [JsonProperty(PropertyName = "fatherTelephone")]
        public string FatherTelephone { get; set; }

        [BsonElement("fatherOccupation")]
        [JsonProperty(PropertyName = "fatherOccupation")]
        public string FatherOccupation { get; set; }

        [BsonElement("fatherEmployment")]
        [JsonProperty(PropertyName = "fatherEmployment")]
        public string FatherEmployment { get; set; }

        [BsonElement("fatherMainIncomeSource")]
        [JsonProperty(PropertyName = "fatherMainIncomeSource")]
        public string FatherMainIncomeSource { get; set; }

        [BsonElement("motherName")]
        [JsonProperty(PropertyName = "motherName")]
        public string MotherName { get; set; }

        [BsonElement("motherAddress")]
        [JsonProperty(PropertyName = "motherAddress")]
        public string MotherAddress { get; set; }

        [BsonElement("motherTelephone")]
        [JsonProperty(PropertyName = "motherTelephone")]
        public string MotherTelephone { get; set; }

        [BsonElement("motherOccupation")]
        [JsonProperty(PropertyName = "motherOccupation")]
        public string MotherOccupation { get; set; }

        [BsonElement("motherEmployment")]
        [JsonProperty(PropertyName = "motherEmployment")]
        public string MotherEmployment { get; set; }

        [BsonElement("motherMainIncomeSource")]
        [JsonProperty(PropertyName = "motherMainIncomeSource")]
        public string MotherMainIncomeSource { get; set; }

        [BsonElement("guardianName")]
        [JsonProperty(PropertyName = "guardianName")]
        public string GuardianName { get; set; }

        [BsonElement("guardianAddress")]
        [JsonProperty(PropertyName = "guardianAddress")]
        public string GuardianAddress { get; set; }

        [BsonElement("guardianTelephone")]
        [JsonProperty(PropertyName = "guardianTelephone")]
        public string GuardianTelephone { get; set; }

        [BsonElement("guardianOccupation")]
        [JsonProperty(PropertyName = "guardianOccupation")]
        public string GuardianOccupation { get; set; }

        [BsonElement("guardianEmployment")]
        [JsonProperty(PropertyName = "guardianEmployment")]
        public string GuardianEmployment { get; set; }

        [BsonElement("guardianMainIncomeSource")]
        [JsonProperty(PropertyName = "guardianMainIncomeSource")]
        public string GuardianMainIncomeSource { get; set; }

        [BsonElement("siblingsList")]
        [JsonProperty(PropertyName = "siblingsList")]
        public List<Sibling> SiblingsList { get; set; }

        [BsonElement("applicationReason")]
        [JsonProperty(PropertyName = "applicationReason")]
        public string ApplicationReason { get; set; }

        [BsonElement("hasPreviousBursary")]
        [JsonProperty(PropertyName = "hasPreviousBursary")]
        public string HasPreviousBursary { get; set; }

        [BsonElement("previousBursaryAmount")]
        [JsonProperty(PropertyName = "previousBursaryAmount")]
        public double PreviousBursaryAmount { get; set; }

        [BsonElement("previousBursaryDate")]
        [JsonProperty(PropertyName = "previousBursaryDate")]
        public DateTime PreviousBursaryDate { get; set; }

        [BsonElement("previousFinancialSupport")]
        [JsonProperty(PropertyName = "previousFinancialSupport")]
        public string PreviousFinancialSupport { get; set; }

        [BsonElement("previousFinancialSupportDetails")]
        [JsonProperty(PropertyName = "previousFinancialSupportDetails")]
        public string PreviousFinancialSupportDetails { get; set; }

        [BsonElement("hasPhysicalImpairment")]
        [JsonProperty(PropertyName = "hasPhysicalImpairment")]
        public string HasPhysicalImpairment { get; set; }

        [BsonElement("physicalImpairmentDetails")]
        [JsonProperty(PropertyName = "physicalImpairmentDetails")]
        public string PhysicalImpairmentDetails { get; set; }

        [BsonElement("hasChronicIllness")]
        [JsonProperty(PropertyName = "hasChronicIllness")]
        public string HasChronicIllness { get; set; }

        [BsonElement("chronicIllnessDetails")]
        [JsonProperty(PropertyName = "chronicIllnessDetails")]
        public string ChronicIllnessDetails { get; set; }

        [BsonElement("hasDisabledParent")]
        [JsonProperty(PropertyName = "hasDisabledParent")]
        public string HasDisabledParent { get; set; }

        [BsonElement("disableParentDetails")]
        [JsonProperty(PropertyName = "disableParentDetails")]
        public string DisableParentDetails { get; set; }

        [BsonElement("hasParentChronicIllness")]
        [JsonProperty(PropertyName = "hasParentChronicIllness")]
        public string HasParentChronicIllness { get; set; }

        [BsonElement("parentChronicIllnessDetails")]
        [JsonProperty(PropertyName = "parentChronicIllnessDetails")]
        public string ParentChronicIllnessDetails { get; set; }

        [BsonElement("secondaryMainFundingSource")]
        [JsonProperty(PropertyName = "secondaryMainFundingSource")]
        public string SecondaryMainFundingSource { get; set; }

        [BsonElement("collegeMainFundingSource")]
        [JsonProperty(PropertyName = "collegeMainFundingSource")]
        public string CollegeMainFundingSource { get; set; }

        [BsonElement("universityMainFundingSource")]
        [JsonProperty(PropertyName = "universityMainFundingSource")]
        public string UniversityMainFundingSource { get; set; }

        [BsonElement("secondaryOtherFundingSource")]
        [JsonProperty(PropertyName = "secondaryOtherFundingSource")]
        public string SecondaryOtherFundingSource { get; set; }

        [BsonElement("collegeOtherFundingSource")]
        [JsonProperty(PropertyName = "collegeOtherFundingSource")]
        public string CollegeOtherFundingSource { get; set; }

        [BsonElement("universityOtherFundingSource")]
        [JsonProperty(PropertyName = "universityOtherFundingSource")]
        public string UniversityOtherFundingSource { get; set; }

        [BsonElement("averageAcademicPerformance")]
        [JsonProperty(PropertyName = "averageAcademicPerformance")]
        public string AverageAcademicPerformance { get; set; }

        [BsonElement("hasAbsenceRecord")]
        [JsonProperty(PropertyName = "hasAbsenceRecord")]
        public string HasAbsenceRecord { get; set; }

        [BsonElement("absenceReason")]
        [JsonProperty(PropertyName = "absenceReason")]
        public string AbsenceReason { get; set; }

        [BsonElement("absenceDuration")]
        [JsonProperty(PropertyName = "absenceDuration")]
        public int AbsenceDuration { get; set; }

        [BsonElement("totalAnnualFees")]
        [JsonProperty(PropertyName = "totalAnnualFees")]
        public double TotalAnnualFees { get; set; }

        [BsonElement("lastSemesterBalance")]
        [JsonProperty(PropertyName = "lastSemesterBalance")]
        public double LastSemesterBalance { get; set; }

        [BsonElement("currentSemesterBalance")]
        [JsonProperty(PropertyName = "currentSemesterBalance")]
        public double CurrentSemesterBalance { get; set; }

        [BsonElement("nextSemesterBalance")]
        [JsonProperty(PropertyName = "nextSemesterBalance")]
        public double NextSemesterBalance { get; set; }

        [BsonElement("helbLoanReceived")]
        [JsonProperty(PropertyName = "helbLoanReceived")]
        public double HelbLoanReceived { get; set; }

        [BsonElement("referee1Name")]
        [JsonProperty(PropertyName = "referee1Name")]
        public string Referee1Name { get; set; }

        [BsonElement("referee1Address")]
        [JsonProperty(PropertyName = "referee1Address")]
        public string Referee1Address { get; set; }

        [BsonElement("referee1PhoneNumber")]
        [JsonProperty(PropertyName = "referee1PhoneNumber")]
        public string Referee1PhoneNumber { get; set; }

        [BsonElement("referee2Name")]
        [JsonProperty(PropertyName = "referee2Name")]
        public string Referee2Name { get; set; }

        [BsonElement("referee2Address")]
        [JsonProperty(PropertyName = "referee2Address")]
        public string Referee2Address { get; set; }

        [BsonElement("referee2PhoneNumber")]
        [JsonProperty(PropertyName = "referee2PhoneNumber")]
        public string Referee2PhoneNumber { get; set; }

        [BsonElement("religiousLeaderName")]
        [JsonProperty(PropertyName = "religiousLeaderName")]
        public string ReligiousLeaderName { get; set; }

        [BsonElement("religiousLeaderEmail")]
        [JsonProperty(PropertyName = "religiousLeaderEmail")]
        public string ReligiousLeaderEmail { get; set; }

        [BsonElement("religiousLeaderPhone")]
        [JsonProperty(PropertyName = "religiousLeaderPhone")]
        public string ReligiousLeaderPhone { get; set; }

        [BsonElement("religiousLeaderReligionName")]
        [JsonProperty(PropertyName = "religiousLeaderReligionName")]
        public string ReligiousLeaderReligionName { get; set; }

        [BsonElement("religiousLeaderReligionType")]
        [JsonProperty(PropertyName = "religiousLeaderReligionType")]
        public string ReligiousLeaderReligionType { get; set; }

        [BsonElement("otherReligionDetials")]
        [JsonProperty(PropertyName = "otherReligionDetials")]
        public string OtherReligionDetials { get; set; }

        [BsonElement("chiefName")]
        [JsonProperty(PropertyName = "chiefName")]
        public string ChiefName { get; set; }

        [BsonElement("chiefEmail")]
        [JsonProperty(PropertyName = "chiefEmail")]
        public string ChiefEmail { get; set; }

        [BsonElement("chiefPhone")]
        [JsonProperty(PropertyName = "chiefPhone")]
        public string ChiefPhone { get; set; }

        [BsonElement("chiefLocation")]
        [JsonProperty(PropertyName = "chiefLocation")]
        public string ChiefLocation { get; set; }

        [BsonElement("chiefSublocation")]
        [JsonProperty(PropertyName = "chiefSublocation")]
        public string ChiefSublocation { get; set; }

        [BsonElement("fileAttachments")]
        [JsonProperty(PropertyName = "fileAttachments")]
        public object[] FileAttachments { get; set; }

        [BsonElement("religiousLeaderApproved")]
        [JsonProperty(PropertyName = "religiousLeaderApproved")]
        public bool ReligiousLeaderApproved { get; set; }

        [BsonElement("administratorApproved")]
        [JsonProperty(PropertyName = "administratorApproved")]
        public bool AdministratorApproved { get; set; }

        [BsonElement("pollingStationApproval")]
        [JsonProperty(PropertyName = "pollingStationApproval")]
        public bool PollingStationApproval { get; set; }

        [BsonElement("pollingStationRejectReasons")]
        [JsonProperty(PropertyName = "pollingStationRejectReasons")]
        public string PollingStationRejectReasons { get; set; }

        [BsonElement("cdfCommiteeApproval")]
        [JsonProperty(PropertyName = "cdfCommiteeApproval")]
        public bool CDFCommiteeApproval { get; set; }

        [BsonElement("cdfCommiteeRejectReasons")]
        [JsonProperty(PropertyName = "cdfCommiteeRejectReasons")]
        public string CDFCommiteeRejectReasons { get; set; }

        [BsonElement("amountApproved")]
        [JsonProperty(PropertyName = "amountApproved")]
        public double AmountApproved { get; set; }
    }
}
