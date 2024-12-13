//disable click
//$(document).ready(function () {$("body").on("contextmenu",function(e){return false;});});
// font size
var current_Url = window.location.href;
$(document).ready(function(){
    $('.decrease-me').tooltip({title: "<span style='font-size:8px;'><strong>AAA</strong></span>", html: true, placement: "bottom"});
    $('.reset-me').tooltip({title: "<strong>AAA</strong>", html: true, placement: "bottom"});
    $('.increase-me').tooltip({title: "<h3><strong>AAA</strong></h3>", html: true, placement: "bottom"});
});
// login form validation
//if (current_Url.match(/https\:\/\/egreetings\.gov\.in\/login.*/) || current_Url.match(/https\:\/\/www\.egreetings\.gov\.in\/login.*/)){
if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/login.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/login.*/)){
(function($,W,D){var JQUERY4U = {};
    JQUERY4U.UTIL = {setupFormValidation: function(){
	$("#nic_gv").validate({
                rules: {nic_email:{required: true,},nic_password: {required: true,},nic_cap: {required: true,}
                },
                messages: {nic_email:{required:"*Please enter your NIC/GOV Email Address"},nic_password:{required:"*Please enter your password",},nic_password:{required:"*Please enter captcha value",}},
                submitHandler: function(form) {}
            });	} }
    $(D).ready(function($) {JQUERY4U.UTIL.setupFormValidation();});
})($, window, document);}
//custom message disbale
function chkind(){
	var e_select_message = document.getElementById('e_select_message').value;
	var a = document.getElementById('e_select_message').options[document.getElementById('e_select_message').selectedIndex].text;
	var e_custom_message = document.getElementById('e_custom_message');
	if(e_select_message != '0')
        {e_custom_message.value = a;document.getElementById("e_custom_message").disabled = true;}
        else {document.getElementById("e_custom_message").value = '';document.getElementById("e_custom_message").disabled = false;}
}
// limit text character count.
function limitText(limitField, counter_id, limitNum)
{
	if (document.getElementById('e_custom_message').value.length > limitNum)
        {document.getElementById('e_custom_message').value = document.getElementById('e_custom_message').value.substring(0, limitNum);}
	else {document.getElementById(counter_id).innerHTML = limitNum - document.getElementById('e_custom_message').value.length;}
}
// theme section picker etc
function picker(color)
{
	if( color == "selectcolor" )
        {$('.thm1').show();$('.thm2').hide(); $('#Themeid').val("Default");}
        else if( color == "selecttheme" )
        {$('.thm2').show();$('.thm1').hide();$('#bgcolor').val("#1967a7");$('#txtcolor').val("#00f000");}
}
//colorpicker js
$(function () {$('#cp2').colorpicker(); });
$(function () {$('#cp3').colorpicker(); });
//e_select_msg 
$(document).ready(function () {
//if (current_Url.match(/https\:\/\/egreetings\.gov\.in\/customize\-.*/) && !current_Url.match(/https\:\/\/egreetings\.gov\.in\/customize\-custom.*/) && !current_Url.match(/https\:\/\/egreetings\.gov\.in\/customize\-gif.*/) || current_Url.match(/https\:\/\/www\.egreetings\.gov\.in\/customize\-.*/) && !current_Url.match(/https\:\/\/www\.egreetings\.gov\.in\/customize\-custom.*/) && !current_Url.match(/https\:\/\/www\.egreetings\.gov\.in\/customize\-gif.*/)){ 
if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\/customize\-.*/) && !current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/customize\-custom.*/) && !current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/customize\-gif.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/customize\-.*/) && !current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/customize\-custom.*/) && !current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/customize\-gif.*/)){ 
var e_select_message = document.getElementById('e_select_message').value;
if(e_select_message==0){document.getElementById("e_custom_message").disabled = false;}
else{document.getElementById("e_custom_message").disabled = true;}}
});
//read instruction popup for music
$(document).ready(function () {if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/customize\-.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/customize\-.*/)){$('#slide').popup({focusdelay: 400,outline: true,vertical: 'top'});}});
//read instruction popup for managecontactbook
$(document).ready(function () {if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/manage\-contactbook.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/manage\-contactbook.*/)){$('#slide').popup({focusdelay: 400,outline: true,vertical: 'top'});}});
//read instruction popup for csv/text
$(document).ready(function () {if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/recipients*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/recipients*/)){$('#slide').popup({focusdelay: 400,outline: true,vertical: 'top'});}});
//read instruction popup for upload GIF 
$(document).ready(function () {if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/index*/) || current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\//) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/index*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\//)){$('#slide').popup({focusdelay: 400,outline: true,vertical: 'top'});}});
//upload audio sections
function call(m){
  if( m == "browse" ){document.getElementById("res1").style.display = 'block';document.getElementById("res2").style.display = 'none';document.getElementById('Audioid').value = '';clear_audio();}
  else if( m == "select" ){document.getElementById("res2").style.display = 'block';document.getElementById("res1").style.display = 'none';}
}
//upload audio file trigger
$(function(){if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/customize\-.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/customize\-.*/)){$("#upload_btn").on('click', function(e){e.preventDefault();$("#file:hidden").trigger('click');});}});
//upload csv/text file trigger
$(function(){if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/recipients*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/recipients*/)){$("#rcpt_upload").on('click', function(e){e.preventDefault();$("#file:hidden").trigger('click');});}});
//upload csv/text file trigger
$(function(){if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/my\-account*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/my\-account*/)){$("#upload_pic").on('click', function(e){e.preventDefault();$("#usr_Pic:hidden").trigger('click');});}});
//quote or slogan section
function showMe (box,box1) {
	var chboxs = document.getElementsByName("c1");var vis = "none";
        for(var i=0;i<chboxs.length;i++) {if(chboxs[i].checked){vis = "block";break;} }
        document.getElementById(box).style.display = vis;document.getElementById(box1).style.display = vis;
}
//get quotes 
function GetQuotes(n)
{m = n;var html = '<select class="form-control" name="Qid" ><option value="" >--- Please Select A Quote ---</option>';
if(m != ""){$.ajax({url : "getQuote-"+m+".html",dataType : 'html',contentType : 'text/html',type : 'POST',success : function(data) {html = html + data;html = html + "</select>";$("#res").html(html);}});}
}
// light box for image zoom
$(document).ready(function() {
    var $lightbox = $('#lightbox');
    $('[data-target="#lightbox"]').on('click', function(event) {
        var $img = $(this).find('img'), 
            src = $img.attr('src'),
            alt = $img.attr('alt'),
            css = {
                'maxWidth': $(window).width() - 100,
                'maxHeight': $(window).height() - 100
            };
        $lightbox.find('.close').addClass('hidden');
        $lightbox.find('img').attr('src', src);
        $lightbox.find('img').attr('alt', alt);
        $lightbox.find('img').css(css);
    });
    $lightbox.on('shown.bs.modal', function (e) {
        var $img = $lightbox.find('img');
        $lightbox.find('.modal-dialog').css({'width': $img.width()});
        $lightbox.find('.close').removeClass('hidden');
    });
});
//add  and delete recipient rows
function GetDynamicTextBox(value){
	return '<div class="form_send_area"><div class="row form_mar"><div class="col-lg-6 form_mar"><input type="text" class="form-control edit_profile_select " id="exampleInputEmail1" placeholder="Full Name" name="txtRecepientName[]" maxlength="50"></div><div class="col-lg-6 form_mar" style="width: 46%;"><input type="email" class="form-control edit_profile_select " id="exampleInputEmail1" placeholder="Email Address" name="txtRecepientEmail[]"></div></div></div>'+'<button type="button" value="Remove" onclick="RemoveTextBox(this)" style="position: relative;float: right;margin-top: -65px;font-size: xx-large;background: none;border: none;" title="Remove Row"><i class="fa fa-remove"></i></button>';
}
function AddTextBox() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextBox("");
    document.getElementById("TextBoxContainer").appendChild(div);
}
function getrecp(sn,se){
        return '<div class="form_send_area"><div class="row form_mar"><div class="col-lg-6 form_mar"><input type="text" class="form-control edit_profile_select " id="exampleInputEmail1" placeholder="Full Name" name="txtRecepientName[]" value="'+sn+'" maxlength="50"></div><div class="col-lg-6 form_mar" style="width: 46%;"><input type="email" class="form-control edit_profile_select " id="exampleInputEmail1" value="'+se+'" placeholder="Email Address" name="txtRecepientEmail[]"></div></div></div>'+'<button type="button" value="Remove" onclick="RemoveTextBox(this)" style="position: relative;float: right;margin-top: -65px;font-size: xx-large;background: none;border: none;" title="Remove Row"><i class="fa fa-remove"></i></button>';
}
function srecp(sn,se) {
    var div = document.createElement('DIV');
    div.innerHTML = getrecp(sn,se);
    document.getElementById("TextBoxContainer").appendChild(div);
}
function RemoveTextBox(div) {
    document.getElementById("TextBoxContainer").removeChild(div.parentNode);
}
function RecreateDynamicTextboxes() {
    var values = eval('<%=Values%>');
    if (values != null) {
        var html = "";
        for (var i = 0; i < values.length; i++) {
            html += "<div>" + GetDynamicTextBox(values[i]) + "</div>";
        }
        document.getElementById("TextBoxContainer").innerHTML = html;
    }
}
//schedule date on recipient details
$('#sandbox-container .input-group.date').datepicker({todayHighlight: true,format: 'dd-M-yyyy',startDate: 'now'});
//dob date on contactbook
$('#sandbox-container-contactbook .input-group.date').datepicker({todayHighlight: true,format: 'yyyy-mm-dd',endDate: 'now'});
//DOB for user profile
$('#user_Dob .input-group.date').datepicker({format: 'dd-M-yyyy',todayHighlight: true,endDate: "now"});
//reset form 
function reset(){
$('#rcpt_Details')[0].reset();
$("#selected_rcpt").tagsinput('removeAll');
	$("tr").each(function(){
                $(this).find("td:eq(4) .addcnt").css('color','');
        });
}
//reset address book
function resetabook(){
$("#selected_rcpt").tagsinput('removeAll');
        $("tr").each(function(){
                $(this).find("td:eq(4) .addcnt").css('color','');
        });
}

