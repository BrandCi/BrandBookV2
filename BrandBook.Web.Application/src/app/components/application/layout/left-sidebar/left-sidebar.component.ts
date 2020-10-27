import { Component, OnInit } from '@angular/core';

declare var $: any;


@Component({
  selector: 'app-layout-left-sidebar',
  templateUrl: './left-sidebar.component.html',
  styleUrls: ['./left-sidebar.component.scss']
})
export class LayoutLeftSidebarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

        // handling two columns menu if present
        const twoColSideNav = $('#two-col-sidenav-main');
        if (twoColSideNav.length) {
            const twoColSideNavItems = $('#two-col-sidenav-main .nav-link');
            const sideSubMenus = $('.twocolumn-menu-item');

            const nav = $('.twocolumn-menu-item .nav-second-level');
            const navCollapse = $('#two-col-menu li .collapse');

            // open one menu at a time only
            navCollapse.on({
                'show.bs.collapse'() {
                    const nearestNav = $(this).closest(nav).closest(nav).find(navCollapse);
                    if (nearestNav.length)
                    {
                        nearestNav.not($(this)).collapse('hide');
                    }
                    else
                    {
                        navCollapse.not($(this)).collapse('hide');
                    }
                }
            });

            twoColSideNavItems.on('click', function(e) {
                const target = $($(this).attr('href'));

                if (target.length) {
                    e.preventDefault();

                    twoColSideNavItems.removeClass('active');
                    $(this).addClass('active');

                    sideSubMenus.removeClass('d-block');
                    target.addClass('d-block');

                    // showing full sidebar if menu item is clicked
                    // $.LayoutThemeApp.leftSidebar.changeSize('default');
                    return false;
                }
                return true;
            });

            // activate menu with no child
            const pageUrl = window.location.href.split(/[?#]/)[0];
            twoColSideNavItems.each(function() {
                if (this.href === pageUrl) {
                    $(this).addClass('active');
                }
            });


            // activate the menu in left side bar (Two column) based on url
            $('#two-col-menu a').each(function() {
                if (this.href === pageUrl) {
                    $(this).addClass('active');
                    $(this).parent().addClass('menuitem-active');
                    $(this).parent().parent().parent().addClass('show');
                    $(this).parent().parent().parent().parent().addClass('menuitem-active'); // add active to li of the current link

                    const firstLevelParent = $(this).parent().parent().parent().parent().parent().parent();
                    if (firstLevelParent.attr('id') !== 'sidebar-menu') {
                        firstLevelParent.addClass('show');
                    }

                    $(this).parent().parent().parent().parent().parent().parent().parent().addClass('menuitem-active');

                    const secondLevelParent = $(this).parent().parent().parent()
                                                    .parent().parent().parent()
                                                    .parent().parent().parent();
                    if (secondLevelParent.attr('id') !== 'wrapper') {
                        secondLevelParent.addClass('show');
                    }

                    const upperLevelParent = $(this).parent().parent().parent()
                                                    .parent().parent().parent()
                                                    .parent().parent().parent()
                                                    .parent();
                    if (!upperLevelParent.is('body')) {
                        upperLevelParent.addClass('menuitem-active');
                    }

                    // opening menu
                    let matchingItem = null;
                    const targetEl = '#' + $(this).parents('.twocolumn-menu-item').attr('id');
                    $('#two-col-sidenav-main .nav-link').each(function() {
                        if ($(this).attr('href') === targetEl) {
                            matchingItem = $(this);
                        }
                    });
                    if (matchingItem) {
                        matchingItem.trigger('click');
                    }
                }
            });
        }


  }

}
