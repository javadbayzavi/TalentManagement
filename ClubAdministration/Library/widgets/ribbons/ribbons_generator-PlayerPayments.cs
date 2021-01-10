using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> finance_playerpayments_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditPlayerPayment",
                controller = "finance",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ویرایش جلسه تمرین",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerPayments",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "لیست پرداختی‌های بازیکن",
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_playerpayments_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeletePlayerPayment",
                controller = "finance",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "financeform",
                placeholder = "حذف سند مالی بازیکن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerPayments",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "لیست پرداختی‌های بازیکن",
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> finance_playerpayments_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "CreatePlayerPayment",
                controller = "finance",
                title = "ایجاد",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ثبت سند مالی برای بازیکن"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditPlayerPayment",
                controller = "finance",
                title = "ویرایش",
                placeholder = "ویرایش سند مالی بازیکن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DetailsPlayerPayment",
                controller = "finance",
                title = "نمایش",
                placeholder = "مشاهده جزئیات سند مالی بازیکن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeletePlayerPayment",
                controller = "finance",
                title = "حذف",
                placeholder = "حذف اطلاعات سند مالی بازیکن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerInvoices",
                controller = "finance",
                title = "صورتحساب بازيكن",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "صورتحساب كلي بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerCosts",
                controller = "finance",
                title = "هزينه‌هاي بازيكن",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ليست هزينه‌هاي بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerPayments",
                controller = "finance",
                title = "به‌روزآوری",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "به‌روزآوری لیست جلسات تمرین"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayersInvoices",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به لیست هزینه‌های بازیکنان"
            });

            return ribbons;
        }
    }
}
