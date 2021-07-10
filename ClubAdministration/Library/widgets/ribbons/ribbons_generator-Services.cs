using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> services_details_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "services",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش سرويس",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "services",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> services_delete_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "services",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "servicesform",
                placeholder = "حذف سرويس",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "services",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> services_list_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "services",
                title = "ايجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد سرويس",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "services",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات سرويس",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "services",
                title = "نمایش",
                placeholder = "نمایش اطلاعات سرويس",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "services",
                title = "حذف",
                placeholder = "حذف اطلاعات سرويس",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "services",
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
