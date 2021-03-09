using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> users_groups_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deleteGroup",
                controller = "users",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "groupsform",
                placeholder = "حذف اطلاعات گروه",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "groups",
                controller = "users",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست گروه‌ها"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> users_groups_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "groups",
                controller = "users",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست گروه‌ها"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> users_groups_list(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "addGroup",
                controller = "users",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت گروه جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "detailsGroup",
                controller = "users",
                title = "نمایش",
                placeholder = "نمایش اطلاعات گروه",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deleteGroup",
                controller = "users",
                title = "حذف",
                placeholder = "حذف اطلاعات كاربر",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "users",
                placeholder = "ليست گروه‌ها به‌روز آوري شود",
                controller = "users",
                title = "به‌روزآوري",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "users",
                title = "بازگشت",
                placeholder = "بازگشت به ليست كاربر‌ها",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }

    }
}
