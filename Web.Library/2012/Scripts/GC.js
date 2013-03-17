$(function () {
    $(".nav-sign-in").click(function () {
        var asset = getAsset();

        // poor man's validation
        if (asset == null) {
            alert("Specify a name please!");
            return;
        }

        $.ajax({
            url: '@Url.Action("Search/Query", "home")',
            data: JSON.stringify("davido"),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                alert(result.Name);
            }
            
        // take the data and post it via json
        //$.post("Search/Query", asset, function (data) {
        //    // get the result and do some magic with it
        //    var customers = data;
        //    console.log(message);
        //    $.each(customers, function (index, contact) {
        //        var spnCustomer =$('<a href=\'mailto:'+contact.Name+'\'>'+contact.Title+' ['+contact.Author+']</a><br/>');
        //        $('#modLogin').append(spnCustomer);
            
            });
        });
    });
});

function getAerson() {
    var name = $("#email").val();
  

    // poor man's validation
    return (name == "") ? null : { Name: name };
}