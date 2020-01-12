$(document).ready(function () {

    var currentBlogKey = location.href.substring(location.href.lastIndexOf('/') + 1);


    $.ajax({
        url: "/api/v1/blogs/" + currentBlogKey
    }).then(function (data) {
        $('.blog-title').append(data.title);
        $('.blog-subtitle').append(data.subTitle);
        $('.blog-text').append(data.content);
        $('.blog-additionalstyles').append(data.additionalStyles);
    });

});