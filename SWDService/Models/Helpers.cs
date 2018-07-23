using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models
{
    public static class ConstantManager
    {
        public const int STT_SUCCESS = 0;
        public const int STT_FAIL = 1;
        public const int STT_MISSING_PARAM = 2;
        public const int STT_UNAUTHORIZED = 3;
        public const int STATUS_SUCCESS = 200;

        public const string MES_LOGIN_SUCCESS = "Login successfully";
        public const string MES_LOGIN_FAIL = "Login fail";
        public const string MES_UPDATE_SUCCESS = "Update successfully";
        public const string MES_UPDATE_FAIL = "Update fail";
        public const string MES_MISSING_PARAM = "Missing parameter";
        public const string MES_UNVALID_TOKEN = "Token is unvalid or expired";
        //check role khi xem store
        public const string MES_STORE_UNAUTHENTICATED = "You do not have permission to see report of this store";
        // check role khi nhan token
        public const string MES_ROLE_UNAUTHENTICATED = "You do not have permission";
        public const string MES_LOAD_REPORT_SUCCESS = "Load report success";
        public const string MES_FAIL = "Return fail";
        public const string MES_SUCCESS = "Return success";
        public const string ROLE_ADMIN = "Administrator";
        public const string ROLE_MANAGER = "StoreManager";

        public const string MES_PROMOTION_FAIL = "Don't have promotion";
        public const string MES_PROMOTION_SUCCESS = "Success";
        public const string MES_STORE_FAIL = "Don't have store";
        public const string MES_STORE_SUCCESS = "Success";
        public const string MES_PAYMENT_CASH = "Thanh toán bằng tiền mặt";
        public const string MES_PAYMENT_MOMO = "Thanh toán qua MomMo";

        public const string PRIVATE_KEY = "SWDSecretKey";
        public const int MAX_RECORD = 25;
        public const string DELIVERY = "DELIVERY";
        public const string PRODUCT_IMAGE_SERVER_BASEURL = "http://103.79.142.115:3333";
        public const string PRODUCT_IMAGE_SERVER_PATH = "C:\\PublicIIS\\Imageserver";
        //public const string PRODUCT_IMAGE_SERVER_PATH = "D:\\";
        public const string IMAGE_FORMAT_EXTENSION = ".Png";
    }
}
