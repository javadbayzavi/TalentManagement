using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> roles_permissions_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deletePermission",
                controller = "roles",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "rolesform",
                placeholder = "حذف اطلاعات دسترسي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "permissions",
                controller = "roles",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست دسترسي‌ها"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> roles_permissions_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "permissions",
                controller = "roles",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست دسترسي‌ها"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> roles_permissions_list(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "addPermission",
                controller = "roles",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت دسترسي جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "detailsPermission",
                controller = "roles",
                title = "نمایش",
                placeholder = "نمایش اطلاعات دسترسي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "deletePermission",
                controller = "roles",
                title = "حذف",
                placeholder = "حذف اطلاعات دسترسي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "permissions",
                placeholder = "ليست دسترسي‌ها به‌روز آوري شود",
                controller = "roles",
                title = "به‌روزآوري",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "roles",
                title = "بازگشت",
                placeholder = "بازگشت به ليست نقش‌ها",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }

    }
}
