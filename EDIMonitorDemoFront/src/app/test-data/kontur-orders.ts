import { IKonturOrder } from "./Ikontur-order";

export class KonturOrder implements IKonturOrder{
    fileName : string;
    orderNumber: string;
    orderDate : Date;
    buyerName: string;

    constructor(flname: string, ordnumber: string, orddate: Date, buyer: string){
        this.fileName = flname;
        this.orderNumber = ordnumber;
        this.orderDate = orddate;
        this.buyerName = buyer;
    }
}