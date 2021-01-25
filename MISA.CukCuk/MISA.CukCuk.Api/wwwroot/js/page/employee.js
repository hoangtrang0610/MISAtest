$(document).ready(function () {
    new employeeJS();
    ////khai báo các thông tin chung cho dialog
    dialogDefault = $('#dialog1').dialog({
        autoOpen: false,
        fluid: true,
        minWidth: 800,
        height: 860,
        //maxWidth: 860,
        resizable: true,
        position: ({
            my: "center", at: "center", of: window
        }),
        modal: true
    });
})


class employeeJS extends baseJS {
    constructor() {
        //this.loadData();
        super();
    }
    setApiRouter() {
        this.apiRouter = "/Employees";
    }
    
    
}

