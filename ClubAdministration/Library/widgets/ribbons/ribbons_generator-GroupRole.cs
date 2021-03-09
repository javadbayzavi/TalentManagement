using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> groups_roles_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deleteRole",
                controller = "groups",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "groupsform",
                placeholder = "حذف اطلاعات نقش",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "roles",
                controller = "groups",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست نقش‌ها"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> groups_roles_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "roles",
                controller = "groups",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست نقش‌ها"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> groups_roles_list(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "addRole",
                controller = "groups",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت نقش جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "detailsRole",
                controller = "groups",
                title = "نمایش",
                placeholder = "نمایش اطلاعات نقش",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deleteRole",
                controller = "groups",
                title = "حذف",
                placeholder = "حذف اطلاعات نقش",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "roles",
                placeholder = "ليست نقش‌ها به‌روز آوري شود",
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
