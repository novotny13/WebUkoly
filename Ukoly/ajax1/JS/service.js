class Service {
    constructor(conn) {
        this.outputArray = [];
        this.outputJSON = [];
        this.tabPeople = "people";
        this.tabTypes = "types";
        this.dbdrv = new DbDriver(conn);
    }

    async getPeopleList() {
        return await this.dbdrv.select(this.tabPeople, "*");
    }

    async getTypesList() {
        return await this.dbdrv.select(this.tabTypes, "*");
    }

    processRequest(input) {
        const data = JSON.parse(input);
        let idUser = "";
    }

    async saveDrinks(drinks) {
        let res = 0;
        const userID = drinks.user[0];
        for (let i = 0; i < drinks.type.length; i++) {
            if (drinks.type[i] == 0) continue;
            const row = [new Date().toISOString().split('T')[0], userID, i + 1];
            res += await this.dbdrv.insertRow(row);
        }
        return res === 0 ? -1 : 1;
    }

    async getSummaryOfDrinks(data) {
        let month = 0;
        if (data.month) month = data.month;

        let sql = `SELECT types.typ, count(drinks.ID) as pocet, people.name as pocet 
                   FROM drinks 
                   JOIN people ON drinks.id_people=people.ID 
                   JOIN types ON drinks.id_types=types.ID`;
        if (month > 0 && month < 13) sql += ` WHERE MONTH(date) = ${month}`;
        sql += " GROUP BY types.typ";

        return await this.dbdrv.selectQ(sql);
    }
}
