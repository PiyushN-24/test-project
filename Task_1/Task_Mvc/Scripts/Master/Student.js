


var cnt1 = 0;
$("#addDoc").click(function () {
    cnt1 = cnt1 + 1;
    var html = '';
    html += '<tr class=" mt--1" id="addDocRow">';
    html += '<td class="col-sm-3">';
    html += '<input type="text" id="txtAttachmentName' + cnt1 + '" class="form-control txtAttachmentName" name="txtAttachmentName" value="" placeholder="Enter Attachment Name" />';
    html += '</td>';
    html += '<td class="col-sm-3">';
    html += '<input type="text" class="form-control fileAttachmentUpload" id="fileAttachmentUpload" tabindex="1" name="fileAttachmentUpload" value="" placeholder="Enter Attachment Name">';
    html += '</td>';
    html += '<td class="col-sm-3">';
    html += '<input type="text" class="form-control fileAttachmentUpload" id="fileAttachmentUpload" tabindex="1" name="fileAttachmentUpload" value="" placeholder="Enter Attachment Name">';
    html += '</td>';
    html += '<td class="col-sm-3">';
    html += '<input type="text" class="form-control fileAttachmentUpload" id="fileAttachmentUpload" tabindex="1" name="fileAttachmentUpload" value="" placeholder="Enter Attachment Name">';
    html += '</td>';
    html += '<td class="col-sm-2 text-center">';
    html += '<button id="removeActivitieDocRow" type="button" class="btn btn-outline-danger" ><span class="material-icons-outlined icon-sm">close</span></button>';
    html += '</td>';
    html += '</tr>';

    html += '<tr>';
    html += '</tr>';

    $(document).on('click', '#removeActivitieDocRow', function () {
        $(this).closest('#addDocRow').remove();
    });
    $('#newRowAdd').append(html);
});







