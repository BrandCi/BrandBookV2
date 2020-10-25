/**
 * LeftSidebar
 * @param {*} $
 */
!function ($) {
    'use strict';

    var LeftSidebar = function () {
        this.body = $('body'),
        this.window = $(window)
    };



    /**
     * Changes the size of sidebar
     * @param {*} size
     */
    LeftSidebar.prototype.changeSize = function(size) {
        this.body.attr('data-sidebar-size', size);
        this.parent.updateConfig("sidebar", { "size": size });
    },

    /**
     * Initilizes the menu
     */
    LeftSidebar.prototype.initMenu = function() {
        var self = this;

        var layout = $.LayoutThemeApp.getConfig();
        var sidebar = $.extend({}, layout ? layout.sidebar: {});
        var defaultSidebarSize = sidebar.size ? sidebar.size : 'default';

        // Left menu collapse
        $('.button-menu-mobile').on('click', function (event) {
            event.preventDefault();
            var sidebarSize = self.body.attr('data-sidebar-size');
            if (self.window.width() >= 993) {
                if (sidebarSize === 'condensed') {
                    self.changeSize(defaultSidebarSize === 'condensed'? 'default': defaultSidebarSize);
                } else {
                    self.changeSize('condensed');
                }
            } else {
                self.changeSize(defaultSidebarSize);
                self.body.toggleClass('sidebar-enable');
            }
        });
    },

    /**
     * Initilize the left sidebar size based on screen size
     */
    LeftSidebar.prototype.initLayout = function() {
        var self = this;
        // in case of small size, activate the small menu
        if ((this.window.width() >= 768 && this.window.width() <= 1028) || this.body.data('keep-enlarged')) {
            this.changeSize('condensed');
        } else {
            var layout = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');
            var sidebar = $.extend({}, layout ? layout.sidebar: {});
            var defaultSidebarSize = sidebar && sidebar.size ? sidebar.size : 'default';
            var sidebarSize = self.body.attr('data-sidebar-size');
            this.changeSize(defaultSidebarSize ? defaultSidebarSize :(sidebarSize ? sidebarSize : 'default'));
        }
    },

    /**
     * Initilizes the menu
     */
    LeftSidebar.prototype.init = function() {
        var self = this;
        this.initMenu();
        this.initLayout();

        // on window resize, make menu flipped automatically
        this.window.on('resize', function (e) {
            e.preventDefault();
            self.initLayout();
        });
    },

    $.LeftSidebar = new LeftSidebar, $.LeftSidebar.Constructor = LeftSidebar
}(window.jQuery),





/**
 * Layout and theme manager
 * @param {*} $
 */
function ($) {
    'use strict';

    // Layout and theme manager

    var LayoutThemeApp = function () {
        this.body = $('body'),
        this.window = $(window),
        this.config = {}
    };

    /**
    * Preserves the config in memory
    */
    LayoutThemeApp.prototype._saveConfig = function(newConfig) {
        this.config = $.extend(this.config, newConfig);
        // NOTE: You can make ajax call here to save preference on server side or localstorage as well
    },

    /**
     * Update the config for given config
     * @param {*} param
     * @param {*} config
     */
    LayoutThemeApp.prototype.updateConfig = function(param, config) {
        var newObj = {};
        if (typeof config === 'object' && config !== null) {
            var originalParam = this.config[param];
            newObj[param] = $.extend(originalParam, config);
        } else {
            newObj[param] = config;
        }
        this._saveConfig(newObj);
    }

    /**
    * Apply the config
    */
    LayoutThemeApp.prototype.applyConfig = function() {
        // getting the saved config if available
        this.config = $.extend({}, {
            width: "fluid",
            sidebar: {
                size: "default",
            },
        });

        var sidebarConfig = $.extend({}, this.config.sidebar);

        // activate menus
        this.leftSidebar.init();

        this.leftSidebar.parent = this;

        // width
        this.changeLayoutWidth(this.config.width);
        // left sidebar
        this.leftSidebar.changeSize(sidebarConfig.size);

    },


    /**
     * Changes the width of layout
     */
    LayoutThemeApp.prototype.changeLayoutWidth = function(width) {
        switch (width) {
            case "boxed": {
                this.body.attr('data-layout-width', 'boxed');
                // automatically activating condensed
                $.LeftSidebar.changeSize("condensed");
                this._saveConfig({ width: width });
                break;
            }
            default: {
                this.body.attr('data-layout-width', 'fluid');
                // automatically activating provided size
                var bodyConfig = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');
                $.LeftSidebar.changeSize(bodyConfig && bodyConfig.sidebar ? bodyConfig.sidebar.size : "default");
                this._saveConfig({ width: width });
                break;
            }
        }
    }

    /**
     * Gets the config
     */
    LayoutThemeApp.prototype.getConfig = function() {
        return this.config;
    },

    /**
     * Reset to default
     */
    LayoutThemeApp.prototype.reset = function() {
        this.applyConfig();
    },

    /**
     * Init
     */
    LayoutThemeApp.prototype.init = function() {
        this.leftSidebar = $.LeftSidebar;

        this.leftSidebar.parent = this;

        // initilize the menu
        this.applyConfig();
    },

    $.LayoutThemeApp = new LayoutThemeApp, $.LayoutThemeApp.Constructor = LayoutThemeApp
}(window.jQuery);


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
    $.LayoutThemeApp.init();

}(window.jQuery);

// Waves Effect
Waves.init();