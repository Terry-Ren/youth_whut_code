// JavaScript Document
//导航菜单栏js
$(document).ready(function(){
					$("#muen li").hover(function(){
						$(this).children("a").addClass("active");
						//$(this).children(".secondbox").children(".second").slideDown(300);
						$(this).children(".secondbox").children(".second").show();
						//计算出三级导航偏移二级导航的left值
						var third_left = $(this).find(".second").css("width");
						$(this).find(".thirdbox").css("left",third_left);
					},function(){
						$(this).children("a").removeClass("active");
						//$(this).children(".secondbox").children(".second").slideUp(100);
						$(this).children(".secondbox").children(".second").hide();
					});
					
					$("#muen li:eq(0)").hover(function(){
						$(this).children("a").addClass("active2");
					},function(){
						$(this).children("a").removeClass("active2");
					});
					//三级导航显示隐藏
					$(".second_div").hover(function(){
						$(this).children(".thirdbox").show();
					},function(){
						$(this).children(".thirdbox").hide();
					});
					
					$(".second_div").hover(function(){
						$(this).css({"background":"#618ba8","color":"#fff"});
						$(this).children("a").css("color","#fff");
					},function(){
						$(this).css({"background":"#fff","color":"#fff"});
						$(this).children("a").css("color","#999");
					});
    /*
                     //翻页效果
					$(".num_nav").children().children().eq("1").children("input").hide();
					var nav_a = $(".num_nav").children().children().eq("1").children("a");
					var nav_span = $(".num_nav").children().children().eq("1").children("span");
					for (var i = 0; i < nav_a.length; i++) {
					    var pageNumber = nav_a.eq(i).text();
					    pageNumber = parseInt(pageNumber.replace(/[^0-9]/ig, ""));
					    pageNumber = pageNumber - 1;
					    nav_a.eq(i).text("[" + pageNumber + "]");
					    if (pageNumber == 0) {
					        nav_a.eq(i).hide();
					    }
					}
					for (var j = 0; j < nav_span.length; j++) {
					    var nowNumber = nav_span.eq(j).text();
					    if (nowNumber == "...") { }
					    else
					    {
					    nowNumber = parseInt(nowNumber.replace(/[^0-9]/ig, ""));
					    nowNumber = nowNumber - 1;
					    nav_span.eq(j).text("[" + nowNumber + "]");
					    }
					    if (nowNumber == 0) {
					        nav_span.eq(j).hide();
					    }
					}
					var b = $(".num_nav").children().children().eq("0").children("b");
					var pageNow = b.text();
					pageNow = parseInt(pageNow.replace(/[^0-9]/ig, ""));
					if (pageNow == 1) { }
                    else{
					pageNow = pageNow - 1;
					b.text(pageNow);
					}

					var span = $(".num_nav").children().children().eq("0").children("span");
					var pageNow2 = span.text();
					pageNow2 = parseInt(pageNow2.replace(/[^0-9]/ig, ""));
					pageNow2 = pageNow2 - 1;
					span.text(pageNow2);

                     //翻页列表
					var nav_a2 = $(".num_nav").children().children().eq("1").children("a");
					var ul_li = $(".news ul li");
					ul_li.hide();
					ul_li.slice((pageNow - 1) * 10 , pageNow*10).show();
	*/				
                    //领导照片隐藏
					    $(".td_one").remove();
				});     