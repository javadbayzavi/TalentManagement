using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> coaches_training_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteTraining",
                controller = "coaches",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "coachform",
                placeholder = "حذف اطلاعات مربي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Trainings",
                controller = "coaches",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> coaches_training_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditTraining",
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
                action = "Trainings",
                placeholder = "بازگشت به صفحه قبل",
                controller = "coaches",
                title = "دوره‌ها",
                hostform = "",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> coaches_training_default(params object[] rootParams)
        {
            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "CreateTraining",
                controller = "coaches",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد دوره جديد"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditTraining",
                controller = "coaches",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات دوره",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DetailsTraining",
                controller = "coaches",
                title = "نمایش",
                placeholder = "نمایش اطلاعات كلاس مربي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteTraining",
                controller = "coaches",
                title = "انصراف",
                placeholder = "حذف اطلاعات كلاس مربي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Trainings",
                controller = "coaches",
                title = "به‌روزآوری",
                placeholder = "اطلاعات لیست كلاس‌ها بازآوری شود",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "coaches",
                title = "بازگشت",
                placeholder = "بازگشت به ليست مربيان",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }
    }
}
