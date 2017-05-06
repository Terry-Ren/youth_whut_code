(function ($, w, d) {
    var win = $(w), docu = $(d), _body = d.body, b = $(_body);
    $.extend({
        /**
         * Object 转 JSON String
         * @param {Object} c
         * @return {String}
         */
        toJSON: function (c) {
            var JSON = w.JSON;
            if (typeof (JSON) == "object" && JSON.stringify) {
                return JSON.stringify(c)
            }
            var m = typeof (c);
            if (c === null) {
                return "null";
            }
            if (m == "undefined") {
                return undefined;
            }
            if (m == "number" || m == "boolean") {
                return c + "";
            }
            if (m == "string") {
                return $.quoteString(c);
            }
            if (m == "object") {
                if (typeof c.toJSON == "function") {
                    return $.toJSON(c.toJSON());
                }
                if (c.constructor === Date) {
                    var l = c.getUTCMonth() + 1;
                    if (l < 10) {
                        l = "0" + l;
                    }
                    var p = c.getUTCDate();
                    if (p < 10) {
                        p = "0" + p;
                    }
                    var n = c.getUTCFullYear();
                    var q = c.getUTCHours();
                    if (q < 10) {
                        q = "0" + q;
                    }
                    var f = c.getUTCMinutes();
                    if (f < 10) {
                        f = "0" + f;
                    }
                    var r = c.getUTCSeconds();
                    if (r < 10) {
                        r = "0" + r;
                    }
                    var h = c.getUTCMilliseconds();
                    if (h < 100) {
                        h = "0" + h;
                    }
                    if (h < 10) {
                        h = "0" + h;
                    }
                    return '"' + n + "-" + l + "-" + p + "T" + q + ":" + f + ":" + r + "." + h + 'Z"';
                }
                if (c.constructor === Array) {
                    var j = [];
                    for (var g = 0; g < c.length; g++) {
                        j.push($.toJSON(c[g]) || "null");
                    }
                    return "[" + j.join(",") + "]";
                }
                var b = [];
                for (var e in c) {
                    var a;
                    var m = typeof e;
                    if (m == "number") {
                        a = '"' + e + '"';
                    } else {
                        if (m == "string") {
                            a = $.quoteString(e);
                        } else {
                            continue;
                        }
                    }
                    if (typeof c[e] == "function") {
                        continue;
                    }
                    var d = $.toJSON(c[e]);
                    b.push(a + ":" + d);
                }
                return "{" + b.join(", ") + "}";
            }
        },
        /**
         * 非访问函数
         */
        quoteString: function (a) {
            return '"' + a + '"';
        },
        /**
         * JSON String 转 Object
         * 不建议使用
         * @param {String} src
         * @return {Object}
         */
        evalJSON: function (src) {
            var JSON = w.JSON;
            if (typeof (JSON) == "object" && JSON.parse) {
                return JSON.parse(src);
            }
            return eval("(" + src + ")");
        },
        /**
         * JSON String 转 Object
         * @param {String} src
         * @return {Object}
         */
        secureEvalJSON: function (src) {
            var JSON = w.JSON;
            if (typeof (JSON) == "object" && JSON.parse) {
                return JSON.parse(src);
            }
            var filtered = src;
            filtered = filtered.replace(/\\["\\\/bfnrtu]/g, "@");
            filtered = filtered.replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, "]");
            filtered = filtered.replace(/(?:^|:|,)(?:\s*\[)+/g, "");
            if (/^[\],:{}\s]*$/.test(filtered)) {
                return eval("(" + src + ")");
            } else {
                throw new SyntaxError("Error parsing JSON, source is not valid.");
            }
        },
        /**
         * 替换字符串
         * 支持原生
         * @param {String} template
         * @param {Object} map
         */
        substitute: function (template, map) {
            return template.replace(/\$\{([^\s\:\}]+)(?:\:([^\s\:\}]+))?\}/g, function (match, key, format) {
                if (map[key]) {
                    return map[key];
                } else if (map[key] === 0) {
                    return "0";
                } else {
                    return match;
                }
            });
        },
        /**
         * 获取GET参数
         * @param {String/null} query
         */
        getArgs: function (query) {
            if (!query) {
                query = w.location.search.substring(1);
            } else {
                query = query.split("?");
                query = query[query.length - 1];
            }
            var pairs = query.split("&"), args = {};
            for (var i = 0; i < pairs.length; i++) {
                var pos = pairs[i].indexOf('=');
                if (pos == -1) {
                    continue;
                }
                var argname = pairs[i].substring(0, pos), value = pairs[i].substring(pos + 1);
                value = $.decodeURI(value);
                args[argname] = value;
            }
            return args;
        },
        /**
         * 转换UTF编码[%40到@]
         * @param {String} str
         */
        decodeURI: function (str) {
            return w.decodeURIComponent(str);
        },
        /**
         * 转换到UTF编码[@到%40]
         * @param {String} str
         */
        encodeURI: function (str) {
            return w.encodeURIComponent(str);
        },
        /**
         * 获取/设置 cookie
         * @param {String} name
         * @param {String} value
         * @param {Object} options
         */
        cookie: function (name, value, options) {
            if (typeof value != 'undefined') {// name and value given, set
                // cookie
                options = options || ( {});
                if (value === null) {
                    value = '';
                    options.expires = -1;
                }
                var expires = '';
                if (options.expires && ( typeof options.expires == 'number' || options.expires.toUTCString)) {
                    var date;
                    if (typeof options.expires == 'number') {
                        date = new Date();
                        date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
                    } else {
                        date = options.expires;
                    }
                    expires = '; expires=' + date.toUTCString();
                    // use
                    // expires
                    // attribute,
                    // max-age
                    // is
                    // not
                    // supported
                    // by IE
                }
                var path = options.path ? '; path=' + options.path : '; path=/';
                var domain = options.domain ? '; domain=' + options.domain : '';
                var secure = options.secure ? '; secure' : '';
                d.cookie = [name, '=', w.encodeURIComponent(value), expires, path, domain, secure].join('');
            } else {
                var cookieValue = null;
                if (d.cookie && d.cookie != '') {
                    var cookies = d.cookie.split(';');
                    for (var i = 0; i < cookies.length; i++) {
                        var cookie = $.trim(cookies[i]);
                        if (cookie.substring(0, name.length + 1) == (name + '=')) {
                            cookieValue = w.decodeURIComponent(cookie.substring(name.length + 1));
                            break;
                        }
                    }
                }
                return cookieValue;
            }
        },
        /**
         * Date到String
         * @param {Date/null} value yyyy mm dd HH:MM:SS w?
         * @param {String} type
         */
        format: function (value, type) {
            if (!type) {
                type = value;
                value = new Date();
            }
            if ($.type(value) !== "date") {
                value = new Date();
            }
            return type.replace(/yyyy/g, value.getFullYear()).replace(/mm/g, value.getMonth() + 1).replace(/dd/g, value.getDate()).replace(/HH/g, value.getHours()).replace(/MM/g, value.getMinutes()).replace(/SS/g, value.getSeconds());
        },
        /**
         * AJAX包装方法
         */
        service: function (key) {
            if (!(key && key.url)) {
                console && console.log ? alert("未填写URL") : console.log("未填写URL");
                return !1;
            }
            var k = {
                type: 'POST',
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                timeout: 5000,
                //                jsonp: 'callback',
                data: {},
                error: function (err) {
                    //console.error("error");
                    //console.error(err);
                    // console.error(key);
                }
            };
            var empty = {};
            var solf = this;
            $.extend(empty, k, key);
            //empty.data.date = new Date().getTime();
            empty.url = urlmap[key.url];
            empty.success = function (json) {
                try {
                    key.success(json);
                } catch (e) {
                    empty.error(e);
                }
            };
            $.ajax(empty);
        },
        /**
         * 动画定时器方法~
         * {int} frame 帧数
         * {function} call 回调方法 foot 回调参数 步数
         */
        ani: function (args) {
            var arg = {
                frame: 25
                //duration: 1000,
                //            call: function(foot){
                //                return !0;
                //            }
            };
            args = $.extend(args, arg);
            var f = (1000 / args.frame) | 0;
            var dt = 0, d = (args.duration / f) > (args.duration / f) | 0 ? ((args.duration / f) | 0) + 1 : (args.duration / f) | 0;
            var index = w.setInterval(function () {
                dt++;
                //console.log(args.call(dt))
                if (dt > d || !(args.call(dt, d))) {
                    w.clearInterval(index);
                }
            }, f);
        },
        /**
         * 弹出框
         * @param {Object} args
         */
        pop: function (args) {
            args.bullet ? args.bullet = $(args.bullet) : ((function () {
                throw new Error("大虾你要弹出个虾米东西??偶么知道!");
            })());
            var arg = {
                //  bullet: "",
                //  mask: "",
                target: win

            }, empty = {}, position = "absolute", offset = {
                top: 0,
                left: 0
            };
            $.extend(empty, arg, args);
            empty.target == win || empty.target == w ? ( position = "fixed", empty.target = win) : (empty.target = $(empty.target), offset = empty.target.offset());
            if ($.browser.msie && $.browser.version == "6.0") {
                position = "absolute";
            }
            var that = function () {
                var top = offset.top + empty.target.height() / 2 - empty.bullet.height() / 2;
                var left = offset.left + empty.target.width() / 2 - empty.bullet.width() / 2;
                if (empty.mask) {
                    empty.mask = $(empty.mask).appendTo(b).css({
                        position: position,
                        top: offset.top,
                        left: offset.left,
                        width: empty.target.width(),
                        height: empty.target.height()
                    }).hide();
                }
                empty.bullet.appendTo(b);
                empty.bullet.css({
                    position: position,
                    top: top,
                    left: left
                });
                return that.show();
            };
            that.show = function () {
                empty.bullet.show();
                empty.mask ? empty.mask.show() : null;
                if ($.browser.msie && $.browser.version == "6.0") {
                    $("select").css("visibility", "hidden");
                }
                return that;
            };
            that.hide = function () {
                empty.bullet.hide();
                empty.mask ? empty.mask.hide() : null;
                if ($.browser.msie && $.browser.version == "6.0") {
                    $("select").css("visibility", "inherit");
                }
                return that;
            };
            // $(w).bind("resize", function(evt) {
            // that();
            // });
            return that();
        },
        mousePos: function (e) {
            var x, y;
            var e = e || win.event;
            return {
                x: e.clientX + _body.scrollLeft + d.documentElement.scrollLeft,
                y: e.clientY + _body.scrollTop + d.documentElement.scrollTop
            };
        },
         /**
         *tab切换方法
         *@param {String} tab 要切换的tab的选择器
         *@param {String} con 要切换的对应内容的选择器，可选
         *@param {String} onClass 当前tab要添加的类名
         *@param {String} evt 要触发切换的事件
         *@param {Function} callback 切换完成后执行的函数, 参数：当前tab,切换到的con
         */
        switchTab: function (args) {
            if (!args.tab) throw new Error("没定义要切换的tab的选择器！");
            var opt = {
                onClass: "on",
                evt: "click"
            };
            $.extend(opt, args);
            var tab = $(opt.tab), con = opt.con ? $(opt.con) : null;
            tab.eq(0).addClass(opt.onClass);
            con.hide();
            con.eq(0).show();
            tab.on(opt.evt, function () {
                tab.removeClass(opt.onClass);
                $(this).addClass(opt.onClass);
                if (con && con.length > 0) {
                    con.hide();
                    con.eq(tab.index($(this))).show();
                }
                opt.callback && opt.callback($(this), con.eq(tab.index($(this))));
                return false;
            });
        },
        total: function () {
            var t = 0, that = function () {
                return Number(t).toFixed(2);
            }, a = function (n) {
                if ($.isNumeric(n)) {
                    t = (Number(t) + Number(n)).toFixed(2);
                }
            }, b = function (n) {
                if ($.isNumeric(n)) {
                    t = (Number(t) - Number(n)).toFixed(2);
                }
            }, c = function (n) {
                if ($.isNumeric(n)) {
                    t = (Number(t) * Number(n)).toFixed(2);
                }
            }, d = function (n) {
                if (n == 0) {
                    alert("除数是零吗??");
                    throw new Error("除数是零吗??");
                }
                if ($.isNumeric(n)) {
                    t = (Number(t) / Number(n)).toFixed(2);
                }
            }, tostring = function () {
                return Number(t).toFixed(2);
            }, add = function () {
                $.each(arguments, function (i, n) {
                    if ($.isArray(n)) {
                        $.each(n, function (x, y) {
                            add(y);
                        });
                    } else {
                        a(n);
                    }
                });
                return that;
            }, red = function () {
                $.each(arguments, function (i, n) {
                    if ($.isArray(n)) {
                        $.each(n, function (x, y) {
                            red(y);
                        });
                    } else {
                        b(n);
                    }
                });
                return that;
            }, mul = function () {
                $.each(arguments, function (i, n) {
                    if ($.isArray(n)) {
                        $.each(n, function (x, y) {
                            red(y);
                        });
                    } else {
                        c(n);
                    }
                });
                return that;
            }, exc = function () {
                $.each(arguments, function (i, n) {
                    if ($.isArray(n)) {
                        $.each(n, function (x, y) {
                            exc(y);
                        });
                    } else {
                        d(n);
                    }
                });
                return that;
            }, arr = [];
            $.each(arguments, function (i, n) {
                arr.push(n);
            });
            add(arr);
            that.toString = tostring;
            that["+"] = that.add = add;
            that["-"] = that.red = red;
            that["x"] = that.mul = mul;
            that["/"] = that.exc = exc;
            return that;
        }
    });
    $.fn.extend({
        gotop: function (ages) {
            var that = $(this), age = {
                //偏差量
                devi: 100,
                //
                call: function (t) {
                    if (win.scrollTop() < ages.devi) {
                        t.hide();
                    } else {
                        t.show();
                    }
                    win.scroll(function (evt) {
                        if (win.scrollTop() < ages.devi) {
                            t.hide();
                        } else {
                            t.show();
                        }
                    });
                },
                //移动动画
                ani: function () {
                    //win.animate({scroll:0});
                    var top = win.scrollTop();
                    //                    console.log(top);
                    //$.each()
                    $.ani({
                        duration: 500,
                        call: function (foot, d) {
                            var f = top / d | 0;
                            if (foot == d) {
                                win.scrollTop(0);
                            } else {
                                win.scrollTop(top - f * foot);
                            }
                            return !0;
                        }
                    });
                    //                    win.scrollTop(0);
                },
                //移入动画
                mov: function () {
                    //                    console.log("===");
                },
                //移出动画
                out: function () {
                    //that.fadeOut("slow");
                    //                    console.log("=out=");
                }
            };
            ages = ages || ( {});
            var e = {}
            $.extend(e, age, ages);
            that.each(function (x, y) {
                var t = $(y);
                e.call(t);
                t.bind("mouseover",function () {
                    e.mov();
                }).bind("mouseout",function () {
                        e.out();
                    }).bind("click", function () {
                        e.ani();
                        return !1;
                    });
            });
        },
        revolve : function(args) {
            var win = $(w), arg = {
                auto : !1,
                autotime : 1000,
                item : ".item",
                grope : ".itemmain",
                indexmain : ".index",
                l : "",
                r : "",
                indexdom : "<li class='grup'>${i}</li>",
                begin : function(index, that) {
                }
                //				,
                //                call: function(index, that){
                //					return index;
                //                }
                //				,
                //				locate:function(index){
                //					return index;
                //				}
            };
            this.map(function(x, y) {
                var empty = {};
                var indexitem;
                $.extend(empty, arg, args);
                var that = $(y), grope = that.find(empty.grope), items = that.find(empty.item), w = items.outerWidth(true), fnarr = [];
                var index = 0, z = 0, indexmain = that.find(empty.indexmain);
                that.css({
                    overflow : "hidden",
                    position : "relative"
                });
                grope.css({
                    overflow : "hidden",
                    width : w * items.length+100
                });
                items.each(function(i, n) {
                    var item = $(n);
                    fnarr[i] = function(call) {
                        empty.begin(i, item);
                        indexitem.filter("." + empty.thatindexClass).removeClass(empty.thatindexClass);
                        indexitem.eq(i).addClass(empty.thatindexClass);
                        //console.log(indexmain.find(empty.indexdom))
                        grope.stop().animate({
                            "margin-left" : w * i * -1
                        }, 500, null, function() {
                            //empty.call(i, item);
                            call && (call());
                        });
                        return i;
                    };
                    var c = function() {
                        return $($.substitute(empty.indexdom, {
                            i : i + 1 ,
                            src:item.attr("src")||item.find("img").attr("src")
                        })).appendTo(indexmain).addClass(empty.indexitemClass).bind("click", function() {
                                indexmain.find("." + empty.thatindexClass).removeClass(empty.thatindexClass);
                                fnarr[i](null);
                                index = i;
                                $(this).addClass(empty.thatindexClass);
                                return !1;
                            });
                    };
                    i == 0 ? indexitem = c().addClass(empty.thatindexClass) : indexitem = indexitem.add(c());
                });
                var a = function() {
                    z = setTimeout(function() {
                        if (empty.auto) {
                            fnarr[index] ? index = index : index = 0;
                            fnarr[index++](a);
                        } else {
                            clearTimeout();
                        }
                    }, empty.autotime);
                };
                $(empty.l).on("click", function() {
                    fnarr[index - 1] ? index = index - 1 : index = fnarr.length - 1;
                    indexmain.find("." + empty.indexitemClass).removeClass(empty.thatindexClass);
                    fnarr[index](null);
                    indexmain.find("." + empty.indexitemClass).eq(index).addClass(empty.thatindexClass);
                    return !1;
                });
                $(empty.r).on("click", function() {
                    fnarr[index + 1] ? index = index + 1 : index = 0;
                    indexmain.find("." + empty.indexitemClass).removeClass(empty.thatindexClass);
                    fnarr[index](null);
                    indexmain.find("." + empty.indexitemClass).eq(index).addClass(empty.thatindexClass);
                    return !1;
                });
                if (empty.auto) {
                    a();
                    that.bind("mouseover", function() {
                        clearTimeout(z);
                        empty.auto = !1;
                    }).bind("mouseout", function() {
                            empty.auto = !0;
                            a();
                        });
                }

            });
        },
        boxTip: function (option) {
            var options = $.extend({
                event: "mouseover",
                msg: "提示信息",
                defaultStyle: !1
            }, option || {});
            var objevent = options.event;
            var b = (objevent == "mouseover") || (objevent == "mousemove") ? "mouseout" : "mouseleave";
            $.each(this, function () {
                a(this).on(objevent,function (e) {
                    var src = options.msg;
                    var eleOut = $("#mjstip");
                    if (eleOut.length > 0) {
                        eleOut.html(src);
                    } else {
                        if (options.defaultStyle) {
                            b.append('<div id="mjstip" class="boxtip" style="position:absolute;left:0;top:0;display: none;*width: 190px;">' + src + '</div>');
                        } else {
                            b.append('<div id="mjstip" class="boxtip" style="position:absolute;left:0;top:0;display: none;border: 1px solid #878787;padding: 10px; background-color: #fff; box-shadow: 0 0 5px #555;*width: 190px;">' + src + '</div>');
                        }
                    }
                    var mouse = $.mousePos(e);
                    var cssObj = {
                        'left': mouse.x + 10 + 'px',
                        'top': mouse.y + 'px',
                        'display': 'block'
                    }
                    $("#mjstip").css(cssObj);
                }).on(b, function (e) {
                        $("#mjstip").css("display", "none");
                    });
            })
        },
        outerHTML: function (s) {//模拟javascript    outerHTML
            return (s) ? this.before(s).remove() : a("<p>").append(this.eq(0).clone()).html();
        },
        PlaceHolder: function (op) {//placeholder
            var that = $(this), defaults = {
                maskClass: 'inputMask',
                maskName: 'inputMask', //mask标识(id)的前缀，生成诸如inputMask1、inputMask2......
                color: 'fc-gray', //mask字体的颜色
                autoFix: !1
            };
            var opts = $.extend(defaults, op || {});
            var _support = function () {//检测浏览器是否支持'placeholder'属性
                return 'placeholder' in document.createElement('input');
            }();
            var MakeMask = function ($obj, order) {
                if (opts.autoFix) {
                    var _x = $obj.position().left, _y = $obj.position().top;
                    var _h = $obj.outerHeight();
                    var $mask = $('<span style="display:inline-block; position:absolute; zIndex:100; top:' + _y + 'px; left:' + (_x + 6) + 'px; height:' + _h + 'px; line-height:' + _h + 'px;"></span>').addClass(opts.color).attr('id', opts.maskName + order).text($obj.attr('placeholder')).insertBefore($obj);
                } else {
                    var $mask = $('<span></span>').addClass(opts.maskClass).attr('id', opts.maskName + order).text($obj.attr('placeholder')).insertBefore($obj);
                }
                $mask.click(function (e) {
                    that.hide().next().focus();
                });
            };
            that.each(function (index, n) {
                var $self = $(n);
                if (!_support && $self.get(0).attributes && $self.get(0).attributes.placeholder) {
                    $self.val('');
                    MakeMask($self, index);
                    $self.focus(function (e) {
                        $('#' + opts.maskName + index).hide();
                    }).blur(function (e) {
                            if ($self.val() === '') {
                                $('#' + opts.maskName + index).fadeIn(300);
                            }
                        });
                }
            });
        },
        Jdropdown: function (callback) {
            $(this).each(function (i, n) {
                var $self = $(n);
                $self.hover(function () {
                    $self.addClass('hover');
                    callback ? callback.apply(n) : !1;
                }, function () {
                    $self.removeClass('hover');
                });
            });
        },
        countdown : function(args) {
            args = args || ( {});
            var arg = {
                data : "date-countdown",
                call : function(t, da) {
                    t.html("剩余:" + da.d + "日" + da.h + "时" + da.M + "分" + da.s + "秒");
                },
                end : function(t) {
                    t.html("结束!");
                }
            }, empty = {}, THIS = this,code;
            $.extend(empty, arg, args);
            var fn = function() {
                THIS.each(function(i, n) {
                    var that = $(n);
                    var data = Number(that.attr(empty.data));
                    if (data > 1000) {
                        var d = (data / 86400000) | 0;
                        var h = ((data - d * 86400000) / 3600000) | 0;
                        var M = ((data - d * 86400000 - h * 3600000) / 60000) | 0;
                        var s = ((data - d * 86400000 - h * 3600000 - M * 60000) / 1000) | 0;
                        empty.call(that, {
                            d : d,
                            h : h,
                            M : M,
                            s : s
                        });
                        that.attr(empty.data, data - 1000);
                    } else if (data >= 0) {
                        empty.end(that);
                        that.attr(empty.data, -1);
                        clearInterval(code);
                    }
                });
            };
            code=setInterval(function() {
                fn();
            }, 1000);
            fn();
        },
       
        getPage: function (age) {
            //初始值//
            var ages = {
                size: 1,
                index: 0,
                diffe: 2,
                pageDom: '<a href="#${i}" class="page-i">${i}</a>',
                slur: ' <span>...</span>',
                thatClass: "on",
                call: function (i) {
                },
                pageUp: {
                    dom: '<a href="#" class="pageUp">&#60;</a>',
                    readClass: "read"
                },
                pageDown: {
                    dom: '<a href="#" class="pageDown">&#62;</a>',
                    readClass: "read"
                },
                goPage: {
                    inputdom: '<i>到第</i><input type="text" class="toPage" value="${i}"><i>页</i>',
                    submitdom: '<input type="submit" value="确定" class="jump">'
                },
                sizeerror: function () {
                },
                init: false
            };
            var that = $(this);
            age = age || ( {});
            var e = {};
            var init = e.init;
            var gopage;
            //格式化初始数据//
            $.extend(e, ages, age);
            e.size = Number(e.size);
            e.size < 1 ? e.size = 1 : null;
            // e.index = Number(e.index);
            if (e.size == 1) {
                e.sizeerror();
                return false;
            }
            var call = function (i) {
                fn(i);
                return false;
            };
            var fn = function (index) {
                index = Number(index);
                //if(){return false;}
                !index ? index = 1 : null;
                index < 1 ? index = 1 : null;
                index >= e.size ? index = e.size : null;
                var begin = 0, end = 0;
                that.empty();
                //			$each()
                ////////
                init ? e.call(index) : null;
                init = true;
                ////////
                index <= e.diffe + 1 ? begin = 1 : begin = index - e.diffe - 1;
                index >= e.size - e.diffe - 1 ? end = e.size - 1 : end = index + e.diffe;
                //e.size < 3 ? begin = 1 : begin = e.size - 2;
                var pageUp = $(e.pageUp.dom).appendTo(that).on("click", function () {
                    if ($(this).is("." + e.pageUp.readClass)) {
                        return false;
                    }
                    return call(Number(that.find("." + e.thatClass).attr("name")) - 1);
                });
                var beginPage = $($.substitute(e.pageDom, {
                    i: 1
                })).attr("name", 1).appendTo(that).on("click", function () {
                        return call(1);
                    });
                index == 1 ? (pageUp.addClass(e.pageUp.readClass), beginPage.addClass(e.thatClass)) : null;
                index <= e.diffe + 2 ? null : that.append(e.slur);
                for (var i = begin + 1; i <= end; i++) {
                    var p = $($.substitute(e.pageDom, {
                        i: i
                    })).attr("name", i).appendTo(that).on("click", function () {
                            ;
                            return call($(this).attr("name"));
                        });
                    ;
                    if (i == index) {
                        p.addClass(e.thatClass);
                    }
                }
                ;
                index >= e.size - e.diffe - 1 ? null : that.append(e.slur);
                var endPage = $($.substitute(e.pageDom, {
                    i: e.size
                })).attr("name", e.size).appendTo(that).on("click", function () {
                        return call(e.size);
                    });
                var pageDown = $(e.pageDown.dom).appendTo(that).on("click", function () {
                    if ($(this).is("." + e.pageUp.readClass)) {
                        return false;
                    }
                    return call(Number(that.find("." + e.thatClass).attr("name")) + 1);
                });
                ;
                index == e.size ? (pageDown.addClass(e.pageDown.readClass), endPage.addClass(e.thatClass)) : null;
//                if (e.goPage) {
//                    gopage = $($.substitute(e.goPage.inputdom, {
//                        i: index
//                    })).appendTo(that);
//                    var jump = $($.substitute(e.goPage.submitdom, {
//                        i: e.index
//                    })).appendTo(that).on("click", function () {
//                            //fn(gopage.filter("input[type='text']").val());
//                            //fn(e.index)
//                            //  e.call(index);
//                            return call(gopage.filter("input[type='text']").val());
//                        });
//                }
            };
            that.setSize = function (num) {
                e.size = Number(num);
            };
            fn(e.index);
            return that;
        }
    });
})(jQuery, window, document);
function share_to(toStr){
    var titleStr = document.title ;
    var hrefStr = window.location.href ;
    var picStr = document.getElementById('previewImg').src ;
    var shareUri = "" ;
    //renren
    if(toStr == "renren"){
        shareUri = "http://widget.renren.com/dialog/share?resourceUrl="+hrefStr+"&srcUrl="+hrefStr+"&pic="+picStr+"&title="+titleStr+"&description="+titleStr+"&charset=UTF-8" ;
        //xinlang
    }else if(toStr == "tsina"){
        shareUri = "http://service.weibo.com/share/share.php?url="+hrefStr+"&title="+titleStr+"&pic="+picStr+"&searchPic=false&language=zh_cn&style=simple"
        //qqZone
    }else if(toStr == "qq"){
        shareUri = "http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url="+hrefStr+"&desc="+titleStr+"&summary="+titleStr+"&title="+titleStr+"&site=&pics="+picStr ;
        //qq weibo
    }else if(toStr == "tqq"){
        shareUri = "http://share.v.t.qq.com/index.php?c=share&a=index&url="+hrefStr+"&pic="+picStr+"&appkey=&title="+titleStr;
        //kaixin starid:(可选)公共主页id  aid:(可选)显示分享来源  showcount:是否显示分享数  style:显示样式
    }else if(toStr == "kaixin001"){
        shareUri = "http://www.kaixin001.com/rest/records.php?url="+hrefStr+"&content="+titleStr+"&pic="+picStr;
        //douban
    }else if(toStr == "douban"){
        shareUri = "http://www.douban.com/recommend/?url="+hrefStr+"&title="+titleStr+"&sel="+picStr+"&v=1" ;
    }
    if(shareUri == ""){
        alert("此接口异常！") ;
    }
    window.open(shareUri) ;
}

$(function(){
    $(".nav ul > li").hover(function(){
        $(".nav li").removeClass("on");
        $(this).addClass("on");
    },function(){
        $(".nav li").removeClass("on");
    });
    $(".nav ul > li")/*.add(".nav ul > li:eq(12)")*/.hover(function(){
//        $(".nav li").removeClass("on");
//        $(this).addClass("on");
        $(this).find(".menunav").show();
    },function(){
        $(this).find(".menunav").hide();
    });
    $(".menunav li").hover(function(){
//        $(".menunav li").removeClass("selected");
        $(this).addClass("selected");
    },function(){
        $(this).removeClass("selected");
    });
});
/*
本代码由js代码网收集并编辑整理;
尊重他人劳动成果;
转载请保留js代码网链接 - www.jsdaima.com
*/