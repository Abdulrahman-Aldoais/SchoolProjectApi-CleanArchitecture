namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRouteId = "/{id}";
        public const string root = "Api";
        public const string version = "v1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Perfixe = Rule + "Student";
            public const string List = Perfixe + "/List";
            public const string GetById = Perfixe + SingleRouteId;
            public const string Create = Perfixe + "/Create";
            public const string Edit = Perfixe + "/Edit";
            public const string Delete = Perfixe + SingleRouteId;
            public const string Paginated = Perfixe + "/Paginated";


        }
    }
}
