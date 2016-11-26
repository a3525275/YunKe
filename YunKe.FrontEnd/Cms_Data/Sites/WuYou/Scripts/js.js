$(function(){
	//页面二维码
	$('.top_nav_jiantou,#erweima').hover(function(){
		$('#erweima').show();
	},function(){
		$('#erweima,#erweima').hide();
	});
});

//登陆挑选框
$(function(){
	var click_b_mark=true;//给复选框定义标记
	$('.checked_button').click(function(){
		if(click_b_mark){//为真添加勾选class
			$('.checked_button').addClass('style');
		}else{//否则去除勾选class
			$('.checked_button').removeClass('style');
		}
		click_b_mark=!click_b_mark;
	});
});

//banner轮播
$(function(){
	jQuery(".banner_box,.banner2_box").slide({mainCell:".bd",autoPlay:true,delayTime:1000});
});

//公告tab
$(function(){
	$('.gonggao_tab a').click(function(){
		var gonggao_tab=$(this).index();
		$(this).addClass('style').siblings().removeClass('style');
		$('.gonggao_text ul').eq(gonggao_tab).show().siblings().hide();
	});	
});

//收费导航tab
$(function(){
	$('.shoufei_nav li').click(function(){
		var demo_box=$(this).index();
		$(this).addClass('style').siblings().removeClass('style');	
		$('.demo_box ul').eq(demo_box).show().siblings().hide();
	});	
});

//建站模板左右切换
$(function(){
	jQuery(".mokuai_img_box").slide({autoPage:true,effect:"left",autoPlay:true,vis:4});
	jQuery(".xinwen_img_box").slide({autoPage:true,effect:"left",autoPlay:true,vis:1});
});


//建站模版鼠标经过离开
$(function(){
	$('.moban_01 img').hover(function(){
		$(this).siblings('.moban_01_hover').show('slow');
	});
	$('.moban_01').hover(function(){
	},function(){
		$(this).children('.moban_01_hover').hide('fast');
	});
});


//新闻页面tab切换
$(function(){
	$('.xw_tab_set .tab li').click(function(){
		var xw_text_box_ul=$(this).index();
		$(this).addClass('style').siblings().removeClass('style');	
		$('.xw_text_box ul').eq(xw_text_box_ul).show().siblings().hide();
	});	
});


