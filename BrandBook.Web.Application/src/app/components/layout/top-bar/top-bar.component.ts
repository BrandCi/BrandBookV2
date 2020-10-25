import { Component, OnInit } from '@angular/core';

declare var $: any;


@Component({
  selector: 'app-layout-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss']
})
export class LayoutTopBarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

    const LeftSidebar = function() {
        this.body = $('body'),
        this.window = $(window);
    };

    LeftSidebar.prototype.changeSize = function(size) {
        this.body.attr('data-sidebar-size', size);
        this.parent.updateConfig('sidebar', { '{size}': size });
    },

    /**
     * Initilizes the menu
     */
    LeftSidebar.prototype.initMenu = function() {
        const self = this;

        const layout = $.LayoutThemeApp.getConfig();
        const sidebar = $.extend({}, layout ? layout.sidebar : {});
        const defaultSidebarSize = sidebar.size ? sidebar.size : 'default';

        // Left menu collapse
        $('.button-menu-mobile').on('click', (event) => {
            event.preventDefault();
            const sidebarSize = self.body.attr('data-sidebar-size');
            if (self.window.width() >= 993) {
                if (sidebarSize === 'condensed') {
                    self.changeSize(defaultSidebarSize === 'condensed' ? 'default' : defaultSidebarSize);
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
        const self = this;
        // in case of small size, activate the small menu
        if ((this.window.width() >= 768 && this.window.width() <= 1028) || this.body.data('keep-enlarged')) {
            this.changeSize('condensed');
        } else {
            const layout = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');
            const sidebar = $.extend({}, layout ? layout.sidebar : {});
            const defaultSidebarSize = sidebar && sidebar.size ? sidebar.size : 'default';
            const sidebarSize = self.body.attr('data-sidebar-size');
            this.changeSize(defaultSidebarSize ? defaultSidebarSize : (sidebarSize ? sidebarSize : 'default'));
        }
    },

    /**
     * Initilizes the menu
     */
    LeftSidebar.prototype.init = function() {
        const self = this;
        this.initMenu();
        this.initLayout();

        // on window resize, make menu flipped automatically
        this.window.on('resize', (e) => {
            e.preventDefault();
            self.initLayout();
        });
    },

    $.LeftSidebar = new LeftSidebar(), $.LeftSidebar.Constructor = LeftSidebar;




    const LayoutThemeApp = function() {
    this.body = $('body'),
    this.window = $(window),
    this.config = {};
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
        const newObj = {};
        if (typeof config === 'object' && config !== null) {
            const originalParam = this.config[param];
            newObj[param] = $.extend(originalParam, config);
        } else {
            newObj[param] = config;
        }
        this._saveConfig(newObj);
    };

    /**
     * Apply the config
     */
    LayoutThemeApp.prototype.applyConfig = function() {
        // getting the saved config if available
        this.config = $.extend({}, {
            width: 'fluid',
            sidebar: {
                size: 'default',
            },
        });

        const sidebarConfig = $.extend({}, this.config.sidebar);

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
            case 'boxed': {
                this.body.attr('data-layout-width', 'boxed');
                // automatically activating condensed
                $.LeftSidebar.changeSize('condensed');
                this._saveConfig({ '{width}': width });
                break;
            }
            default: {
                this.body.attr('data-layout-width', 'fluid');
                // automatically activating provided size
                const bodyConfig = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');
                $.LeftSidebar.changeSize(bodyConfig && bodyConfig.sidebar ? bodyConfig.sidebar.size : 'default');
                this._saveConfig({ '{width}': width });
                break;
            }
        }
    };

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

    $.LayoutThemeApp = new LayoutThemeApp(), $.LayoutThemeApp.Constructor = LayoutThemeApp;

    $.LayoutThemeApp.init();
  }

}
