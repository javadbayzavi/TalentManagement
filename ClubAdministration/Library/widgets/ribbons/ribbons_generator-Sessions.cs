using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> session_details_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "sessions",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ویرایش جلسه تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Participants",
                controller = "sessions",
                title = "شرکت کنندگان",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "لیست شرکت کنندگان در تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Coaches",
                controller = "sessions",
                title = "مربيان",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "لیست مربيان در تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> session_delete_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "sessions",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "sessionform",
                placeholder = "حذف جلسه تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> session_list_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "sessions",
                title = "ایجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت یک جلسه تمرین"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "sessions",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "sessions",
                title = "نمایش",
                placeholder = "مشاهده جزئیات جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "sessions",
                title = "حذف",
                placeholder = "حذف اطلاعات جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Participants",
                controller = "sessions",
                title = "شرکت کنندگان",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "لیست شرکت کنندگان در تمرین"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Coaches",
                controller = "sessions",
                title = "مربيان",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "لیست مربيان در تمرین"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "sessions",
                title = "به‌روزآوری",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "به‌روزآوری لیست جلسات تمرین"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> session_participants_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditParticipant",
                controller = "sessions",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ویرایش جلسه تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Participants",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل",
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> session_participants_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteParticipant",
                controller = "sessions",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "sessionform",
                placeholder = "حذف جلسه تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Participants",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل",
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> session_participants_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "AddParticipant",
                controller = "sessions",
                title = "ثبت حضور",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت حضور در جلسه تمرین"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditParticipant",
                controller = "sessions",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات حضور در جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DetailsParticipant",
                controller = "sessions",
                title = "نمایش",
                placeholder = "مشاهده جزئیات حضور در جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteParticipant",
                controller = "sessions",
                title = "حذف",
                placeholder = "حذف اطلاعات حضور در جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Participants",
                controller = "sessions",
                title = "به‌روزآوري",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "به‌روزآوري مجدد ليست شركت كنندگان"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست جلسات"
            });
            return ribbons;
        }


        private static List<Models.ViewModels.ribbons> session_coaches_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditCoach",
                controller = "sessions",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ویرایش مربيان تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Coaches",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل",
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> session_coaches_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteCoach",
                controller = "sessions",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "sessionform",
                placeholder = "حذف مربيان تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Coaches",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل",
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> session_coaches_default(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "AddCoach",
                controller = "sessions",
                title = "ثبت مربي",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت مربي در جلسه تمرین"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditCoach",
                controller = "sessions",
                title = "ویرایش",
                placeholder = "ویرایش مربي جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DetailsCoach",
                controller = "sessions",
                title = "نمایش",
                placeholder = "مشاهده جزئیات حضور مربي در جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteCoach",
                controller = "sessions",
                title = "حذف",
                placeholder = "حذف اطلاعات حضور مربي در جلسه تمرین",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Coaches",
                controller = "sessions",
                title = "به‌روزآوري",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "به‌روزآوري مجدد ليست مربيان"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "sessions",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به ليست جلسات"
            });
            return ribbons;
        }
    }
}
