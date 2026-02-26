using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    public enum ResetType
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Interval
    }
    public enum ResetTimeMode
    {
        UTC,
        Local
    }

    [System.Serializable]
    public class TimeResetConfig:ICloneable
    {
        [UnityEngine.SerializeField]
        private ResetType _resetType;

        [UnityEngine.SerializeField]
        private ResetTimeMode _resetTimeMode;
        [UnityEngine.SerializeField]
        private int _hour;
        [UnityEngine.SerializeField]
        private DayOfWeek _dayOfWeek;
        [UnityEngine.SerializeField]
        private int _dayOfMonth;
        [UnityEngine.SerializeField]
        private long _intervalSeconds;
        public ResetType ResetType => _resetType;
        public ResetTimeMode ResetTimeMode => _resetTimeMode;
        public int Hour => _hour;
        public DayOfWeek DayOfWeek => _dayOfWeek;
        public int DayOfMonth => _dayOfMonth;
        public long IntervalSeconds => _intervalSeconds;
        public TimeResetConfig()
        {
            _resetType = ResetType.Daily;
            _resetTimeMode = ResetTimeMode.UTC;
            _hour = 0;
            _dayOfWeek = DayOfWeek.Monday;
            _dayOfMonth = 1;
            _intervalSeconds = 86400; // 24 hours
        }

        public TimeResetConfig(ResetType resetType, ResetTimeMode resetTimeMode, int hour, DayOfWeek dayOfWeek, int dayOfMonth, long intervalSeconds)
        {
            _resetType = resetType;
            _resetTimeMode = resetTimeMode;
            _hour = hour;
            _dayOfWeek = dayOfWeek;
            _dayOfMonth = dayOfMonth;
            _intervalSeconds = intervalSeconds;
        }

        public bool IsReset(long lastResetUtcTicks)
        {
            DateTime utcNow = TimeManager.Instance.UTCNow;

            
            if (_resetType == ResetType.Interval)
            {
                if (lastResetUtcTicks == 0)
                    return true;

                long intervalTicks = TimeSpan
                    .FromSeconds(_intervalSeconds)
                    .Ticks;

                return utcNow.Ticks >= lastResetUtcTicks + intervalTicks;
            }

            DateTime baseNow = _resetTimeMode == ResetTimeMode.UTC
                ? utcNow
                : utcNow.ToLocalTime();

            DateTime boundary = CalculateBoundary(baseNow);

            DateTime boundaryUtc = _resetTimeMode == ResetTimeMode.UTC
                ? boundary
                : boundary.ToUniversalTime();

            return lastResetUtcTicks < boundaryUtc.Ticks;
        }
        public long GetNextResetUtcTicks(long lastResetUtcTicks)
        {
            DateTime utcNow = TimeManager.Instance.UTCNow;

            // ===== Interval =====
            if (_resetType == ResetType.Interval)
            {
                if (lastResetUtcTicks == 0)
                    return utcNow.AddSeconds(_intervalSeconds).Ticks;

                var nextTime = new DateTime(
                    lastResetUtcTicks,
                    DateTimeKind.Utc);

                TimeSpan interval = TimeSpan.FromSeconds(_intervalSeconds);

                while (nextTime <= utcNow)
                {
                    nextTime = nextTime.Add(interval);
                }

                return nextTime.Ticks;
            }

            // ===== Daily / Weekly / Monthly =====

            DateTime baseNow = _resetTimeMode == ResetTimeMode.UTC
                ? utcNow
                : utcNow.ToLocalTime();

            var next = CalculateNextBoundary(baseNow);

            while (next <= baseNow)
            {
                next = AddPeriod(next);
            }

            DateTime nextUtc = _resetTimeMode == ResetTimeMode.UTC
                ? next
                : next.ToUniversalTime();

            return nextUtc.Ticks;

        }
        private DateTime AddPeriod(DateTime time)
        {
            switch (_resetType)
            {
                case ResetType.Daily:
                    return time.AddDays(1);

                case ResetType.Weekly:
                    return time.AddDays(7);

                case ResetType.Monthly:
                    return time.AddMonths(1);
            }

            return time;
        }
        private DateTime CalculateNextBoundary(DateTime baseNow)
        {
            switch (_resetType)
            {
                case ResetType.Daily:
                {
                    DateTime todayReset = new DateTime(
                        baseNow.Year,
                        baseNow.Month,
                        baseNow.Day,
                        _hour, 0, 0);

                    if (baseNow < todayReset)
                        return todayReset;

                    return todayReset.AddDays(1);
                }

                case ResetType.Weekly:
                {
                    int diff = _dayOfWeek - baseNow.DayOfWeek;
                    if (diff < 0) diff += 7;

                    DateTime next = baseNow.Date
                        .AddDays(diff)
                        .AddHours(_hour);

                    if (next <= baseNow)
                        next = next.AddDays(7);

                    return next;
                }

                case ResetType.Monthly:
                {
                    int clampedDay = Math.Clamp(
                        _dayOfMonth,
                        1,
                        DateTime.DaysInMonth(baseNow.Year, baseNow.Month));

                    DateTime thisMonth = new DateTime(
                        baseNow.Year,
                        baseNow.Month,
                        clampedDay,
                        _hour, 0, 0);

                    if (thisMonth > baseNow)
                        return thisMonth;

                    DateTime nextMonth = baseNow.AddMonths(1);

                    clampedDay = Math.Clamp(
                        _dayOfMonth,
                        1,
                        DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month));

                    return new DateTime(
                        nextMonth.Year,
                        nextMonth.Month,
                        clampedDay,
                        _hour, 0, 0);
                }
            }

            return baseNow;
        }
        private DateTime CalculateBoundary(DateTime baseNow)
        {
            switch (_resetType)
            {
                case ResetType.Daily:
                {
                    DateTime reset = new DateTime(
                        baseNow.Year,
                        baseNow.Month,
                        baseNow.Day,
                        _hour, 0, 0);

                    if (baseNow < reset)
                        reset = reset.AddDays(-1);

                    return reset;
                }

                case ResetType.Weekly:
                {
                    int diff = baseNow.DayOfWeek - _dayOfWeek;
                    if (diff < 0) diff += 7;

                    DateTime reset = baseNow.Date
                        .AddDays(-diff)
                        .AddHours(_hour);

                    if (baseNow < reset)
                        reset = reset.AddDays(-7);

                    return reset;
                }

                case ResetType.Monthly:
                {
                    int clampedDay = Math.Clamp(
                        _dayOfMonth,
                        1,
                        DateTime.DaysInMonth(baseNow.Year, baseNow.Month));

                    DateTime reset = new DateTime(
                        baseNow.Year,
                        baseNow.Month,
                        clampedDay,
                        _hour, 0, 0);

                    if (baseNow < reset)
                        reset = reset.AddMonths(-1);

                    return reset;
                }
            }

            return baseNow;
        }

        public object Clone()
        {
            return new TimeResetConfig(_resetType, _resetTimeMode, _hour, _dayOfWeek, _dayOfMonth, _intervalSeconds);
        }
    }
}