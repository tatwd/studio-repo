!function ($) {

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
        var richEditor = $.document.getElementsByClassName('rich-editor')[0];
        var editArea = $.document.getElementsByClassName('edit-area')[0];
        var placeHolder = $.document.getElementsByClassName('placeholder')[0];

        if (!editArea || !placeHolder) {
            return;
        }

        editArea.addEventListener('keydown', function () {
            placeHolder.style.display = "none";
        }, false);

        editArea.addEventListener('keyup', function () {

            //console.log(editArea);

            if (editArea.value == "") {
                placeHolder.style.display = "block";
            }
        }, false);

        //editArea.addEventListener('focus', function () {

        //    console.log("oh");
        //    richEditor.style.outline = "1px solid #068dd2";
        //}, true);
    };

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
                replyBox.style.zIndex = "999";
                replyBox.style.opacity = "1";

                //console.log(author[i].innerText);
                //console.log(replyWho);
                replyWho.innerHTML = "回复: <a href='#'>" + author[i].innerText + "</a>";

            }, false);
        };

        for (var i = 0, len = content.length; i < len; i++) {

            clickForReply(i);
        }

        cancel.addEventListener('click', function () {
            replyBox.style.opacity = "0";

            var timer = $.setTimeout(function () {

                replyBox.style.zIndex = "-1";

            }, 1000);

        }, false);

    };

    showMenu();
    richEditorGo();
    showReplyBox();

}(window);