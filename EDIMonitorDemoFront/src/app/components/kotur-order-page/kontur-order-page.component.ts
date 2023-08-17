import { Component } from "@angular/core";
import { KonturOrderService } from "src/app/services/kontur-order.service";
import { IKonturOrder } from "src/app/test-data/Ikontur-order";
import { KonturOrder } from "src/app/test-data/kontur-orders";

@Component({
    selector: "app-kontur-order-page",
    templateUrl: "./kontur-order-page.component.html",
    styleUrls: ["./kontur-order-page.component.css"]
})
export class KonturOrderPage
{
    /*orders: KonturOrder[] = [];
        new KonturOrder("ORDERS_fad13e74-c3ea-11ed-9cda-4ca7be8473e6.xml",
        "2000001435533_517",new Date("2023-03-16"),"ИП Сафин Р.Р."),
        new KonturOrder("ORDERS_f6b0927b-c3ea-11ed-b457-a6f6b5722f1c.xml",
        "2000001419229_265",new Date("2023-03-16"),"ИП Бисянова А.А."),
        new KonturOrder("ORDERS_da3275e7-c3ed-11ed-a2ca-9a62d479c248.xml",
        "2000001364277_344",new Date("2023-03-16"),"ИП Ибрагимов Ю.А."),
        new KonturOrder("ORDERS_7c75569b-c3f0-11ed-9fcf-604a3265fece.xml",
        "2000001381144_518",new Date("2023-03-16"),"ИП Пороткин В.В.")
    ];*/
    orders : IKonturOrder[] = [];

    constructor(private orderservice: KonturOrderService){

    }

    ngOnInit() :void{
        this.orderservice.loadOrders().subscribe(orders => {
            this.orders = orders;
            console.log(orders);
        })
        this.startTimer();
    }

    startTimer(): void{
        setInterval(() => this.loadOrdersAgain(),1000);
    }

    loadOrdersAgain() : void{
        this.orders = [];
            this.orderservice.loadOrders().subscribe(orders => {
            this.orders = orders;
            console.log(orders);
        });
    }
}




