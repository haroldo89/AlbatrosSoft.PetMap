jQuery.extend(jQuery.mobile.datebox.prototype.options.lang, {
    'unique': {
        setDateButtonLabel: Resources.jQuery_dateBox_setDateButtonLabel_Text,
        setTimeButtonLabel: Resources.jQuery_dateBox_setTimeButtonLabel_Text,
        setDurationButtonLabel: "Set Duration",
        calTodayButtonLabel: "Jump to Today",
        titleDateDialogLabel: Resources.jQuery_dateBox_titleDateDialogLabel_Text,
        titleTimeDialogLabel: Resources.jQuery_dateBox_titleTimeDialogLabel_Text,
        daysOfWeek: [
          Resources.jQuery_datepicker_dayNames_Sunday, Resources.jQuery_datepicker_dayNames_Monday, Resources.jQuery_datepicker_dayNames_Tuesday,
          Resources.jQuery_datepicker_dayNames_Wednesday, Resources.jQuery_datepicker_dayNames_Thursday, Resources.jQuery_datepicker_dayNames_Friday,
          Resources.jQuery_datepicker_dayNames_Saturday
        ],
        daysOfWeekShort: [
            Resources.Formated_dayNamesShort_Monday, Resources.Formated_dayNamesShort_Tuesday, Resources.Formated_dayNamesShort_Wednesday,
            Resources.Formated_dayNamesShort_Thursday, Resources.Formated_dayNamesShort_Friday, Resources.Formated_dayNamesShort_Saturday, Resources.Formated_dayNamesShort_Sunday
        ],
        monthsOfYear: [
          Resources.jQuery_datepicker_monthNames_January, Resources.jQuery_datepicker_monthNames_February, Resources.jQuery_datepicker_monthNames_March,
          Resources.jQuery_datepicker_monthNames_April, Resources.jQuery_datepicker_monthNames_May, Resources.jQuery_datepicker_monthNames_June,
          Resources.jQuery_datepicker_monthNames_July, Resources.jQuery_datepicker_monthNames_Augost, Resources.jQuery_datepicker_monthNames_September,
          Resources.jQuery_datepicker_monthNames_October, Resources.jQuery_datepicker_monthNames_November, Resources.jQuery_datepicker_monthNames_December
        ],
        monthsOfYearShort: [
          Resources.Formated_monthNamesShort_January, Resources.Formated_monthNamesShort_Febrary, Resources.Formated_monthNamesShort_March,
          Resources.Formated_monthNamesShort_April, Resources.Formated_monthNamesShort_May, Resources.Formated_monthNamesShort_June,
          Resources.Formated_monthNamesShort_July, Resources.Formated_monthNamesShort_Augost, Resources.Formated_monthNamesShort_September,
          Resources.Formated_monthNamesShort_October, Resources.Formated_monthNamesShort_November, Resources.Formated_monthNamesShort_December
        ],
        durationLabel: ["Days", "Hours", "Minutes", "Seconds"],
        durationDays: ["Day", "Days"],
        tooltip: "Open Date Picker",
        nextMonth: "Next Month",
        prevMonth: "Previous Month",
        timeFormat: 12,
        headerFormat: "%A, %B %-d, %Y",
        dateFieldOrder: ["m", "d", "y"],
        timeFieldOrder: ["h", "i", "a"],
        slideFieldOrder: ["y", "m", "d"],
        dateFormat: "%m/%d/%Y",
        useArabicIndic: false,
        isRTL: false,
        calStartDay: 0,
        clearButton: "clear",
        durationOrder: ["d", "h", "i", "s"],
        meridiem: ["AM", "PM"],
        timeOutput: "%k:%M", // 12hr: "%l:%M %p", 24hr: "%k:%M",
        durationFormat: "%Dd %DA, %Dl:%DM:%DS",
        calDateListLabel: "Other Dates",
        calHeaderFormat: "%B %Y",
        calTomorrowButtonLabel: "Jump to Tomorrow"
    }
});
jQuery.extend(jQuery.mobile.datebox.prototype.options, {
    useLang: 'unique'
});

