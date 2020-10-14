const BlogItem = ({ urlKey, author, publishDate, title, subTitle }) => `
                <div class="col-lg-4 col-sm-4">
                <div class="blog_grid_item mb-30">
                    <a href="${urlKey}">
                        <div class="blog-image">

                        </div>
                    </a>
                    <div class="blog_content">
                        <div class="entry_post_info">
                            By: ${author} / ${publishDate}
                        </div>
                        <a href="${urlKey}">
                            <h5 class="f_p f_size_20 f_500 t_color mb_20">
                                ${title}
                            </h5>
                        </a>
                        <p class="f_400 mb-0">
                            ${subTitle}
                        </p>
                    </div>
                </div>
            </div>
        `;


const NoBlogInfoBanner = () => `
                <div class="col-lg-12 col-sm-12">
                            <div class="blog_grid_item mb-30">

                                <div class="blog_content">
                                    <h5 class="f_p f_size_20 f_500 t_color mb_20">
                                         We do not have any published blog entries yet 
                                    </h5>
                                    <p class="f_400 mb-0">
                                         At the moment we are preparing interesting blog entries round about the topic Company Branding for you. 
                                    </p>
                                </div>

                            </div>
                        </div>
        `;



$(document).ready(function () {


    $.ajax({
        url: "/api/v1/blogs/"
    }).then(function (data) {

        if (data.length != 0) {
            data.forEach(appendToBlogItems);
        }
        else {
            $('.blog-item-overview').html(NoBlogInfoBanner);
        }



    });

});


function appendToBlogItems(item) {
    $('.blog-item-overview').append([item].map(BlogItem).join(''));
}