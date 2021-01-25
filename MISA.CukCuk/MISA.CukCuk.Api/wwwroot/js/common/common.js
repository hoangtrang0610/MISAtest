/**---------------
 * format dữ liệu ngày tháng sang ngày/tháng/năm
 * @param {any} date tham số kiểu dữ liệu bất kì
 * @param {any} separate dấu ngăn cách
 * 
 */

function formatDate(date, separate) {
    if (date != null) {
        date = new Date(date);
        if (Number.isNaN(date.getTime())) {
            return "";
        } else {
            var day = date.getDate(),
                month = date.getMonth() + 1,
                year = date.getFullYear();

            day = day < 10 ? '0' + day : day;
            month = month < 10 ? '0' + month : month;
            if (separate == '-') {
                return year + separate + month + separate + day;
            }
            else {
                return day + separate + month + separate + year;

            }
        }

    } else {
        return "";
    }
    
}


/**---------------
 * format lương
 * @param {number} money kiểu number
 */

function formatMoney(money) {
    if (money) {
        var num = parseFloat(money).toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return num;
    }
    else {
        return "";
    }

}

