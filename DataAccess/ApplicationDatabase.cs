using CDF.API.Models;
using CDF.API.Models.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.DataAccess
{
    public class ApplicationDatabase
    {
        private readonly IMongoCollection<ApplicationData> applicationData;

        public ApplicationDatabase(IApplicationDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            applicationData = database.GetCollection<ApplicationData>(settings.CDFAppCollectionName);
        }

        public async Task<List<ApplicationData>> Get()
        {
            try
            {
                var builder = Builders<ApplicationData>.Filter;
                var filter = builder.Empty;
                var result = await applicationData.FindAsync(filter);

                return await result.ToListAsync();
            }
            catch (Exception)
            {
            }

            return new List<ApplicationData>();
        }

        public async Task<ApplicationData> Get(string applicationId)
        {
            try
            {
                var builder = Builders<ApplicationData>.Filter;

                var filter = builder.Eq(data => data.UserToken, applicationId);

                var result = await applicationData.FindAsync(filter);

                return result.FirstOrDefault();
            }
            catch (Exception)
            {
            }
            return new ApplicationData();
        }

        public async Task<bool> Add(ApplicationData application)
        {
            try
            {
                await applicationData.InsertOneAsync(application);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Update(string applicationId, ApplicationData application)
        {
            var builder = Builders<ApplicationData>.Filter;

            var filter = builder.Eq(data => data.Id, applicationId);

            try
            {
                var update = Builders<ApplicationData>.Update
                    .Set(app => app.AbsenceDuration, application.AbsenceDuration)
                    .Set(app => app.AbsenceReason, application.AbsenceReason)
                    .Set(app => app.AdministratorApproved, application.AdministratorApproved)
                    .Set(app => app.AdmissionNumber, application.AdmissionNumber)
                    .Set(app => app.AmountApplied, application.AmountApplied)
                    .Set(app => app.AmountApproved, application.AmountApproved)
                    .Set(app => app.ApplicationReason, application.ApplicationReason)
                    .Set(app => app.AverageAcademicPerformance, application.AverageAcademicPerformance)
                    .Set(app => app.CDFCommiteeApproval, application.CDFCommiteeApproval)
                    .Set(app => app.CDFCommiteeRejectReasons, application.CDFCommiteeRejectReasons)
                    .Set(app => app.ChiefEmail, application.ChiefEmail)
                    .Set(app => app.ChiefLocation, application.ChiefLocation)
                    .Set(app => app.ChiefName, application.ChiefName)
                    .Set(app => app.ChiefPhone, application.ChiefPhone)
                    .Set(app => app.ChiefSublocation, application.ChiefSublocation)
                    .Set(app => app.ChronicIllnessDetails, application.ChronicIllnessDetails)
                    .Set(app => app.CollegeMainFundingSource, application.CollegeMainFundingSource)
                    .Set(app => app.CollegeOtherFundingSource, application.CollegeOtherFundingSource)
                    .Set(app => app.Course, application.Course)
                    .Set(app => app.CourseDuration, application.CourseDuration)
                    .Set(app => app.CurrentSemesterBalance, application.CurrentSemesterBalance)
                    .Set(app => app.DateOfBirth, application.DateOfBirth)
                    .Set(app => app.Department, application.Department)
                    .Set(app => app.DisableParentDetails, application.DisableParentDetails)
                    .Set(app => app.EstimateFamilyExpenses, application.EstimateFamilyExpenses)
                    .Set(app => app.EstimateFamilyIncome, application.EstimateFamilyIncome)
                    .Set(app => app.FamilyStatus, application.FamilyStatus)
                    .Set(app => app.FatherAddress, application.FatherAddress)
                    .Set(app => app.FatherEmployment, application.FatherEmployment)
                    .Set(app => app.FatherMainIncomeSource, application.FatherMainIncomeSource)
                    .Set(app => app.FatherName, application.FatherName)
                    .Set(app => app.FatherOccupation, application.FatherOccupation)
                    .Set(app => app.FatherTelephone, application.FatherTelephone)
                    .Set(app => app.FileAttachments, application.FileAttachments)
                    .Set(app => app.Gender, application.Gender)
                    .Set(app => app.Grade, application.Grade)
                    .Set(app => app.GuardianAddress, application.GuardianAddress)
                    .Set(app => app.GuardianEmployment, application.GuardianEmployment)
                    .Set(app => app.GuardianMainIncomeSource, application.GuardianMainIncomeSource)
                    .Set(app => app.GuardianName, application.GuardianName)
                    .Set(app => app.GuardianOccupation, application.GuardianOccupation)
                    .Set(app => app.GuardianTelephone, application.GuardianTelephone)
                    .Set(app => app.HasAbsenceRecord, application.HasAbsenceRecord)
                    .Set(app => app.HasChronicIllness, application.HasChronicIllness)
                    .Set(app => app.HasDisabledParent, application.HasDisabledParent)
                    .Set(app => app.HasParentChronicIllness, application.HasParentChronicIllness)
                    .Set(app => app.HasPhysicalImpairment, application.HasPhysicalImpairment)
                    .Set(app => app.HasPreviousBursary, application.HasPreviousBursary)
                    .Set(app => app.HelbLoanReceived, application.HelbLoanReceived)
                    .Set(app => app.IdNo, application.IdNo)
                    .Set(app => app.InstitutionAddress, application.InstitutionAddress)
                    .Set(app => app.InstitutionBranch, application.InstitutionBranch)
                    .Set(app => app.InstitutionName, application.InstitutionName)
                    .Set(app => app.InstitutionPhoneNumber, application.InstitutionPhoneNumber)
                    .Set(app => app.LastSemesterBalance, application.LastSemesterBalance)
                    .Set(app => app.LevelOfStudy, application.LevelOfStudy)
                    .Set(app => app.LivingParent, application.LivingParent)
                    .Set(app => app.Location, application.Location)
                    .Set(app => app.ModeOfStudy, application.ModeOfStudy)
                    .Set(app => app.MotherAddress, application.MotherAddress)
                    .Set(app => app.MotherEmployment, application.MotherEmployment)
                    .Set(app => app.MotherMainIncomeSource, application.MotherMainIncomeSource)
                    .Set(app => app.MotherName, application.MotherName)
                    .Set(app => app.MotherOccupation, application.MotherOccupation)
                    .Set(app => app.MotherTelephone, application.MotherTelephone)
                    .Set(app => app.Name, application.Name)
                    .Set(app => app.NextSemesterBalance, application.NextSemesterBalance)
                    .Set(app => app.NumberOfSiblings, application.NumberOfSiblings)
                    .Set(app => app.OtherFamilyStatus, application.OtherFamilyStatus)
                    .Set(app => app.OtherReligionDetials, application.OtherReligionDetials)
                    .Set(app => app.ParentChronicIllnessDetails, application.ParentChronicIllnessDetails)
                    .Set(app => app.PermanentAddress, application.PermanentAddress)
                    .Set(app => app.PhoneNumber, application.PhoneNumber)
                    .Set(app => app.PhysicalAddress, application.PhysicalAddress)
                    .Set(app => app.PhysicalImpairmentDetails, application.PhysicalImpairmentDetails)
                    .Set(app => app.PollingStation, application.PollingStation)
                    .Set(app => app.PollingStationApproval, application.PollingStationApproval)
                    .Set(app => app.PollingStationRejectReasons, application.PollingStationRejectReasons)
                    .Set(app => app.PreviousBursaryAmount, application.PreviousBursaryAmount)
                    .Set(app => app.PreviousBursaryDate, application.PreviousBursaryDate)
                    .Set(app => app.PreviousFinancialSupport, application.PreviousFinancialSupport)
                    .Set(app => app.PreviousFinancialSupportDetails, application.PreviousFinancialSupportDetails)
                    .Set(app => app.Referee1Address, application.Referee1Address)
                    .Set(app => app.Referee1Name, application.Referee1Name)
                    .Set(app => app.Referee1PhoneNumber, application.Referee1PhoneNumber)
                    .Set(app => app.Referee2Address, application.Referee2Address)
                    .Set(app => app.Referee2Name, application.Referee2Name)
                    .Set(app => app.Referee2PhoneNumber, application.Referee2PhoneNumber)
                    .Set(app => app.ReligiousLeaderApproved, application.ReligiousLeaderApproved)
                    .Set(app => app.ReligiousLeaderEmail, application.ReligiousLeaderEmail)
                    .Set(app => app.ReligiousLeaderName, application.ReligiousLeaderName)
                    .Set(app => app.ReligiousLeaderPhone, application.ReligiousLeaderPhone)
                    .Set(app => app.ReligiousLeaderReligionName, application.ReligiousLeaderReligionName)
                    .Set(app => app.ReligiousLeaderReligionType, application.ReligiousLeaderReligionType)
                    .Set(app => app.SecondaryMainFundingSource, application.SecondaryMainFundingSource)
                    .Set(app => app.SecondaryOtherFundingSource, application.SecondaryOtherFundingSource)
                    .Set(app => app.SiblingsList, application.SiblingsList)
                    .Set(app => app.Step, application.Step)
                    .Set(app => app.SubLocation, application.SubLocation)
                    .Set(app => app.TotalAnnualFees, application.TotalAnnualFees)
                    .Set(app => app.UniversityMainFundingSource, application.UniversityMainFundingSource)
                    .Set(app => app.UniversityOtherFundingSource, application.UniversityOtherFundingSource)
                    .Set(app => app.Ward, application.Ward)
                    .Set(app => app.yearOfCompletion, application.yearOfCompletion);

                await applicationData.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
