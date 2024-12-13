namespace WemaAnalytics.Domain.Contract;

public interface IActiveDirectoryService
{
    string GetDepartment(string staffEmail);
    string GetCompanyName(string staffEmail);
    bool AuthenticateStaff(string StaffEmail, string StaffPassword);
    StaffLookUpDto LookUpWemaStaff(string StaffEmail);
    string GetCurrentDomainPath();
}