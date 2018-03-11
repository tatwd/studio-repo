!function ($) {

    var FocusEvent = function () {
        function FocusEvent(elemt_str, validator) {
            (typeof elemt_str == 'string') ? this.element = document.getElementById(elemt_str) : this.element = null;
            (typeof validator == 'string') ? this.validator = validator : this.validator = null;
        }

        FocusEvent.prototype.addFocus = function () {

            var ele = this.element;
            var val = this.validator;

            if (!ele) {
                return;
            }

            ele.addEventListener('focus', function () {
                var validatorName = this.parentElement.getElementsByClassName(val);

                for (var i = 0, length = validatorName.length; i < length; i++) {
                    validatorName[i].style.visibility = 'hidden';
                };

            }, false);
        };

        return FocusEvent;
    }();

    var clicked = false;
}(window);