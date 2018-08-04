(function($){
	//$('.tabHeading').click(function() {
		//alert("kk");
    //var $listSort = $('.tabHeading img');
    //if ($listSort.attr('images/add.gif')) {
        //$listSort.removeAttr('images/add.gif');
    //} else {
        //$listSort.attr('images/edit.gif');
        //$('.tabHeading img').toggleAttr( 'images/edit.gif', 'images/add.gif', 'images/edit.gif' );
 
//});
    $('.tabHeading p').hide();
	$('.tabHeading').on({
    'click': function() {
         var src = ($('.tabHeading img').attr('src') === 'images/add.gif')
            ? 'images/edit.gif'
            : 'images/add.gif';
         $('.tabHeading img').attr('src', src);
         $('p').slideToggle();
    }
});
	$(".fieldset legend").click(function(){
		$(this).parent().toggleClass("close");
		$(".filtersContainer").slideToggle();
	}); 
	$(".statusActionToggle").hide();
	$(".statusActionBtn").click(function(){
		//$(".statusActionToggle").slideToggle(); 
		$(this).parent().children(".statusActionToggle").slideToggle(); 
	});
    $(".checkedActionBtn a").click(function(){
        $(".splitdropdown").slideToggle();
    });1

    $('.bootstrap-switch-wrapper').click(function(){
        if($(this).hasClass('bootstrap-switch-off')){
            $(this).removeClass('bootstrap-switch-off');
            $(this).addClass('bootstrap-switch-on');
            $('.bootstrap-switch-container').css('margin-left','0');
            $('.bt-link-schedule-item--datetime-picker').hide();
            $('.sheduleItemHolder').show();
        }else{
            $(this).addClass('bootstrap-switch-off');
            $(this).removeClass('bootstrap-switch-on');
            $('.bootstrap-switch-container').css('margin-left','-71px');
            $('.bt-link-schedule-item--datetime-picker').show();
            $('.sheduleItemHolder').hide();
        }
    });






   $('.panel-heading').click(function(){
     $('#selectSedualedItem').hide();
   });




})(jQuery);  
