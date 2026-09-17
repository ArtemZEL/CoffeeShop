
$(document).ready(function () {

    initComments();

    function initComments() {
        const url = `${apiurl}/getallcomment`;

        $.get(url).done(function (commentUsers) {
            commentUsers.forEach(commentUser => {
                const commentTags =
                    $('.usercomments-minimal-api .box.templatesuser').clone();

                commentTags.removeClass('templatesuser');

                commentTags.find('h2')
                    .text(commentUser.name);

                commentTags.find('p')
                    .text(commentUser.comment);

                const imageUrl = commentUser.image
                    ? decodeURIComponent(commentUser.image)
                    : '/image/default.jpg';

                commentTags.find('img')
                    .attr('src', imageUrl);

                $('.customers-container.usercomments-minimal-api')
                    .append(commentTags);
            });
        });
    }
});
