namespace S3.Common
{
    public static class ExceptionCodes
    {
        public static string Unauthorized => "unauthorized_action";
        public static string InvalidCredentials => "invalid_credentials";
        public static string InvalidCurrentPassword => "invalid_current_password";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidPassword => "invalid_password";
        public static string InvalidRole => "invalid_role";
        public static string ItemExists => "item_aready_exists";
        public static string RefreshTokenNotFound => "refresh_token_not_found";
        public static string RefreshTokenAlreadyRevoked => "refresh_token_already_revoked";
        public static string NameInUse => "name_in_use";
        public static string SchoolAdminExists => "school_admin_already_exists";
        public static string NotFound => "not_found";
    }
}