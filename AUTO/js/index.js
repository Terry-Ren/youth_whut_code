$(function(){

    var _now =1412297100000 - parseInt($('#gwc-now').val());
    $('div ul.tc.pt5.countdown').attr('date-countdown',_now);

    if($.browser.msie && parseInt($.browser.version) <= 6){
        if($('#en').size()<1){
            $('.picListP li').hover(function() {
                $(this).find('.halfO,p').show()
            }, function() {
                $(this).find('.halfO,p').hide();
            });
        }
    }
    /**
     * 头部幻灯
     */
    if($('#en').size()>0){
        $(".slider").revolve({
            auto : true,
            autotime : 5000,
            item : ".themeitem",
            grope : ".thememain",
            indexmain : ".slide-item",
            l : ".slider .pre",
            r : ".slider .nex"
        });
    }else {
        $(".slider").revolve({
            auto : true,
            autotime : 5000,
            item : ".themeitem",
            grope : ".thememain",
            indexmain : ".slide-item",
            l : ".slider .pre",
            r : ".slider .nex",
            indexitemClass: "revolveinline",
            indexdom : '<li class="mr10"></li>',
            thatindexClass : "on"
        });
    }  
    /**
     *中部幻灯
     */
    $(".sliderinPicList").revolve({
        auto : true,
        autotime : 5000,
        item : ".inPicList ul",
        grope : ".inPicList .inner",
//        indexmain : ".slide-item",
        l : ".inPicList .pre",
        r : ".inPicList .nex"
        //indexitemClass: "revolveinline",
//        indexdom : ' ',
//        thatindexClass : " "
    });
        /**
     *精彩联盟幻灯
     */
//    $(".logoBoxOut").revolve({
//        auto : true,
//        autotime : 5000,
//        item : ".logoBox .inner li",
//        grope : ".logoBox .inner",
////        indexmain : ".slide-item",
//        l : ".logoBoxOut .pre",
//        r : ".logoBoxOut .nex"
//        //indexitemClass: "revolveinline",
////        indexdom : ' ',
////        thatindexClass : " "
//    });
    $(".logoBoxOut").addClass("oh").find(".inner").width($(".logoBoxOut .inner li").size() * ($(".logoBoxOut .inner li").width() + 32));
    $(".logoBoxOut .nex").on("click", function () {
        var b = $(".logoBox .inner li").width() + 32;
        $(".logoBox .inner").stop().animate({marginLeft: 0 - b}, function () {
            $(".logoBox li").eq(0).appendTo($(".logoBox .inner ul:eq(0)"));
            $(".logoBox .inner").css({marginLeft: 0})
        });
        return false;
    });
    $(".logoBoxOut .pre").on("click", function () {
        var b = $(".logoBox .inner li").width() + 32;
        $(".logoBox ul li:last").prependTo($(".logoBox ul:eq(0)"));
        $(".logoBox .inner").css({marginLeft: 0 - b});
        $(".logoBox .inner").stop().animate({marginLeft: 0}, function () {
            $(".logoBox .inner").css({marginLeft: 0});
        });
        return false;
    });
     var index=0;
    var auto=function(){
            if(index){
                      return false;
            }    // index=setInterval(function(){
            var b = $(".logoBox .inner li").width() + 32;
            $(".logoBox .inner").stop().animate({marginLeft: 0 - b},3000, function () {
                $(".logoBox li").eq(0).appendTo($(".logoBox .inner ul:eq(0)"));
                $(".logoBox .inner").css({marginLeft: 0});
                auto();
            });
     //   },100);
    };
    $(".logoBoxOut").hover(function(){
        $(".logoBoxOut .nex").trigger("click");
        index=1;
    },function(){
        index=0;
        auto();
    });
    auto();
     /**
      *南宁欢迎您
     */
    $(".nnArea-left .dpic").revolve({
        auto : true,
        autotime : 5000,
        item : ".dpic-li",
        grope : ".dpic-ul",
        indexmain : ".dpic-item-ul",
        l : ".nnArea-left .dpic .pre",
        r : ".nnArea-left .dpic .nex",
        // indexitemClass: "revolveinline",
        indexdom : '<li><img src="${src}" alt="" width="60" height="48"></li>',
        thatindexClass : "on"
    });
    /**
     *倒计时
     *
     */
    $(".countdown").countdown({
        call : function(t, da) {
            //t.html("剩余:" + da.d + "日" + da.h + "时" + da.M + "分" + da.s + "秒");
            da.d = da.d < 9 ? "0" + da.d : da.d;
            da.h = da.h < 9 ? "0" + da.h : da.h;
            da.M = da.M < 9 ? "0" + da.M : da.M;
            da.s = da.s < 9 ? "0" + da.s : da.s;
            t.find(".days").html(da.d);
            t.find(".hours").html(da.h);
            t.find(".minutes").html(da.M);
            t.find(".seconds").html(da.s);
        },
        end : function(t) {
            t.find(".days").html("00");
            t.find(".hours").html("00");
            t.find(".minutes").html("00");
            t.find(".seconds").html("00");
        }
    });
    // 赛程赛事 选项卡
    $.switchTab({
        tab:".schedule-tit ul li",
        con:".schedule-right .tableTd table",
        onClass:"on",
        evt:"click"
    });
})
/*
本代码由js代码网收集并编辑整理;
尊重他人劳动成果;
转载请保留js代码网链接 - www.jsdaima.com
*/