//usr prof updt
$('#user_prof').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'updtProf/',
 type: 'POST',
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){ 
	var updtR=JSON.parse(data);fNm=updtR['fNm'];
        if(updtR['sNm']){$('.elogName').text('Welcome, '+updtR['sNm']);if(updtR['msg']){ $('input[name="csrf_token"]').val(updtR['csT']);$('#response_prof').fadeOut('slow', function(){ $('#response_prof').fadeIn('slow').html(updtR['msg']); $('#response_prof').fadeOut(10000); });$('input[name='+fNm+']').focus();}} else if(updtR['msg']){ $('input[name="csrf_token"]').val(updtR['csT']);$('#response_prof').fadeOut('slow', function(){ $('#response_prof').fadeIn('slow').html(updtR['msg']); $('#response_prof').fadeOut(10000); });$('input[name='+fNm+']').focus();}
    })
    .fail(function(){
	$('#response_prof').fadeIn('slow').html('<div class="alert alert-danger">Something Went Wrong..</div>'); $("#response_prof").fadeOut(10000);
    });
});
//upload pic to system
$(document).ready(function(e) {
	$(function() {
        $("#usr_Pic").change(function(){$("#resp-msg").empty();var file=this.files[0];var imagefile=file.type;var match=["image/jpeg", "image/png", "image/jpg"];
	if (!((imagefile == match[0]) || (imagefile == match[1]) || (imagefile == match[2]))) {
	$("#resp-msg").html("<div class='alert alert-danger'>Please Select A valid Image File <br/> Only jpeg, jpg and png Images type allowed</div>");$("#resp-msg").fadeOut(3000);
        return false;
        }else {var reader=new FileReader();reader.onload=imageIsLoaded;reader.readAsDataURL(this.files[0]);}
        });
});
function imageIsLoaded(e) {e.preventDefault();$('#loading').show();$("#resp-msg").empty();
	$.ajax({
        url: "profilePic/", 
        type: "POST", 
        data: new FormData( document.getElementById('uploadimage') ), 
        contentType: false,
        cache: false, 
        processData: false, 
        success: function(data) 
        {var msg = '';
	//console.log(data);
        if( data.trim() == 'error' )
        {
       	msg = "<div class='alert alert-danger'>Error in Uploading !<br/> Only jpeg, jpg and png Images type allowed</div>";
	$('#default').show();
       	$('#upload').hide();
	$('#loading').hide();
        }
        else if( data.trim() == 'invalid' )
        {
       	msg =  "<div class='alert alert-danger'>Invalid File type ! <br/> Only jpeg, jpg and png Images type allowed.</div>";
        $('#default').show();
        $('#upload').hide();              
	$('#loading').hide();
        }
	else if( data.trim() == 'size_big' )
        {
        msg =  "<div class='alert alert-danger'>Size out of allowed Range !<br/> Only jpeg, jpg and png Images type allowed. Size less than 2 MB</div>";
        $('#default').show();
        $('#upload').hide();
	$('#loading').hide();
        }
	else if( data.trim() == 'invalid_token' )
        {
        msg =  "<div class='alert alert-danger'>Something Went Wrong !<br/> Please try again</div>";
        $('#default').show();
        $('#upload').hide();
        $('#loading').hide();
        }
        else
        {
	$('#default').hide();
        $('#upload').show();
        $('#upload').html(data);	
	$('#loading').hide();
        }                
        $('#resp-msg').html(msg);$("#resp-msg").fadeOut(3000); 
        },
      	error: function(jqXHR, textStatus, errorThrown){alert('Error: '+ errorThrown);}	
        });    
    };    
});
//dataTable js
//$(document).ready(function() {
//    $('#example').DataTable( {
//        "paging":   true,
//        "ordering": false,
//        "info":     false
//    } );
//} );
$(document).ready(function(){
  $('#example').DataTable();
});
// set contact bday chckbox
$(document).ready(function() {
$('#allData').click(function () {
var checked_status = this.checked;
$('input[name *=bData]:enabled').prop("checked", checked_status);
});
 });
