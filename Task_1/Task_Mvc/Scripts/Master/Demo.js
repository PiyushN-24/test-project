

let rowCount = 0;

$("#addDoc").click(function () {
    rowCount = rowCount + 1;

    var html = '';

    html += `<tr class=" mt--1" id="addDocRow">`;
    html += `<td class="col-sm-3">`;
    html += `<input type="text" id="txtAttachmentName` + rowCount + `" class="form-control txtAttachmentName" name="txtAttachmentName" value="" />`;
    html += `</td>`;


    html += `<td class="col-sm-3">`;
    html += `<input type="text" id="txtAttachmentName` + rowCount + `" class="form-control txtAttachmentName" name="txtAttachmentName" value="" />`;
    html += `</td>`;


    html += `<td class="col-sm-3">`;
    html += `<input type="text" id="txtAttachmentName` + rowCount + `" class="form-control txtAttachmentName" name="txtAttachmentName" value="" />`;
    html += `</td>`;


    html += `<td class="col-sm-3">`;
    html += `<input type="text" id="txtAttachmentName` + rowCount + `" class="form-control txtAttachmentName" name="txtAttachmentName" value="" />`;
    html += `</td>`;


    html += `<td class="col-sm-3">`;
    html += `<input type="text" id="txtAttachmentName` + rowCount + `" class="form-control txtAttachmentName" name="txtAttachmentName" value=""  />`;
    html += `</td>`;

    html += `<td class="col-sm-3">`;
    html += `<input type="text" id="txtAttachmentName` + rowCount + `" class="form-control txtAttachmentName" name="txtAttachmentName" value=""  />`;
    html += `</td>`;



    html += '<td class="col-sm-2 text-center">';
    html += '<button id="removeActivitieDocRow" type="button" class="btn btn-outline-danger" ><span class="material-icons-outlined icon-sm">close</span></button>';
    html += '</td>';

    html += '</tr>';

    $(document).on('click', '#removeActivitieDocRow', function () {
        $(this).closest('#addDocRow').remove();
    });
    $('#newRowAdd').append(html);

})