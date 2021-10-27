import { Component, Input, OnInit } from '@angular/core';
import { Order } from '../../orders-view/shared/models/order.model';

@Component({
  selector: 'app-ready',
  templateUrl: './ready.component.html',
  styleUrls: ['./ready.component.css']
})
export class ReadyComponent implements OnInit {
  orderNumber?: number;
  constructor() { }

  @Input() order?: Order;
  ngOnInit(): void {
    this.orderNumber=this.order?.orderNumber;
  }
}