// all set chckbox in contact management 
$(document).ready(function() {
$('#allContact').click(function(event){
if(this.checked){
$('input[name *= cmData]').each(function(){ this.checked = true; }); }
else { $('input[name *= cmData]').each(function() { this.checked = false; }); }
}); });
//filter contact bday data
$(function(){
$('.data_Value').click(function(){
	var filter_Value = $(this).val();
	$.ajax({
        	url: "bday-arrange/",
                type: "POST",
                data: {f_Value:filter_Value,},
                beforeSend: function(){
                $('#filter_Data').show().html("Loading...");
                },
                success: function(data){
                $('#filter_Data').html(data);
                }
                });
        });
});
var showNewForm = function(){
  var fn = function(i){
    if(i<0){window.location.reload();return;}
    setTimeout(function(){
      $('#response_prof_trying').html('<div class="alert alert-info"><strong>Showing form in ' + i + ' seconds</strong></div>');
      fn(--i);
    }, 1000);
  };
  fn(7);
};
//send feedback query
//usr prof updt
$('#send_Qry').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'mailToFeedback/',
 type: 'POST',
 beforeSend: function( xhr ) {
    $('#response_prof').fadeIn('slow').html('<div align="center"><i class="fa fa-spinner fa-spin fa-2x fa-fw""></i><br/>Processing...<br/></div>'); $("#response_prof").fadeOut(2000);
 },
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){
     $('#response_prof').fadeOut('slow', function(){
          $('#send_Qry').hide();
          showNewForm();
          $('#response_prof').fadeIn('slow').html(data); $("#response_prof").fadeOut(10000);$(':input,textarea').val('');$('#captcha_img').attr('src','feedback-captcha/?' + Math.random()); return false;$('#submitted').val('2');
        });
    })
    .fail(function(){
        $('#send_Qry').hide();
        showNewForm();
	$('#response_prof').fadeIn('slow').html('<div class="alert alert-danger"><strong>Error Occured- </strong>Something Went Wrong Please Try Again Later.</div>'); $("#response_prof").fadeOut(10000);
    });
});
//usr auth
$('#nic_gv').submit(function(e){e.preventDefault();
if($('#nic_email').val() != '' && $('#nic_password').val() != '' &&  $('#nic_cap').val() != '') {
  $.ajax({
 url: 'auth/',
 type: 'POST',
 beforeSend: function( xhr ) {
    $('#response_auth').fadeIn('slow').html('<div align="center"><i class="fa fa-spinner fa-spin fa-2x fa-fw""></i><br/>Authenticating<br/></div>'); $("#response_auth").fadeOut(2000);
 },
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){
	var authR=JSON.parse(data); 
	console.log('Auth response ---------------------'+data);
	if(authR['resp']=='rcpt'){window.location.href="recipients.html";} else if(authR['resp']=='hm'){window.location.href="index.html";} else if(authR['msg']){
     $('#response_auth').fadeOut('slow', function(){
          $('#response_auth').fadeIn('slow').html(authR['msg']); $("#response_auth").fadeOut(10000);$('#nic_email,#nic_password,#nic_cap').val('');$('#captcha_img').attr('src','captcha/?' + Math.random()); return false;
        });}
    })
    .fail(function(){
	$('#response_auth').fadeIn('slow').html('<div class="alert alert-danger"><strong>Error Occured- </strong>Something Went Wrong Please Try Again Later.</div>'); $("#response_auth").fadeOut(10000);
    });
} else {
    $('#response_auth').fadeIn('slow').html('<div align="center"><i class="fa fa-spinner fa-spin fa-2x fa-fw""></i><br/>Enter all three inputs<br/></div>'); $("#response_auth").fadeOut(5000);
}
});
//starrate
function highlightStar(obj,id) {
        removeHighlight(id);
        $('.starrate #tutorial-'+id+' li').each(function(index) {
                $(this).addClass('highlight');
                if(index == $('.starrate #tutorial-'+id+' li').index(obj)) {
                        return false;
                }
        });
}

function removeHighlight(id) { //console.log("lollaaaaa");
        $('.starrate #tutorial-'+id+' li').removeClass('selected');
        $('.starrate #tutorial-'+id+' li').removeClass('highlight');
        $('.starrate #tutorial-'+id+' li').removeClass('selected');

}

function addRating(obj,id) {
        $('.starrate #tutorial-'+id+' li').each(function(index) {
                $(this).addClass('selected');
                $('#tutorial-'+id+' #rating').val((index+1));
                if(index == $('.starrate #tutorial-'+id+' li').index(obj)) {
                        return false;
                }
        });
     $.ajax({
        url: "rateGreeting/",
        data:'id='+id+'&rating='+$('#tutorial-'+id+' #rating').val(),
        type: "POST",
	beforeSend: function(){
	$('#rating_Response_'+id+'').show().html("Loading...");
        },
        success: function(data){
	//console.log(data);
	var resData = jQuery.parseJSON(data)
	$('#rating_Response_'+id+'').fadeIn('slow').html(resData.response);$('#rating_Response_'+id+'').fadeOut(10000);
	$('#resData_'+id+'').fadeIn('slow').html(resData.response_data);
        }
     });
}

