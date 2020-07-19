using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVC.Utilities
{
    public static class SD
    {
        public const string Proc_DeliveryType_Create = "usp_CreateDeliveryType";
        public const string Proc_DeliveryType_Get = "usp_GetDeliveryType";
        public const string Proc_DeliveryType_GetAll = "usp_GetDeliveryTypes";
        public const string Proc_DeliveryType_Update = "usp_UpdateDeliveryType";
        public const string Proc_DeliveryType_Delete = "usp_DeleteDeliveryType";

        public const string Role_User_Indi = "Individual Customer";
        public const string Role_User_Comp = "Company Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
    }
}
