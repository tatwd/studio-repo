!function ($) {

    //$.onload = function () {
    //    var cmntContent = $.document.getElementById('CmntContent');

    //    cmntContent.attributes.removeNamedItem('disabled');
    //};

    // 显示下拉菜单
    var showMenu = function () {
        var userSign = $.document.getElementsByClassName('user-sign')[0];
        var signBox = $.document.getElementsByClassName('sign-box')[0];

        userSign.onmouseover = function () {
            signBox.style.visibility = "visible";
            signBox.style.opacity = '1';
        }

        userSign.onmouseout = function () {
            signBox.style.opacity = '0';
            signBox.style.visibility = "hidden";
        }
    };

    // 处理富文本
    var richEditorGo = function () {

        var richEditor  = $.document.getElementsByClassName('rich-editor');
        var submitCmnt  = $.document.getElementsByClassName('submit-cmnt')[0];
        var submitReply = $.document.getElementsByClassName('submit-reply')[0];

        if (!richEditor || !submitCmnt || !submitReply) {
            console.error('Error: not found `richEditor` or `submitCmnt` or `submitReply`!');
            return;
        }

        var addEventToRichEditor = function (i) {
            var editArea = richEditor[i].getElementsByClassName('edit-area')[0];

            var input = (i === 0) ? submitCmnt.getElementsByTagName('input')[0] : submitReply.getElementsByTagName('input')[0];

            editArea.addEventListener('keydown', function () {
                input.style.opacity = '1';

            }, false);

            editArea.addEventListener('keyup', function () {

                if (editArea.value == '') {
                    input.style.opacity = '0.6';
                    input.disabled = 'true';
                } else {
                    if (input.hasAttribute('disabled')) {
                        input.attributes.removeNamedItem('disabled');
                    }
                }

            }, false);
        };


        for (var i = 0, len = richEditor.length; i < len; ++ i){
            addEventToRichEditor(i); // 闭包
        }

    };

    // 显示回复框
    var showReplyBox = function () {
        var replyBox = $.document.getElementsByClassName('reply-container')[0];
        var comment = $.document.getElementsByClassName('comment')[0];

        if (!replyBox || !comment) {
            return;
        }

        var author = comment.getElementsByClassName('author');
        var content = comment.getElementsByClassName('content');

        
        var cancel = replyBox.getElementsByClassName('icon-cancel')[0];
        var replyWho = replyBox.getElementsByClassName('reply-who')[0];

        //console.log(author);

        var clickForReply = function (i) {


            content[i].addEventListener('click', function () {
                replyBox.style.zIndex = '999';
                replyBox.style.opacity = '1';

                replyWho.innerHTML = '@' + author[i].innerText;

            }, false);
        };

        for (var i = 0, len = content.length; i < len; i++) {

            clickForReply(i);
        }

        cancel.addEventListener('click', function () {
            replyBox.style.opacity = '0';

            var timer = $.setTimeout(function () {

                replyBox.style.zIndex = '-1';

            }, 500);

        }, false);

    };

    showMenu();
    richEditorGo();
    showReplyBox();

}(window);