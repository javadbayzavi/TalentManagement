using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> training_plans_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeletePlan",
                controller = "trainings",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "trainingsform",
                placeholder = "حذف برنامه تمريني",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Plans",
                controller = "trainings",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> training_plans_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditPlan",
                controller = "trainings",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات برنامه تمريني",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Plans",
                placeholder = "بازگشت به صفحه قبل",
                controller = "trainings",
                title = "دوره‌ها",
                hostform = "",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> training_plans_default(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "CreatePlan",
                controller = "trainings",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد برنامه تمريني"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditPlan",
                controller = "trainings",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات دوره",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DetailsPlan",
                controller = "trainings",
                title = "نمایش",
                placeholder = "نمایش اطلاعات برنامه تمريني",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeletePlan",
                controller = "trainings",
                title = "حذف",
                placeholder = "حذف اطلاعات برنامه تمريني",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Plans",
                controller = "trainings",
                title = "به‌روزآوری",
                placeholder = "اطلاعات لیست برنامه‌تمريني بازآوري شود",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "trainings",
                title = "بازگشت",
                placeholder = "بازگشت به دوره‌هاي آموزشي",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }
    }
}
