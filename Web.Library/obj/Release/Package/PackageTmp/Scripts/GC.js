


$(document).ready(function(e) {
    $('.nav-sign-in').submit(function(event) {
        var $form = $(this),
            term = $form.find("#email").val(),
            url = $form.attr('action');
        $.getJSON(url, term, function(data) {
            $.each(data.data, function(index, contact) {
                var spnCustomer = $('<a href=\'mailto:' + contact.Name + '\'>' + contact.Title + ' [' + contact.Author + '] ' + contact.Name + ' </a><br/>');
                console.log(contact.Name);
                $('.cont-forgot-credentials').append(spnCustomer);
            });

        });

    });
});

;


function render(value) {


            var data = value;
            console.log(data.Name);
            $.each(data.data, function(index, contact) {
                var spnCustomer = $('<a href=\'mailto:' + contact.Name + '\'>' + contact.Title + ' [' + contact.Author + '] ' + contact.Name + ' </a><br/>');
                console.log(contact.Name);
                $('.cont-forgot-credentials').append(spnCustomer);
            });
        }

      

   
 
   


function getAsset() {
    var name = $("#email").val();
  

    // poor man's validation
    return (name == "") ? null : { Name: name };
};