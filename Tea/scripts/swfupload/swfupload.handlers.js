$(function () {
    //初始化綁定默認的屬性
    $.swfUpLoadDefaults = $.swfUpLoadDefaults || {};
    $.swfUpLoadDefaults.property = {
        single: true, //是否單文件
        water: false, //是否加水印
        thumbnail: false, //是否生成縮略圖
        sendurl: null, //發送地址
        filetypes: "*.jpg;*.jpge;*.png;*.gif;*.xls;*.xlsx;", //文件類型
        filesize: "2048", //文件大小
        btntext: "瀏覽...", //上傳按鈕的文字
        btnwidth: 48, //上傳按鈕的寬度
        btnheight: 28, //上傳按鈕的高度
        flashurl: null //FLASH上傳控件相對地址
    };
    //初始化SWFUpload上傳控件
    $.fn.InitSWFUpload = function (p) {
        p = $.extend({}, $.swfUpLoadDefaults.property, p || {});
        //創建上傳按鈕
        var parentObj = $(this);
        var parentBtnId = "upload_span_" + Math.floor(Math.random() * 1000 + 1);
        parentObj.append('<div class="upload-btn"><span id="' + parentBtnId + '"></span></div>');
        //初始化屬性
        var btnAction = SWFUpload.BUTTON_ACTION.SELECT_FILES; //多文件上傳

        p.sendurl += "?action=UpLoadFile";
        if (p.single) {
            btnAction = SWFUpload.BUTTON_ACTION.SELECT_FILE; //單文件上傳
        }
        if (p.water) {
            p.sendurl += "&IsWater=1";
        }
        if (p.thumbnail) {
            p.sendurl += "&IsThumbnail=1";
        }

        //初始化上傳控件
        var swfu = new SWFUpload({
            post_params: { "ASPSESSID": "NONE" },
            upload_url: p.sendurl, //上傳地址
            file_size_limit: p.filesize, //文件大小
            file_types: p.filetypes, //文件類型
            file_types_description: "JPG Images",
            file_upload_limit: "0", //一次能上傳的文件數量

            file_queue_error_handler: fileQueueError,
            file_dialog_complete_handler: fileDialogComplete,
            upload_progress_handler: uploadProgress,
            upload_error_handler: uploadError,
            upload_success_handler: uploadSuccess,
            upload_complete_handler: uploadComplete,

            button_placeholder_id: parentBtnId, //指定一個dom元素
            button_width: p.btnwidth, //上傳按鈕的寬度
            button_height: p.btnheight, //上傳按鈕的高度
            button_text: '<span class="btnText">' + p.btntext + '</span>', //上傳按鈕的文字
            button_text_style: ".btnText{font-family:Microsoft YaHei;font-size:12px;line-height:28px;color:#333333;text-align:center;}", //按鈕樣式
            button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT, //背景透明
            button_action: btnAction, //單文件或多文件上傳
            button_cursor: SWFUpload.CURSOR.HAND, //指針手形
            flash_url: p.flashurl, //Flash路徑
            custom_settings: {
                "upload_target": parentObj,
                "button_action": btnAction
            },
            debug: false
        });
    }
});

//==================================以下是上傳時處理事件===================================
//當選擇文件對話框關閉消失時發生
function fileQueueError(file, errorCode, message) {
    try {
        switch (errorCode) {
            case SWFUpload.errorCode_QUEUE_LIMIT_EXCEEDED:
                alert("你選擇的文件太多！");
                break;
            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                alert(file.name + "文件太小！");
                break;
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                alert(file.name + "文件太大！");
                break;
            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                alert(file.name + "文件類型出錯！");
                break;
            default:
                if (file !== null) {
                    alert("出現未知錯誤！");
                }
                break;
        }

    } catch (ex) {
        this.debug(ex);
    }
}
//當選擇文件對話框關閉，所有文件已經處理完成時發生
function fileDialogComplete(numFilesSelected, numFilesQueued) {
    try {
        if (numFilesQueued > 0) {
            //如果是單文件上傳，把舊的文件地址傳過去
            if (this.customSettings.button_action == SWFUpload.BUTTON_ACTION.SELECT_FILE) {
                this.setPostParams({
                    "DelFilePath": $(this.customSettings.upload_target).siblings(".upload-path").val()
                });
            }
            this.startUpload();
            createHtmlProgress(this); //創建進度條
        }
    } catch (ex) {
        this.debug(ex);
    }
}
//flash定時觸發，定時更新頁面中的UI元素達到及時顯示上傳進度的效果
function uploadProgress(file, bytesLoaded) {
    try {
        var percent = Math.ceil((bytesLoaded / file.size) * 100);
        var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
        progressObj.children(".txt").html(file.name);
        progressObj.find(".bar b").width(percent + "%");
    } catch (ex) {
        this.debug(ex);
    }
}
//上傳被終止或者沒有成功完成時觸發
function uploadError(file, errorCode, message) {
    var progress;
    try {
        switch (errorCode) {
            case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                try {
                    var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
                    progressObj.children(".txt").html("上傳被取消：Cancelled");
                }
                catch (ex1) {
                    this.debug(ex1);
                }
                break;
            case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                try {
                    var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
                    progressObj.children(".txt").html("上傳被停止：Stopped");
                }
                catch (ex2) {
                    this.debug(ex2);
                }
            case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                alert(message + "SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED");
                break;
            default:
                alert(message + "未知！");
                break;
        }
    } catch (ex3) {
        this.debug(ex3);
    }
}
//文件上傳的處理已經完成且服務端返回了200的HTTP狀態時觸發
function uploadSuccess(file, serverData) {
    try {
        var jsonstr = eval('(' + serverData + ')');
        if (jsonstr.status == '0') {
            var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
            progressObj.children(".txt").html(jsonstr.msg);
        }
        if (jsonstr.status == '1') {
            //如果是單文件上傳，則賦值相應的表單
            if (this.customSettings.button_action == SWFUpload.BUTTON_ACTION.SELECT_FILE) {
                $(this.customSettings.upload_target).siblings(".upload-name").val(jsonstr.name);
                $(this.customSettings.upload_target).siblings(".upload-path").val(jsonstr.path);
                $(this.customSettings.upload_target).siblings(".upload-size").val(jsonstr.size);
            } else {
                addImage($(this.customSettings.upload_target), jsonstr.path, jsonstr.thumb);
            }
            var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
            progressObj.children(".txt").html("上傳成功：" + file.name);
        }
    } catch (ex) {
        this.debug(ex);
    }
}
//當上傳隊列中的文件已完成時，無論成功(uoloadSuccess觸發)或失敗(uploadError觸發)，此事件都會被觸發
function uploadComplete(file) {
    try {
        if (this.getStats().files_queued > 0) {
            this.startUpload();
        } else {
            var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
            progressObj.children(".txt").html("全部上傳成功");
            progressObj.remove();
        }
    } catch (ex) {
        this.debug(ex);
    }
}

