using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        private static List<Models.ViewModels.ribbons> finance_account_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditAccount",
                controller = "finance",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات حساب بانكي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Accounts",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_account_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteAccount",
                controller = "finance",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "financeform",
                placeholder = "حذف حساب بانكي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Accounts",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> finance_account_transactions(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "finance",
                title = "ایجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ایجاد یک سند مالي جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "finance",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات سند مالي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "finance",
                title = "نمایش",
                placeholder = "مشاهده جزئیات تراکنش",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "finance",
                title = "حذف",
                placeholder = "حذف اطلاعات سند مالي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Accounts",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_account_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "CreateAccount",
                controller = "finance",
                title = "ايجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ايجاد حساب بانكي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "EditAccount",
                controller = "finance",
                title = "ویرایش",
                placeholder = "ویرایش اطلاعات حساب بانكي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DetailsAccount",
                controller = "finance",
                title = "نمایش",
                placeholder = "نمایش اطلاعات حساب بانكي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "DeleteAccount",
                controller = "finance",
                title = "حذف",
                placeholder = "حذف اطلاعات حساب بانكي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "AccountTransactions",
                controller = "finance",
                title = "تراكنش‌ها",
                placeholder = "نمایش تراكنش‌هاي حساب بانكي",
                postback = false,
                rootparam = null,
                selectionneeded = true,
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Accounts",
                controller = "finance",
                title = "به‌روزآوري",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازآوري مجدد ليست"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> finance_player_invoice(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
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
                title = "پرداختی‌های بازيكن",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ليست پرداختی‌های بازيكن",
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
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_players_costs(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
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
                action = "PlayerPayments",
                controller = "finance",
                title = "پرداختی‌های بازيكن",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ليست پرداختی‌های بازيكن",
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
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_players_invoices(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerInvoices",
                controller = "finance",
                title = "صورتحساب بازيكن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "صورتحساب كلي بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerCosts",
                controller = "finance",
                title = "هزينه‌هاي بازيكن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "هزينه‌هاي بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerPayments",
                controller = "finance",
                title = "پرداختی‌های بازيكن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "ليست پرداختی‌های بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "ClubCosts",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> finance_sessioncost_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerCosts",
                controller = "finance",
                title = "هزينه بازيكن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "ليست‌ هزينه‌هاي آموزشي بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayerInvoices",
                controller = "finance",
                title = "صورتحساب بازيكن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "صورتحساب كلي بازيكن",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "TrainingCosts",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> finance_trainingcost_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "SessionCosts",
                controller = "finance",
                title = "هزينه‌هاي‌ جلسه",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "نمايش هزينه‌هاي ‌جلسات آموزشي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "ClubCosts",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> finance_clubcost_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "TrainingCosts",
                controller = "finance",
                title = "مالي‌ كلاس",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "نمايش هزينه‌هاي ‌كلاس آموزشي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "PlayersInvoices",
                controller = "finance",
                title = "مالي بازيكنان",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Create",
                controller = "finance",
                title = "ایجاد",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "ایجاد یک سند مالي جدید"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Accounts",
                placeholder = "مديريت حساب‌هاي بانكي باشگاه",
                controller = "finance",
                title = "حساب‌هاي بانكي",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "ClubCosts",
                placeholder = "مديريت هزينه‌هاي باشگاه",
                controller = "finance",
                title = "هزینه‌هاي باشگاه",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Categories",
                placeholder = "مديريت دسته بندي هزينه‌ها",
                controller = "finance",
                title = "دسته‌بندي پرداخت",
                hostform = "",
                postback = false,
                rootparam = null,
                selectionneeded = false
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "finance",
                title = "به‌روزآوری",
                placeholder = "اطلاعات بخش مديريت مالي بازآوری شود",
                postback = false,
                rootparam = null,
                selectionneeded = false,
            });

            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "finance",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات سند مالي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "AccountTransactions",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> finance_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "finance",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "financeform",
                placeholder = "حذف تراكنش مالي",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "AccountTransactions",
                controller = "finance",
                title = "بازگشت",
                postback = false,
                rootparam = rootParams[1],
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
    }
}
