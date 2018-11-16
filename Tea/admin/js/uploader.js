$(function () {
    //初始化綁定預設的屬性
    $.upLoadDefaults = $.upLoadDefaults || {};
    $.upLoadDefaults.property = {
        multiple: false, //是否多檔
        water: false, //是否加浮水印
        thumbnail: false, //是否生成縮略圖
        sendurl: null, //發送地址
        filetypes: "jpg,jpge,png,gif", //檔案類型
        filesize: "204800", //文件大小
        btntext: "瀏覽...", //上傳按鈕的文字
        swf: null //SWF上傳控制項相對位址
    };
    //初始化上傳控制項
    $.fn.InitUploader = function (p) {
        var fun = function (parentObj) {
            p = $.extend({}, $.upLoadDefaults.property, p || {});
            var btnObj = $('<div class="upload-btn">' + p.btntext + '</div>').appendTo(parentObj);
            //初始化屬性
            p.sendurl += "?action=UpLoadFile";
            if (p.water) {
                p.sendurl += "&IsWater=1";
            }
            if (p.thumbnail) {
                p.sendurl += "&IsThumbnail=1";
            }
            if (!p.multiple) {
                p.sendurl += "&DelFilePath=" + parentObj.siblings(".upload-path").val();
            }

            //初始化WebUploader
            var uploader = WebUploader.create({
                auto: true, //自動上傳
                swf: p.swf, //SWF路徑
                server: p.sendurl, //上傳地址
                pick: {
                    id: btnObj,
                    multiple: p.multiple
                },
                accept: {
                    /*title: 'Images',*/
                    extensions: p.filetypes
                    /*mimeTypes: 'image/*'*/
                },
                formData: {
                    'DelFilePath': '' //定義參數
                },
                fileVal: 'Filedata', //上傳域的名稱
                fileSingleSizeLimit: p.filesize * 1024 //文件大小
            });

            //當validate不通過時，會以派送錯誤事件的形式通知
            uploader.on('error', function (type) {
                switch (type) {
                    case 'Q_EXCEED_NUM_LIMIT':
                        alert("錯誤：上傳檔數量過多！");
                        break;
                    case 'Q_EXCEED_SIZE_LIMIT':
                        alert("錯誤：檔總大小超出限制！");
                        break;
                    case 'F_EXCEED_SIZE':
                        alert("錯誤：檔大小超出限制！");
                        break;
                    case 'Q_TYPE_DENIED':
                        alert("錯誤：禁止上傳該類型檔！");
                        break;
                    case 'F_DUPLICATE':
                        alert("錯誤：請勿重複上傳該文件！");
                        break;
                    default:
                        alert('錯誤代碼：' + type);
                        break;
                }
            });

            //當有檔添加進來的時候
            uploader.on('fileQueued', function (file) {
                //如果是單檔上傳，把舊的檔地址傳過去
                if (!p.multiple) {
                    uploader.options.formData.DelFilePath = parentObj.siblings(".upload-path").val();
                }
                //防止重複創建
                if (parentObj.children(".upload-progress").length == 0) {
                    //創建進度條
                    var fileProgressObj = $('<div class="upload-progress"></div>').appendTo(parentObj);
                    var progressText = $('<span class="txt">正在上傳，請稍候...</span>').appendTo(fileProgressObj);
                    var progressBar = $('<span class="bar"><b></b></span>').appendTo(fileProgressObj);
                    var progressCancel = $('<a class="close" title="取消上傳">關閉</a>').appendTo(fileProgressObj);
                    //綁定點擊事件
                    progressCancel.click(function () {
                        uploader.cancelFile(file);
                        fileProgressObj.remove();
                    });
                }
            });

            //檔上傳過程中創建進度條即時顯示
            uploader.on('uploadProgress', function (file, percentage) {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html(file.name);
                progressObj.find(".bar b").width(percentage * 100 + "%");
            });

            //當文件上傳出錯時觸發
            uploader.on('uploadError', function (file, reason) {
                uploader.removeFile(file); //從佇列中移除
                alert(file.name + "上傳失敗，錯誤代碼：" + reason);
            });

            //當檔上傳成功時觸發
            uploader.on('uploadSuccess', function (file, data) {
                if (data.status == '0') {
                    var progressObj = parentObj.children(".upload-progress");
                    progressObj.children(".txt").html(data.msg);
                }
                if (data.status == '1') {
                    //如果是單檔上傳，則賦值相應的表單
                    if (!p.multiple) {
                        parentObj.siblings(".upload-name").val(data.name);
                        parentObj.siblings(".upload-path").val(data.path);
                        parentObj.siblings(".upload-size").val(data.size);
                    } else {
                        addImage(parentObj, data.path, data.thumb);
                    }
                    var progressObj = parentObj.children(".upload-progress");
                    progressObj.children(".txt").html("上傳成功：" + file.name);
                }
                uploader.removeFile(file); //從佇列中移除
            });

            //不管成功或者失敗，檔上傳完成時觸發
            uploader.on('uploadComplete', function (file) {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html("上傳完成");
                //如果佇列為空，則移除進度條
                if (uploader.getStats().queueNum == 0) {
                    progressObj.remove();
                }
            });
        };
        return $(this).each(function () {
            fun($(this));
        });
    }
});

/*圖片相冊處理事件
=====================================================*/
//添加圖片相冊
function addImage(targetObj, originalSrc, thumbSrc) {
    //插入到相冊UL裡面
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
    var parentObj = $(obj); //父物件
    var hidRemarkObj = parentObj.prevAll("input[name='hid_photo_remark']").eq(0); //取得隱藏值
    var d = parent.dialog({
        title: "圖片描述",
        content: '<textarea id="ImageRemark" style="margin:10px 0;font-size:12px;padding:3px;color:#000;border:1px #d2d2d2 solid;vertical-align:middle;width:300px;height:50px;">' + hidRemarkObj.val() + '</textarea>',
        button: [{
            value: '批量描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    parent.dialog({
                        title: '提示',
                        content: '親，總該寫點什麼吧？',
                        okValue: '確定',
                        ok: function () { },
                        onclose: function(){
                            remarkObj.focus();
                        }
                    }).showModal();
                    return false;
                }
                parentObj.parent().parent().find("li input[name='hid_photo_remark']").val(remarkObj.val());
                parentObj.parent().parent().find("li .img-box .remark i").html(remarkObj.val());
            }
        }, {
            value: '單張描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    parent.dialog({
                        title: '提示',
                        content: '親，總該寫點什麼吧？',
                        okValue: '確定',
                        ok: function () { },
                        onclose: function () {
                            remarkObj.focus();
                        }
                    }).showModal();
                    return false;
                }
                hidRemarkObj.val(remarkObj.val());
                parentObj.siblings(".img-box").children(".remark").children("i").html(remarkObj.val());
            },
            autofocus: true
        }]
    }).showModal();
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
        focusPhotoObj.val(firtImgBox.children("img").attr("src")); //重新給封面的隱藏欄位賦值
    }
}
