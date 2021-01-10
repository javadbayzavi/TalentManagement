using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.widgets.ribbons
{
    public partial class ribbons_generator
    {
        public List<object> rootparams { get; set; }
        public static List<Models.ViewModels.ribbons> get_ribbons(string handleKey,params object[] rootParams)
        {
            if (handleKey == null || handleKey == "")
                return new List<Models.ViewModels.ribbons>();

            //var ribbons = new List<Models.ViewModels.ribbons>();
            switch (handleKey)
            {
                case "training.list.default":
                    return training_list(rootParams);
                case "training.list.players":
                    return training_player_list(rootParams);
                case "training.list.sessions":
                    return training_session_list(rootParams);
                case "training.details.default":
                    return training_details(rootParams);
                case "training.delete.default":
                    return training_delete(rootParams);

                case "players.list.default":
                    return player_list(rootParams);
                case "players.details.default":
                    return player_details(rootParams);
                case "players.delete.default":
                    return player_delete(rootParams);

                case "players.subscriptions.default":
                    return player_subscription_list(rootParams);
                case "players.subscriptions.details":
                    return player_subscription_details(rootParams);
                case "players.subscriptions.delete":
                    return player_subscription_delete(rootParams);

                case "sessions.list.default":
                    return session_list_default(rootParams);
                case "sessions.details.default":
                    return session_details_default(rootParams);
                case "sessions.delete.default":
                    return session_delete_default(rootParams);

                case "sessions.participants.default":
                    return session_participants_default(rootParams);
                case "sessions.participants.details":
                    return session_participants_details(rootParams);
                case "sessions.participants.delete":
                    return session_participants_delete(rootParams);

                case "sessions.coaches.default":
                    return session_coaches_default(rootParams);
                case "sessions.coaches.details":
                    return session_coaches_details(rootParams);
                case "sessions.coaches.delete":
                    return session_coaches_delete(rootParams);
//Finance related ribbons
                case "finance.list.default":
                    return finance_list(rootParams);
                case "finance.details.default":
                    return finance_details(rootParams);
                case "finance.delete.default":
                    return finance_delete(rootParams);

                case "finance.accounts.default":
                    return finance_account_list(rootParams);
                case "finance.accounts.transactions":
                    return finance_account_transactions(rootParams);
                case "finance.accounts.details":
                    return finance_account_details(rootParams);
                case "finance.accounts.delete":
                    return finance_account_delete(rootParams);

                case "finance.categories.default":
                    return finance_categories_list(rootParams);
                case "finance.categories.transactions":
                    return finance_categories_transactions(rootParams);
                case "finance.categories.details":
                    return finance_categories_details(rootParams);
                case "finance.categories.delete":
                    return finance_categories_delete(rootParams);

                case "finance.playerpayments.default":
                    return finance_playerpayments_list(rootParams);
                case "finance.playerpayments.details":
                    return finance_playerpayments_details(rootParams);
                case "finance.playerpayments.delete":
                    return finance_playerpayments_delete(rootParams);

                case "finance.clubcost.default":
                    return finance_clubcost_list(rootParams);
                case "finance.trainingcost.default":
                    return finance_trainingcost_list(rootParams);
                case "finance.sessioncost.default":
                    return finance_sessioncost_list(rootParams);
                case "finance.players.invoices":
                    return finance_players_invoices(rootParams);
                case "finance.player.costs":
                    return finance_players_costs(rootParams);
                case "finance.player.invoices":
                    return finance_player_invoice(rootParams);
//Coach related ribbons
                case "coaches.list.default":
                    return coaches_list_default(rootParams);
                case "coaches.details.default":
                    return coaches_details(rootParams);
                case "coaches.delete.default":
                    return coaches_delete(rootParams);

                case "coaches.trainings.default":
                    return coaches_training_default(rootParams);
                case "coaches.trainings.delete":
                    return coaches_training_delete(rootParams);
                case "coaches.trainings.details":
                    return coaches_training_details(rootParams);

                case "coaches.certificates.default":
                    return coaches_certificate_default(rootParams);
                case "coaches.certificates.delete":
                    return coaches_certificate_delete(rootParams);
                case "coaches.certificates.details":
                    return coaches_certificate_details(rootParams);

                case "coaches.issuers.default":
                    return coaches_issuers_default(rootParams);
                case "coaches.issuers.delete":
                    return coaches_issuers_delete(rootParams);
                case "coaches.issuers.details":
                    return coaches_issuers_details(rootParams);
                case "coaches.issuers.certificates":
                    return coaches_issuers_certificates(rootParams);

                default:
                    return new List<Models.ViewModels.ribbons>();
            }
        }
        private static List<Models.ViewModels.ribbons> training_delete(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Delete",
                controller = "club",
                title = "حذف",
                postback = true,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "trainingform",
                placeholder = "حذف اطلاعات کلاس آموزشی",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "club",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> training_details(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Edit",
                controller = "club",
                title = "ويرايش",
                postback = false,
                rootparam = rootParams[0],
                selectionneeded = false,
                hostform = "",
                placeholder = "ويرايش اطلاعات کلاس آموزشی",
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "club",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> training_session_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
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
                action = "Index",
                controller = "club",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> training_player_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Details",
                controller = "players",
                title = "پرونده بازیکن",
                postback = false,
                rootparam = null,
                selectionneeded = true,
                hostform = "",
                placeholder = "مشاهده پرونده بازیکن"
            });
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "club",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }
        private static List<Models.ViewModels.ribbons> training_list(params object[] rootParams)
            {
                List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Create",
                    controller = "club",
                    title = "ایجاد",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                    hostform = "",
                    placeholder = "ایجاد یک کلاس آموزشی جدید"
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Edit",
                    controller = "club",
                    title = "ویرایش",
                    placeholder = "ویرایش اطلاعات کلاس آموزشی",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Details",
                    controller = "club",
                    title = "نمایش",
                    placeholder = "نمایش اطلاعات کلاس آموزشی",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Delete",
                    controller = "club",
                    title = "حذف",
                    placeholder = "حذف اطلاعات کلاس آموزشی",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Sessions",
                    placeholder = "جلسات تمرین برنامه‌ریزی شده برای کلاس",
                    controller = "club",
                    title = "جلسات تمرین",
                    hostform = "",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Players",
                    placeholder = "بازیکان ثبت نام شده در کلاس",
                    controller = "club",
                    title = "بازیکنان",
                    hostform = "",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Index",
                    controller = "club",
                    title = "به‌روزآوری",
                    placeholder = "اطلاعات لیست کلاس ها بازآوری شود",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                });

                return ribbons;
            }
    }
}
