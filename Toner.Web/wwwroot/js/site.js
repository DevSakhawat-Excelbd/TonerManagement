//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.


//$('tbody').delegate('.amount,.device_price', 'keyup', function () {
//   var tr = $(this).parent().parent();
//   var amount = tr.find('.amount').val();
//   var device_price = tr.find('.device_price').val();
//   var total_column_price = (amount * device_price);
//   tr.find(.total_column_price).val(total_column_price);
//   total_price();
//});
//function total_price() {
//   var total_price = 0;
//   $('.total_column_price').each(function (i, e) {
//      var total_column_price = $(this).val() - 0;
//      total_price += total_column_price;
//   });
//   $('.total_price').html(total_price + ",00");
//}


window.onkeyup = function () {
   var items = document.querySelectorAll(".item");
   var itemsArray = Array.prototype.slice.call(items, 0);
/*   var prev, current, total, net = 0;*/
   var prev, current, total = 0;
   itemsArray.forEach(function (el) {
      prev = el.querySelector('input[name="PrevCount"]').value;
      current = el.querySelector('input[name="CurCount"]').value;
      total = current - prev;
      el.querySelector('input[name="TotalCount"]').value = total;
      /*      net += total;*/
   });


   var tonerDetailItems = document.querySelectorAll(".tonerDetailItem");
   var tonerDetailItemsArray = Array.prototype.slice.call(tonerDetailItems, 0);
   var totalMachineToner, currentTonerStock, inHouseTotalToner, lastMonthTotalTonerStock, monthlyDeliveryToner, totalTonerStock, monthlyUsedToner = 0;

   tonerDetailItemsArray.forEach(function (el) {
      totalMachineToner = el.querySelector('input[name="TotalMachineToner"]').value;
      currentTonerStock = el.querySelector('input[name="CurrentTonerStock"]').value;
      inHouseTotalToner = parseFloat(totalMachineToner) + parseFloat(currentTonerStock);
      el.querySelector('input[name="InHouseTotalToner"]').value = inHouseTotalToner.toFixed(2);

      lastMonthTotalTonerStock = el.querySelector('input[name="LastMonthTotalTonerStock"]').value;
      monthlyDeliveryToner = el.querySelector('input[name="MonthlyDeliveryToner"]').value;
      totalTonerStock = parseFloat(inHouseTotalToner) + parseFloat(monthlyDeliveryToner);
      el.querySelector('input[name="TotalTonerStock"]').value = totalTonerStock.toFixed(2);

      monthlyUsedToner = parseFloat(lastMonthTotalTonerStock) - parseFloat(inHouseTotalToner);
      el.querySelector('input[name="MonthlyUsedToner"]').value = monthlyUsedToner.toFixed(2);
   });
/*   document.getElementById('net').value = net;*/
}

//function addRowsUses() {
//   var table = document.getElementById('UsesCreateTable');
//   var rowCount = table.rows.length;
//   var cellCount = table.rows[0].cells.length;
//   var row = table.insertRow(rowCount);
//   for (var i = 0; i <= cellCount; i++) {
//      var cell = 'cell' + i;
//      cell = row.insertCell(i);
//      var copycel = document.getElementById('col' + i).innerHTML;
//      cell.innerHTML = copycel;
//   }
//}

//function deleteRowsUses() {
//   var table = document.getElementById('UsesCreateTable');
//   var rowCount = table.rows.length;
//   if (rowCount > '2') {
//      var row = table.deleteRow(rowCount - 1);
//      rowCount--;
//   }
//   else {
//      alert('There should be atleast one row');
//   }
//}


//function addRowsTonerDetail() {
//   var table = document.getElementById('TonerCreateTable');
//   var rowCount = table.rows.length;
//   var cellCount = table.rows[0].cells.length;
//   var row = table.insertRow(rowCount);
//   for (var i = 0; i <= cellCount; i++) {
//      var cell = 'cell' + i;
//      cell = row.insertCell(i);
//      var copycel = document.getElementById('col' + i).innerHTML;
//      cell.innerHTML = copycel;
//   }
//}

//function deleteRowsTonerDetail() {
//   var table = document.getElementById('TonerCreateTable');
//   var rowCount = table.rows.length;
//   if (rowCount > '2') {
//      var row = table.deleteRow(rowCount - 1);
//      rowCount--;
//   }
//   else {
//      alert('There should be atleast one row');
//   }
//}





$(document).ready(function () {
   $('.btnAddTonerDetail').click(function () {
      $('#TonerCreateTable').append(
         '<tr class="tonerDetailItem"><td><input class="form-control" type="text" data-val="true" data-val-number="The field TotalMachineToner must be a number." data-val-required="The TotalMachineToner field is required." id="TotalMachineToner" name="TotalMachineToner" value="0"></td><td><input class="form-control" type="text" data-val="true" data-val-number="The field CurrentTonerStock must be a number." data-val-required="The CurrentTonerStock field is required." id="CurrentTonerStock" name="CurrentTonerStock" value="0"></td><td><input readonly="" class="form-control" type="text" data-val="true" data-val-number="The field InHouseTotalToner must be a number." data-val-required="The InHouseTotalToner field is required." id="InHouseTotalToner" name="InHouseTotalToner" value="0"></td><td><input class="form-control" type="text" data-val="true" data-val-number="The field LastMonthTotalTonerStock must be a number." data-val-required="The LastMonthTotalTonerStock field is required." id="LastMonthTotalTonerStock" name="LastMonthTotalTonerStock" value="0"></td><td><input class="form-control" type="text" data-val="true" data-val-number="The field MonthlyDeliveryToner must be a number." data-val-required="The MonthlyDeliveryToner field is required." id="MonthlyDeliveryToner" name="MonthlyDeliveryToner" value="0"></td><td><input class="form-control" type="text" data-val="true" data-val-number="The field TotalTonerStock must be a number." data-val-required="The TotalTonerStock field is required." id="TotalTonerStock" name="TotalTonerStock" value="0"></td><td><input class="form-control" type="text" data-val="true" data-val-number="The field MonthlyUsedToner must be a number." data-val-required="The MonthlyUsedToner field is required." id="MonthlyUsedToner" name="MonthlyUsedToner" value="0"></td><td><button type="button" class="btn btn-primary btnAdd">Add</button><button type="button" class="btn btn-danger btnDelete">Delete</button></td></tr>'
      );
   });

   $('#TonerCreateTable').on('click', '.btnTonerDetail', function () {
      $(this).closest('tr').remove();
   });

   $('.btnAddUses').click(function () {
      $('#UsesCreateTable').append(
         '<tr class="item"><td><input class="form-control Prev_Count" type="number" data-val="true" data-val-required="The PrevCount field is required." id="PrevCount" name="PrevCount" value="0"></td><td><input class="form-control Cur_Count" type="number" data-val="true" data-val-required="The CurCount field is required." id="CurCount" name="CurCount" value="0"></td><td><input class="form-control Total_Count" type="number" data-val="true" data-val-required="The TotalCount field is required." id="TotalCount" name="TotalCount" value="0"></td><td><input class="form-control" type="number" data-val="true" data-val-required="The TonerPercentage field is required." id="TonerPercentage" name="TonerPercentage" value="0"></td><td><button type="button" class="btn btn-primary btnAddUses">Add</button><button type="button" class="btn btn-danger btnDeleteUses">Delete</button></td></tr>'
      );
   });

   $('#UsesCreateTable').on('click', '.btnDeleteUses', function () {
      //var table = $('#TonerCreateTable');
      //var rowCount = table.rows.length;
      //console.log(rowCount);
      $(this).closest('tr').remove();
   });





});