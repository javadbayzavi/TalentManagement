using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> coaches_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "coaches",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "coachesform",
                placeholder = "حذف اطلاعات مربي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "coaches",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> coaches_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "coaches",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات مربي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Certificates",
                placeholder = "مدارك مربيگري اخذ شده",
                controller = "coaches",
                title = "مدارك",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Trainings",
                placeholder = "دوره‌هاي اموزشي",
                controller = "coaches",
                title = "دوره‌ها",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Sessions",
                placeholder = "جلسات تمرين",
                controller = "coaches",
                title = "تمرينات",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Plan",
                placeholder = "برنامه ريزي تمرين",
                controller = "coaches",
                title = "برنامه هفتگي",
                hostform = "",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "coaches",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> coaches_list_default(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "coaches",
                title = "ایجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت مربي جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "coaches",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات مربي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "coaches",
                title = "نمایش",
                placeholder = "نمایش اطلاعات مربي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "coaches",
                title = "حذف",
                placeholder = "حذف اطلاعات مربي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Certificates",
                placeholder = "مدارك مربيگري اخذ شده",
                controller = "coaches",
                title = "مدارك",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Trainings",
                placeholder = "دوره‌هاي اموزشي",
                controller = "coaches",
                title = "دوره‌ها",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Sessions",
                placeholder = "جلسات تمرين",
                controller = "coaches",
                title = "تمرينات",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Plan",
                placeholder = "برنامه ريزي تمرين",
                controller = "coaches",
                title = "برنامه هفتگي",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = true
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "coaches",
                title = "به‌روزآوری",
                placeholder = "اطلاعات لیست مربيان بازآوری شود",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Issuers",
                controller = "coaches",
                title = "صادركنند‌گان",
                placeholder = " ليست صادركنندگان مدارك مربيگري",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }
    }
}
