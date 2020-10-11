import 'bootstrap';
import * as WOW from 'wow.js';
import 'owl.carousel';
import '../styles/app.scss';


/*
    MAIN
 */

;(function($){
    "use strict";

    /*-------------------------------------------------------------------------------
	  Navbar 
	-------------------------------------------------------------------------------*/

	//* Navbar Fixed  
    function navbarFixed(){
        if ( $('.header_area').length ){ 
            $(window).scroll(function() {
                var scroll = $(window).scrollTop();   
                if (scroll){
                    $(".header_area").addClass("navbar_fixed");
                } else {
                    $(".header_area").removeClass("navbar_fixed");
                }
            });
        };
    };
    navbarFixed();
    
    
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
    
    
    
    /*===========Start Service Slider js ===========*/
    function serviceSlider(){
        var service_slider = $(".service_carousel");
        if( service_slider.length ){
            service_slider.owlCarousel({
                loop:true,
                margin:15,
                items: 4,
                autoplay: true,
                smartSpeed: 2000,
                responsiveClass:true,
                nav: true,
                dots: false,
                stagePadding: 100,
                navText: [,'<i class="ti-arrow-left"></i>'],
                responsive:{
                    0:{
                        items:1, 
                        stagePadding: 0,
                    },
                    578:{
                        items:2, 
                        stagePadding: 0,
                    },
                    992:{
                        items:3,
                        stagePadding: 0,
                    }, 
                    1200:{
                        items:3,   
                    }
                },
            })
        }
    }
    serviceSlider();
    /*===========End Service Slider js ===========*/
    
    /*===========Start about_img_slider js ===========*/
    function aboutSlider(){
        var reviews_slider2 = $(".about_img_slider");
        if( reviews_slider2.length ){
            reviews_slider2.owlCarousel({
                loop:true,
                margin:0,
                items: 1,
                nav:false,
                autoplay: false,
                smartSpeed: 2000,
                responsiveClass:true,
            })
        }
    }
    aboutSlider();
    /*=========== End about_img_slider js ===========*/
    
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
    
    
    /*===========Start feedback_slider js ===========*/
    function feedbackSlider(){
        var feedback_slider = $(".feedback_slider");
        if( feedback_slider.length ){
            feedback_slider.owlCarousel({
                loop:true,
                margin:20,
                items: 3,
                nav:false,
                center: true,
                autoplay: false,
                smartSpeed: 2000,
                stagePadding: 0,
                responsiveClass:true,
                responsive:{
                    0:{
                        items:1, 
                    },
                    776:{
                        items:2, 
                    },
                    1199:{
                        items:3,   
                    }
                },
            })
        }
    }
    feedbackSlider();
    
    /*===========Start feedback_slider js ===========*/
    function feedbackSlider_two(){
        var feedback_sliders = $("#fslider_two");
        if( feedback_sliders.length ){
            feedback_sliders.owlCarousel({
                loop:true,
                margin:0,
                items: 2,
                nav:true,
                autoplay: false,
                smartSpeed: 2000,
                stagePadding: 0,
                responsiveClass:true,
                navText: ['<i class="ti-angle-left"></i><i class="ti-angle-right"></i>'],
                responsive:{
                    0:{
                        items:1, 
                    },
                    776:{
                        items:2, 
                    },
                    1199:{
                        items:2,   
                    }
                },
            })
        }
    }
    feedbackSlider_two();
    
    
    function feedbackSlider_three(){
        var feedback_sliders_three = $("#fslider_three");
        if( feedback_sliders_three.length ){
            feedback_sliders_three.owlCarousel({
                loop:true,
                margin:0,
                items: 2,
                nav:true,
                autoplay: false,
                smartSpeed: 2000,
                stagePadding: 0,
                responsiveClass:true,
                navText: ['<i class="ti-angle-left"></i>','<i class="ti-angle-right"></i>'],
                responsive:{
                    0:{
                        items:1, 
                    },
                    776:{
                        items:2, 
                    },
                    1199:{
                        items:3,   
                    }
                },
            })
        }
    }
    feedbackSlider_three();
    
    
    
    
    function erpTestimonial(){
        var erpT = $(".erp_testimonial_info");
        if( erpT.length ){
            erpT.owlCarousel({
                loop:true,
                margin:0,
                items: 2,
                nav:true,
                dots: false,
                autoplay: false,
                smartSpeed: 2000,
                stagePadding: 0,
                responsiveClass:true,
                navText: ['<i class="arrow_left"></i>','<i class="arrow_right"></i>'],
                responsive:{
                    0:{
                        items:1, 
                    },
                    776:{
                        items:2, 
                    },
                    1199:{
                        items:2,   
                    }
                },
            })
        }
    }
    erpTestimonial();
    
    /*=========== End feedback_slider js ===========*/
    
    /*===========Start Service Slider js ===========*/
    function testimonialSlider(){
        var testimonialSlider = $(".testimonial_slider");
        if( testimonialSlider.length ){
            testimonialSlider.owlCarousel({
                loop:true,
                margin:10,
                items: 1,
                autoplay: true,
                smartSpeed: 2500,
                autoplaySpeed: false,
                responsiveClass:true,
                nav: true,
                dot: true,
                stagePadding: 0,
                navContainer: '.agency_testimonial_info',
                navText: ['<i class="ti-angle-left"></i>','<i class="ti-angle-right"></i>'],
            })
        }
    }
    testimonialSlider();
    /*===========End Service Slider js ===========*/
    
    /*===========Start app_testimonial_slider js ===========*/
    function app_testimonialSlider(){
        var app_testimonialSlider = $(".app_testimonial_slider");
        if( app_testimonialSlider.length ){
            app_testimonialSlider.owlCarousel({
                loop:true,
                margin:10,
                items: 1,
                autoplay: true,
                smartSpeed: 2000,
                autoplaySpeed: true,
                responsiveClass:true,
                nav: true,
                dot: true,
                navText: ['<i class="ti-arrow-left"></i>','<i class="ti-arrow-right"></i>'],
                navContainer: '.nav_container'
            })
        }
    }
    app_testimonialSlider();
    /*===========End app_testimonial_slider js ===========*/
    
    
    /*===========Start app_testimonial_slider js ===========*/
    function appScreenshot(){
        var app_screenshotSlider = $(".app_screenshot_slider");
        if( app_screenshotSlider.length ){
            app_screenshotSlider.owlCarousel({
                loop:true,
                margin:10,
                items: 5,
                autoplay: false,
                smartSpeed: 2000,
                responsiveClass:true,
                nav: false,
                dots: true,
                responsive:{
                    0:{
                        items: 1
                    },
                    650:{
                        items:2, 
                    },
                    776:{
                        items:4, 
                    },
                    1199:{
                        items:5,   
                    },
                },
            })
        }
    }
    appScreenshot();
    /*===========End app_testimonial_slider js ===========*/
    
    /*===========Start app_testimonial_slider js ===========*/
    function prslider(){
        var p_Slider = $(".pr_slider");
        if( p_Slider.length ){
            p_Slider.owlCarousel({
                loop:true,
                margin:10,
                items: 1,
                autoplay: true,
                smartSpeed: 1000,
                responsiveClass:true,
                nav: true,
                dots: false,
                navText: ['<i class="ti-angle-left"></i>','<i class="ti-angle-right"></i>'],
                navContainer: '.pr_slider'
            })
        }
    }
    prslider();
    /*===========End app_testimonial_slider js ===========*/
    
    
    
    /*===========Start app_testimonial_slider js ===========*/
    function tslider(){
        var tSlider = $(".testimonial_slider_four");
        if( tSlider.length ){
            tSlider.owlCarousel({
                loop:true,
                margin:10,
                items: 1,
                autoplay: true,
                smartSpeed: 1000,
                responsiveClass:true,
                nav: true,
                dots: false,
                navText: ['<i class="ti-angle-left"></i>','<i class="ti-angle-right"></i>'],
                navContainer: '.testimonial_title'
            })
        }
    }
    tslider();
    
    
    
    function caseStudies(){
        var CSlider = $(".case_studies_slider");
        if( CSlider.length ){
            CSlider.owlCarousel({
                loop:true,
                margin:0,
                items: 3,
                autoplay: true,
                smartSpeed: 1000,
                responsiveClass:true,
                nav: false,
                dots: true,
                responsive:{
                    0:{
                        items: 1
                    },
                    650:{
                        items:2, 
                    },
                    776:{
                        items:3, 
                    },
                    1199:{
                        items:3,   
                    },
                },
            })
        }
    }
    caseStudies();
    
    /*===========Start app_testimonial_slider js ===========*/
    function videoslider(){
        var dSlider = $(".digital_video_slider");
        if( dSlider.length ){
            dSlider.owlCarousel({
                loop:true,
                margin:30,
                items: 1,
                center:true,
                autoplay:true,
                smartSpeed: 1000,
                stagePadding: 200,
                responsiveClass:true,
                nav: false,
                dots: false,
                responsive:{
                    0:{
                        items: 1,
                        stagePadding: 0,
                    },
                    575:{
                        items:1, 
                        stagePadding: 100,
                    },
                    768:{
                        items:1, 
                        stagePadding: 40,
                    },
                    992:{
                        items:1, 
                        stagePadding: 100,
                    },
                    1250:{
                        items:1, 
                        stagePadding: 200,
                    }
                },
            })
        }
    }
    videoslider();
    
    
    
    function Saasslider(){
        var SSlider = $(".saas_banner_area_three");
        if( SSlider.length ){
            SSlider.owlCarousel({
                loop:true,
                margin:30,
                items: 1,
                animateOut: 'fadeOut',
                autoplay:true,
                smartSpeed: 1000,
                responsiveClass:true,
                nav: false,
                dots: true,
            })
        }
    }
    Saasslider();
    
    
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
    
    if($('.selectpickers').length > 0){
        $('.selectpickers').niceSelect();
    }
    
    
    function pr_slider(){
        var pr_image = $('.pr_image')
        if(pr_image.length){
            pr_image.owlCarousel({
                loop: true,
                items: 1,
                autoplay: true,
                dots: false,
                thumbs: true,
                thumbImage: true,
            });
        }
    }
    pr_slider()
    
    $('.ar_top').on('click', function () {
        var getID = $(this).next().attr('id');
        var result = document.getElementById(getID);
        var qty = result.value;
        $('.proceed_to_checkout .update-cart').removeAttr('disabled');
        if( !isNaN( qty ) ) {
            result.value++;
        }else{
            return false;
        }
    });

    $('.ar_down').on('click', function () {
        var getID = $(this).prev().attr('id');
        var result = document.getElementById(getID);
        var qty = result.value;
        $('.proceed_to_checkout .update-cart').removeAttr('disabled');
        if( !isNaN( qty ) && qty > 0 ) {
            result.value--;
        }else {
            return false;
        }
    });
    
    
    /*===========Portfolio isotope js===========*/
    function portfolioMasonry(){
        var portfolio = $("#work-portfolio");
        if( portfolio.length ){
            portfolio.imagesLoaded( function() {
              // images have loaded
                // Activate isotope in container
                portfolio.isotope({
                    itemSelector: ".portfolio_item",
                    layoutMode: 'masonry',
                    filter:"*",
                    animationOptions :{
                        duration:1000
                    },
                    transitionDuration: '0.5s',
                    masonry: {
                       
                    }
                });

                // Add isotope click function
                $("#portfolio_filter div").on('click',function(){
                    $("#portfolio_filter div").removeClass("active");
                    $(this).addClass("active");

                    var selector = $(this).attr("data-filter");
                    portfolio.isotope({
                        filter: selector,
                        animationOptions: {
                          animationDuration: 750,
                          easing: 'linear',
                          queue: false
                      }
                    })
                    return false;
                })
            })
        }
    }
    portfolioMasonry();
    
    function jobFilter(){
        var jobsfilter = $("#tab_filter");
        if( jobsfilter.length ){
            jobsfilter.imagesLoaded( function() {
              // images have loaded
                // Activate isotope in container
                jobsfilter.isotope({
                    itemSelector: ".item",
                });

                // Add isotope click function
                $("#job_filter div").on('click',function(){
                    $("#job_filter div").removeClass("active");
                    $(this).addClass("active");

                    var selector = $(this).attr("data-filter");
                    jobsfilter.isotope({
                        filter: selector,
                        animationOptions: {
                          animationDuration: 750,
                          easing: 'linear',
                          queue: false
                      }
                    })
                    return false;
                })
            })
        }
    }
    jobFilter();
    
    
    
    /*===========Portfolio isotope js===========*/
    function blogMasonry(){
        var blog = $("#blog_masonry")
        if( blog.length ){
            blog.imagesLoaded( function() {
                blog.isotope({
                    layoutMode: 'masonry',
                });
            })
        }
    }
    blogMasonry();

    
    /*--------------- End popup-js--------*/
    function popupGallery(){
        if ($(".img_popup,.image-link").length) {
            $(".img_popup,.image-link").each(function(){
                $(".img_popup,.image-link").magnificPopup({
                    type: 'image',
                    tLoading: 'Loading image #%curr%...',
                    removalDelay: 300,
                    mainClass:  'mfp-with-zoom mfp-img-mobile',
                    gallery: {
                        enabled: true,
                        navigateByImgClick: true,
                        preload: [0,1] // Will preload 0 - before current, and 1 after the current image,
                    }
                });
            })
        }
        if($('.popup-youtube').length){
            $('.popup-youtube').magnificPopup({
                disableOn: 700,
                type: 'iframe',
                removalDelay: 160,
                preloader: false,
                fixedContentPos: false,
                mainClass:  'mfp-with-zoom mfp-img-mobile',
            });
            $('.popup-youtube').magnificPopup({
                disableOn: 700,
                type: 'iframe',
                mainClass: 'mfp-fade',
                removalDelay: 160,
                preloader: false,
                fixedContentPos: false
            });
        }
    }
    popupGallery();
    
    if ( $('#mapBox').length ){
        var $lat = $('#mapBox').data('lat');
        var $lon = $('#mapBox').data('lon');
        var $zoom = $('#mapBox').data('zoom');
        var $marker = $('#mapBox').data('marker');
        var $info = $('#mapBox').data('info');
        var $markerLat = $('#mapBox').data('mlat');
        var $markerLon = $('#mapBox').data('mlon');
        var map = new GMaps({
        el: '#mapBox',
        lat: $lat,
        lng: $lon,
        scrollwheel: false,
        scaleControl: true,
        streetViewControl: false,
        panControl: true,
        disableDoubleClickZoom: true,
        mapTypeControl: false,
        zoom: $zoom,
        });
        map.addMarker({
            lat: $markerLat,
            lng: $markerLon,
            icon: $marker,    
            infoWindow: {
              content: $info
            }
        })
    }
    
    /* ===== Parallax Effect===== */
	function parallaxEffect() {
        if($('.parallax-effect').length){
            $('.parallax-effect').parallax();
        };
	}
    parallaxEffect();
    
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
    
    // Pricing Filter
    if($("#slider-range").length){
        $( "#slider-range" ).slider({
            range: true,
            min: 5,
            max: 150,
            values: [ 5, 100 ],
            slide: function( event, ui ) {
                $( "#amount" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
            }
        });
        $( "#amount" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) +
        " - $" + $( "#slider-range" ).slider( "values", 1 ) );
    }
    
    $('.search-btn').on('click', function(){
        $('body').addClass('open');
        setTimeout(function () {
            $('.search-input').focus();
        }, 500);
        return false;
    });
	$('.close_icon').on('click', function(){
		$('body').removeClass('open');
		return false;
	});
    
    if($('.develor_tab li a').length > 0){
        $(".develor_tab li a").click(function () {
            var tab_id = $(this).attr("data-tab");
            $(".tab_img").removeClass("active");
            $("#" + tab_id).addClass("active");
        });
    }
    
    
    $('.alert_close').on('click', function(e){
		$(this).parent().hide();
	});
     
    
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
    
   
    function hamberger_menu(){
        if ( $('.burger_menu').length ){
            $('.burger_menu').on('click', function(){
                $(this).toggleClass('open')
                $('body').removeClass('menu-is-closed').addClass('menu-is-opened');
            });
            $('.close, .click-capture').on('click', function() {
                $('body').removeClass('menu-is-opened').addClass('menu-is-closed');
            });
        }
    }
    hamberger_menu();

})(jQuery)


