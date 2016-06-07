$.fn.datetimepicker.defaults.calendarWeeks = true;
$.fn.datetimepicker.defaults.showTodayButton = true;

//Update Jquery validator for datetime format 'dd/mm/yyyy'
$.validator.methods.date = function (value, element) {
    var isChrome = /Chrome/.test(navigator.userAgent) && /Google Inc/.test(navigator.vendor);
    if (isChrome) {
        //var d = new Date();
        //return this.optional(element) || !/Invalid|NaN/.test(new Date(d.toLocaleDateString(value)));
        var d = value.split("/");
        return this.optional(element) || !/Invalid|NaN/.test(new Date((/chrom(e|ium)/.test(navigator.userAgent.toLowerCase())) ? d[1] + "/" + d[0] + "/" + d[2] : value));
    } else {
        return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
    }
};