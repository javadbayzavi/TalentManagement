using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> templates_details_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "templates",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش قالب",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "templates",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> templates_delete_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "templates",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "templatesform",
                placeholder = "حذف قالب",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "templates",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> templates_list_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "templates",
                title = "ايجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد قالب",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "templates",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات قالب",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "templates",
                title = "نمایش",
                placeholder = "نمایش اقالب",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "templates",
                title = "حذف",
                placeholder = "حذف اطلاعات قالب",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "templates",
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
