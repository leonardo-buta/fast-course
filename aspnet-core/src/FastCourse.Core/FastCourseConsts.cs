using FastCourse.Debugging;

namespace FastCourse
{
    public class FastCourseConsts
    {
        public const string LocalizationSourceName = "FastCourse";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c81e6537d9ef4d06b6ea492bcea1d339";
    }
}
