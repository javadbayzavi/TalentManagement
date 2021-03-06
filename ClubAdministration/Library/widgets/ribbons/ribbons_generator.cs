﻿using System;
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
                case "training.list.coaches":
                    return training_coaches_list(rootParams);
                case "training.details.default":
                    return training_details(rootParams);
                case "training.delete.default":
                    return training_delete(rootParams);

                case "training.plans.default":
                    return training_plans_default(rootParams);
                case "training.plans.details":
                    return training_plans_details(rootParams);
                case "training.plans.delete":
                    return training_plans_delete(rootParams);

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

                case "coaches.levels.default":
                    return coaches_levels_default(rootParams);
                case "coaches.levels.delete":
                    return coaches_levels_delete(rootParams);
                case "coaches.levels.details":
                    return coaches_levels_details(rootParams);
                case "coaches.levels.certificates":
                    return coaches_levels_certificates(rootParams);

                // drill related ribbons
                case "drills.list.default":
                    return drills_list_default(rootParams);
                case "drills.details.default":
                    return drills_details(rootParams);
                case "drills.delete.default":
                    return drills_delete(rootParams);

                case "drills.types.default":
                    return drills_types_default(rootParams);
                case "drills.types.details":
                    return drills_types_details(rootParams);
                case "drills.types.delete":
                    return drills_types_delete(rootParams);
                case "drills.types.typedrills":
                    return drills_types_typedrills(rootParams);

                case "drills.patterns.default":
                    return drills_patterns_default(rootParams);
                case "drills.patterns.details":
                    return drills_patterns_details(rootParams);
                case "drills.patterns.delete":
                    return drills_patterns_delete(rootParams);
                case "drills.patterns.simulate":
                    return drills_patterns_simulate(rootParams);

                case "drills.patternitems.default":
                    return drills_patternitems_default(rootParams);
                case "drills.patternitems.details":
                    return drills_patternitems_details(rootParams);
                case "drills.patternitems.delete":
                    return drills_patternitems_delete(rootParams);

                case "drills.emphasises.default":
                    return drills_emphasises_default(rootParams);
                case "drills.emphasises.details":
                    return drills_emphasises_details(rootParams);
                case "drills.emphasises.delete":
                    return drills_emphasises_delete(rootParams);
                case "drills.emphasises.emphasisdrills":
                    return drills_emphasises_typedrills(rootParams);

                case "drills.locations.default":
                    return drills_locations_default(rootParams);
                case "drills.locations.details":
                    return drills_locations_details(rootParams);
                case "drills.locations.delete":
                    return drills_locations_delete(rootParams);
                case "drills.locations.emphasisdrills":
                    return drills_locations_typedrills(rootParams);

                case "agelevels.list.default":
                    return agelevels_list_default(rootParams);
                case "agelevels.delete.default":
                    return agelevels_delete_default(rootParams);
                case "agelevels.details.default":
                    return agelevels_details_default(rootParams);

                case "positions.list.default":
                    return positions_list_default(rootParams);
                case "positions.delete.default":
                    return positions_delete_default(rootParams);
                case "positions.details.default":
                    return positions_details_default(rootParams);

                case "skills.list.default":
                    return skills_list_default(rootParams);
                case "skills.delete.default":
                    return skills_delete_default(rootParams);
                case "skills.details.default":
                    return skills_details_default(rootParams);

                case "materials.list.default":
                    return materials_list_default(rootParams);
                case "materials.delete.default":
                    return materials_delete_default(rootParams);
                case "materials.details.default":
                    return materials_details_default(rootParams);

                case "groups.list.default":
                    return groups_list_default(rootParams);
                case "groups.details.default":
                    return groups_details_default(rootParams);
                case "groups.delete.default":
                    return groups_delete_default(rootParams);

                case "zones.list.default":
                    return zones_list_default(rootParams);
                case "zones.details.default":
                    return zones_details_default(rootParams);
                case "zones.delete.default":
                    return zones_delete_default(rootParams);

                case "services.list.default":
                    return services_list_default(rootParams);
                case "services.details.default":
                    return services_details_default(rootParams);
                case "services.delete.default":
                    return services_delete_default(rootParams);

                case "groups.roles.list":
                    return groups_roles_list(rootParams);
                case "groups.roles.details":
                    return groups_roles_details(rootParams);
                case "groups.roles.delete":
                    return groups_roles_delete(rootParams);

                case "groups.users.list":
                    return groups_users_list(rootParams);
                case "groups.users.details":
                    return groups_users_details(rootParams);
                case "groups.users.delete":
                    return groups_users_delete(rootParams);

                case "users.list.default":
                    return users_list_default(rootParams);
                case "users.details.default":
                    return users_details_default(rootParams);
                case "users.delete.default":
                    return users_delete_default(rootParams);

                case "users.groups.list":
                    return users_groups_list(rootParams);
                case "users.groups.details":
                    return users_groups_details(rootParams);
                case "users.groups.delete":
                    return users_groups_delete(rootParams);


                case "templates.list.default":
                    return templates_list_default(rootParams);
                case "templates.details.default":
                    return templates_details_default(rootParams);
                case "templates.delete.default":
                    return templates_delete_default(rootParams);

                case "roles.list.default":
                    return roles_list_default(rootParams);
                case "roles.details.default":
                    return roles_details_default(rootParams);
                case "roles.delete.default":
                    return roles_delete_default(rootParams);

                case "roles.permissions.list":
                    return roles_permissions_list(rootParams);
                case "roles.permissions.details":
                    return roles_permissions_details(rootParams);
                case "roles.permissions.delete":
                    return roles_permissions_delete(rootParams);

                case "permissions.list.default":
                    return permissions_list_default(rootParams);
                case "permissions.details.default":
                    return permissions_details_default(rootParams);
                case "permissions.delete.default":
                    return permissions_delete_default(rootParams);

                case "menus.list.default":
                    return menus_list_default(rootParams);
                case "menus.details.default":
                    return menus_details_default(rootParams);
                case "menus.delete.default":
                    return menus_delete_default(rootParams);

                case "menus.items.default":
                    return menus_items_default(rootParams);
                case "menus.items.details":
                    return menus_items_details(rootParams);
                case "menus.items.delete":
                    return menus_items_delete(rootParams);

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
                controller = "trainings",
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
                controller = "trainings",
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
                controller = "trainings",
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
                controller = "trainings",
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
                controller = "trainings",
                title = "بازگشت",
                postback = false,
                rootparam = null,
                selectionneeded = false,
                hostform = "",
                placeholder = "بازگشت به صفحه قبل"
            });
            return ribbons;
        }

        private static List<Models.ViewModels.ribbons> training_coaches_list(params object[] rootParams)
        {

            List<ClubAdministration.Models.ViewModels.ribbons> ribbons = new List<ClubAdministration.Models.ViewModels.ribbons>();
            ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
            {
                action = "Index",
                controller = "trainings",
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
                controller = "trainings",
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
                    controller = "trainings",
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
                    controller = "trainings",
                    title = "ویرایش",
                    placeholder = "ویرایش اطلاعات کلاس آموزشی",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Details",
                    controller = "trainings",
                    title = "نمایش",
                    placeholder = "نمایش اطلاعات کلاس آموزشی",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Delete",
                    controller = "trainings",
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
                    controller = "trainings",
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
                    controller = "trainings",
                    title = "بازیکنان",
                    hostform = "",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Coaches",
                    placeholder = "مربيان کلاس",
                    controller = "trainings",
                    title = "مربيان",
                    hostform = "",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Plans",
                    placeholder = "برنامه ريزي تمرينات",
                    controller = "trainings",
                    title = "برنامه‌ريزي تمرين",
                    hostform = "",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Preview",
                    placeholder = "مشاهده برنامه تمرينات",
                    controller = "trainings",
                    title = "تقويم",
                    hostform = "",
                    postback = false,
                    rootparam = null,
                    selectionneeded = true
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Index",
                    controller = "trainings",
                    title = "به‌روزآوری",
                    placeholder = "اطلاعات لیست کلاس ها بازآوری شود",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Index",
                    controller = "agelevels",
                    title = "گروه‌هاي سني",
                    placeholder = "بخش برنامه‌ريزي گروه‌هاي سني",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Index",
                    controller = "skills",
                    title = "مهارت‌ها",
                    placeholder = "بخش برنامه‌ريزي مهارت‌ها",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Index",
                    controller = "materials",
                    title = "تجهيزات",
                    placeholder = "بخش برنامه‌ريزي تجهيزات",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                });
                ribbons.Add(new ClubAdministration.Models.ViewModels.ribbons()
                {
                    action = "Index",
                    controller = "positions",
                    title = "پست بازي",
                    placeholder = "بخش برنامه‌ريزي پست‌هاي بازي",
                    postback = false,
                    rootparam = null,
                    selectionneeded = false,
                });
            return ribbons;
            }
    }
}
