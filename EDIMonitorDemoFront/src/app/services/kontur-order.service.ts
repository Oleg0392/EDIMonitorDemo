import { Injectable } from '@angular/core';
import { KonturOrder } from '../test-data/kontur-orders';
import { IKonturOrder } from '../test-data/Ikontur-order';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class KonturOrderService{

    constructor(private http: HttpClient){

    }

    loadOrders(): Observable<IKonturOrder[]> {
        return this.http.get<IKonturOrder[]>('https://localhost:7171/kontur/inbox-test');
    }
}