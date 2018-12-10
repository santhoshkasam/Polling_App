$(document).ready(function () {
  $(".dropdown").hover(
    function () {
      $('.dropdown-menu', this).not('.in .dropdown-menu').stop(true, true).slideDown("400");
      $(this).toggleClass('open');
    },
    function () {
      $('.dropdown-menu', this).not('.in .dropdown-menu').stop(true, true).slideUp("400");
      $(this).toggleClass('open');
    }
  );
});
function ShowEntityModal(result) {
  if (result) {
    if (result.responseJSON) {
      if (result.responseJSON.Status === "Failed") {
        buildMessageContainer(false, result.responseJSON.Message);
        return;
      }
    }
  }
  // reInitializeScripts();
  //$('#divMessage').hide();
  $('#entityModal').modal('show');
  $("#Add").attr('data-toggle', 'modal');
  $("form").removeData("validator");
  $(".modal-body").animate({
    scrollTop: 0
  });
  //$(".modal").draggable({
  //  handle: ".modal-header"
  //});
  return false;
}