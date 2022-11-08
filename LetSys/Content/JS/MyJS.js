function parseDate(value) {
    try {
        var date = new Date(parseInt(/\d+/.exec(value)[0]));
        var year = parseInt(date.getFullYear(), 10);
        if (year > 2500 || year < 1900) { return ""; }
        return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    } catch (e) {
        return "";
    }
}

var EmpState = { 0: "删除", 1: "在职", 2: "离职", 3: "退休" };
var HState = { 0: "删除", 1: "待租", 2: "维护", 10: "已租" };
var PayState = { 1: "待缴费", 2: "缴费中", 3: "已缴费" };