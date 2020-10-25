!function ($) {
    "use strict";

    var Components = function () { };

    //initializing tooltip
    Components.prototype.initTooltipPlugin = function () {
        $.fn.tooltip && $('[data-toggle="tooltip"]').tooltip()
    },

    //initializing popover
    Components.prototype.initPopoverPlugin = function () {
        $.fn.popover && $('[data-toggle="popover"]').popover()
    },

    //initializing toast
    Components.prototype.initToastPlugin = function() {
        $.fn.toast && $('[data-toggle="toast"]').toast()
    },

    //initializing form validation
    Components.prototype.initFormValidation = function () {
        $(".needs-validation").on('submit', function (event) {
            $(this).addClass('was-validated');
            if ($(this)[0].checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
                return false;
            }
            return true;
        });
    },

    //initilizing
    Components.prototype.init = function () {
        this.initTooltipPlugin(),
        this.initPopoverPlugin(),
        this.initToastPlugin(),
        this.initFormValidation()
    },

    $.Components = new Components, $.Components.Constructor = Components

}(window.jQuery),


//initializing main application module
function ($) {
    "use strict";

    $.Components.init();


}(window.jQuery);

// Waves Effect
Waves.init();