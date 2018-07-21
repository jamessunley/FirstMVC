$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var option = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-first-target"));
            $target.replaceWith(data);
        });

        return false;
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-first-autocomplete")
        };

        $input.autocomplete(options);
    };

    $("form[data-first-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-first-autocomplete]").each(createAutocomplete);

});