/* 
    THEME
*/

(function($) {
    "use strict";
    
    
    $(document).on ('ready', function (){
        
        // -------------------- Navigation Scroll
        $(window).on('scroll', function (){   
          var sticky = $('.theme-main-menu'),
          scroll = $(window).scrollTop();
          if (scroll >= 100) sticky.addClass('fixed');
          else sticky.removeClass('fixed');

        });



        // ------------------------- Add OnepageNav
        if($('body').length){
          // Smooth scrolling using jQuery easing
          $('a.js-scroll-trigger[href*="#"]:not([href="#"])').on('click',function() {
            if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
              var target = $(this.hash);
              target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
              if (target.length) {
                $('html, body').animate({
                  scrollTop: (target.offset().top - 54)
                }, 1000, "easeInOutExpo");
                return false;
              }
            }
          });

          // Closes responsive menu when a scroll trigger link is clicked
          $('.js-scroll-trigger').on('click',function() {
            $('.navbar-collapse').collapse('hide');
          });

          // Activate scrollspy to add active class to navbar items on scroll
          $('body').scrollspy({
            target: '#mega-menu-holder',
            offset: 100
          });
        }

        // ------------------------------ Video Blog 
          var embed = $ (".embed-video");
            if (embed.length) {
              embed.fitVids();
            }


        // ------------------------ Market Rate Slider
        var mSlider = $ ("#market-rate");
        if(mSlider.length) {
            mSlider.owlCarousel({
              loop:true,
              nav:false,
              dots:false,
              margin:30,
              autoplay:true,
              autoplayTimeout:1000,
              smartSpeed:1200,
              autoplayHoverPause:true,
              lazyLoad:true,
              responsive:{
                    0:{
                        items:1
                    },
                    500:{
                        items:2
                    },
                    992:{
                        items:3
                    },
                    1300:{
                        items:4,
                    }
                },
          })
        }



        // ------------------------------- Testimonial Slider
        var tSlider = $ (".testimonial-slider");
        if(tSlider.length) {
            tSlider.owlCarousel({
              loop:true,
              nav:false,
              dots:true,
              autoplay:true,
              margin:30,
              autoplayTimeout:4000,
              smartSpeed:1200,
              autoplayHoverPause:true,
              lazyLoad:true,
              responsive:{
                    0:{
                        items:1
                    },
                    500:{
                        items:1
                    },
                    992:{
                        items:2
                    }
                },
          })
        }


        // ------------------------------- Testimonial Slider
        var tSlider = $ (".testimonial-slider-two");
        if(tSlider.length) {
            tSlider.owlCarousel({
              loop:true,
              nav:false,
              dots:true,
              autoplay:true,
              margin:30,
              autoplayTimeout:4000,
              smartSpeed:1200,
              autoplayHoverPause:true,
              lazyLoad:true,
              responsive:{
                    0:{
                        items:1
                    },
                    992:{
                        items:2
                    },
                    1530:{
                        items:3
                    }
                },
          })
        }


        // ------------------------------- Partner Slider
        var pSlider = $ (".partner-slider");
        if(pSlider.length) {
            pSlider.owlCarousel({
              loop:true,
              nav:false,
              dots:false,
              autoplay:true,
              autoplayTimeout:4000,
              smartSpeed:1200,
              autoplayHoverPause:true,
              lazyLoad:true,
              responsive:{
                    0:{
                        items:2
                    },
                    768:{
                        items:3
                    },
                    992:{
                        items:4
                    },
                    1200:{
                        items:5
                    }
                },
          })
        }


        // ------------------------------- Work Progress Slider
        var pSlider = $ (".progress-slider");
        if(pSlider.length) {
            pSlider.owlCarousel({
              loop:true,
              nav:false,
              dots:false,
              autoplay:true,
              margin:30,
              autoplayTimeout:4000,
              smartSpeed:1200,
              autoplayHoverPause:true,
              lazyLoad:true,
              responsive:{
                    0:{
                        items:1
                    },
                    576:{
                        items:2
                    },
                    1550:{
                        items:3
                    }
                },
          })
        }


        // ------------------------- Road Map
        var timeline = $('#timeline-frame');
        if(timeline.length) {
            
            var events = [
            {
              date: 'Apr 10, 2018',
              content: '<p>Development <br> Started</p>'
            },
            {
              date: 'Jun 14, 2018',
              content: '<p>Pre-ICO Opens</p>'
            },
            {
              date: 'Jul 24, 2018',
              content: '<p>Private Token <br> Round</p>'
            },
            {
              date: 'Sep 14, 2018',
              content: '<p>Pre-ICO <br> Closed</p>'
            },
            {
                date: 'Dec 24, 2018',
                content: '<p>Decentralized <br> Platform Launch</p>'
            },
            {
                date: 'Jan 15, 2019',
                content: '<p>App Integration <br> Process</p>'
            },
            {
                date: 'Q4 - 2019',
                content: '<p>Development Started</p>'
            },
            {
                date: 'Q1 - 2020',
                content: '<p>Development Started</p>'
            },
            {
                date: 'Q2 - 2020',
                content: '<p>Development Started</p>'
            },
            {
                date: 'Q3 - 2020',
                content: '<p>Development Started</p>'
            },
            {
                date: 'Q4 - 2020',
                content: '<p>Development Started</p>'
            },
            {
              date: 'Q1 - 2021',
              content: '<p>Development Started</p>'
            },
            {
              date: 'Q2 - 2021',
              content: '<p>Development Started</p>'
            },
            {
              date: 'Q3 - 2021',
              content: '<p>Development Started</p>'
            },
            {
              date: 'Q4 - 2021',
              content: '<p>Development Started</p>'
            }
          ];

            timeline.roadmap(events, {
                eventsPerSlide: 6,
                slide: 1,
                prevArrow: '<i class="fa fa-angle-left" aria-hidden="true"></i>',
                nextArrow: '<i class="fa fa-angle-right" aria-hidden="true"></i>'
            });
        }




        
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

        // ------------------------------------- Fancybox
        var fancy = $ (".fancybox");
        if(fancy.length) {
          fancy.fancybox({
            arrows: true,
            animationEffect: "zoom-in-out",
            transitionEffect: "zoom-in-out",
          });
        }


         // ------------------------------ Language Switcher
         var plang = $('#polyglotLanguageSwitcher');
         if (plang.length) {
              plang.polyglotLanguageSwitcher({
                effect: 'fade',
                        testMode: true,
                        onChange: function(evt){
                            alert("The selected language is: "+evt.selectedItem);
                        }
              });
          };







          // ---------------------------------- Validation Alert
          var closeButton = $ (".closeAlert");
            if(closeButton.length) {
                closeButton.on('click', function(){
                  $(".alert-wrapper").fadeOut();
                });
                closeButton.on('click', function(){
                  $(".alert-wrapper").fadeOut();
                })
            };


            // ------------------------------- Related Blog Slider
            var tSlider = $ (".related-blog-slider");
            if(tSlider.length) {
                tSlider.owlCarousel({
                  loop:true,
                  nav:false,
                  dots:false,
                  autoplay:true,
                  autoplayTimeout:4000,
                  autoplayHoverPause:true,
                  smartSpeed:1100,
                  lazyLoad:true,
                  responsive:{
                        0:{
                            items:1
                        },
                        500:{
                            items:2
                        },
                        992:{
                            items:3
                        }
                    },
              })
            };


            // -------------------------------- Accordion Panel
            if ($('.theme-accordion > .panel').length) {
              $('.theme-accordion > .panel').on('show.bs.collapse', function (e) {
                    var heading = $(this).find('.panel-heading');
                    heading.addClass("active-panel");
                    
              });
              $('.theme-accordion > .panel').on('hidden.bs.collapse', function (e) {
                  var heading = $(this).find('.panel-heading');
                    heading.removeClass("active-panel");
                    //setProgressBar(heading.get(0).id);
              });
              $('.panel-heading a').on('click',function(e){
                  if($(this).parents('.panel').children('.panel-collapse').hasClass('in')){
                      e.stopPropagation();
                  }
              });
            };


        
    });

    
    $(window).on ('load', function (){ // makes sure the whole site is loaded

        // -------------------- Site Preloader
        $('#loader').fadeOut(); // will first fade out the loading animation
        $('#loader-wrapper').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
        $('body').delay(350).css({'overflow':'visible'});


        // ------------------------------- AOS Animation 
        AOS.init({
          duration: 1000,
          mirror: true
        });



    })
    
})(jQuery)