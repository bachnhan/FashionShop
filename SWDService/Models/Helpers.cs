using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models
{
    public static class ConstantManager
    {
        public static int STT_SUCCESS = 0;
        public static int STT_FAIL = 1;
        public static int STT_MISSING_PARAM = 2;
        public static int STT_UNAUTHORIZED = 3;
        public static int STATUS_SUCCESS = 200;

        public static string MES_LOGIN_SUCCESS = "Login successfully";
        public static string MES_LOGIN_FAIL = "Login fail";
        public static string MES_UPDATE_SUCCESS = "Update successfully";
        public static string MES_UPDATE_FAIL = "Update fail";
        public static string MES_MISSING_PARAM = "Missing parameter";
        public static string MES_UNVALID_TOKEN = "Token is unvalid or expired";
        //check role khi xem store
        public static string MES_STORE_UNAUTHENTICATED = "You do not have permission to see report of this store";
        // check role khi nhan token
        public static string MES_ROLE_UNAUTHENTICATED = "You do not have permission";
        public static string MES_LOAD_REPORT_SUCCESS = "Load report success";
        public static string MES_FAIL = "Return fail";
        public static string MES_SUCCESS = "Return success";
        public static string ROLE_ADMIN = "Administrator";
        public static string ROLE_MANAGER = "StoreManager";
        
        public static string MES_PROMOTION_FAIL = "Don't have promotion";
        public static string MES_PROMOTION_SUCCESS = "Success";
        public static string MES_STORE_FAIL = "Don't have store";
        public static string MES_STORE_SUCCESS = "Success";
        public static string MES_PAYMENT_CASH = "Thanh toán bằng tiền mặt";
        public static string MES_PAYMENT_MOMO = "Thanh toán qua MomMo";

        public const string PRIVATE_KEY = "WiskySRKey";
        public static int MAX_RECORD = 25;
        public static string DELIVERY = "DELIVERY";
    }
}
