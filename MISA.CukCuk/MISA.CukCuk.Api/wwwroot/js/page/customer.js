$(document).ready(function () {
    new customerJS();
    dialogDetail = $(".m-dialog").dialog({
        autoOpen: false,
        fluid: true,
        minWidth: 700,
        resizable: true,
        modal: true,
    })
})

class customerJS extends baseJS {
    constructor() {
        super();
    }

    setApiRouter() {
        this.apiRouter = "/Customers";
    }


    
}