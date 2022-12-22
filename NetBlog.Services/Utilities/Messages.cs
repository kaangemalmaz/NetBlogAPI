namespace NetBlog.Business.Utilities
{
    public class Messages
    {
        public enum EntityTypes
        {
            Categories,
            Comment,
            Contact,
            Post
        }

        public static class GeneralMessages
        {
            public static string IdMustBeGreaterZero() { return "Id must be greater than Zero!"; }
            public static string NotFoundData(EntityTypes entityType) { return $"Not Found any data for {entityType}"; }
            public static string NameMustBeUnique(EntityTypes entityTypes) { return $"{entityTypes} name must be unique!"; }
        }
    }
}
