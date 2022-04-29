using System;

namespace Hospital.View.DoctorView
{
    class CustomTimeSpanUpDown : Xceed.Wpf.Toolkit.TimeSpanUpDown
    {
        protected override TimeSpan? ConvertTextToValue(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            return new TimeSpan(Convert.ToInt32(text.Substring(0, 2)), Convert.ToInt32(text.Substring(3, 2)), 0);
        }

        protected override string ConvertValueToText()
        {
            if (!Value.HasValue)
            {
                return string.Empty;
            }
            return Value.Value.ToString(@"hh\:mm");
        }

        protected override void OnIncrement()
        {
            if (Value.HasValue)
            {
                Value = Value.Value.Add(TimeSpan.FromMinutes(5));
            }
        }

        protected override void OnDecrement()
        {
            if (Value.HasValue)
            {
                Value = Value.Value.Add(TimeSpan.FromMinutes(-5));
            }
        }
    }
}
