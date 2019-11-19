using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Common.constants
{
    public class RedisKeyConstants
    {

        // token缓存KEY前缀
        public static string TOKEN_KEY = "WINV_TOKEN";
        public static string USER_TOKEN_KEY_PRE = "WINV_USER_TOKEN_";
        public static string CUSTOMER_TOKEN_ID_KEY = "CUSTOMER_TOKEN_ID_KEY_";
        public static string CUSTOMER_ID_TOKEN_KEY = "CUSTOMER_ID_TOKEN_KEY_";

        // 缓存用户信息
        public static string USER_DETAIL_KEY_PRE = "USER_DETAIL_";
        public static string CARLIFE_USER_DETAIL_KEY_PRE = "CARLIFE_USER_DETAIL_";
        public static string CUSTOMER_DETAIL_KEY_PRE = "CUSTOMER_DETAIL_KEY_PRE_";

        // 短信验证码
        public static string VERIFY_CODE = "VERIFY_CODE_";

    }
}
