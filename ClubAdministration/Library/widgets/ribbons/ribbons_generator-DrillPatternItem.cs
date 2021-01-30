using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {

        private static List<Models.ViewModels.ribbons> drills_patternitems_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Deleteitem",
                controller = "drills",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "drillsform",
                placeholder = "حذف اطلاعات تمرين",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "patternitems",
                controller = "drills",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست برنامه تمريني"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> drills_patternitems_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edititem",
                controller = "drills",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات برنامه تمرين",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "patternitems",
                controller = "drills",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست برنامه تمريني"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> drills_patternitems_default(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Createitem",
                controller = "drills",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد برنامه تمرين"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edititem",
                controller = "drills",
                title = "ویرایش",
                placeholder = "ویرایش برنامه تمرين",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Detailsitem",
                controller = "drills",
                title = "نمایش",
                placeholder = "نمایش اطلاعات برنامه تمرين",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Deleteitem",
                controller = "drills",
                title = "حذف",
                placeholder = "حذف اطلاعات برنامه تمرين",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "patternitems",
                placeholder = "ليست برنامه تمريني",
                controller = "drills",
                title = "به‌روزآوري",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "patterns",
                controller = "drills",
                title = "بازگشت",
                placeholder = "بازگشت به ليست برنامه‌ها",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }
    }
}