//==================================以上是上傳時處理事件===================================
//創建上傳進度條
function createHtmlProgress(swfuInstance) {
    //判斷顯示進度的DIV是否存在，不存在則創建
    var targetObj = $(swfuInstance.customSettings.upload_target);
    var fileProgressObj = $('<div class="upload-progress"></div>').appendTo(targetObj);
    var progressText = $('<span class="txt">正在上傳，請稍候...</span>').appendTo(fileProgressObj);
    var progressBar = $('<span class="bar"><b></b></span>').appendTo(fileProgressObj);
    var progressCancel = $('<a class="close" title="取消上傳">關閉</a>').appendTo(fileProgressObj);
    //綁定點擊事件
    progressCancel.click(function () {
        swfuInstance.stopUpload();
        fileProgressObj.remove();
    });
}

//======================================圖片相冊處理事件======================================
//添加圖片相冊
function addImage(targetObj, originalSrc, thumbSrc) {
    //插入到相冊UL里面
    var newLi = $('<li>'
    + '<input type="hidden" name="hid_photo_name" value="0|' + originalSrc + '|' + thumbSrc + '" />'
    + '<input type="hidden" name="hid_photo_remark" value="" />'
    + '<div class="img-box" onclick="setFocusImg(this);">'
    + '<img src="' + thumbSrc + '" bigsrc="' + originalSrc + '" />'
    + '<span class="remark"><i>暫無描述...</i></span>'
    + '</div>'
    + '<a href="javascript:;" onclick="setRemark(this);">描述</a>'
    + '<a href="javascript:;" onclick="delImg(this);">刪除</a>'
    + '</li>');
    newLi.appendTo(targetObj.siblings(".photo-list").children("ul"));

    //默認第一個為相冊封面
    var focusPhotoObj = targetObj.siblings(".focus-photo");
    if (focusPhotoObj.val() == "") {
        focusPhotoObj.val(thumbSrc);
        newLi.children(".img-box").addClass("selected");
    }
}
//設置相冊封面
function setFocusImg(obj) {
    var focusPhotoObj = $(obj).parents(".photo-list").siblings(".focus-photo");
    focusPhotoObj.val($(obj).children("img").eq(0).attr("src"));
    $(obj).parent().siblings().children(".img-box").removeClass("selected");
    $(obj).addClass("selected");
}
//設置圖片描述
function setRemark(obj) {
    var parentObj = $(obj); //父對象
    var hidRemarkObj = parentObj.prevAll("input[name='hid_photo_remark']").eq(0); //取得隱藏值
    var m = $.dialog({
        lock: true,
        max: false,
        min: false,
        padding: 0,
        title: "圖片描述",
        content: '<textarea id="ImageRemark" style="margin:10px 0;font-size:12px;padding:3px;color:#000;border:1px #d2d2d2 solid;vertical-align:middle;width:300px;height:50px;">' + hidRemarkObj.val() + '</textarea>',
        button: [{
            name: '批量描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    $.dialog.alert('總該寫點什么吧？', function () {
                        remarkObj.focus();
                    }, m);
                    return false;
                }
                parentObj.parent().parent().find("li input[name='hid_photo_remark']").val(remarkObj.val());
                parentObj.parent().parent().find("li .img-box .remark i").html(remarkObj.val());
            }
        }, {
            name: '單張描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    $.dialog.alert('總該寫點什么吧？', function () {
                        remarkObj.focus();
                    }, m);
                    return false;
                }
                hidRemarkObj.val(remarkObj.val());
                parentObj.siblings(".img-box").children(".remark").children("i").html(remarkObj.val());
            },
            focus: true
        }]
    });
}
//刪除圖片LI節點
function delImg(obj) {
    var parentObj = $(obj).parent().parent();
    var focusPhotoObj = parentObj.parent().siblings(".focus-photo");
    var smallImg = $(obj).siblings(".img-box").children("img").attr("src");
    $(obj).parent().remove(); //刪除的LI節點
    //檢查是否為封面
    if (focusPhotoObj.val() == smallImg) {
        focusPhotoObj.val("");
        var firtImgBox = parentObj.find("li .img-box").eq(0); //取第一張做為封面
        firtImgBox.addClass("selected");
        focusPhotoObj.val(firtImgBox.children("img").attr("src")); //重新給封面的隱藏域賦值
    }
}