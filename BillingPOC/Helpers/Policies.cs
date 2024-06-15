namespace BillingPOC.Helpers
{
    public static class Policies
    {
        public const string AdministratorOnly = "AdministratorOnly";
        public const string InsuranceCoordinatorOnly = "InsuranceCoordinatorOnly";
        public const string AccountantOnly = "AccountantOnly";
        public const string AuditorOnly = "AuditorOnly";
        public const string MultiRolePolicy = "MultiRolePolicy";
    }
}
