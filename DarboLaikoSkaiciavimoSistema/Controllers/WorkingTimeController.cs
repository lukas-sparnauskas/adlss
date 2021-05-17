using DarboLaikoSkaiciavimoSistema.Cache;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Controllers
{
    /// <summary>
    /// Darbo laiko statistikos apskaičiavimo klasė.
    /// </summary>
    public class WorkingTimeController
    {
        /// <summary>
        /// Naudotojo likusio darbo laiko šiandien apskaičiavimas.
        /// </summary>
        /// <param name="remainingWorkingTimeToday"></param>
        /// <returns>Likęs naudotojo darbo laikas šiandien.</returns>
        public static TimeSpan RemainingWorktimeToday(TimeSpan? remainingWorkingTimeToday)
        {
            try
            {
                if (remainingWorkingTimeToday == TimeSpan.MaxValue) return TimeSpan.MaxValue;
                using (dlssdb db = new dlssdb())
                {
                    TimeSpan timeWorkedToday = new TimeSpan(0);
                    User current_user = UserController.GetUserByID(LocalCache.GetLastUserId());
                    List<Entry> entries = db.Entries.Where(x => x.card_id.Equals(current_user.card_id)).Where(x => DbFunctions.DiffDays(x.auth_date, DateTime.Today) == 0 && (DbFunctions.DiffHours(x.auth_datetime, DateTime.Today) < 24)).OrderBy(x => x.id).ToList();
                    if (entries.Count == 0) return new TimeSpan(current_user.work_hours_in_week / 5, 0, 0);
                    if (entries.Count % 2 == 0)
                    {
                        for (int i = 0; i < entries.Count; i += 2)
                        {
                            timeWorkedToday += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                        }
                        return new TimeSpan(current_user.work_hours_in_week / 5, 0, 0) - timeWorkedToday;
                    }
                    for (int i = 0; i < entries.Count - 1; i += 2)
                    {
                        timeWorkedToday += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                    }
                    timeWorkedToday += (DateTime.Now - entries.Last().auth_datetime).Value;
                    return new TimeSpan(current_user.work_hours_in_week / 5, 0, 0) - timeWorkedToday;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errDatabase, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Naudotojo likusio darbo laiko šią savaitę apskaičiavimas.
        /// </summary>
        /// <param name="remainingWorkingTimeWeek"></param>
        /// <returns>Likęs naudotojo darbo laikas šią savaitę.</returns>
        public static TimeSpan RemainingWorktimeWeek(TimeSpan? remainingWorkingTimeWeek)
        {
            try
            {
                if (remainingWorkingTimeWeek == TimeSpan.MaxValue) return TimeSpan.MaxValue;
                using (dlssdb db = new dlssdb())
                {
                    TimeSpan timeWorked = new TimeSpan(0);
                    User current_user = UserController.GetUserByID(LocalCache.GetLastUserId());
                    DateTime mondayThisWeek = DateTime.Today.DayOfWeek != DayOfWeek.Sunday ? DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - 1)) : DateTime.Today.AddDays(-6);
                    List<Entry> entries = db.Entries.Where(x => x.card_id.Equals(current_user.card_id)).Where(x => x.auth_date >= mondayThisWeek && DbFunctions.DiffDays(x.auth_date, mondayThisWeek) < 7 && (DbFunctions.DiffHours(x.auth_datetime, DateTime.Today) < 24 * 5)).OrderBy(x => x.id).ToList();
                    if (entries.Count == 0) return new TimeSpan(current_user.work_hours_in_week, 0, 0);
                    if (entries.Count % 2 == 0)
                    {
                        for (int i = 0; i < entries.Count; i += 2)
                        {
                            timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                        }
                        return new TimeSpan(current_user.work_hours_in_week, 0, 0) - timeWorked;
                    }
                    for (int i = 0; i < entries.Count - 1; i += 2)
                    {
                        timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                    }
                    timeWorked += (DateTime.Now - entries.Last().auth_datetime).Value;
                    return new TimeSpan(current_user.work_hours_in_week, 0, 0) - timeWorked;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errDatabase, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Naudotojo likusio darbo laiko šį mėnesį apskaičiavimas.
        /// </summary>
        /// <param name="remainingWorkingTimeMonth"></param>
        /// <returns>Likęs naudotojo darbo laikas šį mėnesį.</returns>
        public static TimeSpan RemainingWorktimeMonth(TimeSpan? remainingWorkingTimeMonth)
        {
            try
            {
                if (remainingWorkingTimeMonth == TimeSpan.MaxValue) return TimeSpan.MaxValue;
                using (dlssdb db = new dlssdb())
                {
                    TimeSpan timeWorked = new TimeSpan(0);
                    User current_user = UserController.GetUserByID(LocalCache.GetLastUserId());
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    List<Entry> entries = db.Entries.Where(x => x.card_id.Equals(current_user.card_id)).Where(x => x.auth_date >= firstDayOfMonth && DbFunctions.DiffDays(x.auth_date, firstDayOfMonth) < daysInCurrentMonth && (DbFunctions.DiffDays(x.auth_datetime, DateTime.Today) < daysInCurrentMonth)).OrderBy(x => x.id).ToList();
                    if (entries.Count == 0) return new TimeSpan(current_user.work_hours_in_week / 5 * daysInCurrentMonth, 0, 0);
                    if (entries.Count % 2 == 0)
                    {
                        for (int i = 0; i < entries.Count; i += 2)
                        {
                            timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                        }
                        return new TimeSpan(current_user.work_hours_in_week / 5 * daysInCurrentMonth, 0, 0) - timeWorked;
                    }
                    for (int i = 0; i < entries.Count - 1; i += 2)
                    {
                        timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                    }
                    timeWorked += (DateTime.Now - entries.Last().auth_datetime).Value;
                    return new TimeSpan(current_user.work_hours_in_week / 5 * daysInCurrentMonth, 0, 0) - timeWorked;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errDatabase, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Naudotojo išdirbto laiko šią savaitę apskaičiavimas.
        /// </summary>
        /// <param name="user_id">Naudotojo ID</param>
        /// <returns>Naudotojo išdirbtas laikas šią savaitę</returns>
        public static string UserTimeWorkedThisWeek(int user_id)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    TimeSpan timeWorked = new TimeSpan(0);
                    User user = UserController.GetUserByID(user_id);
                    DateTime mondayThisWeek = DateTime.Today.DayOfWeek != DayOfWeek.Sunday ? DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - 1)) : DateTime.Today.AddDays(-6);
                    List<Entry> entries = db.Entries.Where(x => x.card_id.Equals(user.card_id)).Where(x => x.auth_date >= mondayThisWeek && DbFunctions.DiffDays(x.auth_date, mondayThisWeek) < 7 && (DbFunctions.DiffHours(x.auth_datetime, DateTime.Today) < 24 * 5)).OrderBy(x => x.id).ToList();
                    if (entries.Count == 0) return Math.Round(timeWorked.TotalHours, 2).ToString("F") + " / " + user.work_hours_in_week;
                    if (entries.Count % 2 == 0)
                    {
                        for (int i = 0; i < entries.Count; i += 2)
                        {
                            timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                        }
                        return Math.Round(timeWorked.TotalHours, 2).ToString("F") + " / " + user.work_hours_in_week;
                    }
                    for (int i = 0; i < entries.Count - 1; i += 2)
                    {
                        timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                    }
                    timeWorked += (DateTime.Now - entries.Last().auth_datetime).Value;
                    return Math.Round(timeWorked.TotalHours, 2).ToString("F") + " / " + user.work_hours_in_week;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errDatabase, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Properties.Strings.errTitle;
            }
        }

        /// <summary>
        /// Naudotojo išdirbto laiko šį mėnesį apskaičiavimas.
        /// </summary>
        /// <param name="user_id">Naudotojo ID</param>
        /// <returns>Naudotojo išdirbtas laikas šį mėnesį</returns>
        public static string UserTimeWorkedThisMonth(int user_id)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    TimeSpan timeWorked = new TimeSpan(0);
                    User user = UserController.GetUserByID(user_id);
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    List<Entry> entries = db.Entries.Where(x => x.card_id.Equals(user.card_id)).Where(x => x.auth_date >= firstDayOfMonth && DbFunctions.DiffDays(x.auth_date, firstDayOfMonth) < daysInCurrentMonth && (DbFunctions.DiffDays(x.auth_datetime, DateTime.Today) < daysInCurrentMonth)).OrderBy(x => x.id).ToList();
                    if (entries.Count == 0) return Math.Round(timeWorked.TotalHours, 2).ToString("F") + " / " + user.work_hours_in_week / 5 * daysInCurrentMonth;
                    if (entries.Count % 2 == 0)
                    {
                        for (int i = 0; i < entries.Count; i += 2)
                        {
                            timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                        }
                        return Math.Round(timeWorked.TotalHours, 2).ToString("F") + " / " + user.work_hours_in_week / 5 * daysInCurrentMonth;
                    }
                    for (int i = 0; i < entries.Count - 1; i += 2)
                    {
                        timeWorked += (entries[i + 1].auth_datetime - entries[i].auth_datetime).Value;
                    }
                    timeWorked += (DateTime.Now - entries.Last().auth_datetime).Value;
                    return Math.Round(timeWorked.TotalHours, 2).ToString("F") + " / " + user.work_hours_in_week / 5 * daysInCurrentMonth;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errDatabase, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Properties.Strings.errTitle;
            }
        }
    }
}