function resetRating(id) {
        if($('#tutorial-'+id+' #rating').val() != 0) {
                $('.starrate #tutorial-'+id+' li').each(function(index) {
                        $(this).addClass('selected');
                        if((index+1) == $('#tutorial-'+id+' #rating').val()) {
                                return false;
                        }
                });
        }
}
//loadmoreData
//if (current_Url.match(/https\:\/\/egreetings\.gov\.in\/cards\-.*/) || current_Url.match(/https\:\/\/egreetings\.gov\.in\/search\-.*/) || current_Url.match(/https\:\/\/www\.egreetings\.gov\.in\/cards\-.*/) || current_Url.match(/https\:\/\/www\.egreetings\.gov\.in\/search\-.*/)){
if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/cards\-.*/) || current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/search\-.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/cards\-.*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/search\-.*/)){
$(window).scroll(function ()
    {
	  if($(document).height() <= $(window).scrollTop() + $(window).height())
	  {
		loadmore();
	  }
    });
    function loadmore()
    { console.log('loadlmidad');
      var val = document.getElementById("row_no").value;
      var valCid = document.getElementById("cId").value;
      var valcnm = document.getElementById("cName").value;
      $.ajax({
      type: 'post',
      url: 'getCards/',
      data: {
       getresult:val,cId:valCid,cName:valcnm
      },
      beforeSend: function(){
      	//$('#loading').show().html('<i class="fa fa-spinner fa-pulse fa-3x fa-fw"></i><br/>Loading...');
      },
      success: function (response) {
	console.log(response);
	var content = document.getElementById("cards_product_area");
	if(response == 'no cards'){ $('#loading').show().html('');} else if(response == 'errC'){$('#loading').show().html('<h3 class="text text-danger">Something went wrong!!!!</h3>');}
	else { 	content.innerHTML = content.innerHTML+response; }

      // We increase the value by 10 because we limit the results by 10
      document.getElementById("row_no").value = Number(val)+9;
      }
      });
    }
}
//searchData
$(document).ready(function () {
$('#searchCat').focus(function()
{$(this).animate({ width: '+=100' }, 'slow');}).blur(function(){$(this).animate({ width: '-=100' }, 'slow');});
        $('#searchCat').typeahead({
	    items:12,
	    showHintOnFocus:true,
	    minLength:1,
            source: function (query, result) {
                $.ajax({
                    url: "eGreetSearch/",
		    data: 'query=' + query,            
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
			result($.map(data, function (item) {
			//var fof = split(item);
			//console.log(fof);
			return item;
                        }));
                    }
                });
            },
	    updater: function(data) {
		var qry = split(data);
		location.href="search-result-"+qry+".html";
    	    }
        });
    });
