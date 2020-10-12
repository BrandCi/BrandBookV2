import 'bootstrap';
import * as WOW from 'wow.js';
import 'owl.carousel';
import '../styles/app.scss';


/*
    MAIN
 */

(function($){
    "use strict";

    /*-------------------------------------------------------------------------------
	  Navbar
	-------------------------------------------------------------------------------*/


    function offcanvasActivator(){
        if ( $('.bar_menu').length ){
            $('.bar_menu').on('click', function(){
                $('#menu').toggleClass('show-menu')
            });
            $('.close_icon').on('click',function(){
                $('#menu').removeClass('show-menu')
            })
        }
    }
    offcanvasActivator();

    $('.offcanfas_menu .dropdown').on('show.bs.dropdown', function(e){
		$(this).find('.dropdown-menu').first().stop(true, true).slideDown(400);
	});
	$('.offcanfas_menu .dropdown').on('hide.bs.dropdown', function(e){
		$(this).find('.dropdown-menu').first().stop(true, true).slideUp(500);
	});

    $(window).on("load",function(){
        if($('.mega_menu_two .scroll').length){
            $(".mega_menu_two .scroll").mCustomScrollbar({
                mouseWheelPixels: 50,
                scrollInertia: 0,
            });
        }
    });

    /*--------- WOW js-----------*/
    function wowAnimation(){
        new WOW({
            offset: 100,
            mobile: true
        }).init()
    }
    wowAnimation()



    function posSlider(){
        var posS = $(".pos_slider");
        if( posS.length ){
            posS.owlCarousel({
                loop:true,
                margin:0,
                items: 1,
                dots: false,
                nav:false,
                autoplay: true,
                slideSpeed: 300,
                mouseDrag: false,
                animateIn: 'fadeIn',
                animateOut: 'fadeOut',
                responsiveClass:true,
            })
        }
    }
    posSlider();



    function tab_hover(){
        var tab = $(".price_tab");
        if($(window).width() > 450){
            if($(tab).length>0 ){
                tab.append('<li class="hover_bg"></li>');
                if($('.price_tab li a').hasClass('active_hover')){
                    var pLeft = $('.price_tab li a.active_hover').position().left,
                        pWidth = $('.price_tab li a.active_hover').css('width');
                    $('.hover_bg').css({
                        left : pLeft,
                        width: pWidth
                    })
                }
                $('.price_tab li a').on('click', function() {
                    $('.price_tab li a').removeClass('active_hover');
                    $(this).addClass('active_hover');
                    var pLeft = $('.price_tab li a.active_hover').position().left,
                        pWidth = $('.price_tab li a.active_hover').css('width');
                    $('.hover_bg').css({
                        left : pLeft,
                        width: pWidth
                    })
                })
            }
        }

    }
    tab_hover();


    /* Counter Js */
    function counterUp(){
        if ( $('.counter').length ){
            $('.counter').counterUp({
                delay: 1,
                time: 500
            });
        };
    };

    counterUp();

    /*===== progress-bar =====*/
    function circle_progress(){
        if( $('.circle').length ){
            $(".circle").each(function() {
                $(".circle").appear(function() {
                    $('.circle').circleProgress({
                        startAngle:-14.1,
                        size: 200,
                        duration: 9000,
                        easing: "circleProgressEase",
                        emptyFill: '#f1f1fa ',
                        lineCap: 'round',
                        thickness:10,
                    })
                }, {
                    triggerOnce: true,
                    offset: 'bottom-in-view'
                })
            })
        }
    }
    circle_progress();

    /*------------- preloader js --------------*/


    function loader(){
        $(window).on('load', function() {
            $('#ctn-preloader').addClass('loaded');
            // Una vez haya terminado el preloader aparezca el scroll

            if ($('#ctn-preloader').hasClass('loaded')) {
                // Es para que una vez que se haya ido el preloader se elimine toda la seccion preloader
                $('#preloader').delay(900).queue(function () {
                    $(this).remove();
                });
            }
        });
    }
    loader();

    if($('[data-toggle="tooltip"]').length){
        $('[data-toggle="tooltip"]').tooltip()
    }


     function active_dropdown() {
        if ($(window).width() < 992) {
            $('.menu li.submenu > a').on('click',function(event){
                event.preventDefault()
                $(this).parent().find('ul').first().toggle(700);
                $(this).parent().siblings().find('ul').hide(700);
            });
        }
    }
    active_dropdown();


})(jQuery)


/*
    THEME
*/

(function($) {
    "use strict";

    $(document).on ('ready', function (){

        // -------------------- Remove Placeholder When Focus Or Click
        $("input,textarea").each( function(){
            $(this).data('holder',$(this).attr('placeholder'));
            $(this).on('focusin', function() {
                $(this).attr('placeholder','');
            });
            $(this).on('focusout', function() {
                $(this).attr('placeholder',$(this).data('holder'));
            });
        });

        // -------------------- From Bottom to Top Button
            //Check to see if the window is top if not then display button
        $(window).on('scroll', function (){
          if ($(this).scrollTop() > 200) {
            $('.scroll-top').fadeIn();
          } else {
            $('.scroll-top').fadeOut();
          }
        });
            //Click event to scroll to top
        $('.scroll-top').on('click', function() {
          $('html, body').animate({scrollTop : 0},1500);
          return false;
        });


        // ----------------------------- Counter Function
        var timer = $('.timer');
        if(timer.length) {
            timer.appear(function () {
              timer.countTo();
          });
        }

    });


    $(window).on ('load', function (){ // makes sure the whole site is loaded

        // -------------------- Site Preloader
        $('#loader').fadeOut(); // will first fade out the loading animation
        $('#loader-wrapper').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
        $('body').delay(350).css({'overflow':'visible'});

    })

})(jQuery)