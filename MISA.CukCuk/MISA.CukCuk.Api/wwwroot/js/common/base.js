class baseJS {
    constructor() {
        this.host = "http://localhost:54485/api/v1";
        this.apiRouter = null;
        this.getCode = null;
        this.setApiRouter();
        this.loadData();
        this.initEvents();
    }

    setApiRouter() {

    }

    initEvents() {
        var me = this;
        $('div#msg-success').attr("display", "block");
        $('#btnAdd').click(function () {
            $('input#txtEmployeeCode')[0].focus();
            me.FormMode = 'Add';
            dialogDefault.dialog('open');
            // hiển thị dialog thêm
            $('input').val('');
            $('.dialog-detail').addClass('show-dialog');
            $('.dialog-detail').removeClass('hide-dialog');
            me.getMaxCode();
            //$('#txtEmployeeCode').prop('disabled', true);
            $('#txtEmployeeCode').focus();
            $('#btnDelete').css("display", "none");
            //hiển thị combobox
            me.loadCombobox($('select#cbxDepartmentGroup,select#cbxPositionGroup'));
        })


        // ẩn nút Hủy hoặc đóng(X)
        $('#btnCancel,#btnClose').click(function () {
            $('.dialog-detail').removeClass('show-dialog');
            $('.dialog-detail').addClass('hide-dialog');
            dialogDefault.dialog('close');
        })

        //refresh lại dữ liệu
        $('#btnRefresh').click(function () {
            me.loadData();
            setTimeout(function () { $('div#msg-refress').css("display", "block"); }, 1000);
            
            setTimeout(function () { $('div#msg-refress').css("display", "none"); }, 3500);

        })

        //save dữ liệu
        $('#btnSave').click(function () {
            try {
                //validate dữ liệu
                var inputValidates = $('input[required], input[type="email"]');
                $.each(inputValidates, function (index, input) {
                    // trigger để kích hoạt một sự kiện nào đó
                    $(input).trigger('blur');
                })
                var inputNotValidate = $('input[validate = "false"]');
                if (inputNotValidate && inputNotValidate.length > 0) {
                    $('div#msg-data').css("display", "block");
                    setTimeout(function () { $('div#msg-data').css("display", "none"); }, 3000);
                    // Focus vào ngay input đầu tiên không thỏa mãn
                    inputNotValidate[0].focus();
                    return;
                }
                //thu thập thông tin dữ liệu được nhập cho vào object
                //lấy tất cả các controll nhập liệu
                var entity = {};
                var inputs = $('input[fieldName], select[fieldName]');
                $.each(inputs, function (index, input) {
                    var propertyName = $(this).attr('fieldName');
                    var value = '';
                    if (propertyName == "PositionGroupName" || propertyName == "DepartmentGroupName") {
                        propertyName = $(this).attr('fieldValue');
                        value = $(this).val();//Lấy giá trị
                    }
                    else {
                        value = $(this).val();//Lấy giá trị
                    }

                    //check với trường hợp input là radio, thì chỉ lấy value của input có atrribute là checked
                    entity[propertyName] = value;
                    //lấy dữ liệu từ ô giới tính và trạng thái làm việc
                    switch (propertyName) {
                        case "Gender":
                            value = value == "Nam" ? 1 : (value == "Nữ" ? 0 : 2);
                            break;
                        case "WorkStatusName":
                            value = value == "Đang làm việc" ? 1 : (value == "Đã nghỉ việc" ? 0 : 2);
                            break;
                    }
                   
                })
                //xác định phương thức cho nút lưu
                var method = "POST";
                var id = '';
                if (me.FormMode == 'Edit') {
                    method = "PUT";
                    id = '/' + me.recordId;
                    //entity.CustomerId = me.recordId;
                }
                //gọi service tương tác thực hiện lưu dữ liệu
                $.ajax({
                    url: me.host + me.apiRouter + id,
                    method: method,
                    data: JSON.stringify(entity),
                    contentType: 'application/json'
                }).done(function (res) {
                    //sau khi lưu thàng công
                    //+ đưa ra thông báo cho người dùng
                    dialogDefault.dialog('close');
                    if (method == "POST") {
                        $('div#msg-success').css("display", "block");
                        setTimeout(function () { $('div#msg-success').css("display", "none"); }, 3000);
                    }
                    else {
                        $('div#msg-update').show(2000, async function () {
                            await setTimeout(function () { $('div#msg-update').hide(2000); }, 3000);
                        })
                        //$('div#msg-update').css("display", "block");
                        //setTimeout(function () { $('div#msg-update').css("display", "none"); }, 3000);
                    }
                    //alert("Thêm Thành công");
                    //+ Ẩn form chi tiết
                    $('.dialog-detail').removeClass('show-dialog');
                    $('.dialog-detail').addClass('hide-dialog');
                    //+ load lại dữ liệu
                    me.loadData();
                }).fail(function (res) {
                    //setTimeout(function () { $('div#msg-faild').css("display", "none"); }, 3000);
                    alert(res.responseJSON.Data[0]);
                    $('div#msg-faild').css("display", "block");
                    setTimeout(function () { $('div#msg-faild').css("display", "none"); }, 3000);
                })
            } catch (e) {
                console.log(e);
            }
        })
        //Khi dblclick vào dòng thì sẽ mở dialog lên

        $('table tbody').on('dblclick', 'tr', function () {
            try {
                dialogDefault.dialog('open');
                $('#btnDelete').css("display", "block");
                me.FormMode = 'Edit';
                //load dữ liệu cho combobox
                me.loadCombobox($('select#cbxDepartmentGroup,select#cbxPositionGroup'));
                // lấy khóa chính của bản ghi
                var recordId = $(this).data('recordId');
                me.recordId = recordId;
                //gọi service lấy thông tin chi tiết theo id
                $.ajax({
                    url: me.host + me.apiRouter + `/${recordId}`,
                    method: "GET"
                }).done(function (res) {
                    //build lên form

                    // lấy tất cả các controll nhập liệu
                    var entity = {};
                    var inputs = $('input[fieldName], select[fieldName]');
                    $.each(inputs, function (index, input) {
                        var propertyName = $(this).attr('fieldName');
                        var value = res[propertyName];
                        if (propertyName == "DateOfBirth" || propertyName == "IdentityDate" || propertyName == "JoinDate") {
                            var dateValue = formatDate(value, '-');
                            $(this).val(dateValue);
                        } else {
                            $(this).val(value);
                        }
                        //lấy lên combobox vị trí 
                        if (propertyName == "PositionGroupName") {
                            var fieldValue1 = $(this).attr('fieldName');
                            var groupId = res[fieldValue1];
                            $("select option").each(function () {
                                if ($(this).text() == groupId)
                                    $(this).attr("selected", "selected");
                            });
                        }
                        //lấy lên combobox phòng ban
                        if (propertyName == "DepartmentGroupName") {
                            var fieldValue1 = $(this).attr('fieldName');
                            var groupId = res[fieldValue1];
                            $("select option").each(function () {
                                if ($(this).text() == groupId)
                                    $(this).attr("selected", "selected");
                            });
                        }
                    })
                }).fail(function (res) {

                })
            } catch (e) {
                console.log(e);
            }
            $('.dialog-detail').addClass('show-dialog');
            $('.dialog-detail').removeClass('hide-dialog');
        })

        $('#btnDelete').click(function () {
            var check = confirm('Bạn có chắc muốn xóa không');
            if (check == true) {
                var recordId = me.recordId;
                //gọi service lấy thông tin chi tiết theo id
                $.ajax({
                    url: me.host + me.apiRouter + `/${recordId}`,
                    method: "DELETE"
                }).done(function (res) {
                    $('.dialog-detail').removeClass('show-dialog');
                    $('.dialog-detail').addClass('hide-dialog');
                    dialogDefault.dialog('close');
                    $('div#msg-delete').css("display", "block");
                    setTimeout(function () { $('div#msg-delete').css("display", "none"); }, 3000);
                    me.loadData();
                }).fail(function () {

                })
            }
        })

        /**---------------
         * validate bắt buộc nhập
         * Created: HTTRANG(31/12/2020)
         --------------* */
        $('input[required]').blur(function () {
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này ko được để trống');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })

        /**---------------
               * validate email đúng định dạng
               * Created: HTTRANG(31/12/2020)
         ---------------------      * */
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
            if (!testEmail.test(value)) {
                $(this).addClass('border-red');
                $(this).attr('title', 'email không đúng định dạng');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }

        })

        /**-------------
         * Validate số điện thoại đúng định dạng
         * Created: HTTRANG(23/01/20)
        -------------- */
        $('input[type1="phone"]').blur(function () {
            var testphone = /^0[0-9]{9,}$/i;
            if (!testphone.test($(this).val())) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Số điện thoại không đúng định dạng {0}xxxxxxxxx');
                $(this).attr('Validate', false);

            }
            else {
                $(this).removeClass('border-red');
                $(this).removeAttr('title');
                $(this).attr('Validate', true);

            }
        });

        /**---------------
         * Validate Mã nhân viên
         * Created: HTTRANG(23/01/20)
        ------------------- */
        $('input[type1="code"]').blur(function () {
            var testCode = /^NV[0-9]+$/i;
            if (!testCode.test($(this).val().trim())) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Mã nhân viên không đúng định dạng (NVxxx)');
                $(this).attr('Validate', false);

            }
            else {
                $(this).removeClass('border-red');
                $(this).removeAttr('title');
                $(this).attr('Validate', true);

            }
        });
    }

    /**
     * 
     * Load combobox
     * CreatedBy:HTTrang(21/01/2021)
     * */
    loadCombobox(selects = $('select#cbxDepartmentGroup')) {
        var me = this;
        // Hiển thị combobox
        selects.empty();
        $.each(selects, function (index, select) {
            var api = $(select).attr('api');
            var fieldName = $(select).attr('fieldName');
            var fieldValue = $(select).attr('fieldValue');
            $.ajax({
                url: me.host + '/' + api,
                method: "GET"
            }).done(function (res) {
                if (res) {
                    $.each(res, function (index, obj) {
                        var option = $(`<option value="${obj[fieldValue]}">${obj[fieldName]}</option>`);
                        $(select).append(option);
                    })
                }
            }).fail(function (res) {

            })
        })

    }
    /**
    * load dữ liệu
    * CreatedBy:HTTrang(31/12/2021)
    * */
    loadData() {
        var me = this;
       
        $('table tbody').empty();
        //lấy thông tin các cột dữ liệu
        var ths = $('table thead th');
        //lấy thông tin dữ liệu sẽ map tương ứng vào các cột
        $.ajax({
            url: me.host + me.apiRouter,
            method: "GET",
            async: true,
            dataType: 'json',
            connectType: 'application/json'
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var tr = $(`<tr></tr>`);
                $(tr).data('recordId', obj.EmployeeId);
                $.each(ths, function (index, th) {
                    var td = $(`<td><div><span></span></div></td>`);
                    var fieldName = $(th).attr('fieldName');
                    var value = obj[fieldName];
                    switch (fieldName) {
                        case "DateOfBirth":
                            td.addClass("text-align-center");
                            value = formatDate(value, '/');
                            break;
                        case "Salary":
                            td.addClass('text-align-right');
                            value = formatMoney(value);
                            break;
                        case "Email":
                            td.attr("style", "max-width:300px")
                            value = obj[fieldName];
                            break;
                        case "Gender":
                            value = value == 1 ? "Nam" : (value == 0 ? "Nữ" : "Khác");
                            break;
                        case "WorkStatusName":
                            value = value == 1 ? "Đang làm việc" : (value == 0 ? "Đã nghỉ việc" : "Đang thử việc");
                            break;
                        default:
                            value = obj[fieldName];
                            break;
                    }
                    td.attr("title", value);
                    td.append(value);
                    $(tr).append(td);
                })
                $('table tbody').append(tr);
            })

        }).fail(function (res) {
        })
    }
    /**
     * Lấy mã nhân viên lớn nhất và gán vào trường mã 
     * CreatedBy: HTTrang()
     * */
    getMaxCode() {
        var me = this;
        var maxCode = 0;
        $.ajax({
            url: me.host + me.apiRouter,
            method: "GET",
            async: true,
            dataType: 'json',
            connectType: 'application/json'
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var code = parseInt(obj["EmployeeCode"].substr(2,));
                if (maxCode < code) {
                    maxCode = code;
                }
                maxCode = maxCode + 1;  
                $('#txtEmployeeCode').val("NV" + maxCode);
            })
        }).fail(function (res) {
        })                 
    }

}

