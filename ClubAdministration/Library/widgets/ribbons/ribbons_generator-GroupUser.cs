using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> groups_users_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deleteUser",
                controller = "groups",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "groupsform",
                placeholder = "حذف اطلاعات كاربر",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "users",
                controller = "groups",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست كاربر‌ها"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> groups_users_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "users",
                controller = "groups",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست كاربر‌ها"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> groups_users_list(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "addUser",
                controller = "groups",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت كاربر جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "detailsUser",
                controller = "groups",
                title = "نمایش",
                placeholder = "نمایش اطلاعات كاربر",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deleteUser",
                controller = "groups",
                title = "حذف",
                placeholder = "حذف اطلاعات كاربر",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "users",
                placeholder = "ليست كاربر‌ها به‌روز آوري شود",
                controller = "groups",
                title = "به‌روزآوري",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "groups",
                title = "بازگشت",
                placeholder = "بازگشت به ليست گروه‌ها",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }

    }
}
