class Requests {
    constructor(conn) {
        this.ser = new Service(conn);
        this.method = document.method;
        this.GETdata = new URLSearchParams(window.location.search);
        this.POSTdata = new FormData(document.forms[0]);
        const cmd = this.GETdata.get("cmd") || "";
        this.controller(cmd);
    }

    controller(cmd) {
        cmd = cmd.replace("cmd/", "");
        switch (cmd) {
            case "getPeopleList":
                this.output(this.ser.getPeopleList());
                break;
            case "getTypesList":
                this.output(this.ser.getTypesList());
                break;
            case "saveDrinks":
                this.output(this.ser.saveDrinks(this.POSTdata));
                break;
            case "listCmd":
                this.output(["getPeopleList", "getTypesList", "saveDrinks", "getSummaryOfDrinks"]);
                break;
            case "getSummaryOfDrinks":
                this.output(this.ser.getSummaryOfDrinks(this.GETdata));
                break;
            default:
                this.output("err");
        }
    }

    output(str) {
        if (!Array.isArray(str))
            console.log(JSON.stringify({ "msg": str }));
        else
            console.log(JSON.stringify(str));
    }
}
