using GameMaker.Core.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Feature.Shop.Editor
{
    [GameMaker.Core.Runtime.TypeCache]
    public class TimeResetConfigHolder : BaseHolder
    {
        private EnumField _resetTypeEnumField;
        private EnumField _resetTimeModeEnumField;
        private IntegerField _hourIntField;
        private EnumField _dayOfWeekEnumField;
        private IntegerField _dayOfMonthIntField;

        private LongField _intervalSecondsLongField;
        public TimeResetConfigHolder(VisualElement root) : base(root)
        {
            _resetTypeEnumField = root.Q<EnumField>("ResetTypeEnumField");
            _resetTimeModeEnumField = root.Q<EnumField>("ResetTimeModeEnumField");
            _hourIntField = root.Q<IntegerField>("HourIntField");
            _dayOfWeekEnumField = root.Q<EnumField>("DayOfWeekEnumField");
            _dayOfWeekEnumField.dataSourceType = typeof(System.DayOfWeek);
            _dayOfMonthIntField = root.Q<IntegerField>("DayOfMonthIntField");
            _intervalSecondsLongField = root.Q<LongField>("IntervalSecondsLongField");
        }
        public override void Bind(SerializedProperty elementProperty)
        {
            base.Bind(elementProperty);
            
            _resetTypeEnumField.BindProperty(elementProperty.FindPropertyRelative("_resetType"));
            _resetTimeModeEnumField.BindProperty(elementProperty.FindPropertyRelative("_resetTimeMode"));
            _hourIntField.BindProperty(elementProperty.FindPropertyRelative("_hour"));
            _dayOfWeekEnumField.BindProperty(elementProperty.FindPropertyRelative("_dayOfWeek"));
            _dayOfMonthIntField.BindProperty(elementProperty.FindPropertyRelative("_dayOfMonth"));
            _intervalSecondsLongField.BindProperty(elementProperty.FindPropertyRelative("_intervalSeconds"));
        }
    }
}