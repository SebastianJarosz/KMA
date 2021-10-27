import { Component, Input, OnInit } from '@angular/core';
import { Order } from '../../orders-view/shared/models/order.model';

@Component({
  selector: 'app-inprogress',
  templateUrl: './inprogress.component.html',
  styleUrls: ['./inprogress.component.css']
})
export class InprogressComponent implements OnInit {

  orderNumber?: number;
  constructor() { }

  @Input() order?: Order;
  ngOnInit(): void {
    this.orderNumber=this.order?.orderNumber;
  }

}
