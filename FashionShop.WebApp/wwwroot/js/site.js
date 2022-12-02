var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        AddtoCartEvents();
        loadCart();
    }
    function loadCart() {    
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/Index',
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            }
        });
    }
    function regsiterEvents() {
        // Write your JavaScript code.
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture +'/Cart/AddToCart',
                data: {
                    id: id,
                    quatity: 1
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                    arlet(res.length)
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }

    function AddtoCartEvents() {
        // Write your JavaScript code.
        $('body').on('click', '.btn-add-to-cart', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val(); 
            const quatity = $('#idquatity').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture,
                    quatity: quatity
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                    arlet(res.length)
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}