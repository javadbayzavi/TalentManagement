using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> users_details_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "users",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش كاربر",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "users",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> users_delete_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "users",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "usersform",
                placeholder = "حذف كاربر",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "users",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> users_list_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "users",
                title = "ايجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد كاربر",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "users",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات كاربر",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "users",
                title = "نمایش",
                placeholder = "نمایش اطلاعات كاربر",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "users",
                title = "حذف",
                placeholder = "حذف اطلاعات كاربر",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "groups",
                controller = "users",
                title = "گروه‌ها",
                placeholder = "نمایش اطلاعات گروه‌ها",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "users",
                title = "به‌روزآوري",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازآوري مجدد ليست"
            });
            return ribbons;
        }
    }
}
