(function($) {
    "use strict";

    $(function() {
        scrollUp();
    });

    $(window).on("scroll", function() {
        showScrollUp();
    });


    gsap.registerPlugin(ScrollTrigger, ScrollSmoother, ScrollToPlugin);
    gsap.config({
        nullTargetWarn: false,
    });

    const smoother = ScrollSmoother.create({
        smooth: true,
        effects: true,
        smoothTouch: true,
        normalizeScroll: false,
    });

    smoother.effects(".image-cont img", { speed: 'auto' })
    smoother.effects(".image-cont-two img", { speed: "auto" })
    smoother.effects(".image-cont-three img", { speed: "auto" })
    smoother.effects(".image-cont-four img", { speed: "auto" })
    smoother.effects(".image-cont-five img", { speed: "auto" })
    smoother.effects(".image-cont-six img", { speed: "auto" })
    smoother.effects(".image-cont-seven img", { speed: "auto" })

    // Scroll Up
    function scrollUp() {
        $(".cs_scrollup").on("click", function(e) {
            e.preventDefault();
            $("html,body").animate({
                    scrollTop: 0,
                },
                0
            );
        });
    }


    $(".banner-scroll-bottom").on("click", function(e) {
        let device_width = $(window).innerWidth();
        if (device_width >= 992) {
            e.preventDefault();
            $("html,body").animate({
                    scrollTop: 1000,
                },
                0
            );
        };
    });

    // For Scroll Up
    function showScrollUp() {
        let scroll = $(window).scrollTop();
        if (scroll >= 350) {
            $(".cs_scrollup").addClass("cs_scrollup_show");
        } else {
            $(".cs_scrollup").removeClass("cs_scrollup_show");
        }
    }

    //gsap
    let arrImgList = [".blog-details-img-1", ".blog-details-img-2", ".blog-details-img-3", ".blog-details-img-4", ".blog-details-img-5", ".blog-details-img-6", ".blog-details-img-7", ".blog-details-img-8"];
    arrImgList.forEach((data) => {
        let t4 = gsap.timeline({
            scrollTrigger: {
                trigger: data,
                start: "top 90%",
                end: "bottom 10%",
                markers: false,
                scrub: false,
                toggleActions: "play none none none",
            },
        });
        t4.fromTo(data, {
            scale: 1,
            opacity: 0,
            duration: 0.0,
            y: "-150%"
        }, {
            scale: 1,
            delay: 0.2,
            opacity: 1,
            duration: 0.1,
            ease: 'elastic.in(1.5, 0.4)',
            y: "-0%"
        });
    })

    let HomeDigital = gsap.timeline({});
    let mark = document.querySelector(".anim-text-hero");
    let cs_subtext = document.querySelector(".anim-subtext");

    let split_creatives = new SplitText(mark, {
        type: "chars,words",
    });
    let splitsubtext = new SplitText(cs_subtext, {
        type: "chars words",
    });

    HomeDigital.from(split_creatives.chars, {
        duration: 0.5,
        x: 100,
        delay: 0.8,
        autoAlpha: 0,
        stagger: 0.1,
    });

    HomeDigital.from(
        splitsubtext.words, {
            duration: 2,
            x: 50,
            autoAlpha: 0,
            stagger: 0.05,
        },
        "-=1"
    );




    let textTextWrittings = gsap.utils.toArray(".anim-heading-title");
    textTextWrittings.forEach((splitTextLine) => {
        const tl = gsap.timeline({
            scrollTrigger: {
                trigger: splitTextLine,
                start: "top 90%",
                end: "bottom 10%",
                scrub: false,
                markers: false,
                toggleActions: "play none none none"
            },
        });
        let textCharsWritting = new SplitText(splitTextLine, {
            type: "chars words",
        });
        tl.from(textCharsWritting.chars, {
            delay: 0.5,
            duration: 0.3,
            y: 50,
            rotationX: 100,
            autoAlpha: 0,
            stagger: 0.05,
            ease: Quint.easeOut
        });

    });

    const count_number = gsap.utils.toArray(".amin-count-funcat");
    const count_id = gsap.utils.toArray(".amin-auto-count");
    if (count_number) {
        count_id.forEach((num) => {
            gsap.from(num, {
                scrollTrigger: {
                    trigger: num,
                    start: "top center+=200",
                    markers: false,
                },
                delay: 1.2,
                innerText: 0,
                duration: 3,
                snap: {
                    innerText: 1,
                },
            });
        });
        gsap.from(count_number, {
            scrollTrigger: {
                trigger: count_number,
                start: "top center+=200",
                markers: false,
            },
            duration: 2,
            scale: 0.5,
            opacity: 0,
            delay: 0.5,
            stagger: 0.2,
            ease: "elastic",
            force3D: true,
        });
    }

    const count_single = gsap.utils.toArray(".amin-auto-count-single");
    count_single.forEach((num) => {
        gsap.from(num, {
            scrollTrigger: {
                trigger: num,
                start: "top 90%",
                end: "bottom 40%",
                markers: false,
            },
            delay: 0.5,
            innerText: 0,
            duration: 2,
            snap: {
                innerText: 1,
            },
        });
    });


    // services one carousel
    $(".service-one-card-container .owl-carousel").owlCarousel({
        loop: true,
        margin: 30,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        dots: false,
        stagePadding: 15,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1200: {
                items: 3,
            },
        },
    });
    // blogs one carousel
    $(".blogs-one-cards-container .owl-carousel").owlCarousel({
        loop: true,
        margin: 20,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        dots: false,
        stagePadding: 5,
        responsive: {
            0: {
                items: 1,
            },
            1000: {
                items: 2,
            },
            1200: {
                items: 3,
            },
        },
    });
    // blogs two carousel
    $(".blogs-two-cards-container .owl-carousel").owlCarousel({
        loop: true,
        margin: 23,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        dots: false,
        responsive: {
            0: {
                items: 1,
            },
            576: {
                items: 2,
            },
            1200: {
                items: 3,
            },
        },
    });
    // Service two carousel
    $(".service-two-cards-container .owl-carousel").owlCarousel({
        loop: true,
        margin: 20,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        dots: false,
        stagePadding: 120,
        responsive: {
            0: {
                items: 1,
                stagePadding: 0,
            },
            580: {
                items: 2,
                stagePadding: 0,
            },
            990: {
                items: 1,
                stagePadding: 120,
            },
            1300: {
                items: 2,
            },
        },
    });
    // service three carousel
    $(".service-three-cards-container .owl-carousel").owlCarousel({
        loop: true,
        margin: 50,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        dots: false,
        responsive: {
            0: {
                items: 1,
            },
            1000: {
                items: 2,
            },
            1200: {
                items: 3,
            },
        },
    });
    // Testimonial one carousel
    $(".testimonial-one-slider-wrapper .owl-carousel").owlCarousel({
        loop: true,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        dots: false,
        responsive: {
            0: {
                items: 1,
            },
        },
    });
    // banner three carousel
    $(".banner-three-carousel .owl-carousel").owlCarousel({
        loop: true,
        nav: true,
        center: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        slideTransition: "linear",
        dots: false,
        navContainer: ".owl-nav-three",
        stagePadding: 0,
        responsive: {
            0: {
                items: 1,
            },
        },
    });
    // Title carousel
    $(".title-carousel .owl-carousel").owlCarousel({
        loop: true,
        margin: 20,
        autoplay: true,
        slideTransition: "linear",
        autoplaySpeed: 7000,
        autoplayHoverPause: false,
        dots: false,
        responsive: {
            0: {
                items: 1,
            },
            578: {
                items: 1,
            }
        },
    });
    // Testimonial one carousel
    $(".team-one-card-carousel .owl-carousel").owlCarousel({
        items: 4,
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 2,
            },
            992: {
                items: 3,
            },
            1200: {
                items: 4,
            },
        },
        loop: true,
        margin: 30,
        autoplay: true,
        slideTransition: "linear",
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        stagePadding: 8,
        dots: false,
    });
    // Video modal
    $(".js-video-button").modalVideo();
    // initialize AOS
    AOS.init();
    // Preloader
    $(window).preloader({
        delay: 1000,
    });
    // animated heading
    $(function() {
        $(".animate-heading").animatedHeadline({
            animationType: "clip",
        });
    });
    // cursor
    $(".appear-text").viewportChecker({
        classToAdd: "visible",
        offset: 100,
        callbackFunction: function(elem, action) {
            if (action === "add") {
                elem.textyle({
                    duration: 100,
                    easing: "swing",
                    callback: function() {
                        $(this).css({
                            color: "#101010",
                            transition: ".1s",
                            // more css here
                        });
                    },
                });
            }
        },
    });

    // expandable menu
    $(function() {
        var Accordion = function(el, multiple) {
            this.el = el || {};
            this.multiple = multiple || false;

            var dropdownlink = this.el.find(".dropdownlink");
            dropdownlink.on(
                "click", {
                    el: this.el,
                    multiple: this.multiple,
                },
                this.dropdown
            );
        };

        Accordion.prototype.dropdown = function(e) {
            var $el = e.data.el,
                $this = $(this),
                $next = $this.next();

            $next.slideToggle();
            $this.parent().toggleClass("open");

            if (!e.data.multiple) {
                $el
                    .find(".submenuItems")
                    .not($next)
                    .slideUp()
                    .parent()
                    .removeClass("open");
            }
        };

        //Set Object
        var accordion = new Accordion($(".accordion-menu"), false);
    });
    /* ======== Preloader ======== */
    $(window).on("load", function() {
        var preloaderDelay = 500,
            preloaderFadeOutTime = 300;

        function hidePreloader() {
            var loadingAnimation = $(".placeholder"),
                preloader = $(".placeholder-cs");
            loadingAnimation.fadeOut();
            preloader.delay(preloaderDelay).fadeOut(preloaderFadeOutTime);
        }

        hidePreloader();
    });
})(jQuery);