//split substring
function splitNew(str) { var i = str.indexOf("<"); if(i > 0) return  str.slice(0, i);else return "";}
function split(str) { var i = str.indexOf("("); if(i > 0) return  str.slice(0, i);else return "";}
function splitdob(str) { var i = str.indexOf("-"); if(i > 0) return  str.slice(0, i);else return "";}
//counter data
$('.counter-Data').each(function () {
        $(this).prop('Counter',0).animate({
            Counter: $(this).text()
        }, {
            duration: 5000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });
//subscribe expand
$('#subseGrt').focus(function()
{$(this).animate({ width: '+=140' }, 'slow');$('.enter-email-left span').hide();}).blur(function(){$(this).animate({ width: '-=140' }, 10);$('.enter-email-left span').show();});
//addsubsciber
$('#eSubscriber').submit(function(e){e.preventDefault();
var emailSubs = $('#subseGrt').val();
  $.ajax({
 url: 'eSubscribe/',
 type: 'POST',
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){
	var Data = jQuery.parseJSON(data);
	$('.modal-header h4').html(Data[1]);
	$('.modal-body p').html(Data[0]);
	$('#myModal').modal('show');
        showNewForm();
    })
    .fail(function(){
 	$('.modal-header h4').html('Something Went Wrong!!');
        $('.modal-body p').html('<div class="alert alert-danger">Oops!!! Please Try Again Later or <a href="contact.html" target="_blank">Contact Us</a></div>');
        $('#myModal').modal('show');
        showNewForm();
    });
});
//activate selected tab
$('#selectedTab1').click(function(event){$(this).css("border-bottom-color","#f00");$('#selectedTab2').css("border-bottom-color","#999");});
$('#selectedTab2').click(function(event){$(this).css("border-bottom-color","#f00");$('#selectedTab1').css("border-bottom-color","#999");});
//play audio
$(document).ready(function() {
$("#Audioid").on("change",function(){
if($(this).val().match('^[ A-Za-z0-9_@./#\(&\)+-]*$')){
if($(this).val()){var src = 'assets/audio/'+$(this).val();audio=$("#audio1");$("#audio1").attr("src",src);audio[0].pause();audio[0].load();audio[0].play();$('#stop_aud').show();$('#start_aud').hide();}
else {var src = '';audio=$("#audio1");audio[0].pause();$('#stop_aud').hide();$('#start_aud').hide(); } } else { $('.iferr').fadeIn('slow').html('<div class="alert alert-danger">Something went wrong please try again.</div>');$('.iferr').fadeOut(10000);} });
$("#stop_aud_btn").on("click",function() { audio=$("#audio1");audio[0].pause();$('#stop_aud').hide();$('#start_aud').show(); });
$("#start_aud_btn").on("click",function() { audio=$("#audio1");audio[0].load();audio[0].play();$('#stop_aud').show();$('#start_aud').hide(); });
});
//addcontactbook
$('#addContact').submit(function(e){e.preventDefault();
//console.log('lolaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa');
  $.ajax({
 url: 'adCont/',
 type: 'POST',
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){ 
	var addR=JSON.parse(data);
	if(addR['msg']){ $('input[name="csrf_token"]').val(addR['csT']);$('#response_ac').fadeOut('slow', function(){ $('#response_ac').fadeIn('slow').html(addR['msg']); $('#response_ac').fadeOut(10000); }); }
    })
    .fail(function(){
	$('#response_ac').fadeIn('slow').html('<div class="alert alert-danger">Something Went Wrong !!!</div>'); $("#response_ac").fadeOut(10000);
    });
});
//editable table
$(function() {
    $("td[contenteditable]").blur(function() { if ($(this).attr("contentEditable") == "true") {	var cId= $(this).attr('id');var attid = $(this).attr('class');var attvalue = $(this).text();var ctype= $(this).attr('class');var cid= $(this).attr('id');var ctkn=$("input[name=csrf_token]").val();
		$.ajax({
                url: 'editable/',
                type: 'POST',
                data: {tdcValue:attvalue,cId:cid,ctk:ctkn,ut:ctype},
                dataType: 'html'
                })
                .done(function(data){
			var inR=JSON.parse(data);
			if(inR['err']=="error"){ $('input[name="csrf_token"]').val(inR['csT']);$('#response_inlinetable').fadeOut('slow', function(){ $('#response_inlinetable').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#response_inlinetable").fadeOut(10000); }); }
        else if(inR['succ']=="success"){$('input[name="csrf_token"]').val(inR['csT']);$('#response_inlinetable').fadeOut('slow', function(){ $('#response_inlinetable').fadeIn('slow').html('<div class="alert alert-success" autofocus>Data has been updated successfully.</div>');$("#response_inlinetable").fadeOut(10000);});}
                })
                .fail(function(){
               		$('#response_inlinetable').fadeOut('slow', function(){ $('#response_inlinetable').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#response_inlinetable").fadeOut(10000); }); 
                });
        }
    });
});
//dob date on contactbook
$('#sandbox-container-inlinetable .input-group.date').datepicker(
		{
		todayHighlight: true,
		format: 'dd-M-yyyy',
		endDate: 'now',
		})
		.on('changeDate', function(ev){ var dateData = new Date(ev.date);var ccl= $(this).attr('class');var ctkn=$("input[name=csrf_token]").val();var cid=splitdob(ccl);
			$.ajax({
                	url: 'editable/',
                	type: 'POST',
                	data: {tdValue:dateData,cId:cid,ctk:ctkn},
                	dataType: 'html'
                	})
                	.done(function(data){
				var inR=JSON.parse(data);
                        if(inR['err']=="error"){ $('input[name="csrf_token"]').val(inR['csT']);$('#response_inlinetable').fadeOut('slow', function(){ $('#response_inlinetable').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#response_inlinetable").fadeOut(10000); }); }
        else if(inR['succ']=="success"){$('input[name="csrf_token"]').val(inR['csT']);$('#response_inlinetable').fadeOut('slow', function(){ $('#response_inlinetable').fadeIn('slow').html('<div class="alert alert-success" autofocus>Data has been updated successfully.</div>');$("#response_inlinetable").fadeOut(10000);});}
                	})
                	.fail(function(){
                		$('#response_inlinetable').fadeOut('slow', function(){ $('#response_inlinetable').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#response_inlinetable").fadeOut(10000); });	
                	});
        		});
//Chnage theme
$(document).ready(function(){ $("#change_theme").click(function(){var theme01=$("input[name='theme']:checked").val();var Themeid=$("#Themeid").val();var bgcolor=$("#bgcolor").val();var txtcolor=$("#txtcolor").val();var fontstyle=$("#FontStyle").val();var theme_bg='';var theme_txt='';if(theme01 != ''){if(theme01 == 'selecttheme'){if(Themeid == 'Theme1'){theme_bg = '#a71919';theme_txt = '#ff0000';}else if(Themeid == 'Theme2'){theme_bg = '#e4d522';theme_txt = '#b400ff';}else if(Themeid == 'Theme3'){theme_bg = '#0c0c0b';theme_txt = '#27ff00';}else{theme_bg='Default';theme_txt = 'Default';}}if(theme01 == 'selectcolor'){if(bgcolor != '' && txtcolor != ''){theme_bg = bgcolor;theme_txt = txtcolor;}else{theme_bg = 'Default';theme_txt = 'Default';}}}if(theme_bg != '' && theme_txt != ''){var dataString = '&theme_bg=' + theme_bg +  '&theme_txt=' + theme_txt + '&fontstyle=' + fontstyle + '&change_theme=1&theme='+theme01+"&themeid="+Themeid;
$.ajax({type: "POST",url: "change_theme.php",data: dataString,beforeSend: function(){$("#change_theme_response").html('<div class="succgreen_a"><strong>Changing...</strong>Please Wait!</div>');},success: function(response){var change_theme_response = response.indexOf('Congrats'); if( change_theme_response != -1 ){$("#theme_bg").val('');$("#change_theme_response").html(response);setTimeout(function(){$("#change_theme_response").html('');},10000);}else{$("#change_theme_response").html(response);}} }); } }); });
// Function to preview image after validation
$(function() {
$("#file").change(function() {var file = this.files[0];var imagefile = file.type;var match = ["application/vnd.ms-excel", "text/plain", "text/csv"];         if (!((imagefile == match[0]) || (imagefile == match[1]) || (imagefile == match[2]))) {return false;} else { 
$.ajax({url: "recpUpload/", type: "POST", data: new FormData(document.getElementById('rcpt_Details')), contentType: false, cache: false, processData: false,beforeSend: function( xhr ) {
    $('#error_cnts').fadeIn('slow').html('<div align="center"><i class="fa fa-spinner fa-spin fa-2x fa-fw""></i><br/>Uploading...<br/></div>'); 
 },
complete: function() { $("#error_cnts").hide(); }, 
success: function(data) {var data=data.trim(); if(data == 'error'){ $('#error_cnts').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">Some error occured. Please check your file or read instructions below.</div>'); });} else if(data == 'no_valid'){ $('#error_cnts').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">Not a valid Data. Please check your file or read instructions below.</div>'); });} else if(data == 'invalid'){ $('#error_cnts').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">File type or size is not valid. Please check your file or read instructions below.</div>'); });} else if(data == 'size_large'){ $('#error_cnts').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">File size is too large. Please check your file or read instructions below.</div>'); });} else if(data == 'invalid_token'){ $('#error_cnts').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">Something went wrong Please try again. Please check your file or read instructions below.</div>'); });} else if(data == 'success') {$('#error_cnts').fadeOut('slow', function(){ $('#error_cnts').fadeIn('slow').html('<div class="alert alert-warning">Successfully uploaded <i class="fa fa-thumbs-o-up"></i>. Please click the link to <button type="button" id="dispcnt" class="button btn-info"><i class="fa fa-address-card"></i> Show Contacts</button></div><div class="alert alert-info">Do you want add these contacts to your contact book ? <button type="button" id="adtoCb" class="button btn-danger"><i class="fa fa-user-plus"></i> Add to Contact book</button></div>');   });}else {$('#error_cnts').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">Something is went wrong please try again later.</div>'); });} } }); } }); });
//check all contact in recipient details
$(document).ready(function() {
$('#allrecp').click(function(event){
if(this.checked){
$('input[name *= recpdata]').each(function(){ this.checked = true; }); }
else { $('input[name *= recpdata]').each(function() { this.checked = false; }); }
}); });
//Adduploadedcontact to contactbook
$(document).ready(function () {
$(document).on("click","#adtoCb",function(e){
$.ajax({url: "adtoCb/", type: "POST", data: new FormData(document.getElementById('rcpt_Details')), contentType: false, cache: false, processData: false,
success: function(data) { $('#error_cnts').fadeOut('slow', function(){ $('#error_cnts').fadeIn('slow').html(data); });$("#error_cnts").fadeOut(10000); } }); });});
//theme-change
$('#themeProcess').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'themeProcess/',
 type: 'POST',
 beforeSend: function( xhr ) {
    $('#thmProccessing').fadeIn('slow').html('<div align="center"><i class="fa fa-spinner fa-spin fa-2x fa-fw""></i><br/>Processing...<br/></div>'); $("#thmProccessing").fadeOut(2000);
 },
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){
	//console.log(data);
	var dataObj = JSON.parse(data);
	$('.theme-send').css('background-color',dataObj['theme_bg']);
        $('.dear_lalit').css({'color':dataObj['theme_txt'],'font-family':dataObj['FontStyle']});
	$('.dear_area_content p').css({'color':dataObj['theme_txt'],'font-family':dataObj['FontStyle']});
	$('.dear_raman').css({'color':dataObj['theme_txt'],'font-family':dataObj['FontStyle']});
	$('.quote_top_heading').css({'color':dataObj['theme_txt'],'font-family':dataObj['FontStyle']});
	$('.quote_middle_heading').css({'color':dataObj['theme_txt'],'font-family':dataObj['FontStyle']});
	$('.quote_bottom_heading').css({'color':dataObj['theme_txt'],'font-family':dataObj['FontStyle']});
    })
    .fail(function(){
        $('#response_prof').fadeIn('slow').html('<div class="alert alert-danger"><strong>Error Occured- </strong>Something Went Wrong Please Try Again Later.</div>'); $("#response_prof").fadeOut(10000);
    });
});
//upload GIF
$(function(){if (current_Url.match(/https\:\/\/egreetingsstaging\.nic\.in\/index*/) || current_Url.match(/https\:\/\/www\.egreetingsstaging\.nic\.in\/index*/)){$("#rcpt_upload").on('click', function(e){e.preventDefault();$("#file:hidden").trigger('click');});}});

$(function(){$("#gifUpld").on('click', function(e){e.preventDefault();$("#gFile:hidden").trigger('click');});});

$("#gFile").change(function() {var file = this.files[0];var imagefile = file.type;var match = ["image/gif"];if(!(imagefile == match[0])) {return false;} else {
$.ajax({url: "src/gupload.php", type: "POST", data: new FormData(document.getElementById('gfupld')), contentType: false, cache: false, processData: false,
success: function(data) {var data=data.trim();if(data=='success'){window.location.href = 'customize-gif.html';} }
});	
}
});
//changeSender
$('input[type=radio][name=sender]').change(function() {
        if (this.value == 'def_sender') {$('.defSender').show();$('.cstmSender').hide();}
        else if (this.value == 'cstm_sender') {$('.defSender').hide();$('.cstmSender').show();}
    });
//del cstmcrd
$('.delC').click(function(){
var k = $(this).attr('name');$('input[name="imid"]').val(k);
$('#delModal').modal('show');
});
//usr prof updt
$('#delc').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'delC/',
 type: 'POST',
 data: $(this).serialize(), 
        dataType: 'html'
    })
    .done(function(data){
	var delR=JSON.parse(data);
	if(delR['err']=="error"){ $('#delR').fadeOut('slow', function(){ $('#delR').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#delR").fadeOut(10000); }); }
	else if(delR['succ']=="success"){$('#delModal').modal('toggle');$('.uHd-'+delR['imId']).hide();$('input[name="csrf_token"]').val(delR['csT']);$('#delR').fadeOut('slow', function(){ $('#delR').fadeIn('slow').html('<div class="alert alert-success" autofocus>eCard has been deleted successfully.</div>');$("#delR").fadeOut(10000);});}
    })
    .fail(function(){
	$('#delR').fadeOut('slow', function(){ $('#delR').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div><br/>'); $("#delR").fadeOut(10000); })
    });
});
//cntmgmt
$(function() {
$("#blkfile").change(function() {console.log("LOLAAAAAAAAAAAa");var file = this.files[0];console.log('test--------'+file);var imagefile = file.type;console.log(imagefile);var match = ["application/vnd.ms-excel", "text/plain", "text/csv"];if (!((imagefile == match[0]) || (imagefile == match[1]) || (imagefile == match[2]))) {return false;} else {
$.ajax({url: "blkUpload/", type: "POST", data: new FormData(document.getElementById('blkCnt')), contentType: false, cache: false, processData: false,
success: function(data) {console.log(data);var data=data.trim(); if(data == 'error'){ $('#response_blk').fadeOut('slow', function(){$('#response_blk').fadeIn('slow').html('<div class="alert alert-danger">Some error occured. Please check your file or read instructions below.</div>'); });} else if(data == 'no_valid'){ $('#response_blk').fadeOut('slow', function(){$('#response_blk').fadeIn('slow').html('<div class="alert alert-danger">Not a valid Data. Please check your file or read instructions below.</div>'); $('#response_blk').fadeOut(10000); });} else if(data == 'invalid'){ $('#response_blk').fadeOut('slow', function(){$('#response_blk').fadeIn('slow').html('<div class="alert alert-danger">File type or size is not valid. Please check your file or read instructions below.</div>'); });} else if(data == 'size_large'){ $('#response_blk').fadeOut('slow', function(){$('#response_blk').fadeIn('slow').html('<div class="alert alert-danger">File size is too large. Please check your file or read instructions below.</div>'); });} else if(data == 'invalid_token'){ $('#response_blk').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">Something went wrong Please try again. Please check your file or read instructions below.</div>'); });} else if(data == 'error2'){ $('#response_blk').fadeOut('slow', function(){$('#error_cnts').fadeIn('slow').html('<div class="alert alert-danger">Something went wrong Please try again. Please check your file or read instructions below.</div>'); });} else {$('#response_blk').fadeOut('slow', function(){ $('#response_blk').fadeIn('slow').html('<div class="alert alert-info">File Contacts has been imported successfully.</div>');  });} } }); } }); });
//del cont
$('#delcont').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'deleteContact/',
 type: 'POST',
 data: $(this).serialize(),
        dataType: 'html'
    })
    .done(function(data){
	//console.log(data);
        var delR=JSON.parse(data);//console.log(data);
        if(delR['err']=="error"){ $('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#delcc").fadeOut(10000); }); }
        else if(delR['succ']=="success"){$('input[name="csrf_token"]').val(delR['csT']);var tmpvar = delR['pbid'];var arrayLength = tmpvar.length;for (var i = 0; i < arrayLength; i++) { $('#Cdel'+tmpvar[i]).hide(); }$('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-success" autofocus>Requested Contact has been deleted successfully.</div>');$("#delcc").fadeOut(10000);});}
    })
    .fail(function(){
        $('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div><br/>'); $("#delcc").fadeOut(10000); })
    });
});
//unsubs
$(function(){
$('.inlineR').click(function(){
        var inlineV = $(this).val();
	if(inlineV=='check_all'){ $('.subsSetting').show();$('.unsubs').hide();$('#subss').text('Change Setting');}else if(inlineV=='cunsubs'){ $('.subsSetting').hide();$('.unsubs').show(); $("input:checkbox").removeAttr("checked");$('#subss').text('Unsubscribe Now');}
        });
});
//updateSubscription setting.
$('#delassfcont').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'src/delcont.php',
 type: 'POST',
 data: $(this).serialize(),
        dataType: 'html'
    })
    .done(function(data){
        //console.log(data);
        var delR=JSON.parse(data);//console.log(data);
        if(delR['err']=="error"){ $('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#delcc").fadeOut(10000); }); }
        else if(delR['succ']=="success"){$('input[name="csrf_token"]').val(delR['csT']);var tmpvar = delR['pbid'];var arrayLength = tmpvar.length;for (var i = 0; i < arrayLength; i++) { $('#Cdel'+tmpvar[i]).hide(); }$('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-success" autofocus>Requested Contact has been deleted successfully.</div>');$("#delcc").fadeOut(10000);});}
    })
    .fail(function(){
        $('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div><br/>'); $("#delcc").fadeOut(10000); })
    });
});
//preview theme and font
$(function() {

  var options = [1, 2, 3, 4];
  var tNM= ['0.png','1.png','2.png','3.png'];
  var fNM= ['0f.png','1f.png','2f.png','3f.png','4f.png','5f.png'];
  $.each(options, function(index, color) {
	
    $("<li>", {
      append: "\nOption " + options[index] + "<img " + "style=position:absolute;left:175px;opacity:0;z-index:100000; " + "src=assets/images/prvw/" + tNM[index] + ">",
      data:{"value": options[index]},
      appendTo: "#catsSelect",
      css: {
	display: "block",
    width: "98%",
    height: "34px",
    padding: "6px 12px",
    fontSize: "14px",
    lineHeight: "1.42857143",
    color: "#555",
    background: "#fff",
    border: "1px solid #ccc",
    borderRadius: "4px",
    transition: "bordercolor easeinout .15s,box-shadow easeinout .15s"
      },
      on: {
        "mouseenter": function() {
          if (!$(this).is("li:first")) {
            $(this).css("backgroundColor", "skyblue")
              .find("img").stop().fadeTo(150, 1)
          }
        },
        "mouseleave": function() {
          $(this).css("backgroundColor", "transparent")
            .find("img").stop().fadeTo(150, 0)
        }
      }
    })
  }); 

  $("#catsSelect li:not(:first)")
    .hide()
    .siblings(":first")
    .clone(true)
    .hide()
    .insertAfter("#catsSelect li:first")
    .parent()
    .click(function(e) { 
      $("input[type=submit]:disabled").attr("disabled", false);
      if ($(e.target).is("li:first")) {
        $(e.target).closest("li").siblings().toggle()
      } else {
        $(e.target).closest("ul")
          .find(":first")
          .html(function(_, html) {
            var selected = $(e.target).closest("li");
            $("form").find("option")
              .val(selected.data().value).select();
            return selected.html()
          })
          .trigger("mouseleave")
          .siblings().toggle()
      }
    })
    .closest("form")
    .submit(function() {
    })
    .find("option").val($("li:first").data().value)
    .closest(".catsSelect li").click(function(event) { 
      if ($("li:gt(0)").is(":visible") && !$(event.target).is("li")) {
        $("li:gt(0)").toggle()
      }
    })
//dynamic contacts
$(document).ready(function() {
var bulktable = $('#bulkcontacts').DataTable({
	 "bProcessing": true,
         "serverSide": true,
         "ajax":{
            url :"getbulkdata/", // json datasource
            type: "post",  // type of method  ,GET/POST/DELETE
            error: function(){
              $("#employee_grid_processing").css("display","none");
            }
          },
	 "columnDefs": [ {
            "targets": -1,
            "data": null,
            "defaultContent": "<div style='text-align:center'><i class='fa fa-edit text-danger editrow' style='cursor:pointer;' title='Edit Contact'></i> <i class='fa fa-trash text-warning deleterow' style='cursor:pointer;' title='Delete Conact'></i></div>"
        } ]
        });
	$('#bulkcontacts tbody').on( 'click', '.editrow', function () {
        var data = bulktable.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 4 ] );
	$('#bulkcontactname').val(data[0]);
	$('#bulkcontactemail').val(data[1]);
	$('#bulkcontactdob').val(data[2]);
	$('#bulkcontactid').val(data[4]);
	$("#contactedit").modal();
    	});
	$('#bulkcontacts tbody').on( 'click', '.deleterow', function () {
        var data = bulktable.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 4 ] );
	$('#cntid').val(data[4]);
        $("#delContact").modal();
        });
//updatebulkcontact
$('#updatebulkContact').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'updtCont/',
 type: 'POST',
 data: $(this).serialize(),
        dataType: 'html'
    })
    .done(function(data){
	console.log(data);
        var updtR=JSON.parse(data);
        if(updtR['msg']){ $('input[name="csrf_token"]').val(updtR['csT']);$('#response_up').fadeOut('slow', function(){ $('#response_up').fadeIn('slow').html(updtR['msg']); $('#response_up').fadeOut(10000); }); }
    })
    .fail(function(){
        $('#response_up').fadeIn('slow').html('<div class="alert alert-danger">Something Went Wrong !!!</div>'); $("#response_up").fadeOut(10000);
    });
});
//DeleteContact
$('#delcontact').submit(function(e){e.preventDefault();
  $.ajax({
 url: 'deletebulkContact/',
 type: 'POST',
 data: $(this).serialize(),
        dataType: 'html'
    })
    .done(function(data){
        //console.log(data);
        var delR=JSON.parse(data);//console.log(data);
        if(delR['err']=="error"){ $('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div>'); $("#delcc").fadeOut(10000); }); }
        else if(delR['succ']=="success"){$('input[name="csrf_token"]').val(delR['csT']);$("#delContact").modal('toggle');$('#delcc').focus(); $('#delcc').fadeIn('slow').html('<div class="alert alert-success" autofocus>Requested Contact has been deleted successfully. Please reload the page to see updated results.</div>');$("#delcc").fadeOut(10000);}
    })
    .fail(function(){
        $('#delcc').fadeOut('slow', function(){ $('#delcc').fadeIn('slow').html('<div class="alert alert-danger">Oops! Something Went Wrong.</div><br/>'); $("#delcc").fadeOut(10000); })
    });
});

//selectbulklist

var bulklist = $('#bulklist').DataTable({
         "bProcessing": true,
         "serverSide": true,
         "ajax":{
            url :"getbulkdata/", // json datasource
            type: "post",  // type of method  ,GET/POST/DELETE
            error: function(){
              $("#employee_grid_processing").css("display","none");
            }
          },
         "columnDefs": [ {
            "targets": -1,
            "data": null,
            "defaultContent": "<div style='text-align:center;'><i class='fa fa-user addcnt' style='cursor:pointer;' title='Click here to add in recipient list'></i></div>"
        } ]
        });
	//var lolllll = bulklist.find('tbody tr:first').css('background','#00f');
        $('#bulklist tbody').on( 'click', '.addcnt', function () {
        var data = bulklist.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 3 ] );
	$("input[data-role=tagsinput]").tagsinput('add', data[1]);
	var addcntval = $('#cntid').val(data[4]);
        console.log('addcntvalue is ' + addcntval);
        $(this).css('color','#00f');

        $('#bulkcontactname').val(data[0]);
        $('#bulkcontactemail').val(data[1]);
        $('#bulkcontactdob').val(data[2]);
        $('#bulkcontactid').val(data[4]);
        $("#contactedit").modal();
        });
        $('#bulkcontacts tbody').on( 'click', '.deleterow', function () {
        var data = bulktable.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 4 ] );
        $('#cntid').val(data[4]);
        $("#delContact").modal();
        });

//select birthday from bulklist

var birthdaybulklist = $('#birthdaytable').DataTable({
         "bProcessing": true,
         "serverSide": true,
         "ajax":{
            url :"getbulkdata/", // json datasource
            type: "post",  // type of method  ,GET/POST/DELETE
            error: function(){
              $("#employee_grid_processing").css("display","none");
            }
          },
         "columnDefs": [ {
            "targets": -1,
            "data": null,
            "defaultContent": "<div style='text-align:center'><i class='fa fa-birthday-cake text-danger' style='cursor:pointer;' title='Set Birthday Mail'></i></div>"
        } ]
        });
        $('#bulkcontacts tbody').on( 'click', '.editrow', function () {
        var data = bulktable.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 4 ] );
        $('#bulkcontactname').val(data[0]);
        $('#bulkcontactemail').val(data[1]);
        $('#bulkcontactdob').val(data[2]);
        $('#bulkcontactid').val(data[4]);
        $("#contactedit").modal();
        });
        $('#bulkcontacts tbody').on( 'click', '.deleterow', function () {
        var data = bulktable.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 4 ] );
        $('#cntid').val(data[4]);
	
        $("#delContact").modal();
        });

//select multiple or all contact book
	$('#recptoptn input[name="recpt2"]').change(function(){
		if( $(this).is(":checked") ){var rcptval = $('input[name="recpt2"]:checked').val();} 
		if(rcptval == 'multicontact'){$('.rcptopt').show();$('.allrcpt').html('');}
		else if(rcptval == 'allcontact'){$('.rcptopt').hide();$('.allrcpt').html('<div class="alert alert-info">All contact has been selected from your contact book.</div><br/>');}
	});

$('.bootstrap-tagsinput input').attr('readonly', 'readonly');
$('.bootstrap-tagsinput input').attr('placeholder', 'Selected Recipient will be shown here');
//show contacts on recipient page
$(document).on('click','#dispcnt',function(){
	$('#showContact').modal();
	var recpuploadfile = $('#recpuploadfile').DataTable({
         "bProcessing": true,
         "serverSide": true,
         "ajax":{
            url :"recpuploaddata/", // json datasource
            type: "post",  // type of method  ,GET/POST/DELETE
            error: function(){
              $("#employee_grid_processing").css("display","none");
            }
          },
        });
        $('#recpuploadfile tbody').on( 'click', '.', function () {
        var data = bulktable.row( $(this).parents('tr') ).data();
        //alert( data[0] +"'s editable id is: "+ data[ 4 ] );
        });

});
//remove selected contacts in datatable
$(document).on('click','span[data-role="remove"]',function(){
	var em = $(this).parent().text();

	$("tr").each(function(){
	    var col_val = $(this).find("td:eq(1)").text();
	    if (col_val == em){
	      //$(this).css('background','#00f');  
		$(this).find("td:eq(4) .addcnt").css('color','');	
	    } else {
	      //$(this).css('background','#f00');
	    }
	  });

	//console.log('DONDONDONDOND-------'+em);
});
//selected dynamic data on pagination
$(document).on('click','a[aria-controls="bulklist"]',function(){
setTimeout(function() {
        $("tr").each(function(){
            var col_val = $(this).find("td:eq(1)").text();
	    var atags= $('#selected_rcpt').val();
	//console.log(atags);
        var abookarray = atags.split(',');
	console.log(col_val);
        if(jQuery.inArray(col_val, abookarray) !== -1){
	console.log('LOLA');
            //if (col_val == em){
              //$(this).css('background','#00f');
                $(this).find("td:eq(4) .addcnt").css('color','#00f');
            } else {
              //$(this).css('background','#f00');
            }
          });
        }, 300);

        //console.log('DONDONDONDOND-------'+em);
});

//selected dynamic data on search
$(document).on('keyup','input[aria-controls="bulklist"]', function(event) {
setTimeout(function() {
        $("tr").each(function(){
            var col_val = $(this).find("td:eq(1)").text();
            var atags= $('#selected_rcpt').val();
        //console.log(atags);
        var abookarray = atags.split(',');
        console.log(col_val);
        if(jQuery.inArray(col_val, abookarray) !== -1){
        console.log('LOLA');
            //if (col_val == em){
              //$(this).css('background','#00f');
                $(this).find("td:eq(4) .addcnt").css('color','#00f');
            } else {
              //$(this).css('background','#f00');
            }
          });
        }, 300);

        //console.log('DONDONDONDOND-------'+em);
});

//selected dynamic data on number of result
$(document).on('change','select[aria-controls="bulklist"]', function(event) {
setTimeout(function() {
        $("tr").each(function(){
            var col_val = $(this).find("td:eq(1)").text();
            var atags= $('#selected_rcpt').val();
        //console.log(atags);
        var abookarray = atags.split(',');
        console.log(col_val);
        if(jQuery.inArray(col_val, abookarray) !== -1){
        console.log('LOLA');
            //if (col_val == em){
              //$(this).css('background','#00f');
                $(this).find("td:eq(4) .addcnt").css('color','#00f');
            } else {
              //$(this).css('background','#f00');
            } 
          });
        }, 300);
        
        //console.log('DONDONDONDOND-------'+em);
});

	   
});
    var e_custom_message = $("#e_custom_message").val();
    if(e_custom_message != "") {
        $("#e_custom_message").prop('disabled', true);
    }
    $("#inlineRadio2").click(function(){
        if($('#inlineRadio2').is(':checked')) { 
            $("#selected_rcpt").val("All contact has been selected from your contact book."); 
        }else{
            $("#selected_rcpt").val(""); 
        }
    });
    $(".a1").click(function(){
        $("#find_tab").val(1);
    });
    $(".a2").click(function(){
        $("#find_tab").val(2);
    });
    $(".a3").click(function(){
        $("#find_tab").val(3);
    });

//Datatable for stats
//var statList = $('#statList').DataTable();
var catCountList = $('#catCountList').DataTable();

var activityResponse = $('#statList').DataTable({
         "bProcessing": true,
         "serverSide": true,
         "ajax":{
            url :"eActivityResponse/", // json datasource
            type: "post",  // type of method  ,GET/POST/DELETE
            error: function(){
              $("#employee_grid_processing").css("display","none");
            }
          }
        });

});
