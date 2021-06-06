// HTML document is loaded
jQuery( window ).on( "load", function() {
        "use strict";
		
        // var preloader
        var loader = jQuery( '.preloader, .preloader-white' );
        var bgpreloader = jQuery( '.bg-preloader, .bg-preloader-white' );
        // var navigation
        var menumobile = jQuery( '#main-menu' );
        var navdefault = jQuery( '.navbar-default-white' );
        var Navactive = jQuery( "nav a" );
        var subnav = jQuery( ".subnav" );
		
        // start function fadeOut preloader when condition window has been load
        loader.fadeOut( 'slow', function() {
            "use strict";
            // opening slideup
            bgpreloader.fadeOut( 1500 );
            // animated transition & scroll onStep
            onStep();
            // stick navbar
            navdefault.sticky();
            // responsive part
            if ( jQuery( window )
                .width() < 1025 ) {}
            // mobile icon
            jQuery( ".navbar-toggle" )
                .on( "click", function() {
                    menumobile.toggleClass( 'menu-show' );
                    navdefault.toggleClass( 'fullHeight' );
                } );
        } );
        // end function
		
        // contact form
        var contactname = jQuery( '#name-contact' );
        var contactemail = jQuery( '#email-contact, input#email-contact' );
        var contactmessage = jQuery( '#message-contact' );
        var contactsent = jQuery( '#send-contact' );
        //form failed succes var
        var successent = jQuery( "#mail_success" );
        var failedsent = jQuery( "#mail_failed" );
        jQuery( function() {
            contactsent.on( 'click', function( e ) {
                e.preventDefault();
                var e = contactname.val(),
                    a = contactemail.val(),
                    s = contactmessage.val(),
                    r = !1;
                if ( 0 == a.length || "-1" == a.indexOf( "@" ) || "-1" == a.indexOf( "." ) ) {
                    var r = !0;
                    contactemail.css( {
                        "border": "1px solid #ffb600"
                    } );
                } else contactemail.css( {
                    "border": "1px solid #959595"
                } );
                if ( 0 == e.length ) {
                    var r = !0;
                    contactname.css( {
                        "border": "1px solid #ffb600"
                    } );
                } else contactname.css( {
                    "border": "1px solid #959595"
                } );
                if ( 0 == s.length ) {
                    var r = !0;
                    contactmessage.css( {
                        "border": "1px solid #ffb600"
                    } );
                } else contactmessage.css( {
                    "border": "1px solid #959595"
                } );
                return 0 == r && ( contactsent.attr( {
                    disabled: "true",
                    value: "Sending..."
                } ), jQuery.ajax( {
                    type: "POST",
                    url: "send.php",
                    data: "name=" + e + "&email=" + a + "&subject=You Got Email&message=" + s,
                    success: function( e ) {
                        "success" == e ? ( successent.fadeIn( 500 ) ) : ( failedsent.html( e )
                            .fadeIn( 500 ), contactsent.removeAttr( "disabled" )
                            .attr( "value", "send" )
                            .remove() )
                    }
                } ) ), !1
            } )
        } );
		
        // reservation form
        var sentbook = jQuery( '#send' );
        var selectroom = jQuery( '#selectroom, select#selectroom' );
        var stardate = jQuery( '#date1' );
        var enddate = jQuery( '#date2' );
        var phonebook = jQuery( '#phonebook' );
        var personbook = jQuery( '#personbook' );
        var namebook = jQuery( '#namebook' );
        var emailbook = jQuery( '#emailbook, input#emailbook' );
        var messagebook = jQuery( '#messagebook' );
        jQuery( function() {
            sentbook.on( 'click', function( e ) {
                e.preventDefault();
                var sr = selectroom.val(),
                    b = stardate.val(),
                    h = enddate.val(),
                    ph = phonebook.val(),
                    p = personbook.val(),
                    e = namebook.val(),
                    a = emailbook.val(),
                    s = messagebook.val(),
                    r = !1;
                if ( 0 == a.length || "-1" == a.indexOf( "@" ) || "-1" == a.indexOf( "." ) ) {
                    var r = !0;
                    emailbook.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else emailbook.css( "border", "none" );
                if ( 0 == b.length ) {
                    var r = !0;
                    stardate.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else stardate.css( "border", "none" );
                if ( 0 == h.length ) {
                    var r = !0;
                    enddate.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else enddate.css( "border", "none" );
                if ( 0 == ph.length ) {
                    var r = !0;
                    phonebook.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else phonebook.css( "border", "none" );
                if ( 0 == p.length ) {
                    var r = !0;
                    personbook.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else personbook.css( "border", "none" );
                if ( 0 == e.length ) {
                    var r = !0;
                    namebook.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else namebook.css( "border", "none" );
                if ( 0 == s.length ) {
                    var r = !0;
                    messagebook.css( {
                        "border-color": "#ffb600",
                        "border-width": "1px",
                        "border-style": "solid"
                    } );
                } else messagebook.css( "border", "none" );
                return 0 == r && ( sentbook.attr( {
                    disabled: "true",
                    value: "Sending..."
                } ), jQuery.ajax( {
                    type: "POST",
                    url: "book.php",
                    data: "&selectroom=" + sr + "&stardate=" + b + "&enddate=" + h + "&phonebook=" + ph + "&person=" + p + "&name=" + e + "&email=" + a + "&subject=You Got Reservation&message=" + s,
                    success: function( e ) {
                        "success" == e ? ( successent.fadeIn( 500 ) ) : ( failedsent.html( e )
                            .fadeIn( 500 ), sentbook.removeAttr( "disabled" )
                            .attr( "value", "send" )
                            .remove() )
                    }
                } ) ), !1
            } )
        } );
    } );
// HTML document is loaded end