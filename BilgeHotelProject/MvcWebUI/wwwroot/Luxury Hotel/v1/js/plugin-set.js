jQuery( document ).ready( function() {
								   			   
        // reservation date
        jQuery( '.fox2' )
            .focusin( function() {
                jQuery.dateSelect.show( {
                    element: 'input[name="date2"]'
                } );
            } );
        jQuery( '.fox1' )
            .focusin( function() {
                jQuery.dateSelect.show( {
                    element: 'input[name="date1"]'
                } );
            } );
        // slidertext var
        var slidtext = jQuery( '#slidertext' );
        // slideshow text home
        jQuery( function() {
            var slideBegin = 3000,
                transSpeed = 500,
                simple_slideshow = slidtext,
                listItems = simple_slideshow.children( '.main-text' ),
                listLen = listItems.length,
                i = 0,
                changeList = function() {
                    listItems.eq( i )
                        .fadeOut( transSpeed, function() {
                            i += 1, i === listLen && ( i = 0 ), listItems.eq( i )
                                .fadeIn( transSpeed )
                        } )
                };
            listItems.not( ':first' )
                .hide(), setInterval( changeList, slideBegin );
        } );
        // Magnific Popup img
        jQuery( '.big-img' )
            .magnificPopup( {
                delegate: 'a',
                type: 'image',
                closeOnContentClick: false,
                closeBtnInside: false,
                mainClass: 'mfp-with-zoom mfp-img-mobile',
                image: {
                    verticalFit: true,
                },
                gallery: {
                    enabled: false
                },
                zoom: {
                    enabled: true,
                    duration: 300, // don't foget to change the duration also in CSS
                    opener: function( element ) {
                        return element.find( 'img' );
                    }
                }
            } );
        // Magnific Popup form
        jQuery( '.popup-form' )
            .magnificPopup( {
                type: 'inline',
                closeOnBgClick: false,
                preloader: false,
                // It looks not nice, so we disable it:
                callbacks: {
                    beforeOpen: function() {
                        jQuery( 'body' )
                            .css( 'overflow', 'hidden' );
                        jQuery( "#date1, #date2, #personbook, #namebook, #emailbook, #phonebook, #messagebook " )
                            .val( "" );
                        jQuery( "form#subscribe .subscribeerror" )
                            .remove();
                        if ( jQuery( window )
                            .width() < 700 ) {
                            this.st.focus = false;
                        } else {
                            this.st.focus = '#subscribeemail';
                        }
                    },
                    beforeClose: function() {
                        jQuery( 'body' )
                            .css( 'overflow', 'auto' );
                        jQuery.dateSelect.hide( {
                            element: 'input[name="date2"]'
                        } );
                        jQuery.dateSelect.hide( {
                            element: 'input[name="date1"]'
                        } );
                    }
                }
            } );
        // step work
        var jQuerycontainerstep = jQuery( '#step-text' );
        jQuerycontainerstep.isotope( {
            itemSelector: '.cont',
            filter: '.planing',
            hiddenStyle: {
                opacity: 0
            },
            visibleStyle: {
                opacity: 1
            }
        } );
        jQuery( '.filt-step' )
            .on( 'click', function( e ) {
                e.preventDefault();
                var jQuerythis = jQuery( this );
                if ( jQuerythis.hasClass( 'active' ) ) {
                    return false;
                }
                var jQueryoptionSet = jQuerythis.parents();
                jQueryoptionSet.find( '.active' )
                    .removeClass( 'active' );
                jQuerythis.addClass( 'active' );
                var selector = jQuery( this )
                    .attr( 'data-filter' );
                jQuerycontainerstep.isotope( {
                    filter: selector,
                } );
                return false;
            } );
        // service
        var jQuerycontainer = jQuery( '#services' );
        jQuerycontainer.isotope( {
            itemSelector: '.service',
            filter: '.passion',
            hiddenStyle: {
                opacity: 0
            },
            visibleStyle: {
                opacity: 1
            }
        } );
        jQuery( '.filt-serv' )
            .on( 'click', function( e ) {
                e.preventDefault();
                var jQuerythis = jQuery( this );
                if ( jQuerythis.hasClass( 'selected' ) ) {
                    return false;
                }
                var jQueryoptionSet = jQuerythis.parents();
                jQueryoptionSet.find( '.selected' )
                    .removeClass( 'selected' );
                jQuerythis.addClass( 'selected' );
                var selector = jQuery( this )
                    .attr( 'data-filter' );
                jQuerycontainer.isotope( {
                    filter: selector,
                } );
                return false;
            } );
        // projects
        var jQuerycontainerpro = jQuery( '#projects-wrap' );
        jQuerycontainerpro.isotope( {
            itemSelector: '.item',
            filter: '*'
        } );
        jQuery( '.filt-projects' )
            .on( 'click', function( e ) {
                e.preventDefault();
                var jQuerythis = jQuery( this );
                if ( jQuerythis.hasClass( 'selected' ) ) {
                    return false;
                }
                var jQueryoptionSetpro = jQuerythis.parents();
                jQueryoptionSetpro.find( '.selected' )
                    .removeClass( 'selected' );
                jQuerythis.addClass( 'selected' );
                var selector = jQuery( this )
                    .attr( 'data-project' );
                jQuerycontainerpro.isotope( {
                    filter: selector,
                } );
                return false;
            } );
        // owlCarousel projects
        var owl = jQuery( "#owl-project" );
        owl.owlCarousel( {
            navigation: true,
            autoPlay: false,
            stopOnHover: true,
            pagination: false,
            itemsDesktop: [ 1600, 4 ],
            itemsDesktopSmall: [ 1024, 4 ],
            itemsTablet: [ 800, 2 ],
            navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ],
        } );
        // owlCarousel team
        var owl = jQuery( "#owl-team" );
        owl.owlCarousel( {
            items: 3,
            pagination: false,
            itemsDesktop: [ 1000, 2 ],
            itemsDesktopSmall: [ 900, 2 ],
            itemsTablet: [ 600, 1 ],
            itemsMobile: false,
            autoPlay: false,
            navigation: true,
            navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ]
        } );
        // owlCarousel testimonial
        var owl = jQuery( "#owl-testimonial" );
        owl.owlCarousel( {
            slideSpeed: 1000,
            items: 1,
            navigation: true,
            itemsDesktop: [ 1000, 1 ],
            itemsDesktopSmall: [ 900, 1 ],
            itemsTablet: [ 600, 1 ],
            itemsMobile: false,
            pagination: false,
            autoPlay: 3000,
            stopOnHover: true,
            navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ],
        } );
        // owlCarousel recent post
        var owl = jQuery( "#owl-post" );
        owl.owlCarousel( {
            items: 3,
            pagination: false,
            itemsDesktop: [ 1000, 2 ],
            itemsDesktopSmall: [ 900, 2 ],
            itemsTablet: [ 600, 1 ],
            itemsMobile: false,
            autoPlay: false,
            navigation: true,
            navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ]
        } );
        // owlCarousel brand
        var owl = jQuery( "#owl-brand" );
        owl.owlCarousel( {
            items: 5,
            pagination: false,
            itemsDesktop: [ 1000, 4 ],
            itemsDesktopSmall: [ 900, 3 ],
            itemsTablet: [ 600, 2 ],
            itemsMobile: false,
            autoPlay: 2000,
            stopOnHover: true
        } );
        // img detail projects 
        var owl = jQuery( "#detailpro" );
        owl.owlCarousel( {
            navigation: true,
            singleItem: true,
            pagination: false,
            transitionStyle: "fade",
            navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ],
        } );
        // owlCarousel blog news
        var owl = jQuery( "#owl-blog" );
        owl.owlCarousel( {
            items: 3,
            itemsDesktop: [ 1000, 3 ],
            itemsDesktopSmall: [ 900, 3 ],
            itemsTablet: [ 600, 2 ],
            itemsMobile: [ 500, 1 ],
            autoPlay: 4000,
            stopOnHover: true
        } );
        // owl slider home
        var time = 7; // time in seconds
        var jQueryprogressBar,
            jQuerybar,
            jQueryelem,
            isPause,
            tick,
            percentTime;
        // Init the carousel
        jQuery( "#owl-slider-home" )
            .owlCarousel( {
                slideSpeed: 1000,
                paginationSpeed: 1000,
                pagination: false,
                singleItem: true,
                transitionStyle: 'fade',
                afterInit: progressBar,
                afterMove: moved,
                loop: true,
                autoHeight: true,
                touchDrag: false,
                mouseDrag: false,
                navigation: true,
                navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ]
            } );
        // Init progressBar where elem is jQuery("#owl-slider-home")
        function progressBar( elem ) {
            jQueryelem = elem;
            // build progress bar elements
            buildProgressBar();
            // start counting
            start();
        }
        // create div#progressBar and div#bar then prepend to jQuery("#owl-slider-home")
        function buildProgressBar() {
            jQueryprogressBar = jQuery( "<div>", {
                id: "progressBar"
            } );
            jQuerybar = jQuery( "<div>", {
                id: "bar"
            } );
            jQueryprogressBar.append( jQuerybar )
                .prependTo( jQueryelem );
        }

        function start() {
            // reset timer
            percentTime = 0;
            isPause = false;
            // run interval every 0.01 second
            tick = setInterval( interval, 10 );
        };

        function interval() {
            if ( isPause === false ) {
                percentTime += 1 / time;
                jQuerybar.css( {
                    width: percentTime + "%"
                } );
                // if percentTime is equal or greater than 100
                if ( percentTime >= 100 ) {
                    // slide to next item 
                    jQueryelem.trigger( 'owl.next' )
                }
            }
        }
        // moved callback
        function moved() {
            // clear interval
            clearTimeout( tick );
            // start again
            start();
        }
        // owl  detail 2
        var roomsBig = jQuery( "#roomsBig" );
        var roomsSmall = jQuery( "#roomsSmall" );
        roomsBig.owlCarousel( {
            singleItem: true,
            slideSpeed: 1000,
            navigation: true,
            navigationText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>" ],
            pagination: false,
            afterAction: syncPosition,
            responsiveRefreshRate: 200,
        } );
        roomsSmall.owlCarousel( {
            items: 4,
            itemsDesktop: [ 1199, 4 ],
            itemsDesktopSmall: [ 979, 3 ],
            itemsTablet: [ 768, 2 ],
            itemsMobile: [ 414, 1 ],
            pagination: false,
            responsiveRefreshRate: 100,
            afterInit: function( el ) {
                el.find( ".owl-item" )
                    .eq( 0 )
                    .addClass( "synced" );
            }
        } );

        function syncPosition( el ) {
            var current = this.currentItem;
            jQuery( "#roomsSmall" )
                .find( ".owl-item" )
                .removeClass( "synced" )
                .eq( current )
                .addClass( "synced" )
            if ( jQuery( "#roomsSmall" )
                .data( "owlCarousel" ) !== undefined ) {
                center( current )
            }
        }
        jQuery( "#roomsSmall" )
            .on( "click", ".owl-item", function( e ) {
                e.preventDefault();
                var number = jQuery( this )
                    .data( "owlItem" );
                roomsBig.trigger( "owl.goTo", number );
            } );

        function center( number ) {
            var roomsSmallvisible = roomsSmall.data( "owlCarousel" )
                .owl.visibleItems;
            var num = number;
            var found = false;
            for ( var i in roomsSmallvisible ) {
                if ( num === roomsSmallvisible[ i ] ) {
                    var found = true;
                }
            }
            if ( found === false ) {
                if ( num > roomsSmallvisible[ roomsSmallvisible.length - 1 ] ) {
                    roomsSmall.trigger( "owl.goTo", num - roomsSmallvisible.length + 2 )
                } else {
                    if ( num - 1 === -1 ) {
                        num = 0;
                    }
                    roomsSmall.trigger( "owl.goTo", num );
                }
            } else if ( num === roomsSmallvisible[ roomsSmallvisible.length - 1 ] ) {
                roomsSmall.trigger( "owl.goTo", roomsSmallvisible[ 1 ] )
            } else if ( num === roomsSmallvisible[ 0 ] ) {
                roomsSmall.trigger( "owl.goTo", num - 1 )
            }
        }
        // revolution slider
        var revapi;
        revapi = jQuery( '#revolution-slider' )
            .revolution( {
                delay: 15000,
                startwidth: 1170,
                startheight: 600,
                onHoverStop: "on",
                thumbWidth: 100,
                thumbHeight: 50,
                thumbAmount: 3,
                touchenabled: "on",
                stopAtSlide: -1,
                stopAfterLoops: -1,
                touchenabled: "on",
                navigationType: "none",
                dottedOverlay: "",
                fullWidth: "on",
                fullScreen: "on",
                shadow: 0
            } );
			
			
 } );