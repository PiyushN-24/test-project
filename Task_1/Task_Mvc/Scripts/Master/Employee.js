$(document).ready(function () {
    loadEmpGrid();
    clearData();
});

const loadEmpGrid = async () => {
    $("#tblEmployee").empty();
    try {
        await $.ajax({
            url: '/Employee/GetEmployeeList/',
            dataType: "json",
            method: 'POST',
            async: false,
            success: function (data) {
                var html = '';
                for (var i = 0; i < data.length; i++) {
                    html += `<tr>`
                    html += `<th>${data[i].EMP_ID}</th>`;
                    html += `<th>${data[i].EMP_NAME}</th>`;
                    html += `<th>${data[i].EMP_AGE}</th>`;
                    html += `<th>${data[i].EMP_CITY}</th>`;
                    html += `<th><button class="btn btn-info" onclick="return EditFun(` + data[i].EMP_ID  +`)"> Edit </button></th>`;
                    html += `</tr>`;
                }
                $("#tblEmployee").append(html);
            },
            error: function (err) {
                console.log(err);
            }
        });
    } catch (e) {
        console.log(e);
    }
}


$("#btnSaveEmp").click(function () {
    if ($("#txtEmpName").val().trim() == "") {
        iziToast.warning({ title: 'Please Enter Employee Name !', message: 'warning!', });
        $("#txtEmpName").focus();
        return false;
    }
    if ($("#txtEmpAge").val().trim() == "") {
        iziToast.warning({ title: 'Please Enter Employee Age !', message: 'warning!', });
        $("#txtEmpAge").focus();
        return false;
    }
    if ($("#txtEmpCity").val().trim() == "") {
        iziToast.warning({ title: 'Please Enter Employee City !', message: 'warning!', });
        $("#txtEmpCity").focus();
        return false;
    }

    var objEmp = {
        EMP_ID: $("#hdnEmpId").val(),
        EMP_NAME: $("#txtEmpName").val(),
        EMP_AGE: $("#txtEmpAge").val(),
        EMP_CITY: $("#txtEmpCity").val()
    }
    saveEmployee(objEmp);
});

const saveEmployee = async (objEmp) => {
    try {
        await $.ajax({
            url: "/Employee/SaveEmployee/",
            type: "POST",
            data: JSON.stringify(objEmp),
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (data) {
                iziToast.success({ title: 'Employee Added Successfully !', message: 'success!', });
                clearData();
                loadEmpGrid();
            }
        });
    } catch (e) {
        console.log(e);
    }
}

$("#btnClear").click(function () {
    clearData();
});

function clearData() {
    $("#hdnEmpId").val("");
    $("#txtEmpName").val("");
    $("#txtEmpAge").val("");
    $("#txtEmpCity").val("");
    $("#btnSaveEmp").text("Save Employee");
}

const EditFun = async (id) => {
    try {
        await $.ajax({
            url: "/Employee/GetEmployeeById/",
            data: { id: id },
            type: "POST",
            async: false,
            success: function (data) {
                $('#hdnEmpId').val(data.EMP_ID);
                $('#txtEmpName').val(data.EMP_NAME);
                $('#txtEmpAge').val(data.EMP_AGE);
                $('#txtEmpCity').val(data.EMP_CITY);
                $('#btnSaveEmp').text('Update');
            },
            error: function (errResponse) {
                console.log(errResponse);
            }
        });
    } catch (e) {
        console.log(e);
    }
}












