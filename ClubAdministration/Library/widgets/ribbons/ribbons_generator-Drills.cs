using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> drills_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "drills",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "drillform",
                placeholder = "حذف اطلاعات تمرين",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "drills",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> drills_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "drills",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات برنامه تمريني",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "drills",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> drills_list_default(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "drills",
                title = "ایجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت برنامه تمريني جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "drills",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات برنامه تمريني",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "drills",
                title = "نمایش",
                placeholder = "نمایش اطلاعات برنامه تمريني",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "drills",
                title = "حذف",
                placeholder = "حذف اطلاعات برنامه تمريني",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "types",
                placeholder = "انواع برنامه تمريني",
                controller = "drills",
                title = "انواع",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "emphasises",
                placeholder = "تمركز تمرينات",
                controller = "drills",
                title = "تمركز",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "locations",
                placeholder = "محل‌هاي تمرين",
                controller = "drills",
                title = "محل‌ها",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "materials",
                placeholder = "لوازم مورد نياز تمرين",
                controller = "drills",
                title = "برنامه هفتگي",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "drills",
                title = "به‌روزآوری",
                placeholder = "اطلاعات لیست مربيان بازآوری شود",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "skills",
                controller = "drills",
                title = "مهارت‌ها",
                placeholder = " مهارت‌هاي مورد بررسي در تمرين",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "kpis",
                controller = "drills",
                title = "فاكتورها",
                placeholder = " فاكتورهاي مورد بررسي در تمرين",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });

            return ribbons;
        }
    }
}
